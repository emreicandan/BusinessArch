using System;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptor;

[AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple =true,Inherited =true)]

public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
{
    public int Priority { get; set; }
    //Priority verdiğimiz methodların üstündeki nesnelerin hangi sırayla çalışacağını ayarlamak için tanımlanır.
    public virtual void Intercept(IInvocation invocation)
    {
        
    }
};