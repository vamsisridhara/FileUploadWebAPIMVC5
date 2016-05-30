(function () {
    "use strict";

    var app = angular.module("productResourceMock",
                              ["ngMockE2E"]);

    app.run(function ($httpBackend) {
        var products = [
            {
                "productID": "1",
                "productName": "Leaf Rake",
                "releaseDate": "March 20 2015",
                "description": "test",
                "cost": 9.00,
                "price": 19.95,
                "category": "garden",
                "tags": ["leaf", "tool"]
            },
            {
                "productID": "2",
                "productName": "Leaf Rake",
                "releaseDate": "March 20 2015",
                "description": "test",
                "cost": 9.00,
                "price": 19.95,
                "category": "garden",
                "tags": ["leaf", "tool"]
            },
            {
                "productID": "3",
                "productName": "Leaf Rake",
                "releaseDate": "March 20 2015",
                "description": "test",
                "cost": 9.00,
                "price": 19.95,
                "category": "garden",
                "tags": ["leaf", "tool"]
            }
        ];
        var productURL = "/api/products";
        $httpBackend.whenGET(productURL).respond(products);

        var productRegex = new RegExp(productURL + '/[0-9][0-9]*', '');
        $httpBackend.whenGET(productRegex).respond(function (method,url,data) {
            var parameters = url.split('/');
            var length = parmeters.length;
            var id = parameters[length - 1];
            var product = {"productID":0};
            if (id > 0) {
                for (var count = 0 ; count < products.length; count++) {
                    if (products[count].productID == id) {
                        product = products[count]; break;
                    }
                }
            }
            return [200, product, {}];
        });

        $httpBackend.whenPOST(productURL).respond(function (method, url, data) {
            var product = angular.fromJson(data);
            if (!product.productID) {
                product.productID = products[products.length - 1].productID + 1;
                products.push(product);
            } else {
                for (var count = 0 ; count < products.length; count++) {
                    if (products[count].productID == product.productID) {
                        products[count] = product;
                        break;
                    }
                }
            }
            return [200, product, {}];
        });

        $httpBackend.whenGET(/app/).passThrough();

    });

}());