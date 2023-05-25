using Business.Abstract;
using Business.Rules.Business;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly RefreshTokenBusinessRules _refreshTokenBusinessRules;
    private readonly IUserOperationClaimService _userOperationClaimService;

    public AuthController(
        IAuthService authService,
        IUserService userService,
        IRefreshTokenService refreshTokenService,
        RefreshTokenBusinessRules refreshTokenBusinessRules,
        IUserOperationClaimService userOperationClaimService
    )
    {
        _authService = authService;
        _userService = userService;
        _refreshTokenService = refreshTokenService;
        _refreshTokenBusinessRules = refreshTokenBusinessRules;
        _userOperationClaimService = userOperationClaimService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
    {
        User loggedUser = await _authService.LoginAsync(userLoginDto);
        AccessToken createdAccessToken = await _authService.CreateAccessTokenAsync(loggedUser);
        RefreshToken createdRefreshToken = await _authService.CreateRefreshTokenAsync(loggedUser, getIpAddress());
        RefreshToken addedRefreshToken = await _refreshTokenService.AddAsync(createdRefreshToken);
        setRefreshTokenToCookie(addedRefreshToken);
        await _refreshTokenService.DeleteOldsAsync(loggedUser.Id);
        return Ok(createdAccessToken);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RefreshToken()
    {
        RefreshToken refreshToken = await _refreshTokenService.GetByTokenAsync(getRefreshTokenFromCookies());
        if (refreshToken.Revoked is not null)
            await _refreshTokenService.RevokeDescendantsAsync(
                refreshToken,
                getIpAddress(),
                reason: $"Attempted reuse of revoked ancestor token: {refreshToken.Token}"
            );

        await _refreshTokenBusinessRules.RefreshTokenShouldBeActive(refreshToken);
        User user = await _userService.GetByIdAsync(refreshToken.UserId);
        RefreshToken newRefreshToken = await _refreshTokenService.RotateAsync(user: user, refreshToken, getIpAddress());
        RefreshToken addedRefreshToken = await _refreshTokenService.AddAsync(newRefreshToken);
        setRefreshTokenToCookie(addedRefreshToken);
        await _refreshTokenService.DeleteOldsAsync(user.Id);
        AccessToken createdAccessToken = await _authService.CreateAccessTokenAsync(user);
        return Ok(createdAccessToken);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
    {
        User registeredUser = await _authService.RegisterAsync(userRegisterDto);
        await _userOperationClaimService.AddByRegisteredUser(registeredUser.Id);
        AccessToken createdAccessToken = await _authService.CreateAccessTokenAsync(registeredUser);
        RefreshToken createdRefreshToken = await _authService.CreateRefreshTokenAsync(registeredUser, getIpAddress());
        RefreshToken addedRefreshToken = await _refreshTokenService.AddAsync(createdRefreshToken);
        setRefreshTokenToCookie(addedRefreshToken);
        return Ok(createdAccessToken);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RevokeToken(
        [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] string? refreshToken
    )
    {
        RefreshToken refreshTokenToCheck = await _refreshTokenService.GetByTokenAsync(
            refreshToken ?? getRefreshTokenFromCookies()
        );

        await _refreshTokenService.RevokeAsync(
            refreshToken: refreshTokenToCheck,
            getIpAddress(),
            reason: "Revoked without replacement"
        );

        return Ok();
    }

    private string getRefreshTokenFromCookies() =>
        Request.Cookies["refreshToken"]
        ?? throw new ArgumentException("Refresh token is not found in request cookies.");

    private void setRefreshTokenToCookie(RefreshToken refreshToken)
    {
        CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7) };
        Response.Cookies.Append(key: "refreshToken", refreshToken.Token, cookieOptions);
    }
}
