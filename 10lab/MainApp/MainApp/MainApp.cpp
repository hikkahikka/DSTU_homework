#include "Header.h"
int main()
{
    cout << "Hello!!! Input how many trains you want to write: ";
    int n;
    vector<Train> trains;
    do {
        cin >> n;
    } while (CheckInput(n, 0, 10) != 1);
    trains = InputTrainToVector(n);
    cout << "If you want to exit input \"-1\"" << endl;
    int ch;
    while (1) {
        cout << "Input number of train: " << endl;
        cin >> ch;
        if (ch == -1) break;
        GetInfoAboutTrain(ch, trains);
    }
    cout << "GoodBye" << endl;

}
