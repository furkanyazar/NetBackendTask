using Business.Constants;
using Core.CrossCuttingConcerns.Exception.Types;
using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Business.Rules.Business;

public class RefreshTokenBusinessRules : BaseBusinessRules
{
    public Task RefreshTokenShouldBeExistsWhenSelected(RefreshToken? refreshToken)
    {
        if (refreshToken is null)
            throw new NotFoundException(RefreshTokenMessages.RefreshDontExists);
        return Task.CompletedTask;
    }

    public Task RefreshTokenShouldBeActive(RefreshToken refreshToken)
    {
        if (refreshToken.Revoked is not null && DateTime.UtcNow >= refreshToken.Expires)
            throw new BusinessException(AuthMessages.InvalidRefreshToken);
        return Task.CompletedTask;
    }
}
