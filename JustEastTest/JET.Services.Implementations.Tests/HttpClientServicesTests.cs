﻿using System;
using System.Linq;
using System.Net.Http;
using JET.Entities;
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

            var testingHandler = new TestingDelegatingHandler<Restaurant[]>(restaurants);

            using (var client = new HttpClientService())
            {
                client.SetBaseAddress(uriAddress);

                // Act
                var restaurantsReturned = client.GetResultsAsyns<Restaurant>(queryString);

                // Assert

                Assert.AreEqual(2, restaurantsReturned.Count());
            }
        }
    }
}
