using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace JET.Services.Implementations.Tests
{
    public class TestingDelegatingHandler<T> : DelegatingHandler
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> _httpResponseMessageFunc;

        public TestingDelegatingHandler(T value)
            : this(HttpStatusCode.OK, value)
        { }

        public TestingDelegatingHandler(HttpStatusCode statusCode)
          : this(statusCode, default(T))
        { }

        public TestingDelegatingHandler(HttpStatusCode statusCode, T value)
        {
            _httpResponseMessageFunc = request => request.CreateResponse(statusCode, value);
        }

        public TestingDelegatingHandler(
            Func<HttpRequestMessage, HttpResponseMessage> httpResponseMessageFunc)
        {
            _httpResponseMessageFunc = httpResponseMessageFunc;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() => _httpResponseMessageFunc(request));
        }
    }
}
