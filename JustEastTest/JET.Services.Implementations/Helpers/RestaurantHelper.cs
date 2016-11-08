using System;
using JET.Entities.POJO;
using JET.Services.Interfaces.Helper;
using JET.Services.Interfaces.WebClient;
using JET.Services.Interfaces.WebStore;
using JET.UnityDependency;

namespace JET.Services.Implementations.Helpers
{
    public class RestaurantHelper : IRestaurantHelpers
    {
        private ICacheHelper _cacheHelper;
        private const string JustEastUriAddress = "https://public.je-apis.com/restaurants";

        public RestaurantHelper(ICacheHelper cacheHelper)
        {
            if(cacheHelper == null)
                throw new ArgumentNullException("cacheHelper");
            _cacheHelper = cacheHelper;
        }

        public bool IsAlreadySubmitted(string postCode)
        {
            var isAlreadySubmited = false;

            var submittedPostcode = _cacheHelper.RetrieveCachedObj<string>("SubmittedPostcode");

            if (submittedPostcode != null)
            {
                if (String.Equals(submittedPostcode,postCode,StringComparison.InvariantCulture))
                {
                    isAlreadySubmited = true;
                }
            }

            return isAlreadySubmited;
        }

        public Result GetRestaurantsDetails(string postcode, string cuisine, string restaurantName)
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
