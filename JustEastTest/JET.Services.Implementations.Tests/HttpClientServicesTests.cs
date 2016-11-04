using System;
using System.Dynamic;
using JET.Services.Implementations.WebClient;
using JET.Services.Interfaces.WebClient;
using NUnit.Framework;
using StructureMap.AutoMocking;

namespace JET.Services.Implementations.Tests
{
    [TestFixture]
    public class HttpClientServicesTests
    {
        private RhinoAutoMocker<HttpClientService> _httpClientServices;

        [SetUp]
        public void SetUp()
        {
            _httpClientServices = new RhinoAutoMocker<HttpClientService>();
        }


        [Test]
        public void Existing_HttpClientService()
        {
            var mockHttpClientServices = new HttpClientService();
            Assert.IsNotNull(mockHttpClientServices);
            Assert.IsInstanceOf<IHttpClientService>(mockHttpClientServices);
        }

        [Test]
        [TestCase("https://public.je-apis.com/")]
        public void Should_GetBaseAddress_Successfully(string uriAddress)
        {         
            var baseAddress = _httpClientServices.ClassUnderTest.GetBaseAddress(uriAddress);
            Assert.IsNotNull(baseAddress);
            Assert.IsInstanceOf<Uri>(baseAddress);
        }
    }
}
