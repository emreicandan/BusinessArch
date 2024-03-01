using System;
using Microsoft.Extensions.Caching.Memory;

namespace Core.CrossCuttingConcerns.Caching.Custom.Microsoft;

	public class MicrosoftCacheMenager:ICacheService
	{

    private readonly IMemoryCache _memoryCache;
    public MicrosoftCacheMenager(IMemoryCache memoryCache)
	{
       _memoryCache = memoryCache;
	}

    public void Add(string key, object value, int duration)
    {
        _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
    }

    public object Get(string key)
    {
        return _memoryCache.Get(key) ?? throw new Exception("Cache key is not found");
    }

    public T Get<T>(string key)
    {
        return _memoryCache.Get<T>(key) ?? throw new Exception("Cache key is not found");
    }

    public bool isAdd(string key)
    {
        return _memoryCache.TryGetValue(key, out _);
    }

    public void Remove(string key)
    {
        _memoryCache.Remove(key);
    }
}

