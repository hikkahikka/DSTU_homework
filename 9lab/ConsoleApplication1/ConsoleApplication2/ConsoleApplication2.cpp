#include <iostream>
using namespace std;
void SortInc3(float* a, float* b, float* c) {
    float buf;
    if (*a > *b) {
        buf = *a;
        *a = *b;
        *b = buf;
    }
    if (*a > *c) {
        buf = *a;
        *a = *c;
        *c = buf;
    }
    if (*b > *c) {
        buf = *b;
        *b = *c;
        *c = buf;
    }
}
int main()
{
    float a, b, c;
    cout << "Input a, b ,c: "<<"\n";
    cin >> a >> b >> c;
    if (cin.fail() || cin.peek() != '\n')
    {
        cout << "Bad input, poka";
        return -1;
    }
    
    float* ap = &a;
    float* bp= &b;
    float* cp = &c;
    cout << *ap << " " << *bp << " " <<*cp<<"\n";
    SortInc3(ap, bp, cp);
    cout << *ap <<" " << *bp << " " << *cp<<"\n";

    cout << "Input a1, b1 ,c1 " << "\n";
    cin >> a >> b >> c;
    if (cin.fail() || cin.peek() != '\n')
    {
        cout << "Bad input, poka";
        return -1;
    }

    ap = &a;
    bp = &b;
    cp = &c;
    cout << *ap << " " << *bp << " " << *cp << "\n";
    SortInc3(ap, bp, cp);
    cout << *ap << " " << *bp << " " << *cp;
}

