#pragma once
class Triangle {
private:
    double a, b, c;
public:
    Triangle(double side1, double side2, double side3);
    double getArea();
    double getPerimeter();
};

class Square {
private:
    double side;
public:
    Square(double s);
    double getArea();
    double getPerimeter();
};

class Circle {
private:
    double radius;
public:
    Circle(double r);
    double getArea();
    double getPerimeter();
};

