using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexts;

namespace DataAccess.Concrete;

public class EfUserDal : EfRepositoryBase<User, int, BaseDbContext>, IUserDal
{
    public EfUserDal(BaseDbContext context)
        : base(context) { }
}
