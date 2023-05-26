using AutoMapper;
using Core.DataAccess.Paging;
using Entities.Concrete;
using Entities.Dtos.Products;

namespace Business.Profiles;

public class ProductMappingProfiles : Profile
{
    public ProductMappingProfiles()
    {
        CreateMap<Product, ProductGetListDto>().ReverseMap();
        CreateMap<IPaginate<Product>, GetListResponse<ProductGetListDto>>().ReverseMap();
        CreateMap<Product, ProductGetByIdDto>().ReverseMap();
        CreateMap<Product, DeletedProductDto>().ReverseMap();
        CreateMap<Product, AddedProductDto>().ReverseMap();
        CreateMap<Product, UpdatedProductDto>().ReverseMap();
        CreateMap<Product, AddProductDto>().ReverseMap();
    }
}
