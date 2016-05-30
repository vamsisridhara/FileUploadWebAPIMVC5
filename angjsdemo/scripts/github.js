(function () {
    var github = function ($http) {
        var getuser = function (username) {
            return $http.get("https://api.github.com/users/" + username).
                    then(function (response) {
                        return response.data;
                    });
        };
        var getrepos = function (user) {
            return $http.get(user.repos_url)
                       .then(function (response) {
                           return response.data;
                       });
        };
        return {
            getuser: getuser,
            getrepos: getrepos
        };
    };
    var module = angular.module('githubviewer');
    module.factory("github", github);

}());