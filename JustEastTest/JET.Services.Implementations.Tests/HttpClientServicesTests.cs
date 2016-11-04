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
            
        }


        [Test]
        public void Existing_HttpClientService()
        {
            _httpClientServices = new RhinoAutoMocker<HttpClientService>();
            Assert.IsNotNull(_httpClientServices);
            Assert.IsInstanceOf<IHttpClientService>(_httpClientServices);
        }

        [Test]
        [TestCase("https://public.je-apis.com/")]
        public void Should_GetBaseAddress_Successfully(string uriAddress)
        {
            _httpClientServices = new RhinoAutoMocker<HttpClientService>();
            _httpClientServices.ClassUnderTest.BaseAddress(uriAddress);
            Assert.IsNotNull(_httpClientServices);
            Assert.IsInstanceOf<IHttpClientService>(_httpClientServices);
        }
    }
}
