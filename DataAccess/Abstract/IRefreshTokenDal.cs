using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract;

public interface IRefreshTokenDal : IAsyncRepository<RefreshToken, int>, IRepository<RefreshToken, int> { }
