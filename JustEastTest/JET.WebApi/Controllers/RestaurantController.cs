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
            Result restaurantsReturned;

            if (_restaurantHelpers.IsAlreadySubmitted(postcode))
            {
                restaurantsReturned = _cacheHelper.GetCacheInHours(CacheKey.GetRestaurantDetail.ToString(), 1, () =>
                {
                    var cacheResult = _restaurantHelpers.GetRestaurantsDetails(postcode, cuisine, restaurantName);                
                    return cacheResult;
                });
            }
            else
            {
                _cacheHelper.RemoveCacheObj("SubmittedPostcode");
                _cacheHelper.StoreObjToCacheInHour("SubmittedPostcode", postcode, 1);
                _cacheHelper.RemoveCacheObj(CacheKey.GetRestaurantDetail.ToString());
                restaurantsReturned = _cacheHelper.GetCacheInHours(CacheKey.GetRestaurantDetail.ToString(), 1, () =>
                {
                    var cacheResult = _restaurantHelpers.GetRestaurantsDetails(postcode, cuisine, restaurantName);
                    return cacheResult;
                });
            }

            if (restaurantsReturned == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, restaurantsReturned.Restaurants);
        }
    }
}