#include <iostream>
#include <string>
using namespace std;
int main()
{
    string s, s0;
    cout << "Input s: ";
    getline(cin, s);
    cout << "Input s0: ";
    getline(cin, s0);

    if (s0.length() > s.length()) {
        return 0;
    }
    int ans = 0;
    for (int i = 0; i < s.length() - s0.length()+1; i++) {
        if (s[i] == s0[0]) {
            bool sub = true;
            for (int j = 0, k = i; j < s0.length(); j++) {
                if (s0[j] != s[k++]) {
                    sub = false;
                    break;
                }
            }
            if (sub) ans++;
        }
    }
    cout<< ans;
}

