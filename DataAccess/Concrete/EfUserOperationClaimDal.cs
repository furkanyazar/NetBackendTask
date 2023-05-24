using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexts;

namespace DataAccess.Concrete;

public class EfUserOperationClaimDal : EfRepositoryBase<UserOperationClaim, int, BaseDbContext>, IUserOperationClaimDal
{
    public EfUserOperationClaimDal(BaseDbContext context)
        : base(context) { }
}
