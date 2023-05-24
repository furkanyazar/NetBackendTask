using Business.Abstract;
using Business.Rules.Business;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;
    private readonly UserBusinessRules _userBusinessRules;

    public UserManager(IUserDal userDal, UserBusinessRules userBusinessRules)
    {
        _userDal = userDal;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        User? user = await _userDal.GetAsync(c => c.Id == id);
        await _userBusinessRules.UserShouldBeExistsWhenSelected(user);
        return user;
    }
}
