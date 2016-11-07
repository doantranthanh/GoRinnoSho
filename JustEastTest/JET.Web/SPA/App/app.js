(function () {
    'use strict';

    function config($routeProvider, $locationProvider) {
        $routeProvider
          .when('/restaurants/details/v1', {
              templateUrl: '/signuponline/Spa/Templates/productOptionsMainPage.html',
              controller: 'productOptionsController'
          }).when('/restaurants/details/v2', {
              templateUrl: '/signuponline/Spa/Templates/yourOrderMainPage.html',
              controller: 'yourOrderController'
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
        $rootScope.layout = {};
        $rootScope.layout.loading = false;

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

