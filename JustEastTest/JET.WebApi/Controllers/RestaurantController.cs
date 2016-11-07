﻿using System.Net;
using System.Net.Http;
using System.Web.Http;
using JET.Entities;
using JET.Services.Interfaces.WebClient;
using JET.UnityDependency;
using Microsoft.Practices.Unity;

namespace JET.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class RestaurantController : ApiController
    {

        private const string JustEastUriAddress = "https://public.je-apis.com/restaurants";

        [Route("restaurant/{postcode}/{cuisine?}/{restaurantName?}")]
        [HttpGet]
        public HttpResponseMessage GetRestaurants(string postcode = null, string cuisine = null, string restaurantName = null)
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
                restaurantsReturned = client.GetResultAsyns<Result>("?q=" + postcode + "&c="+ cuisine + "&name="+ restaurantName);
            }
           
            if (restaurantsReturned == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, restaurantsReturned.Restaurants);
        }
    }
}