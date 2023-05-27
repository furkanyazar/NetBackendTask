using Core.Entities.Abstract;

namespace Entities.Dtos.Products;

public class AddProductDto : IDto
{
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }

    public AddProductDto()
    {
        Name = string.Empty;
    }

    public AddProductDto(string name, decimal unitPrice, short unitsInStock)
        : this()
    {
        Name = name;
        UnitPrice = unitPrice;
        UnitsInStock = unitsInStock;
    }
}
