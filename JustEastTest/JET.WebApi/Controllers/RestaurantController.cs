using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JET.Entities.Enums;
using JET.Entities.POJO;
using JET.Services.Interfaces.Helper;
using JET.Services.Interfaces.Logger;
using JET.Services.Interfaces.WebStore;
using JET.UnityDependency;

namespace JET.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class RestaurantController : ApiController
    {
      
        private readonly ICacheHelper _cacheHelper;
        private readonly IRestaurantHelpers _restaurantHelpers;
        private readonly ILoggerService<RestaurantController> _logger;
        public RestaurantController()
        {
            _cacheHelper = UnityDependencyContainer.GetCurrent().Resolve<ICacheHelper>();
            _restaurantHelpers = UnityDependencyContainer.GetCurrent().Resolve<IRestaurantHelpers>();
            _logger = UnityDependencyContainer.GetCurrent().Resolve<ILoggerService<RestaurantController>>();
        }

        [Route("restaurant/{postcode}/{cuisine?}/{restaurantName?}")]
        [HttpGet]
        public HttpResponseMessage GetRestaurants(string postcode = "", string cuisine = "", string restaurantName = "")
        {
            var exMessage = string.Empty;

            var restaurantsReturned = new Result()
            {
                Restaurants = new List<Restaurant>()
            };

            HttpResponseMessage response;
            var isPostCodeValid = false;
            try
            {
                isPostCodeValid = _restaurantHelpers.IsPostCodeValid(postcode);
                if (isPostCodeValid)
                {
                    if (_restaurantHelpers.IsAlreadySubmitted(postcode))
                    {
                        _logger.Info("Submitted postcode" + postcode);
                        restaurantsReturned = _cacheHelper.GetCacheInHours(CacheKey.GetRestaurantDetail.ToString(), 1,
                            () =>
                            {
                                var cacheResult = _restaurantHelpers.GetRestaurantsDetails(postcode, cuisine,
                                    restaurantName);
                                return cacheResult;
                            });
                    }
                    else
                    {
                        _logger.Info("New Submitted postcode" + postcode);
                        _logger.Info(String.Format("Starting calling JET WebAPI with {0})", postcode));
                        _cacheHelper.RemoveCacheObj("SubmittedPostcode");
                        _cacheHelper.StoreObjToCacheInHour("SubmittedPostcode", postcode, 1);
                        _cacheHelper.RemoveCacheObj(CacheKey.GetRestaurantDetail.ToString());
                        restaurantsReturned = _cacheHelper.GetCacheInHours(CacheKey.GetRestaurantDetail.ToString(), 1,
                            () =>
                            {
                                var cacheResult = _restaurantHelpers.GetRestaurantsDetails(postcode, cuisine,
                                    restaurantName);
                                return cacheResult;
                            });
                    }
                }               
               
            }
            catch (Exception ex)
            {
                _logger.Warn("Calling GetRestaurants from Web API has exception " + ex.Message);
                restaurantsReturned = null;
                exMessage = ex.Message;
            }

            finally
            {
                if (restaurantsReturned == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, exMessage);
                }
                else
                {
                    if (isPostCodeValid)
                    {
                        if (restaurantsReturned.Restaurants.Any())
                        {
                            response = Request.CreateResponse(HttpStatusCode.OK, restaurantsReturned.Restaurants);
                        }
                        else
                        {
                            response = Request.CreateResponse(HttpStatusCode.NotFound, restaurantsReturned.Restaurants);
                        }
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.BadGateway);
                    }                                   
                }
               
            }
            return response;
        }
    }
}