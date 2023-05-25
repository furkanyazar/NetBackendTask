namespace Business.Abstract;

public interface IUserOperationClaimService
{
    public Task AddByRegisteredUser(int userId);
}
