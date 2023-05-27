using Core.Entities.Abstract;

namespace Core.Entities.Dtos;

public class UserRegisterDto : IDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public UserRegisterDto()
    {
        Email = string.Empty;
        Password = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
    }

    public UserRegisterDto(string email, string password, string firstName, string lastName)
        : this()
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
    }
}
