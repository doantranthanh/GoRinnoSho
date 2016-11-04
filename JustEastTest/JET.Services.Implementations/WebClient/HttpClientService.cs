using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JET.Services.Interfaces.WebClient;

namespace JET.Services.Implementations.WebClient
{
    public class HttpClientService : IHttpClientService
    {

        private readonly HttpClient _client;

        public HttpClientService()
        {
            _client = new HttpClient();
        }

        public Uri GetBaseAddress(string uriAddress)
        {
            return _client.BaseAddress = new Uri(uriAddress);
        }
    }
}
