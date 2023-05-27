using Core.Entities.Abstract;

namespace Entities.Dtos;

public class UserGetByIdDto : IDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public UserGetByIdDto()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
    }

    public UserGetByIdDto(string firstName, string lastName, string email)
        : this()
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}
