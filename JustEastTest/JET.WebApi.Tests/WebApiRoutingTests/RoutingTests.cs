using System.Net.Http;
using System.Web.Http;
using JET.WebApi.Controllers;
using MvcRouteTester;
using NUnit.Framework;

namespace JET.WebApi.Tests.WebApiRoutingTests
{
    [TestFixture]
    public class RoutingTests
    {    
        private HttpConfiguration _httpConfiguration;

        [SetUp]
        public void SetUp()
        {           
            _httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(_httpConfiguration);
            _httpConfiguration.EnsureInitialized();
        }

        [Test]
        [TestCase("cr85ng")]
        public void GetRestaurants_WithCorrectRoute_CallsAppropriateMethod(string stringQuery)
        {
            const string route = "/api/restaurant/q=cr8&c=&name=";
            RouteAssert.HasApiRoute(_httpConfiguration, route, HttpMethod.Get);
            _httpConfiguration.ShouldMap(route).To<RestaurantController>(HttpMethod.Get, x => x.GetRestaurants(stringQuery));
        }
    }  
}
