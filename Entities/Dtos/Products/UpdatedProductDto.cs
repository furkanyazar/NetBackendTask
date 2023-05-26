using Core.Entities.Abstract;

namespace Entities.Dtos.Products;

public class UpdatedProductDto : IDto
{
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }

    public UpdatedProductDto()
    {
        Name = string.Empty;
    }

    public UpdatedProductDto(string name, decimal unitPrice, short unitsInStock)
        : this()
    {
        Name = name;
        UnitPrice = unitPrice;
        UnitsInStock = unitsInStock;
    }
}
