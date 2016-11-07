(function (app) {
    'use strict';

    function productOptionsController($scope, restaurantService, $sessionStorage, $location, $window) {


        $scope.config = restaurantService.setupConfigApi();

        $scope.restaurants = restaurantService.restaurants;


        function getRestaurantDetailsCompleted(response) {
            $scope.restaurants = response.data;
        }

       
        function getRestaurantDetailsFailed(response) {
            console.log(response);
        }


        $scope.submit = function (signupForm) {
            if (signupForm.$valid) {
                restaurantService.getRestaurantDetails($scope.postCode, $scope.cuisine, $scope.restaurantName, $scope.config, getRestaurantDetailsCompleted, getRestaurantDetailsFailed);
            }
        };


    }

    app.controller('restaurantController', ['$scope', 'restaurantService', '$sessionStorage', '$location', '$window', productOptionsController]);
})(angular.module('justEastTesting'));