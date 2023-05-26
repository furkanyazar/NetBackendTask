using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects;
using Business.Rules.Business;
using Business.Rules.Validation.Products;
using Core.Aspects.Validation;
using Core.DataAccess.Paging;
using Core.Entities.Models;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Products;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;
    private readonly IMapper _mapper;
    private readonly ProductBusinessRules _productBusinessRules;

    public ProductManager(IProductDal productDal, IMapper mapper, ProductBusinessRules productBusinessRules)
    {
        _productDal = productDal;
        _mapper = mapper;
        _productBusinessRules = productBusinessRules;
    }

    [SecuredOperation("admin")]
    [ValidationAspect(typeof(AddProductDtoValidator))]
    public async Task<AddedProductDto> AddAsync(int userId, AddProductDto addProductDto)
    {
        await _productBusinessRules.ProductNameShouldNotExistsWhenInsert(userId, addProductDto.Name);
        Product newProduct = _mapper.Map<Product>(addProductDto);
        newProduct.UserId = userId;
        Product addedProduct = await _productDal.AddAsync(newProduct);
        AddedProductDto mappedProduct = _mapper.Map<AddedProductDto>(addedProduct);
        return mappedProduct;
    }

    [SecuredOperation("admin")]
    public async Task<DeletedProductDto> DeleteAsync(int userId, DeleteItemModel<int> deleteItemModel)
    {
        Product? product = await _productDal.GetAsync(c => c.Id == deleteItemModel.Id);
        await _productBusinessRules.ProductShouldBeExistsWhenSelected(product);
        await _productBusinessRules.ProductShouldBeYoursWhenSelected(userId, product!);
        Product deletedProduct = await _productDal.DeleteAsync(product!, deleteItemModel.Permanent);
        DeletedProductDto mappedProduct = _mapper.Map<DeletedProductDto>(deletedProduct);
        return mappedProduct;
    }

    [SecuredOperation("admin")]
    public async Task<ProductGetByIdDto> GetByIdAsync(int userId, int productId)
    {
        Product? product = await _productDal.GetAsync(c => c.Id == productId);
        await _productBusinessRules.ProductShouldBeExistsWhenSelected(product);
        await _productBusinessRules.ProductShouldBeYoursWhenSelected(userId, product!);
        ProductGetByIdDto mappedProduct = _mapper.Map<ProductGetByIdDto>(product);
        return mappedProduct;
    }

    [SecuredOperation("admin")]
    public async Task<GetListResponse<ProductGetListDto>> GetListAsync(
        int userId,
        PageRequest pageRequest,
        string? name
    )
    {
        name ??= "";
        IPaginate<Product> products = await _productDal.GetListAsync(
            c => c.UserId == userId && c.Name.ToLower().Contains(name.ToLower()),
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize
        );
        GetListResponse<ProductGetListDto> mappedProducts = _mapper.Map<GetListResponse<ProductGetListDto>>(products);
        return mappedProducts;
    }

    [SecuredOperation("admin")]
    [ValidationAspect(typeof(UpdateProductDtoValidator))]
    public async Task<UpdatedProductDto> UpdateAsync(int userId, UpdateProductDto updateProductDto)
    {
        Product? product = await _productDal.GetAsync(c => c.Id == updateProductDto.Id);
        await _productBusinessRules.ProductShouldBeExistsWhenSelected(product);
        await _productBusinessRules.ProductShouldBeYoursWhenSelected(userId, product!);
        await _productBusinessRules.ProductNameShouldNotExistsWhenUpdate(
            product!.Id,
            product.UserId,
            updateProductDto.Name
        );

        product.Name = updateProductDto.Name;
        product.UnitPrice = updateProductDto.UnitPrice;
        product.UnitsInStock = updateProductDto.UnitsInStock;

        Product updatedProduct = await _productDal.UpdateAsync(product);
        UpdatedProductDto mappedProduct = _mapper.Map<UpdatedProductDto>(updatedProduct);
        return mappedProduct;
    }
}
