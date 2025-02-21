#include <iostream>
#include <ctime>
int main()
{
    srand(time(0));
    int boys_value = 1+ rand() %9;
    int boys[10];
    int girls_value = 10 - boys_value;
    int girls[10];
    int girls_sum = 0;
    int boys_sum = 0;
    std::cout << "Boys: ";
    for (int i = 0; i < boys_value; ++i) {
        *(boys + i) = rand() % 31 + 160;
        std::cout << *(boys + i)<<" ";
    }
    std::cout << "Boys - " << boys_value;
    std::cout << std::endl << "Girls: ";
    for (int i = 0; i < girls_value; ++i) {
        *(girls + i) = rand() % 31 + 150;
        std::cout << *(girls + i)<<" ";
    }
    std::cout << "Girls - " << girls_value;



    for (int i = 0; i < boys_value; ++i) {
        boys_sum += *(boys + i);
    }
    for (int i = 0; i < girls_value; ++i) {
        girls_sum += *(girls + i);
    }
    std::cout << std::endl << "Boys avg : " << boys_sum / boys_value << std::endl << "Girls avg: " << girls_sum / girls_value;

}

