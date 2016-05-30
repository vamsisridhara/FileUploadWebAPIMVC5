(function () {
    "use strict";
    var app = angular.module('MyApp', []);
    app.controller("bookStoreController", function ($scope) {
        $scope.items = [
			{ ISBN: "5674789", Name: "Asp.Net MVC", Price: 560, Quantity: 20, Department: "Engineering", Perks: "Company Car", PayrollType: "none" },
			{ ISBN: "4352134", Name: "AngularJS", Price: 450, Quantity: 25, Department: "Finance", Perks: "Stock Options", PayrollType: "W-2" },
			{ ISBN: "2460932", Name: "Javascript", Price: 180, Quantity: 15, Department: "Marketing", Perks: "Six Weeks Vacation", PayrollType: "1099" }
        ];
        $scope.editMode = false;
        $scope.addItem = function (item) {
            $scope.items.push(item);
            $scope.item = {};
        }
        $scope.total = totalPrice;

        function totalPrice() {
            var total = 0;
            for (count = 0; count < $scope.items.length; count++) {
                total += $scope.items[count].Price * $scope.items[count].Quantity;
            }
            return 20;
        }

        $scope.removeItem = function (index) {
            $scope.items.splice(index, 1);
        }

        $scope.editItem = function (index) {
            $scope.editing = $scope.items.indexOf(index);
        }



    });

    



}());


