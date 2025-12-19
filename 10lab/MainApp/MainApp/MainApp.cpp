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
    cout << "Write start point" << endl;
    cout << "Write end point" << endl;

    /*cout << "Write number to get info about train" << endl;
    cout << "If you want to exit input \"-1\"" << endl;
    int ch;
    while (1) {
        cout << "Input number of train: " << endl;
        cin >> ch;
        if (ch == -1) break;
        GetInfoAboutTrain(ch, trains);
    }
    cout << "Do you want to save info in file? (0-no, 1-yes)" << endl;
    cin >> ch;
    if (ch == 1) {
        WriteToFile(trains, "info.txt");
    }*/

   

}
