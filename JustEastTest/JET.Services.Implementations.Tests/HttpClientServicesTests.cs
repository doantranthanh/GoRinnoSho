using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using JET.Entities.POJO;
using JET.Services.Implementations.WebClient;
using JET.Services.Interfaces.WebClient;
using Newtonsoft.Json;
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
        public void Should_Return_Client_When_GetCurrent_Called()
        {
            using (var mockHttpClientServices = new HttpClientService())
            {
                var resutl = mockHttpClientServices.GetCurrent;
                Assert.IsNotNull(resutl);
                Assert.IsInstanceOf<HttpClient>(resutl);
            }
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

        [Test]
        [TestCase("https://public.je-apis.com/", "q=cr8&c=&name=")]
        public void When_Gettting_All_Restaurants_They_Should_Be_Returned(string uriAddress, string queryString)
        {
            // Arrange
            var restaurants = new []
            {
                new Restaurant
                {
                    Id = 1,
                    City = "London",
                    Postcode = "CR85NG"
                },
                new Restaurant
                {
                    Id = 2,
                    City = "London",
                    Postcode = "SW112SE"
                }
            };

            var mockResult = new Result()
            {
                Restaurants = restaurants
            };

            var testingHandler = new TestingDelegatingHandler<Result>(mockResult);

            using (var server = new HttpServer(new HttpConfiguration(), testingHandler))
            {        
                using (var client = new HttpClient(server))
                {
                    client.BaseAddress= new Uri(uriAddress);
                    // Act
                    var response = client.GetAsync(queryString).Result;
                    response.EnsureSuccessStatusCode();
                    var content = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<Result>(content);
                    // Assert

                    Assert.AreEqual(2, result.Restaurants.Count());
                }
            }
        }
    }
}
