using Core.CrossCuttingConcerns.Exception.Types;
using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation;

public static class ValidationTool
{
    public static void Validate(IValidator validator, object entity)
    {
        var context = new ValidationContext<object>(entity);
        var result = validator.Validate(context);

        if (!result.IsValid)
            throw new Core.CrossCuttingConcerns.Exception.Types.ValidationException(
                result.Errors
                    .GroupBy(
                        keySelector: c => c.PropertyName,
                        resultSelector: (propertyName, errors) =>
                            new ValidationExceptionModel
                            {
                                Property = propertyName,
                                Errors = errors.Select(c => c.ErrorMessage)
                            }
                    )
                    .ToList()
            );
    }
}
