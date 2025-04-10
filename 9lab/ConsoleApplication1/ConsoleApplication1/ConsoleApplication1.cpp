#include <iostream>

using namespace std;
int SumRange(int a, int b) {
    if (a > b) return 0;
    int s = 0;
    for (int i = a; i < b + 1; i++) {
        s += i;
    }
    return s;
}
int main()
{
    int a, b, c;
    cout << "Input a, b ,c ";
    cin >> a >> b >> c;
    if (cin.fail() || cin.peek() != '\n')
    {
        cout << "Bad input, poka";
        return -1;
    }
    cout << "Sum from a to b " << SumRange(a, b) << "\n"
        << "Sum from b to c " << SumRange(b, c);
    
}

