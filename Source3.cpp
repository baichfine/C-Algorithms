#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;
struct   triangle {
	int   x1, y1, x2, p, s;  //   координаты
};

int rand_X_Y(); //генерац€ точки на оси абсцисс
void triag(triangle *&structs, int n, int &a, int &b);
void res(triangle *&structs, int n);
float per(int x1, int y1, int x2, int x3, int y3);
float plosh(int x1, int y1, int x2, int y3);

int main() {
	int n, a, b;
	setlocale(LC_ALL, "rus");
	srand(time(NULL));
	cout << " Enter number of triangles :"; cin >> n;
	triangle *structs = new triangle[n];
	triag(structs, n, a, b);
	res(structs, n);
	system("pause");
	return 0;
}

void triag(triangle *&structs, int n, int &a, int &b) {
	int i, x1, y1, x2, x3, y3;
	a = 8;
	b = 9;
	for (i = 0; i < n; i++) {
		x1 = rand_X_Y();
		y1 = rand_X_Y();
		x2 = rand_X_Y();
		x3 = abs((float(x2 - x1)/2));
		y3 = rand_X_Y();
		triangle s1 = { x1, y1, x2, per(x1, y1, x2, x3, y3), plosh( x1,  y1,  x2,  y3) };
		structs[i] = s1;
	}
};

float per(int x1, int y1, int x2, int x3, int y3) {
	float s1, s2, p, S;
	s1 = abs(x2-x1);
	s2 = abs(sqrt((x3 - x1)*(x3 - x1) + (y3 - y1)*(y3 - y1)));
	return p = s1 + s2 + s2;
};
float plosh(int x1, int y1, int x2, int y3) {
	float s1, S;
	s1 = abs(x2 - x1);
	return S = 0.5* s1 * abs(y3 - y1);
};

void res(triangle *&structs, int n) {
	int i;
	float P=0, S=0;
	for (i = 0; i < n; i++) {
		cout << "“реугольник N" << i+1 << endl;
		cout << "ѕериметр " << structs[i].p << endl;
		cout << "ѕлощадь " << structs[i].s << endl;
		P += structs[i].p;
		S += structs[i].s;
	}
	P = P / n;
	S = S / n;
	cout << endl << " —реднее значение суммы периметров " << P << endl;
	cout << endl << " —реднее значение суммы площадей " << S << endl;
};
int rand_X_Y() {
	return rand() % (20 - (-20) + 1) + (-20);
};
