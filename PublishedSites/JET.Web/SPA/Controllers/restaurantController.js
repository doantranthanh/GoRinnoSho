(function (app) {
    'use strict';

    function restaurantController($scope, $location, $sessionStorage, restaurantService) {

        $sessionStorage.searchPage = $location.path();

        $scope.config = restaurantService.setupConfigApi();

        $scope.searchModel = restaurantService.searchModel;

        $scope.restaurants = restaurantService.restaurants;

        $scope.loading = false;

        function getRestaurantDetailsCompleted(response) {
            $scope.loading = false;
            $scope.restaurants = response.data;
        }

       
        function getRestaurantDetailsFailed(response) {
            console.log(response.data);
            $scope.loading = false;
            $location.path("/error");
        }


        $scope.submit = function (getRestaurantForm) {
            if (getRestaurantForm.$valid) {
                $scope.loading = true;
                restaurantService.getRestaurantDetails($scope.searchModel.postCode, $scope.searchModel.cuisine, $scope.searchModel.restaurantName, $scope.config, getRestaurantDetailsCompleted, getRestaurantDetailsFailed);
            }
        };


    }

    app.controller('restaurantController', ['$scope', '$location', '$sessionStorage' ,'restaurantService', restaurantController]);
})(angular.module('jet'));