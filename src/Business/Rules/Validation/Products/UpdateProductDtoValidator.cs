using Entities.Dtos.Products;
using FluentValidation;

namespace Business.Rules.Validation.Products;

public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductDtoValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(2);
        RuleFor(c => c.UnitPrice).GreaterThanOrEqualTo(0);
        RuleFor(c => c.UnitsInStock).GreaterThanOrEqualTo((short)0);
    }
}
