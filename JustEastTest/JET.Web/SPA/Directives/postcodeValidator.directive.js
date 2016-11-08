(function(app) {
    'use strict';

    function postcodeValidator() {
        var fullPostcodeRegexp = /^(([gG][iI][rR] {0,}0[aA]{2})|((([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y]?[0-9][0-9]?)|(([a-pr-uwyzA-PR-UWYZ][0-9][a-hjkstuwA-HJKSTUW])|([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y][0-9][abehmnprv-yABEHMNPRV-Y]))) {0,}[0-9][abd-hjlnp-uw-zABD-HJLNP-UW-Z]{2}))$/;
        var postCodeLeftRegexp = /^[A-Za-z]{1,2}[0-9Rr][0-9A-Za-z]? {0,1}$/;

        return {
            restrict: 'A',
            require: '?ngModel',
            link: function(scope, element, attributes, ngModel) {
                ngModel.$validators.postcodeValidator = function(modelValue) {
                    if (modelValue.length !== 0) {
                        if (modelValue.length === 3) {
                            if (postCodeLeftRegexp.test(modelValue)) {
                                return true;
                            } else {
                                return false;
                            }
                        }
                        if (modelValue.length > 3) {
                            if (fullPostcodeRegexp.test(modelValue)) {
                                return true;
                            } else {
                                return false;
                            }
                        }
                    } else {
                        return true;
                    }
                };
            }
        };
    }

    app.directive('postcodeValidator', postcodeValidator);

})(angular.module('common.ui'));


