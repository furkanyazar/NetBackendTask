using Core.Entities.Abstract;

namespace Core.Entities.Concrete;

public class OperationClaim : Entity<int>
{
    public string Name { get; set; }
    public string Value { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = null!;

    public OperationClaim()
    {
        Name = string.Empty;
        Value = string.Empty;
    }

    public OperationClaim(int id, string name, string value)
        : this()
    {
        Id = id;
        Name = name;
        Value = value;
    }
}
