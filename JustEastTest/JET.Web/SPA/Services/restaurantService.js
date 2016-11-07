(function (app) {
    'use strict';

    function restaurantService(apiService) {

        var config = {};

        var restaurants = {
           
        };
     

        function setupConfigApi() {
            return config = {
                params: {

                }
            };
        }

        function getRestaurantDetails(postcode,cuisine,restaurantName, inputConfig, completedFunction, failedFunction) {
            apiService.get('/justeatapi/api/restaurant/' + postcode + "/" + cuisine + "/" + restaurantName, inputConfig, completedFunction, failedFunction);
        }
       
        var restaurantServiceObj = {
            restaurants: restaurants,
            setupConfigApi: setupConfigApi,
            getRestaurantDetails: getRestaurantDetails
        };

        return restaurantServiceObj;
    }

    restaurantService.$inject = ["apiService"];
    app.factory('restaurantService', restaurantService);

})(angular.module('common.core'));