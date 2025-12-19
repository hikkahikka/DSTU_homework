#include "geometry.h"
#include <iostream>
namespace Geometry{
    double squareArea(double side) {
        return side * side;
    }

    double squarePerimeter(double side) {
        return 4 * side;
        //vetka tst
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
    void compireSquare(double a, double b){
        if(a<b){
            std::cout<<"first smaller";
            return ;
        }
        else if (a>b){
            std::cout<<"first bigger";
            return ;

        }
        std::cout<<"equal";
    }
}