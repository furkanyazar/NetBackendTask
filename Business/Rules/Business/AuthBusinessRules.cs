using Business.Constants;
using Core.CrossCuttingConcerns.Exception.Types;
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;

namespace Business.Rules.Business;

public class AuthBusinessRules : BaseBusinessRules
{
    private readonly IUserDal _userDal;

    public AuthBusinessRules(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public Task UserShouldBeExistsWhenSelected(User? user)
    {
        if (user is null)
            throw new NotFoundException(AuthMessages.UserDontExists);
        return Task.CompletedTask;
    }

    public Task UserPasswordShouldBeMatch(User user, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException(AuthMessages.PasswordDontMatch);
        return Task.CompletedTask;
    }

    public async Task UserEmailShouldBeNotExists(string email)
    {
        bool doesExists = await _userDal.AnyAsync(c => c.Email == email, enableTracking: false);
        if (doesExists)
            throw new BusinessException(AuthMessages.UserMailAlreadyExists);
    }
}
