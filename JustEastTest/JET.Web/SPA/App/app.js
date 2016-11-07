(function () {
    'use strict';

    function config($routeProvider, $locationProvider) {
        $routeProvider
          .when('/restaurants/details/v1', {
              templateUrl: 'Spa/Templates/detailsV1.html',
              controller: 'reastaurantController'
          }).when('/restaurants/details/v2', {
              templateUrl: 'Spa/Templates/detailsV2.html',
              controller: 'reastaurantControllerV2'
          }).otherwise({
              redirectTo: '/'
          });
       
        $locationProvider.html5Mode(true);    
    }

    config.$inject = ['$routeProvider', '$locationProvider'];

    function run($rootScope, $location, $route, $timeout, $window) {
        $rootScope.config = {};
        $rootScope.config.app_url = $location.url();
        $rootScope.config.app_path = $location.path();

        $rootScope.$on('$routeChangeStart', function () {
            $window.scrollTo(0, 0);
           
        });
        $rootScope.$on('$routeChangeSuccess', function () { 
           
        });
        $rootScope.$on('$routeChangeError', function () {
            
        }); 
    }

    run.$inject = ['$rootScope', '$location', '$route', '$timeout', '$window'];

    angular.module('justEastTesting', ['common.core', 'common.ui'])
        .config(config)
        .run(run);

})();

