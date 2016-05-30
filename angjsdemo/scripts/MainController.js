//var myApp = angular.module('githubviewer', []);
//myApp.controller('MainController', ['$scope', '$http',function ($scope, $http) {
//    var onusercomplete = function (response) {
//        $scope.user = response.data;
//    };
//    var onerror = function (reason) {
//        $scope.error = "couldnt fetch the user";
//    };
//    $http.get("https://api.github.com/users/robconery")
//        .then(onusercomplete,onerror);
//    $scope.message = "hello";
//}]);

(function () {
    var app = angular.module('githubviewer');
    var MainController = function(
        $scope, $interval,$location) {
        var decrementcountdown = function () {
            $scope.countdown -= 1;
            if ($scope.countdown < 1) {
                $scope.search($scope.username);
            }
        };
        var countdowninterval = null;
        var startcountdown = function () {
            countdowninterval = $interval(decrementcountdown, 1000, $scope.countdown);
        };

        $scope.search = function (username) {
            if (countdowninterval) {
                $interval.cancel(countdowninterval);
                $scope.countdown = null;
            }
        };

        $scope.username = "angular";
        $scope.countdown = 5;
        startcountdown();
    };
    app.controller("MainController", ['$scope', '$interval', 'location', MainController]);
}());