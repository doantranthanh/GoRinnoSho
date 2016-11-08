using System;
using System.Collections.Generic;

namespace JET.Services.Interfaces.WebStore
{
    public interface ICacheHelper
    {
        void StoreObjToCache(string key, object value);

        void StoreObjToCache(string key, object value, int days);

        void StoreObjToCacheInHour(string key, object value, int hour);

        T RetrieveCachedObj<T>(string key);

        void RemoveCacheObj(string key);

        /*Generic Caching Methods*/

        T Cache<T>(string key, List<string> filePathToMonitor, Func<T> fn);
        T Cache<T>(string key, int hours, Func<T> fn);

        T GetCacheInHours<T>(string key, int hour, Func<T> func);

        T GetCacheInDays<T>(string key, int days, Func<T> func);
    }
}
