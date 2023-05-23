using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Core.Aspects.Exception;

public class ExceptionLogAspect : MethodInterception
{
    private LoggerServiceBase _loggerServiceBase;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ExceptionLogAspect(Type loggerService)
    {
        if (loggerService.BaseType != typeof(LoggerServiceBase))
            throw new ArgumentException(AspectMessages.WrongLoggerType);

        _loggerServiceBase = (LoggerServiceBase)ServiceTool.ServiceProvider.GetService(loggerService);
        _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
    }

    protected override void OnException(IInvocation invocation, System.Exception e)
    {
        _loggerServiceBase.Error(e, GetLogDetail(invocation, e));
    }

    private string GetLogDetail(IInvocation invocation, System.Exception e)
    {
        List<LogParameter> logParameters = new();
        for (var i = 0; i < invocation.Arguments.Length; i++)
        {
            logParameters.Add(
                new()
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name,
                }
            );
        }

        LogDetailWithException logDetail =
            new()
            {
                FullName = invocation.Method.ReflectedType.FullName,
                MethodName = invocation.Method.Name,
                LogParameters = logParameters,
                ExceptionMessage = e.Message,
                User = _httpContextAccessor.HttpContext?.User.Identity?.Name ?? "?"
            };

        return JsonConvert.SerializeObject(logDetail);
    }
}
