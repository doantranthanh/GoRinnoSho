using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using JET.Services.Interfaces.WebClient;
using Newtonsoft.Json;

namespace JET.Services.Implementations.WebClient
{
    public class HttpClientService : IHttpClientService
    {

        private readonly HttpClient _httpClient;

        public HttpClientService()
        {
            _httpClient = new HttpClient();
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

        public void SetAcceptDefaultHeader(string responseContentType)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(responseContentType));
        }

        public void AddAuthorizationHeader(string type, string value)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(type,value);
        }

        public void AddValidRequestHeader(string name, string value)
        {
            _httpClient.DefaultRequestHeaders.Add(name, value);
        }

        public IEnumerable<T> GetResultsAsyns<T>(string queryString)
        {
            var response = _httpClient.GetAsync(queryString).Result;
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;       
            return JsonConvert.DeserializeObject<List<T>>(content);
        }

        public T GetResultAsyns<T>(string queryString)
        {
            var response = _httpClient.GetAsync(queryString).Result;
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(content);
        }

        public void Dispose()
        {
            _httpClient.Dispose();    
        }
    }
}
