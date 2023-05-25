using Core.Entities.Abstract;

namespace Core.Entities.Dtos;

public class UpdatedUserDto : IDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public UpdatedUserDto() { }

    public UpdatedUserDto(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}
