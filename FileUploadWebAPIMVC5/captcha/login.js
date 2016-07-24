(function () {
    var app = angular.module('recaptchaApp', ['vcRecaptcha', 'loginService']);
    app.controller('recaptchaCtrl',
        ['$scope', 'vcRecaptchaService', 'loginServiceFactory',
            recpatchCtrlFunction]);

    function recpatchCtrlFunction($scope, vcRecaptchaService, loginServiceFactory) {
        console.log("this is your app's controller");
        $scope.response = null;
        $scope.widgetId = null;

        $scope.username = '';
        $scope.password = '';

        $scope.model = {
            //**this key should be from your company**
            key: '6LdUu_cSAAAAAJT-SnxZm_EL_NwazPuCwgfb70Wo'
        };

        $scope.setResponse = function (response) {
            console.info('Response available');
            $scope.response = response;
        };
        $scope.setWidgetId = function (widgetId) {
            console.info('Created widget ID: %s', widgetId);
            $scope.widgetId = widgetId;
        };
        $scope.cbExpiration = function () {
            console.info('Captcha expired. Resetting response object');
            vcRecaptchaService.reload($scope.widgetId);
            $scope.response = null;
        };

        $scope.submit = function () {
            var input = { username: $scope.username, password: $scope.password };
            loginServiceFactory.validate(input).then(function success(response) {
                console.log('Success');
            }, function error(data) {
                vcRecaptchaService.reload($scope.widgetId);
            });
        };
    }
}());