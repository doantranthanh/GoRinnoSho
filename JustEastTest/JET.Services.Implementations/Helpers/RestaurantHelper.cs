using System;
using System.Text.RegularExpressions;
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

        public bool IsPostCodeValid(string postCode)
        {
            var isValid = false;
            var regexFullPostCode = new Regex(@"^(([gG][iI][rR] {0,}0[aA]{2})|((([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y]?[0-9][0-9]?)|(([a-pr-uwyzA-PR-UWYZ][0-9][a-hjkstuwA-HJKSTUW])|([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y][0-9][abehmnprv-yABEHMNPRV-Y]))) {0,}[0-9][abd-hjlnp-uw-zABD-HJLNP-UW-Z]{2}))$");
            var postCodeOutWardRegexp = new Regex(@"^[A-Za-z]{1,2}[0-9Rr][0-9A-Za-z]? {0,1}$");

            if (postCode.Length > 4 && postCode.Length <= 8)
            {
                if (regexFullPostCode.Match(postCode).Success)
                {
                    isValid = true;
                }
            }

            if (postCode.Length >= 2 && postCode.Length <= 4)
            {
                if (postCodeOutWardRegexp.Match(postCode).Success)
                {
                    isValid = true;
                }

            }

            return isValid;
        }
    }
}
