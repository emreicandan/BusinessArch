using System;
using System.Reflection;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptor;

public class AspectInterceptorSelector : IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        var classAttribute = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList() ?? new();
        var methodAttributes = type.GetMethod(method.Name)?.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList() ?? new();
        classAttribute.AddRange(methodAttributes);
        return classAttribute.OrderBy(x => x.Priority).ToArray();
    }
}

