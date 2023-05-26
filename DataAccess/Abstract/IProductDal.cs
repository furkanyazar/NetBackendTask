using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IProductDal : IAsyncRepository<Product, int>, IRepository<Product, int> { }
