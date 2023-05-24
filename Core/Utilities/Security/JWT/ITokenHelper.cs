using Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user);
    RefreshToken CreateRefreshToken(User user, string ipAddress);
}
