using Core.Entities.Abstract;

namespace Entities.Dtos;

public class UpdateUserDto : IDto
{
    public string Email { get; set; }
    public string? Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public UpdateUserDto()
    {
        Email = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
    }

    public UpdateUserDto(string email, string? password, string firstName, string lastName)
        : this()
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
    }
}
