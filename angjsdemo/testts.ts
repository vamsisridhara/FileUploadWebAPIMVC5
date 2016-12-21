class User {
    fullName: string;
    //point: Point[];
    constructor(firstName: string, lastName: string) {
        this.fullName = firstName + " " + lastName;
    }
    hello(): string {
        return this.fullName;
    }
    getPoints(): Point[] {
        return [
            new Point(10, 20),
            new Point(20, 30)
        ];
    }
    getColor(): string {
        var c = colors.Red;
        return colors[c];
        //var myNumber = Numbers.two;
        //return Numbers[myNumber]; // twoAsString == "two"
    }
}
class Animal {
    name: string;
    constructor(theName: string) {
        this.name = theName;
    }
    move(meters: number = 0) {
        alert(this.name + " moved " + meters + "m.");
    }
}
class Snake extends Animal {
    constructor(name: string) {
        super(name);
    }
    move(meters = 5) {
        alert("Slithering…");
        super.move(meters);
    }
}
class Horse extends Animal {
    constructor(name: string) {
        super(name);
    }
    move(meters = 45) {
        alert("Galloping…");
        super.move(meters);
    }
}
enum Numbers { zero, one, two, three, four }
enum colors { Red, Green, Blue };
class Point {
    x: number;
    y: number;
    constructor(_x: number, _y: number) {
        this.x = _x;
        this.y = _y;
    }
}