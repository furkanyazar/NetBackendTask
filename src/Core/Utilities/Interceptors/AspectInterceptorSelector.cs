﻿using Castle.DynamicProxy;
using Core.Aspects.Performance;
using System.Reflection;

namespace Core.Utilities.Interceptors;

public class AspectInterceptorSelector : IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
        var methodAttributes = type.GetMethod(
                method.Name,
                method.GetParameters().Select(c => c.ParameterType).ToArray()
            )
            .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);

        classAttributes.AddRange(methodAttributes);
        classAttributes.Add(new PerformanceAspect(5));

        return classAttributes.OrderBy(c => c.Priority).ToArray();
    }
}