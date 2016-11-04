using System.Dynamic;
using JET.Services.Implementations.WebClient;
using JET.Services.Interfaces.WebClient;
using NUnit.Framework;

namespace JET.Services.Implementations.Tests
{
    [TestFixture]
    public class HttpClientServicesTests
    {
        private IHttpClientService _httpClientServices;

        [SetUp]
        public void SetUp()
        {
            
        }


        [Test]
        public void Existing_HttpClientService()
        {
            _httpClientServices = new HttpClientService();
            Assert.IsNull(_httpClientServices);
            Assert.IsInstanceOf<IHttpClientService>(_httpClientServices);
        }
    }
}
