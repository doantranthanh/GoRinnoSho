using System.Net;
using System.Net.Http;
using System.Web.Http;
using JET.Entities.Enums;
using JET.Entities.POJO;
using JET.Services.Interfaces.Helper;
using JET.Services.Interfaces.WebClient;
using JET.Services.Interfaces.WebStore;
using JET.UnityDependency;

namespace JET.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class RestaurantController : ApiController
    {
        private const string JustEastUriAddress = "https://public.je-apis.com/restaurants";
        private readonly ICacheHelper _cacheHelper;
        private readonly IRestaurantHelpers _restaurantHelpers;
        public RestaurantController()
        {
            _cacheHelper = UnityDependencyContainer.GetCurrent().Resolve<ICacheHelper>();
            _restaurantHelpers = UnityDependencyContainer.GetCurrent().Resolve<IRestaurantHelpers>();
        }

        [Route("restaurant/{postcode}/{cuisine?}/{restaurantName?}")]
        [HttpGet]
        public HttpResponseMessage GetRestaurants(string postcode = "", string cuisine = "", string restaurantName = "")
        {
            Result restaurantsReturned = null;

            if (_restaurantHelpers.IsAlreadySubmitted(postcode))
            {
                _cacheHelper.GetCacheInHours<Result>(CacheKey.GetRestaurantDetail.ToString(), 2, () =>
                {
                    restaurantsReturned = GetRestaurantsDetails(postcode, cuisine, restaurantName);
                    return restaurantsReturned;
                });
            }
            else
            {
                _cacheHelper.StoreObjToCacheInHour("SubmittedPostcode", postcode, 2);
                _cacheHelper.GetCacheInHours<Result>(CacheKey.GetRestaurantDetail.ToString(), 2, () =>
                {
                    restaurantsReturned = GetRestaurantsDetails(postcode, cuisine, restaurantName);
                    return restaurantsReturned;
                });
            }

            if (restaurantsReturned == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, restaurantsReturned.Restaurants);
        }

        private static Result GetRestaurantsDetails(string postcode, string cuisine, string restaurantName)
        {
            Result restaurantsReturned;
            using (var client = UnityDependencyContainer.GetCurrent().Resolve<IHttpClientService>())
            {
                client.SetBaseAddress(JustEastUriAddress);
                client.ClearDefaultHeader();
                client.SetAcceptDefaultHeader("application/json");
                client.AddAuthorizationHeader("Basic", "VGVjaFRlc3RBUEk6dXNlcjI=");
                client.AddValidRequestHeader("Accept-Tenant", "uk");
                client.AddValidRequestHeader("Accept-Language", "en-GB");
                client.AddValidRequestHeader("Accept-Charset", "utf-8");
                client.AddValidRequestHeader("Host", "public.je-apis.com");
                restaurantsReturned =
                    client.GetResultAsyns<Result>("?q=" + postcode + "&c=" + cuisine + "&name=" + restaurantName);
            }
            return restaurantsReturned;
        }
    }
}