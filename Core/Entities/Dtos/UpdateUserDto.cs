using Core.Entities.Abstract;

namespace Core.Entities.Dtos;

public class UpdateUserDto : IDto
{
    public string Email { get; set; }
    public string? Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public UpdateUserDto() { }

    public UpdateUserDto(string email, string? password, string firstName, string lastName)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
    }
}
