#include <iostream>
using namespace std;
int main()
{
	const float R = 8.31E+3, N = 6.002E+23;
	float n, p, T;

	cout << "p="; cin >> p;
	cout << "T="; cin >> T;
	n = (p*N) / (R*T*(1E+3));
	cout << "n=" << n << endl;
	system("pause");
	return 0;
}