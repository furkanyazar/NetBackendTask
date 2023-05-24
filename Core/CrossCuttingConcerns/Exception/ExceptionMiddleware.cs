using Core.CrossCuttingConcerns.Exception.Handlers;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Core.CrossCuttingConcerns.Exception;

public class ExceptionMiddleware
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly HttpExceptionHandler _httpExceptionHandler;
    private readonly LoggerServiceBase _loggerService;
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(
        RequestDelegate next,
        IHttpContextAccessor httpContextAccessor,
        LoggerServiceBase loggerService
    )
    {
        _next = next;
        _httpContextAccessor = httpContextAccessor;
        _loggerService = loggerService;
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
            await LogException(context, exception);
            await HandleExceptionAsync(context.Response, exception);
        }
    }

    private Task HandleExceptionAsync(HttpResponse response, System.Exception exception)
    {
        response.ContentType = "application/json";
        _httpExceptionHandler.Response = response;
        return _httpExceptionHandler.HandleExceptionAsync(exception);
    }

    private Task LogException(HttpContext context, System.Exception exception)
    {
        List<LogParameter> logParameters =
            new()
            {
                new LogParameter { Type = context.GetType().Name, Value = exception.ToString() }
            };

        LogDetail logDetail =
            new()
            {
                MethodName = _next.Method.Name,
                LogParameters = logParameters,
                User = _httpContextAccessor.HttpContext?.User.Identity?.Name ?? "?"
            };

        _loggerService.Info(JsonSerializer.Serialize(logDetail));
        return Task.CompletedTask;
    }
}
