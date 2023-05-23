using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Core.Aspects.Logging;

public class LogAspect : MethodInterception
{
    private readonly LoggerServiceBase _loggerServiceBase;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LogAspect(Type loggerService)
    {
        if (loggerService.BaseType != typeof(LoggerServiceBase))
            throw new ArgumentException(AspectMessages.WrongLoggerType);

        _loggerServiceBase = (LoggerServiceBase)ServiceTool.ServiceProvider.GetService(loggerService);
        _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
    }

    protected override void OnBefore(IInvocation invocation)
    {
        _loggerServiceBase.Info(GetLogDetail(invocation));
    }

    private string GetLogDetail(IInvocation invocation)
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

        LogDetail logDetail =
            new()
            {
                FullName = invocation.Method.ReflectedType.FullName,
                MethodName = invocation.Method.Name,
                LogParameters = logParameters,
                User = _httpContextAccessor.HttpContext?.User.Identity?.Name ?? "?"
            };

        return JsonConvert.SerializeObject(logDetail);
    }
}
