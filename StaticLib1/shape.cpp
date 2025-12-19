#include "shape.h"
#include <cmath>

Triangle::Triangle(double side1, double side2, double side3) 
    : a(side1), b(side2), c(side3) {}

double Triangle::getArea() {
    double p = (a + b + c) / 2;
    return sqrt(p * (p - a) * (p - b) * (p - c));
}

double Triangle::getPerimeter() {
    return a + b + c;
}

Square::Square(double s) : side(s) {}

double Square::getArea() {
    return side * side;
}

double Square::getPerimeter() {
    return 4 * side;
}

Circle::Circle(double r) : radius(r) {}

double Circle::getArea() {
    return 3.14 * radius * radius;
}

double Circle::getPerimeter() {
    return 2 * 3.14 * radius;
}