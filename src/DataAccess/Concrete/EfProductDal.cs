using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete;

public class EfProductDal : EfRepositoryBase<Product, int, BaseDbContext>, IProductDal
{
    public EfProductDal(BaseDbContext context)
        : base(context) { }
}
