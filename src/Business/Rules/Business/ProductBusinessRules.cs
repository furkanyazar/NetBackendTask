using Business.Constants;
using Core.CrossCuttingConcerns.Exception.Types;
using Core.Entities.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Rules.Business;

public class ProductBusinessRules : BaseBusinessRules
{
    private readonly IProductDal _productDal;

    public ProductBusinessRules(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public Task ProductShouldBeExistsWhenSelected(Product? product)
    {
        if (product is null)
            throw new NotFoundException(ProductMessages.ProductDontExists);
        return Task.CompletedTask;
    }

    public Task ProductShouldBeYoursWhenSelected(int userId, Product product)
    {
        if (product.UserId != userId)
            throw new AuthorizationException(ProductMessages.ProductIsntYours);
        return Task.CompletedTask;
    }

    public async Task ProductNameShouldBeNotExistsWhenInsert(int userId, string name)
    {
        bool doesExists = await _productDal.AnyAsync(c => c.UserId == userId && c.Name == name, enableTracking: false);
        if (doesExists)
            throw new BusinessException(ProductMessages.ProductNameAlreadyExists);
    }

    public async Task ProductNameShouldBeNotExistsWhenUpdate(int id, int userId, string name)
    {
        bool doesExists = await _productDal.AnyAsync(
            c => c.Id != id && c.UserId == userId && c.Name == name,
            enableTracking: false
        );
        if (doesExists)
            throw new BusinessException(ProductMessages.ProductNameAlreadyExists);
    }
}
