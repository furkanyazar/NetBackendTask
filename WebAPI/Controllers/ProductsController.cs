using Business.Abstract;
using Core.DataAccess.Paging;
using Core.Entities.Models;
using Entities.Dtos.Products;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : BaseController
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddProductDto addProductDto)
    {
        AddedProductDto product = await _productService.AddAsync(getUserIdFromRequest(), addProductDto);
        return Ok(product);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] DeleteItemModel<int> deleteItemModel)
    {
        DeletedProductDto product = await _productService.DeleteAsync(getUserIdFromRequest(), deleteItemModel);
        return Ok(product);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        ProductGetByIdDto product = await _productService.GetByIdAsync(getUserIdFromRequest(), id);
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromQuery] string? name)
    {
        GetListResponse<ProductGetListDto> products = await _productService.GetListAsync(
            getUserIdFromRequest(),
            pageRequest,
            name
        );
        return Ok(products);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductDto updateProductDto)
    {
        UpdatedProductDto product = await _productService.UpdateAsync(getUserIdFromRequest(), updateProductDto);
        return Ok(product);
    }
}
