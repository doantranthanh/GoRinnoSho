using System;
using System.Net.Http;
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
            var mockHttpClientServices = new HttpClientService(new HttpClient());
            Assert.IsNotNull(mockHttpClientServices);
            Assert.IsInstanceOf<IHttpClientService>(mockHttpClientServices);
        }

        [Test]
        public void Should_Return_Client_When_GetCurrent_Called()
        {
            var mockHttpClientServices = new HttpClientService(new HttpClient());
            var resutl = mockHttpClientServices.GetCurrent;
            Assert.IsNotNull(resutl);
            Assert.IsInstanceOf<HttpClient>(resutl);
        }

        [Test]
        public void Should_Throws_ArgumentException_If_HttpClient_Is_Null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new HttpClientService(null));
            Assert.That(ex.Message, Is.StringContaining("Value cannot be null"));
            Assert.That(ex.ParamName, Is.StringContaining("client"));
        }

        [Test]
        [TestCase("https://public.je-apis.com/")]
        public void Should_GetBaseAddress_Successfully(string uriAddress)
        {         
            var baseAddress = _httpClientServices.ClassUnderTest.SetBaseAddress(uriAddress);
            Assert.IsNotNull(baseAddress);
            Assert.IsInstanceOf<Uri>(baseAddress);
            Assert.AreEqual(baseAddress.AbsoluteUri, uriAddress);
        }
       
    }
}
