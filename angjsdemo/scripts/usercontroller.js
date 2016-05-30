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
    var MainController = function (
        $scope, github, $interval,
        $log, $anchorScroll, $location) {
        var onusercomplete = function (data) {
            $scope.user = data;
            github.getrepos($scope.user)
                .then(onRepos, onerror);
        };
        var onRepos = function (data) {
            $scope.repos = data;
            $location.hash("userdetails");
            $anchorScroll();
        };

        var onerror = function (reason) {
            $scope.error = "Couldn't fetch the user";
        };

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
            $log.info("searching for :" + username);
            github.getuser(username)
                .then(onusercomplete, onerror);
            if (countdowninterval) {
                $interval.cancel(countdowninterval);
                $scope.countdown = null;
            }
        };

        $scope.message = "github viewer";
        $scope.username = "angular";
        $scope.reposortorder = "-stargazers_count";
        $scope.countdown = 5;
        startcountdown();
    };
    app.controller("MainController", ['$scope', 'github', '$interval', '$log', '$anchorScroll', '$location', MainController]);
}());