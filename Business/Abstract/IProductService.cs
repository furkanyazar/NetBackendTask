using Core.DataAccess.Paging;
using Core.Entities.Models;
using Entities.Dtos.Products;

namespace Business.Abstract;

public interface IProductService
{
    public Task<AddedProductDto> AddAsync(int userId, AddProductDto addProductDto);
    public Task<DeletedProductDto> DeleteAsync(int userId, DeleteItemModel<int> deleteItemModel);
    public Task<ProductGetByIdDto> GetByIdAsync(int userId, int productId);
    public Task<GetListResponse<ProductGetListDto>> GetListAsync(int userId, PageRequest pageRequest, string? name);
    public Task<UpdatedProductDto> UpdateAsync(int userId, UpdateProductDto addProductDto);
}
