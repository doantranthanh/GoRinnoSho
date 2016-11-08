﻿namespace JET.Services.Interfaces.WebStore
{
    public interface ICacheHelper
    {
        void StoreObjToCache(string key, object value);

        void StoreObjToCache(string key, object value, int days);

        void StoreObjToCacheInHour(string key, object value, int hour);

        T RetrieveCacheObj<T>(string key);
    }
}
