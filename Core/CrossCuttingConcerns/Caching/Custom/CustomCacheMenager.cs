using System;
namespace Core.CrossCuttingConcerns.Caching.Custom;

public class CacheData
{
    public static IDictionary<string, object> CacheResults = new Dictionary<string, object>();

}

public class CustomCacheMenager:ICacheService
{

    public void Add(string key, object value, int duration)
    {
        if (this.isAdd(key))
        {
            CacheData.CacheResults[key] = value;
            return;
        }
        CacheData.CacheResults.Add(key, value);
    }

    public object Get(string key)
    {
        if (this.isAdd(key))
            return CacheData.CacheResults[key];
        return default;
    }

    public T Get<T>(string key)
    {
        return (T)this.Get(key);
    }

    public bool isAdd(string key)
    {
        return CacheData.CacheResults.ContainsKey(key);
    }

    public void Remove(string key)
    {
        if (this.isAdd(key))
            CacheData.CacheResults.Remove(key);
    }
}


