using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract;

public interface IUserOperationClaimDal
    : IAsyncRepository<UserOperationClaim, int>,
        IRepository<UserOperationClaim, int> { }
