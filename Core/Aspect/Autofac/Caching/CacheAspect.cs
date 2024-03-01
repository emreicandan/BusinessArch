using System;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptor;
using Core.Utilities.Tools;

namespace Core.Aspect.Autofac.Caching;

public class CacheAspect:MethodInterception
{
	public int _duration;
	private readonly ICacheService _cacheService;
	public CacheAspect(int duration)
	{
		_duration = duration;
		_cacheService = ServiceTool.GetService<ICacheService>();
	}

    public override void Intercept(IInvocation invocation)
    {
		string key = invocation.Method.ReflectedType.FullName + "." + invocation.Method.Name;
		if (_cacheService.isAdd(key))
		{
			invocation.ReturnValue = _cacheService.Get(key);
			Console.WriteLine("Cachden Getirildi.");
			return;
		}
		invocation.Proceed();
		_cacheService.Add(key, invocation.ReturnValue, _duration);
		Console.WriteLine("Cache Kaydedildi.");
    }
}

public class CacheRemoveAspect:MethodInterception
{
	public string _key;
	private readonly ICacheService _cacheService;

	public CacheRemoveAspect(string key)
	{
		_cacheService = ServiceTool.GetService<ICacheService>();
		_key = key;
	}

    protected override void OnSuccess(IInvocation invocation)
    {
        
		_cacheService.Remove(_key);
    }
}

