#pragma once
#include <iostream>
#include <string>
#include <ctime>
#include<vector>
#include <iostream>
#include <fstream>
using namespace std;
struct Train
{
	std::string name;
	int number;
	struct tm time;
	string start;
	string end;

};


struct Route {
	vector<Train> trains;    // Список поездов в маршруте
	string currentCity;      // Текущий город (куда приехали)
};
int main();
int CheckInput(int value, int param1, int param2);
bool CheckLeapYear(int y);
int CheckMonth(int y, int m, int d);
Train AddTrain();
vector<Train> InputTrainToVector(int n);
void SortTrainByNumber(vector<Train> trains);
void GetInfoAboutTrain(int n, vector<Train> trains);
void WriteToFile(vector <Train> trains, string path);
