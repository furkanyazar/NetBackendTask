using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract;

public interface IOperationClaimDal : IAsyncRepository<OperationClaim, int>, IRepository<OperationClaim, int> { }
