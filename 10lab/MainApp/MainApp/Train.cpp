#include "Header.h"
Train AddTrain() {
	Train train;
    cin.ignore();
	cout << "Enter train's name: "<< endl;
	getline(cin, train.name);

    cout << "Enter train's number: " << endl;
    int number;
    do {
        cin >> number;
    } while (CheckInput(number, 0, INT32_MAX) != 1);
    train.number = number;

    cout << "Enter data"<<endl<<"Enter years (must be from 1900 to 2050): "<<endl;
    int data;
    do {
        cin >> data;
    } while (CheckInput(data, 1900, 2050) != 1);
    train.time.tm_year = data-1900;

    cout << "Enter month: " << endl;
    do {
        cin >> data;
    } while (CheckInput(data,1, 12) != 1);
    train.time.tm_mon = data-1;

    cout << "Enter day: " << endl;
    do {
        cin >> data;
    } while (CheckInput(data,1, 31) != 1 || CheckMonth(train.time.tm_year, train.time.tm_mon+1, data)!=1);
    train.time.tm_mday = data;

    cout<<"Enter hour:" << endl;
    do {
        cin >> data;
    } while (CheckInput(data,0,  23) != 1);
    train.time.tm_hour = data;

    cout << "Enter minute:" << endl;
    do {
        cin >> data;
    } while (CheckInput(data, 0, 59) != 1);
    train.time.tm_min = data;    

    return train;
}
vector<Train> InputTrainToVector(int n) {
    vector<Train> trains;
    Train train;
    for (int i = 0; i < n; ++i) {
        train = AddTrain();
        trains.push_back(train);
    }
    SortTrainByNumber(trains);
    return trains;
}
void SortTrainByNumber(vector<Train> trains) {
    int n = trains.size();
    bool flag;
    for (int i = 0; i < n - 1; ++i) {
        flag = false;
        for (int j = 0; j < n - i - 1; ++j) {
            if (trains[j].number > trains[j + 1].number) {
                swap(trains[j], trains[j + 1]);
                flag = true;
            }
        }
        if (!flag) break;
    }
}
void GetInfoAboutTrain(int n, vector<Train> trains) {
    bool fl = false;
    for (int i = 0; i < trains.size(); i++) {
        if (trains[i].number == n) {
            fl = true;
            cout << trains[i].name << endl;
            cout << trains[i].number << endl;
            cout << trains[i].time.tm_year+1900 <<"." << trains[i].time.tm_mon+1 << "." << trains[i].time.tm_mday << "\t" << trains[i].time.tm_hour << ":" << trains[i].time.tm_min << endl << endl;
        }
    }
    if (!fl) {
        cout << "No train with this number"<<endl;
    }
}

