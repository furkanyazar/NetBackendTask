using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Security.JWT;

namespace Business.Abstract;

public interface IAuthService
{
    public Task<AccessToken> CreateAccessTokenAsync(User user);
    public Task<RefreshToken> CreateRefreshTokenAsync(User user, string ipAddress);
    public Task<User> LoginAsync(UserLoginDto userLoginDto);
    public Task<User> RegisterAsync(UserRegisterDto userRegisterDto);
}
