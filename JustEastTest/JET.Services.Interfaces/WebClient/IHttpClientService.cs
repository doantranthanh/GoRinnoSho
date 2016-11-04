using System;
using System.Collections.Generic;

namespace JET.Services.Interfaces.WebClient
{
    public interface IHttpClientService
    {
        Uri SetBaseAddress(string uriAddress);
        void ClearDefaultHeader();
        void AddValidRequestHeader(string name, string value);

        IEnumerable<T> GetResultsAsyns<T>();
        T GetResultAsyns<T>();
    }
}
