#include <iostream>
#include <cmath>
using namespace std;

struct bykva {
	int X[16];
	int Y;
};
void ves(bykva K, int w[], int n);
int ostanov(bykva K, int w[], int n);

int main() {
	//bykva K{ { 1, 01, 1, 1, 1, 1, 0, 0, 1 } , 1 };
	//bykva R{ { 1, 1, 1, 1, 0, 1, 1, 0, 1 } , 0 };
	bykva K{ { 1, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1 } , 1 };
	bykva R{ { 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0 } , 0 };
	int w[] = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
	int n = 16, S1, S2, y1 = 0, y2 = 0;
	while (y1 == 0 || y2 == -1) {
		ves(K, w, n);
		ves(R, w, n);
		S1 = ostanov(K, w, n);
		S2 = ostanov(R, w, n);
		if (S1 > 0) { y1 = 1; cout << " Bykva K : " << S1 << endl; }
		if (S2 < 0) { y2 = 0; cout << " Bykva R : " << S2 << endl; }
	}
	system("pause");
	return 0;
}

void ves(bykva B, int w[], int n) {
	int i, x0=1, dw;
	
	if ((x0 * B.Y) == 1) dw = 1;
	else if (x0 != 0 && B.Y == 0) dw = -1;
	else dw = 0;
	w[0] = w[0] + dw;
	cout << w[0] << " ";
	for (i = 1; i <= n; i++) {
		
		if ((B.X[i - 1] * B.Y) == 1) dw = 1;
		else if (B.X[i - 1] != 0 && B.Y == 0) dw = -1;
		else  dw = 0;
		w[i] = w[i] + dw;
		cout << w[i] << " ";
	}
	cout << endl;
}

int ostanov(bykva B, int w[], int n) {
	int S = 0;
	for (int i = 1; i < n; i++) {

		S += B.X[i - 1] * w[i];
	}
	S = S + w[0];
	return S;

};
