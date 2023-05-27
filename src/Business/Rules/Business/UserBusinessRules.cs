using Business.Constants;
using Core.CrossCuttingConcerns.Exception.Types;
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace Business.Rules.Business;

public class UserBusinessRules : BaseBusinessRules
{
    private readonly IUserDal _userDal;

    public UserBusinessRules(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public Task UserShouldBeExistsWhenSelected(User? user)
    {
        if (user is null)
            throw new NotFoundException(UserMessages.UserDontExists);
        return Task.CompletedTask;
    }

    public async Task UserMailShouldBeNotExistsWhenUpdate(int id, string email)
    {
        bool doesExists = await _userDal.AnyAsync(c => c.Id != id && c.Email == email, enableTracking: false);
        if (doesExists)
            throw new BusinessException(UserMessages.UserMailAlreadyExists);
    }
}
