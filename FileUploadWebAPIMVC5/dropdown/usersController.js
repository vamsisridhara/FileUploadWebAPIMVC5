(function () {

    var app = angular.module("postExample", []);

    var UsersController = function ($scope, userRepoService) {

        var onFetchError = function (message) {
            $scope.error = "Error Fetching Users. Message:" + message;
        };

        var onFetchCompleted = function (data) {
            $scope.users = data;
        };

        var getUsers = function () {
            userRepoService.get().then(onFetchCompleted, onFetchError);
        };

        getUsers();

    };

    app.controller("UsersController", UsersController);

}());