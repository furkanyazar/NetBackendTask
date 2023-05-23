using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Exception.Types;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects;

public class SecuredOperation : MethodInterception
{
    private string[] _claims;
    private IHttpContextAccessor _httpContextAccessor;

    public SecuredOperation(string claims)
    {
        _claims = claims.Split(',');
        _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
    }

    protected override void OnBefore(IInvocation invocation)
    {
        var userClaims = _httpContextAccessor.HttpContext.User.GetUserClaims();

        foreach (var claim in _claims)
            if (userClaims.Contains(claim))
                return;

        throw new AuthorizationException();
    }
}
