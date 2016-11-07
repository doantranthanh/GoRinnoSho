using System;
using System.Net.Http;
using System.Web.Http;
using JET.Entities;
using JET.Services.Interfaces.WebClient;
using JET.UnityDependency;
using JET.WebApi.Controllers;
using NUnit.Framework;
using Rhino.Mocks;
using StructureMap.AutoMocking;

namespace JET.WebApi.Tests.RestaurantControllerTests
{
    [TestFixture]
    public class RestaurantServiceControllerTests
    {
        private RhinoAutoMocker<RestaurantController> _mockRestaurantController;
        private IHttpClientService _httpClientService;

        [SetUp]
        public void SetUp()
        {
            _httpClientService = MockRepository.GenerateMock<IHttpClientService>();        
            UnityDependencyContainer.GetCurrent().Register(_httpClientService);
            _mockRestaurantController = new RhinoAutoMocker<RestaurantController>();
            _mockRestaurantController.ClassUnderTest.Request = new HttpRequestMessage();
            _mockRestaurantController.ClassUnderTest.Configuration = new HttpConfiguration();
        }

        [Test]
        [TestCase("cr85ng", "https://public.je-apis.com/restaurants")]
        public void Should_Get_Return_Bad_Request_Result(string postcode, string uriAddress)
        {          
            _httpClientService.Expect(x => x.GetResultAsyns<Result>(Arg<string>.Is.Anything))
                .Return(null);
            var response = _mockRestaurantController.ClassUnderTest.GetRestaurants(postcode, string.Empty, string.Empty);
            Assert.IsNotNull(response);
            Assert.AreEqual("NotFound", response.StatusCode.ToString());
            _httpClientService.AssertWasCalled(x => x.GetResultAsyns<Result>(Arg<string>.Is.Anything));

        }
    }
}
