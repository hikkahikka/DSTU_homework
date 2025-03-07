
#include <iostream>
#include <ctime>
#include <cmath>

int main()
{

    srand(time(0));
    int n;
    int min_abs = INT_MAX;
    
    std::cout << "Input n:\n";
    std::cin >> n;

    if (std::cin.fail() || std::cin.peek() != '\n' || n<1)
    {
        std::cout << "Bad input, bb";
        return -1;
    }
    int* numbers = new int[n];
    int posit = 0;
    int summ = 0;
    for (int i = 0; i < n; i++) {
        numbers[i] = -20 + rand() % 41;
        min_abs = std::min(min_abs, abs(numbers[i]));
        if (numbers[i] > 0) {
            posit++;

        }
        if (posit <= 2 && posit > 0) {
            summ += numbers[i];
        }
        std::cout << numbers[i]<<" ";

    }
    std::cout << "\nMin abs "<<min_abs<<" Summ "<<summ<< "\n";

    int* change = new int[n];

    for (int i = 0; i < n/2 +n%2; i++) {
        change[i] = numbers[i * 2];
    }
    for (int i = n / 2 + n % 2 , k = 1; i < n; i++) {
        change[i] = numbers[k];
        k += 2;
    }
    for (int i = 0; i < n; i++) {
        numbers[i] = change[i];
        
        std::cout << numbers[i] << " ";
    }
    delete[]change;
    delete[]numbers;

}
