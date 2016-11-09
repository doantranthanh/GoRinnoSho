(function (app) {
    'use strict';

    function apiService($http, $location, $rootScope, $window) {
        function get(url, config, success, failure) {
            return $http.get(url, config)
                .then(function (result) {
                    success(result);
                }, function (error) {
                    if (error.status === 401) {
                        $rootScope.previousState = $location.path();
                        $window.location.href = '/error';
                    }
                    else if (failure != null) {
                        failure(error);
                    }
                });
        };

        function post(url, data, success, failure) {
            return $http.post(url, data)
                    .then(function (result) {
                        success(result);
                    }, function (error) {
                        if (error.status === 401 || error.status === 400) {
                            $rootScope.previousState = $location.path();
                            $window.location.href = '/error';
                        }
                        else if (failure != null) {
                            failure(error);
                        }
                    });
        };

        var service = {
            get: get,
            post: post
        };

        return service;
    }


    apiService.$inject = ['$http', '$location', '$rootScope', '$window'];

    app.factory('apiService', apiService);


})(angular.module('common.core'));