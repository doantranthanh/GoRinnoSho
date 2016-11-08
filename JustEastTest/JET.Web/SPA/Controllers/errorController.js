(function (app) {
    'use strict';

    function errorController($scope, $sessionStorage) {
        $scope.justEatHomepage = "https://www.just-eat.co.uk";
        $scope.searchPage = $sessionStorage.searchPage;
    }

    app.controller('errorController', ['$scope', '$sessionStorage', errorController]);

})(angular.module('jet'));