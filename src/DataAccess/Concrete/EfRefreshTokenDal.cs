using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexts;

namespace DataAccess.Concrete;

public class EfRefreshTokenDal : EfRepositoryBase<RefreshToken, int, BaseDbContext>, IRefreshTokenDal
{
    public EfRefreshTokenDal(BaseDbContext context)
        : base(context) { }
}
