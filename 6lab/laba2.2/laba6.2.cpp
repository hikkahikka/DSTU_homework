#include <iostream>
#include <ctime>
#include <cmath>
int main()
{
    srand(time(0));
    double value[10];
    double summ = 0;
    for(int i = 0; i < 10; ++i) {
        *(value + i) = pow((-1), rand() % 2) * (rand() % 50 + (double)rand() / RAND_MAX);
        if(*(value+i)>0) summ += *(value + i);
        std::cout << *(value + i)<< "; ";
    }
    std::cout << std::endl << summ;


}

