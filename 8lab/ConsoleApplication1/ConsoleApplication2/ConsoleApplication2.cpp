#include <iostream>
#include <string>

using namespace std;
int main()
{
    string text, text_new, l;
    cout << "Input text: ";
    getline(cin, text);

    cout << "Input letter: ";
    getline(cin, l);

    if (l.length() != 1)return 0;
    char let = l[0];
    for (int i = 0; i < text.length(); i++) {
        if (text[i] != let) {
            text_new+= text[i];
        }
    }
    cout << text_new;
    
}
