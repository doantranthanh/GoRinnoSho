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
        [TestCase("cr85ng", "", "")]
        [TestCase("cr85ng", null, null)]
        public void GetRestaurants_WithCorrectRoute_CallsAppropriateMethod(string postcode,string cuisine,string restaurantName)
        {
            var route = "/api/restaurant/"+ postcode + "/" + cuisine + "/"  + restaurantName;
            RouteAssert.HasApiRoute(_httpConfiguration, route, HttpMethod.Get);
            _httpConfiguration.ShouldMap(route).To<RestaurantController>(HttpMethod.Get, x => x.GetRestaurants(postcode, cuisine, restaurantName));
        }
    }  
}
