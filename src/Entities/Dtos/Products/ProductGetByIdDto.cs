using Core.Entities.Abstract;

namespace Entities.Dtos.Products;

public class ProductGetByIdDto : IDto
{
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }

    public ProductGetByIdDto()
    {
        Name = string.Empty;
    }

    public ProductGetByIdDto(string name, decimal unitPrice, short unitsInStock)
        : this()
    {
        Name = name;
        UnitPrice = unitPrice;
        UnitsInStock = unitsInStock;
    }
}
