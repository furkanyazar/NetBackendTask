using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete;

public class Product : Entity<int>
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }

    public virtual User User { get; set; } = null!;

    public Product()
    {
        Name = string.Empty;
    }

    public Product(int id, int userId, string name, decimal unitPrice, short unitsInStock)
        : this()
    {
        Id = id;
        UserId = userId;
        Name = name;
        UnitPrice = unitPrice;
        UnitsInStock = unitsInStock;
    }
}
