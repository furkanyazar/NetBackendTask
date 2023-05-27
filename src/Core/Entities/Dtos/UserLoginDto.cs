using Core.Entities.Abstract;

namespace Core.Entities.Dtos;

public class UserLoginDto : IDto
{
    public string Email { get; set; }
    public string Password { get; set; }

    public UserLoginDto()
    {
        Email = string.Empty;
        Password = string.Empty;
    }

    public UserLoginDto(string email, string password)
        : this()
    {
        Email = email;
        Password = password;
    }
}
