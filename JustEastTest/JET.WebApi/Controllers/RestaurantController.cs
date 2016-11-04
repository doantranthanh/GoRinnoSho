using System.Net.Http;
using System.Web.Http;

namespace JET.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class RestaurantController : ApiController
    {
        [Route("restaurant/{queryString}")]
        [HttpGet]
        public HttpResponseMessage GetRestaurants(string queryString = null)
        {
            return null;
        }
    }
}