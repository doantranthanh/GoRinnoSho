(function(app) {
    'use strict';

    function loadingDirective() {
        return {
            restrict: 'E',
            replace: true,
            template: '<div class="loading"><img src="http://www.nasa.gov/multimedia/videogallery/ajax-loader.gif" width="45" height="45" /></div>',
            link: function(scope, element, attr) {
                scope.$watch('loading', function(val) {
                    if (val)
                        $(element).show();
                    else
                        $(element).hide();
                });
            }
        };
    }

    app.directive('loadingDirective', loadingDirective);

})(angular.module('common.ui'));