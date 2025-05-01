#include "Header.h"
int CheckInput(int value, int param1, int param2) {
    if (cin.fail() || cin.peek() != '\n' || value <param1 || value > param2) {
        cout << "Input error!!!"<<endl;
        cin.clear();
        cin.ignore(32767, '\n');
        return -1;
    }
    return 1;
}
bool CheckLeapYear(int y) {
    if ((y % 4 == 0 && y % 100 != 0) || (y % 400 == 0)) return true;
    return false;
}
int CheckMonth(int y, int m, int d) {
    int res=0;
    switch (m) {
    case 1:if (d > 31) res = -1;break;
    case 2:
        if (CheckLeapYear(y)) {
            if (d > 29) res = -1;
        }
        else {
            if (d > 28) res = -1;
        }
        break;
    case 3:if (d > 31) res = -1;break;
    case 4:if (d > 30) res = -1;break;
    case 5:if (d > 31) res = -1;break;
    case 6:if (d > 30) res = -1;break;
    case 7:if (d > 31) res = -1;break;
    case 8:if (d > 31) res = -1;break;
    case 9:if (d > 30) res = -1;break;
    case 10: if (d > 31) res = -1;break;
    case 11:if (d > 30) res = -1;break;
    case 12:if (d > 31) res = -1;break;
    }
    if (res == -1) {
        cout << "Incorrect number of days in a month!!!"<<endl;
        return -1;
    }
    return 1;
}