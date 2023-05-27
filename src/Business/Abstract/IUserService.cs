using Core.Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract;

public interface IUserService
{
    public Task<User> GetByIdAsync(int id);
    public Task<UserGetByIdDto> GetByIdDtoAsync(int id);
    public Task<UpdatedUserDto> UpdateAsync(int id, UpdateUserDto updateUserDto);
}
