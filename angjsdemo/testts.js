var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var User = (function () {
    //point: Point[];
    function User(firstName, lastName) {
        this.fullName = firstName + " " + lastName;
    }
    User.prototype.hello = function () {
        return this.fullName;
    };
    User.prototype.getPoints = function () {
        return [
            new Point(10, 20),
            new Point(20, 30)
        ];
    };
    User.prototype.getColor = function () {
        var c = colors.Red;
        return colors[c];
        //var myNumber = Numbers.two;
        //return Numbers[myNumber]; // twoAsString == "two"
    };
    return User;
}());
var Animal = (function () {
    function Animal(theName) {
        this.name = theName;
    }
    Animal.prototype.move = function (meters) {
        if (meters === void 0) { meters = 0; }
        alert(this.name + " moved " + meters + "m.");
    };
    return Animal;
}());
var Snake = (function (_super) {
    __extends(Snake, _super);
    function Snake(name) {
        _super.call(this, name);
    }
    Snake.prototype.move = function (meters) {
        if (meters === void 0) { meters = 5; }
        alert("Slithering…");
        _super.prototype.move.call(this, meters);
    };
    return Snake;
}(Animal));
var Horse = (function (_super) {
    __extends(Horse, _super);
    function Horse(name) {
        _super.call(this, name);
    }
    Horse.prototype.move = function (meters) {
        if (meters === void 0) { meters = 45; }
        alert("Galloping…");
        _super.prototype.move.call(this, meters);
    };
    return Horse;
}(Animal));
var Numbers;
(function (Numbers) {
    Numbers[Numbers["zero"] = 0] = "zero";
    Numbers[Numbers["one"] = 1] = "one";
    Numbers[Numbers["two"] = 2] = "two";
    Numbers[Numbers["three"] = 3] = "three";
    Numbers[Numbers["four"] = 4] = "four";
})(Numbers || (Numbers = {}));
var colors;
(function (colors) {
    colors[colors["Red"] = 0] = "Red";
    colors[colors["Green"] = 1] = "Green";
    colors[colors["Blue"] = 2] = "Blue";
})(colors || (colors = {}));
;
var Point = (function () {
    function Point(_x, _y) {
        this.x = _x;
        this.y = _y;
    }
    return Point;
}());
//# sourceMappingURL=testts.js.map