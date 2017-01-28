(function () {
    'use strict';
    var app = angular.module('app', []);
    app.controller('demoCtrl', ['$scope', 'demoFactory', demoCtrlfunction]);
    function demoCtrlfunction($scope, demoFactory) {
        var vm = this;
        vm.init = function () {
            vm.disablediv = true;
            vm.testp = '';
            vm.testm = '';
            vm.radioselected = '';
            vm.disablePort = true;
            vm.radioOptions = [
                { id: 1, name: 'port' },
                { id: 2, name: 'mark' },
                { id: 3, name: 'assum' },
                { id: 4, name: 'cycle' }
            ];
            vm.portCheckOptions = [
                { id: 1, name: 'check1', selected: false },
                { id: 2, name: 'check2', selected: false },
                { id: 3, name: 'check3', selected: false },
                { id: 4, name: 'check4', selected: false }
            ];
        };

        vm.toggle = function () {
            switch (vm.radioselected) {
                case 'port':
                    vm.disablePort = false;
                    console.log(vm.portCheckOptions);
                    break;
                default:
                    vm.disablePort = true;

                    console.log(vm.portCheckOptions);
                    break;
            }
        };


        vm.deleteIds = function () {
            var ids = [20, 30];
            var userId = 'vamsi';
            demoFactory.deleteIds(userId, ids).then(function success(data) {
                alert('successfully deleted ids');
            },
            function error(data) {
                console.log('failed in deleting ids');
            })
        };
        vm.disableP = function (input) {
            if (input === "portfolio") {
                vm.disablediv = false;
            } else {
                vm.disablediv = true;
            }
        };
        vm.init();
    }
    app.factory('demoFactory', ['$http', '$q', demoFactoryFunction]);
    function demoFactoryFunction($http, $q) {
        return {
            deleteIds: deleteIds
        };
        function deleteIds(userId, ids) {
            var defer = $q.defer();
            $http({
                method: 'POST',
                url: '/FileUploadWebAPIMVC5/api/testdel/deleteall/' + userId,
                data: ids
            }).success(function (data, status) {
                defer.resolve(data);
            }).error(function (data, status) {
                defer.reject('error in posting data');
            });
            return defer.promise;
        }
    }
}());