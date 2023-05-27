using Core.CrossCuttingConcerns.Exception.Extensions;
using Core.CrossCuttingConcerns.Exception.HttpProblemDetails;
using Core.CrossCuttingConcerns.Exception.Types;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exception.Handlers;

public class HttpExceptionHandler : ExceptionHandler
{
    public HttpResponse Response
    {
        get => _response ?? throw new ArgumentNullException(nameof(_response));
        set => _response = value;
    }

    private HttpResponse? _response;

    protected override Task HandleException(BusinessException businessException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        string details = new BusinessProblemDetails(businessException.Message).AsJson();
        return Response.WriteAsync(details);
    }

    protected override Task HandleException(ValidationException validationException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        string details = new ValidationProblemDetails(validationException.Errors).AsJson();
        return Response.WriteAsync(details);
    }

    protected override Task HandleException(AuthorizationException authorizationException)
    {
        Response.StatusCode = StatusCodes.Status401Unauthorized;
        string details = new AuthorizationProblemDetails(authorizationException.Message).AsJson();
        return Response.WriteAsync(details);
    }

    protected override Task HandleException(NotFoundException notFoundException)
    {
        Response.StatusCode = StatusCodes.Status404NotFound;
        string details = new NotFoundProblemDetails(notFoundException.Message).AsJson();
        return Response.WriteAsync(details);
    }

    protected override Task HandleException(System.Exception exception)
    {
        Response.StatusCode = StatusCodes.Status500InternalServerError;
        string details = new InternalServerErrorProblemDetails(exception.Message).AsJson();
        return Response.WriteAsync(details);
    }
}
