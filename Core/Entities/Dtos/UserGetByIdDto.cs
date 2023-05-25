using Core.Entities.Abstract;

namespace Core.Entities.Dtos;

public class UserGetByIdDto : IDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public UserGetByIdDto() { }

    public UserGetByIdDto(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}
