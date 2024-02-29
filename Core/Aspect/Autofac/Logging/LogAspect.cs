using System;
using System.Diagnostics;
using Castle.DynamicProxy;
using Core.Utilities.Interceptor;

namespace Core.Aspect.Autofac.Logging;

public class LogAspect:MethodInterception
{
    protected override void OnBefore(IInvocation invocation)
    {
        Debug.WriteLine("Test");
    }
}

public class DebugWriteAspect : MethodInterception
{
    public string Message { get; set; }
    protected override void OnBefore(IInvocation invocation)
    {
        Debug.WriteLine(Message);
    }
}