(function () {
    "use strict";
    angular.module("productManagement")
            .controller("productListCtrl",
                ["productResource", productListCtrl]);

    function productListCtrl(productResource) {
        var vm = this;
        productResource.query(function (data) {
            vm.products = data;
        });
        

    }


}());