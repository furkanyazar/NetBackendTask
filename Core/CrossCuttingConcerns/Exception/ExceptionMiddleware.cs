using Core.CrossCuttingConcerns.Exception.Handlers;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exception;

public class ExceptionMiddleware
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly HttpExceptionHandler _httpExceptionHandler;
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(
        RequestDelegate next,
        IHttpContextAccessor httpContextAccessor,
        LoggerServiceBase loggerServiceBase
    )
    {
        _next = next;
        _httpContextAccessor = httpContextAccessor;
        _httpExceptionHandler = new HttpExceptionHandler();
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (System.Exception exception)
        {
            await HandleExceptionAsync(context.Response, exception);
        }
    }

    private Task HandleExceptionAsync(HttpResponse response, System.Exception exception)
    {
        response.ContentType = "application/json";
        _httpExceptionHandler.Response = response;
        return _httpExceptionHandler.HandleExceptionAsync(exception);
    }
}
