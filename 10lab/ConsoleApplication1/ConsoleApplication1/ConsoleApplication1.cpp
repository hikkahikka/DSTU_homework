#include "Header.h"
int main()
{
    string word, ch;
    int c = 0;
    cout << "Input find word: " << endl;
    cin >> ch;
    ifstream file("text.txt");
    
    if (!file.is_open()) {
        cerr << "No file in directory!" << endl;
        return -1;
    }
    while (file >> word) {
        if (word == ch)c++;
    }
    file.close();
    cout << "Number of words: " << c;
}
