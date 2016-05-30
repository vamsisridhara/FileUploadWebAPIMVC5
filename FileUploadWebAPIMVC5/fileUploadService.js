(function () {
    'use strict';
    var commuteService = angular.module('fileUploadService', []);
    commuteService.factory('uploadServiceFactory',
        ['$http', '$q',
        function ($http, $q) {
            var service = {
                uploadFile: uploadFile
            };
            return service;

            function uploadFile() {
                var defer = $q.defer();
                $http({
                    url: '/api/fileupload/uploadfile',
                    method: "POST",
                    data: data,
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                }).success(function (data, status, headers, config) {
                    $scope.listofFiles = data;
                }).error(function (data, status, headers, config) {

                });
                return
            }
        }
        ]);
})();