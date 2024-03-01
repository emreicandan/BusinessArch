using System;
using System.Diagnostics;
using Castle.DynamicProxy;
using Core.Utilities.Interceptor;

namespace Core.Aspect.Autofac.Performance;

public class PerformanceAspect:MethodInterception
{
    public int _interval;
    public Stopwatch _stopWatch { get; set; }

    public PerformanceAspect(int interval)
    {
        _interval = interval;
        _stopWatch = new Stopwatch();
    }

    protected override void OnBefore(IInvocation invocation)
    {
        _stopWatch.Start();
    }

    protected override void OnAfter(IInvocation invocation)
    {
        if (_stopWatch.Elapsed.TotalSeconds > _interval)
        {
            Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}==>{_stopWatch.Elapsed.TotalSeconds}");
            _stopWatch.Stop();
            _stopWatch.Reset();
        }
    }
}

