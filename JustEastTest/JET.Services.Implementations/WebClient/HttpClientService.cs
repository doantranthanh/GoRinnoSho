using System;
using System.Collections.Generic;
using System.Net.Http;
using JET.Services.Interfaces.WebClient;

namespace JET.Services.Implementations.WebClient
{
    public class HttpClientService : IHttpClientService
    {

        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient)
        {
            if(httpClient == null)
                throw new ArgumentNullException("httpClient");

            _httpClient = httpClient;
        }

        public HttpClient GetCurrent
        {
            get {return _httpClient; }
        }


        public Uri BaseUrl { get; private set; }

        public Uri SetBaseAddress(string uriAddress)
        {
            BaseUrl = new Uri(uriAddress);
            return _httpClient.BaseAddress = BaseUrl;
        }

        public void ClearDefaultHeader()
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
        }

        public void AddValidRequestHeader(string name, string value)
        {
            _httpClient.DefaultRequestHeaders.Add(name, value);
        }

        public IEnumerable<T> GetResultsAsyns<T>(string queryString)
        {
            var response = _httpClient.GetAsync(queryString).Result;
            response.EnsureSuccessStatusCode();         
            return response.Content.ReadAsAsync<T[]>().Result;
        }

        public T GetResultAsyns<T>(string queryString)
        {
            var response = _httpClient.GetAsync(queryString).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsAsync<T>().Result;
        }
    }
}
