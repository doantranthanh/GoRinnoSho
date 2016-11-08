using System;
using System.Configuration;
using System.Runtime.Caching;
using JET.Services.Interfaces.WebStore;

namespace JET.Services.Implementations.WebStore
{
    public class CacheHelper : ICacheHelper
    {
        private static readonly ObjectCache _cache = MemoryCache.Default;

        public void StoreObjToCache(string key, object value)
        {
            StoreObjToCache(key, value, 7);
        }

        public void StoreObjToCache(string key, object value, int days)
        {
            key = FormatKey(key);
            var cacheItemPolicy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddDays(days) };
            _cache.Add(key, value, cacheItemPolicy);
        }

        public void StoreObjToCacheInHour(string key, object value, int hour)
        {
            key = FormatKey(key);
            var cacheItemPolicy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddHours(hour) };
            _cache.Add(key, value, cacheItemPolicy);
        }

        private string FormatKey(string key)
        {
            return string.Format("{0}-{1}", ConfigurationManager.AppSettings["cache_namespace"], key);
        }

        public T RetrieveCachedObj<T>(string key)
        {
            key = FormatKey(key);
            if (_cache.Contains(key))
                return (T)_cache.Get(key);
            return default(T);
        }
    }
}
