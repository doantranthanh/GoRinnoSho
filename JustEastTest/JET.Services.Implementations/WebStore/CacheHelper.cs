using System;
using System.Collections;
using System.Collections.Generic;
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

        public void RemoveCacheObj(string key)
        {
            key = FormatKey(key);
            _cache.Remove(key);
        }

        public T Cache<T>(string key, List<string> filePathToMonitor, Func<T> fn)
        {
            if (_cache[key] != null)
                return (T)_cache[key];

            T res = fn();

            var policy = new CacheItemPolicy();
            policy.ChangeMonitors.Add(new HostFileChangeMonitor(filePathToMonitor));

            _cache.Add(key, res, policy);

            return res;
        }

        public T Cache<T>(string key, int hours, Func<T> fn)
        {
            if (_cache[key] != null)
                return (T)_cache[key];

            T res = fn();

            var policy = new CacheItemPolicy() { AbsoluteExpiration = DateTime.Now.AddHours(hours) };

            _cache.Add(key, res, policy);

            return res;
        }

        public T GetCacheInHours<T>(string key, int hour, Func<T> func)
        {
            key = FormatKey(key);
            if (_cache.Contains(key))
            {
                var ret = (T)_cache.Get(key);
                var list = ret as IList;

                if (list != null && list.Count > 0)
                {
                    return ret;
                }

                if (ret != null && !ret.GetType().IsGenericType)
                    return ret;
            }
            var result = func();
            var cacheItemPolicy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddHours(hour) };
            _cache.Add(key, result, cacheItemPolicy);
            return result;
        }

        public T GetCacheInDays<T>(string key, int days, Func<T> func)
        {
            key = FormatKey(key);
            if (_cache.Contains(key))
            {
                var ret = (T)_cache.Get(key);
                var list = ret as IList;
                if (list != null && list.Count > 0)
                {
                    return ret;
                }
                if (ret != null && !ret.GetType().IsGenericType)
                    return ret;
            }
            var result = func();
            var cacheItemPolicy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddDays(days) };
            _cache.Add(key, result, cacheItemPolicy);
            return result;
        }
    }
}
