using Core.Entities.Abstract;

namespace Entities.Dtos.Products;

public class UpdateProductDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }

    public UpdateProductDto()
    {
        Name = string.Empty;
    }

    public UpdateProductDto(int id, string name, decimal unitPrice, short unitsInStock)
        : this()
    {
        Id = id;
        Name = name;
        UnitPrice = unitPrice;
        UnitsInStock = unitsInStock;
    }
}
