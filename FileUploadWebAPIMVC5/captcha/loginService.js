(function () {
    'use strict';
    var app = angular.module('loginService', []);
    app.factory('loginServiceFactory', ['$http', '$q', loginServiceFunction]);
    function loginServiceFunction($http, $q) {
        var service = {
            validate: validate
        };
        return service;
        function validate(input) {
            var defer = $q.defer();
            $http({
                method: 'POST',
                url: '/FileUploadWebAPIMVC5/api/login/validate',
                data: JSON.stringify(input)
            }).then(function (data) {
                defer.resolve(data);
            }, function (error) {
                defer.reject(error);
            });
            return defer.promise;
        };
    }
}());