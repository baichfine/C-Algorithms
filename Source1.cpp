#include <iostream>
#include <cmath>
#include <cstdlib>
#include <ctime>

using namespace std;
double signal(double t);
double midle(int i, int n, double l);

int main() {
	srand(time(NULL));
	int n, j=0, i;
	double t, Ut, l, s=0, S;
	n = 1,5 / 0.2 + 1;
	cout << " Enter real coefficient l (0 ; 1)"; cin >> l;
	if (l >= 1 || l <= 0) {
		cout << " Error, wrong enter! " << endl;
		system("pause");
		exit(1);
	}
	for (t = 0, i = 0; t < 1.5; t += 0.2, i++) {
		Ut =signal(t);
		s += Ut*midle(i, n, l);
		cout << "\tTime " << "   " << "\tSignal" << endl;
		cout << "\t"<< t << "   " << "\t\t" << Ut << endl;
	}
	i = 0;
	S = (1 - l) / (1 - midle(i, n, l))* s;
	cout << " Exponentially weighted average = " << S << endl;

	system("pause");
	return 0;
}

double signal(double t) {
	double k = 4.1E-2, w=1.3E+2, f=5.5E-2, U;
	int r;
	r = rand() % (2 - 0 + 1) + 0;
	U = (sin(w*t + f) / exp(k*t));
	if (r == 1) {
		return U+U*0.05;
	}
	else if (r == 2) {
		return U - U*0.05;
	}
	else return U;


};

double midle(int i, int n, double l) {
	for (int p = 1; p < (n - i); p++) {
		l *= l;}
	return l;

};