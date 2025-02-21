#include <iostream>
#include <cmath>
using namespace std;
int main()
{
    float z, y;
    cout << "Input z,y: ";
    cin >> z >>y;
    z = abs(z);
    y = abs(y);
    if (cin.fail() || cin.peek() != '\n')
    {
        cout << "Bad input, bb";
        return -1;
    }
    cout << pow(z, y) << pow(y, z);
    float x = -1 * pow(z, y) + pow(y, z);
    cout << x;
}
