using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexts;

namespace DataAccess.Concrete;

public class EfOperationClaimDal : EfRepositoryBase<OperationClaim, int, BaseDbContext>, IOperationClaimDal
{
    public EfOperationClaimDal(BaseDbContext context)
        : base(context) { }
}
