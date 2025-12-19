#include "geometry.h"
namespace Geometry{
    double squareArea(double side) {
        return side * side;
    }

    double squarePerimeter(double side) {
        return 4 * side;
    }

    double circleArea(double radius) {
        return 3.14 * radius * radius;
    }

    double circlePerimeter(double radius) {
        return 2 * 3.14 * radius;
    }

    double triangleArea(double base, double height) {
        return (base * height) / 2.0;
    }

    double trianglePerimeter(double a, double b, double c) {
        return a + b + c;
    }
}