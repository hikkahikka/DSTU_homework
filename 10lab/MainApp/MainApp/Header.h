#pragma once
#include <iostream>
#include <string>
#include <ctime>
#include<vector>
using namespace std;
struct Train
{
	std::string name;
	int number;
	struct tm time;

};
int main();
int CheckInput(int value, int param1, int param2);
bool CheckLeapYear(int y);
int CheckMonth(int y, int m, int d);
Train AddTrain();
vector<Train> InputTrainToVector(int n);
void SortTrainByNumber(vector<Train> trains);
void GetInfoAboutTrain(int n, vector<Train> trains);

