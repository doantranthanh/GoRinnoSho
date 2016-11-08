(function (app) {
    'use strict';

    function restaurantController($scope, restaurantService) {


        $scope.config = restaurantService.setupConfigApi();

        $scope.searchModel = restaurantService.searchModel;

        $scope.restaurants = restaurantService.restaurants;


        function getRestaurantDetailsCompleted(response) {
            console.log(response.data);
            $scope.restaurants = response.data;
        }

       
        function getRestaurantDetailsFailed(response) {
            console.log(response);
        }


        $scope.submit = function (getRestaurantForm) {
            if (getRestaurantForm.$valid) {
                restaurantService.getRestaurantDetails($scope.searchModel.postCode, $scope.searchModel.cuisine, $scope.searchModel.restaurantName, $scope.config, getRestaurantDetailsCompleted, getRestaurantDetailsFailed);
            }
        };


    }

    app.controller('restaurantController', ['$scope', 'restaurantService', restaurantController]);
})(angular.module('jet'));