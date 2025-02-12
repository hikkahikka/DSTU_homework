#include <iostream>
#include <cmath>
using namespace std;
int main()
{
    int z, y;
    cout << "Input z,y: ";
    cin >> z >>y;
    if (cin.fail() || cin.peek() != '\n')
    {
        cout << "Bad input, bb";
        return -1;
    }
    int x = -1 * pow(z, y) + pow(y, z);
    cout << x;
}

