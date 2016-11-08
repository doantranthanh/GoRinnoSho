using System;
using JET.Services.Interfaces.Helper;
using JET.Services.Interfaces.WebStore;

namespace JET.Services.Implementations.Helpers
{
    public class RestaurantHelper : IRestaurantHelpers
    {
        private ICacheHelper _cacheHelper;

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
    }
}
