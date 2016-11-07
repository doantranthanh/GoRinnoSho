(function () {
    'use strict';

    function config($routeProvider, $locationProvider) {
        $routeProvider
          .when('/restaurants/details/v1', {
              templateUrl: '/Spa/Templates/detailsV1.html',
              controller: 'restaurantController'
          }).when('/restaurants/details/v2', {
              templateUrl: '/Spa/Templates/detailsV2.html',
              controller: 'restaurantControllerV2'
          }).otherwise({
              redirectTo: '/'
          });
       
        $locationProvider.html5Mode(true);    
    }

    config.$inject = ['$routeProvider', '$locationProvider'];

    angular.module('jet', ['common.core', 'common.ui'])
        .config(config);

})();

