using Business.Constants;
using Core.CrossCuttingConcerns.Exception.Types;
using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Business.Rules.Business;

public class UserBusinessRules : BaseBusinessRules
{
    public Task UserShouldBeExistsWhenSelected(User? user)
    {
        if (user is null)
            throw new NotFoundException(UserMessages.UserDontExists);
        return Task.CompletedTask;
    }
}
