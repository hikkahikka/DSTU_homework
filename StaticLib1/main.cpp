#include "geometry.h"
#include <iostream>
int main(){
    std::cout<<Geometry::squareArea(4)<<std::endl;
    Geometry::compireSquare(Geometry::squareArea(5), Geometry::circleArea(5));
}
