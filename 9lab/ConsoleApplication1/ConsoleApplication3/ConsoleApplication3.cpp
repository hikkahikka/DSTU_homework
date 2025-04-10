#include <iostream>
#include <ctime>
using namespace std;

int Combin2(int n, int k, int** mass) {
    if (k == 0 || k == n ) {
        return 1;
    }
    //cout << n << ' ' << k << endl;
    int b = Combin2(n - 1, k, mass) + Combin2(n - 1, k - 1, mass);
    if (mass[n][k] == 0) {
        mass[n][k]=b;
    }
    return b;
}
int main()
{
    srand(time(0));
    int n, k;
    cout << "Input n: " << "\n";
    cin >> n;
    if (cin.fail() || cin.peek() != '\n' || n>20||n<0)
    {
        cout << "Bad input, poka";
        return -1;
    }
    int** mass = new int*[20];
    for (int i = 0; i < 20; i++) {
        mass[i] = new int[20];
        for (int j = 0; j < 20; j++) {
            mass[i][j] = 0;
        }
    }
    for (int i = 0; i < 5; i++) {
        k = rand()%(n+1);
        cout <<"n " << n<< " k " << k << endl;
        cout<<Combin2(n, k, mass)<<endl;
    }
    for (int i = 0; i < 20; i++)
    {
        delete[] mass[i];
    }
    delete[] mass;

    
}
