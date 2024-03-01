using System;
namespace Core.CrossCuttingConcerns.Caching;

public interface ICacheService
{
    void Add(string key, object value, int duration);

    object Get(string key);

    T Get<T>(string key);

    bool isAdd(string key);

    void Remove(string key);
}

