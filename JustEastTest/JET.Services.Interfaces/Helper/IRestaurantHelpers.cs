using JET.Entities.POJO;

namespace JET.Services.Interfaces.Helper
{
    public interface IRestaurantHelpers
    {
        bool IsAlreadySubmitted(string postCode);

        Result GetRestaurantsDetails(string postcode, string cuisine, string restaurantName);
    }
}
