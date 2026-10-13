#include <iostream>
#include <functional>
using namespace std;
int main()
{
	function<void()> b = {};
	{
		string a = "lenya";
		b = [&] {cout << a;};
		a = "girl";
	}
	string q = "swaga";
	cout << q<<endl;
	b();

}

