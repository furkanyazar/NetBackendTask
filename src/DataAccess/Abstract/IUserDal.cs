using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract;

public interface IUserDal : IAsyncRepository<User, int>, IRepository<User, int> { }
