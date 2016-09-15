(function () {

    var app = angular.module('appFactoryModule', []);
    app.factory('appFactory', ['$http', '$q', appfn]);
    function appfn($http, $q) {
        var service = {
            getProducts: getProducts
        };
        return service;

        function getProducts() {
            //var promise = $q.defer();
            var products = [
                    { productID: 10, productName: 'TEST', price: 200 },
                    { productID: 101, productName: 'TEST2', price: 300 }
            ];
            return products;
        }
    }

})();