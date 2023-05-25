using Business.Abstract;
using Business.Rules.Business;
using Business.Rules.Validation.Users;
using Core.Aspects.Validation;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class AuthManager : IAuthService
{
    private readonly IUserDal _userDal;
    private readonly IUserOperationClaimDal _userOperationClaimDal;
    private readonly ITokenHelper _tokenHelper;
    private readonly AuthBusinessRules _authBusinessRules;

    public AuthManager(
        IUserDal userDal,
        IUserOperationClaimDal userOperationClaimDal,
        ITokenHelper tokenHelper,
        AuthBusinessRules authBusinessRules
    )
    {
        _userDal = userDal;
        _userOperationClaimDal = userOperationClaimDal;
        _tokenHelper = tokenHelper;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<AccessToken> CreateAccessTokenAsync(User user)
    {
        IList<OperationClaim> operationClaims = await _userOperationClaimDal
            .Query()
            .AsNoTracking()
            .Where(c => c.UserId == user.Id)
            .Select(
                c =>
                    new OperationClaim
                    {
                        Id = c.OperationClaimId,
                        Name = c.OperationClaim.Name,
                        Value = c.OperationClaim.Value
                    }
            )
            .ToListAsync();
        operationClaims.Add(new() { Value = "logged" });

        AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
        return accessToken;
    }

    public Task<RefreshToken> CreateRefreshTokenAsync(User user, string ipAddress)
    {
        RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
        return Task.FromResult(refreshToken);
    }

    [ValidationAspect(typeof(UserLoginDtoValidator))]
    public async Task<User> LoginAsync(UserLoginDto userLoginDto)
    {
        User? user = await _userDal.GetAsync(c => c.Email == userLoginDto.Email);
        await _authBusinessRules.UserShouldBeExistsWhenSelected(user);
        await _authBusinessRules.UserPasswordShouldBeMatch(user!, userLoginDto.Password);
        return user!;
    }

    [ValidationAspect(typeof(UserRegisterDtoValidator))]
    public async Task<User> RegisterAsync(UserRegisterDto userRegisterDto)
    {
        await _authBusinessRules.UserEmailShouldBeNotExists(userRegisterDto.Email);

        HashingHelper.CreatePasswordHash(userRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
        User newUser =
            new()
            {
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                Email = userRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
        User addedUser = await _userDal.AddAsync(newUser);
        return addedUser;
    }
}
