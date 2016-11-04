using System.Net;
using System.Net.Http;
using System.Web.Http;
using JET.Entities;
using JET.Services.Interfaces.WebClient;

namespace JET.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class RestaurantController : ApiController
    {
        private readonly IHttpClientService _httpClientService;
        private const string JustEastUriAddress = "https://public.je-apis.com/";

        public RestaurantController(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
            _httpClientService.SetBaseAddress(JustEastUriAddress);
        }

        [Route("restaurant/{queryString}")]
        [HttpGet]
        public HttpResponseMessage GetRestaurants(string queryString = null)
        {
            _httpClientService.ClearDefaultHeader();
            _httpClientService.AddValidRequestHeader("Accept-Tenant", "uk");
            _httpClientService.AddValidRequestHeader("Authorization", "Basic VGVjaFRlc3RBUEk6dXNlcjI=");
            _httpClientService.AddValidRequestHeader("Accept-Version", "1");
            var restaurantsReturned = _httpClientService.GetResultsAsyns<Restaurant>(queryString);
            if (restaurantsReturned == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, restaurantsReturned);
        }
    }
}