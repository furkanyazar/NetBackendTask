using Business.Abstract;
using Business.Rules.Business;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Business.Concrete;

public class RefreshTokenManager : IRefreshTokenService
{
    private readonly IRefreshTokenDal _refreshTokenDal;
    private readonly TokenOptions _tokenOptions;
    private readonly RefreshTokenBusinessRules _refreshTokenBusinessRules;
    private readonly ITokenHelper _tokenHelper;

    public RefreshTokenManager(
        IRefreshTokenDal refreshTokenDal,
        IConfiguration configuration,
        RefreshTokenBusinessRules refreshTokenBusinessRules,
        ITokenHelper tokenHelper
    )
    {
        const string tokenOptionsConfigurationSection = "TokenOptions";
        _tokenOptions =
            configuration.GetSection(tokenOptionsConfigurationSection).Get<TokenOptions>()
            ?? throw new NullReferenceException(
                $"\"{tokenOptionsConfigurationSection}\" section cannot found in configuration"
            );

        _refreshTokenDal = refreshTokenDal;
        _refreshTokenBusinessRules = refreshTokenBusinessRules;
        _tokenHelper = tokenHelper;
    }

    public async Task<RefreshToken> AddAsync(RefreshToken refreshToken)
    {
        RefreshToken addedRefreshToken = await _refreshTokenDal.AddAsync(refreshToken);
        return addedRefreshToken;
    }

    public async Task DeleteOldsAsync(int userId)
    {
        List<RefreshToken> refreshTokens = await _refreshTokenDal
            .Query()
            .AsNoTracking()
            .Where(
                c =>
                    c.UserId == userId
                    && c.Revoked == null
                    && c.Expires >= DateTime.UtcNow
                    && c.CreatedDate.AddDays(_tokenOptions.RefreshTokenTTL) <= DateTime.UtcNow
            )
            .ToListAsync();

        await _refreshTokenDal.DeleteRangeAsync(refreshTokens);
    }

    public async Task<RefreshToken?> GetByTokenAsync(string token)
    {
        RefreshToken? refreshToken = await _refreshTokenDal.GetAsync(c => c.Token == token);
        await _refreshTokenBusinessRules.RefreshTokenShouldBeExistsWhenSelected(refreshToken);
        return refreshToken;
    }

    public async Task RevokeAsync(
        RefreshToken refreshToken,
        string ipAddress,
        string? reason = null,
        string? replacedByToken = null
    )
    {
        refreshToken.Revoked = DateTime.UtcNow;
        refreshToken.RevokedByIp = ipAddress;
        refreshToken.ReasonRevoked = reason;
        refreshToken.ReplacedByToken = replacedByToken;
        await _refreshTokenDal.UpdateAsync(refreshToken);
    }

    public async Task RevokeDescendantsAsync(RefreshToken refreshToken, string ipAddress, string reason)
    {
        RefreshToken? childToken = await _refreshTokenDal.GetAsync(c => c.Token == refreshToken.ReplacedByToken);

        if (childToken?.Revoked is not null && childToken.Expires <= DateTime.UtcNow)
            await RevokeAsync(childToken, ipAddress, reason);
        else
            await RevokeDescendantsAsync(refreshToken: childToken!, ipAddress, reason);
    }

    public async Task<RefreshToken> RotateAsync(User user, RefreshToken refreshToken, string ipAddress)
    {
        RefreshToken newRefreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
        await RevokeAsync(refreshToken, ipAddress, reason: "Replaced by new token", newRefreshToken.Token);
        return newRefreshToken;
    }
}
