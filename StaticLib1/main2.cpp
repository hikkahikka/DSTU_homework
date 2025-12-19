#include <iostream>
#include "shape.h"

int main() {
    Triangle tri(3, 4, 5);
    Square sq(5);
    Circle circ(3);
    
    std::cout << "Triangle area: " << tri.getArea() 
              << ", perimeter: " << tri.getPerimeter() << std::endl;
    
    std::cout << "Square area: " << sq.getArea() 
              << ", perimeter: " << sq.getPerimeter() << std::endl;
    
    std::cout << "Circle area: " << circ.getArea() 
              << ", perimeter: " << circ.getPerimeter() << std::endl;
    
    return 0;
}