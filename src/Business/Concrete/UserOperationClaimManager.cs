using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete;

public class UserOperationClaimManager : IUserOperationClaimService
{
    private readonly IUserOperationClaimDal _userOperationClaimDal;

    public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
    {
        _userOperationClaimDal = userOperationClaimDal;
    }

    public async Task AddByRegisteredUser(int userId)
    {
        UserOperationClaim newUserOperationClaim = new() { OperationClaimId = 1, UserId = userId };
        await _userOperationClaimDal.AddAsync(newUserOperationClaim);
    }
}
