using Core.Entities.Concrete;

namespace Business.Abstract;

public interface IUserService
{
    public Task<User?> GetByIdAsync(int id);
}
