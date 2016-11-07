using System;
using System.Collections.Generic;

namespace JET.Services.Interfaces.WebClient
{
    public interface IHttpClientService : IDisposable
    {
        Uri SetBaseAddress(string uriAddress);
        void ClearDefaultHeader();
        void SetAcceptDefaultHeader(string responseContentType);
        void AddAuthorizationHeader(string type, string value);
        void AddValidRequestHeader(string name, string value);
        IEnumerable<T> GetResultsAsyns<T>(string queryString);
        T GetResultAsyns<T>(string queryString);
    }
}
