(function (app) {
    'use strict';

    function restaurantController($scope, restaurantService) {


        $scope.config = restaurantService.setupConfigApi();

        $scope.searchModel = restaurantService.searchModel;

        $scope.restaurants = restaurantService.restaurants;

        $scope.loading = false;

        function getRestaurantDetailsCompleted(response) {
            $scope.loading = false;
            $scope.restaurants = response.data;
            console.log(response.data);
        }

       
        function getRestaurantDetailsFailed(response) {
            $scope.loading = false;
        }


        $scope.submit = function (getRestaurantForm) {
            if (getRestaurantForm.$valid) {
                $scope.loading = true;
                restaurantService.getRestaurantDetails($scope.searchModel.postCode, $scope.searchModel.cuisine, $scope.searchModel.restaurantName, $scope.config, getRestaurantDetailsCompleted, getRestaurantDetailsFailed);
            }
        };


    }

    app.controller('restaurantController', ['$scope', 'restaurantService', restaurantController]);
})(angular.module('jet'));