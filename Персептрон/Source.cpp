#include <iostream>
#include <cmath>
using namespace std;

struct bykva {
	int kod[16];
	int A[2];
	int X[2];
	int signal;
};

void Perceptron(bykva& K, bykva& R);
void ElementsA(bykva& B);
int Signal(bykva& B, int w[]);
int Iteration(bykva& B, int w[]);

int main() {
	//bykva K{ { 1, 0, 1, 1, 1, 1, 1, 0, 1 } ,{ }, { }, -1 };
	//bykva R{ { 1, 1, 1, 1, 0, 1, 1, 0, 1 } ,{ },{ }, 1};
	bykva K{ { 1, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1 } ,{},{}, -1 };
	bykva R{ { 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0 } ,{},{}, 1 };
	Perceptron(K, R);
	system("pause");
	return 0;
}

void Perceptron(bykva& K, bykva& R) {
	int w[] = { 0, 0 };
	int sign1 = 0, sign2 = 0, i = 1;
	ElementsA(K);
	ElementsA(R);

	while (sign1 != K.signal || sign2 != R.signal) {
		cout << "\n\t\t Iteration N" << i << endl;
		cout << " Starting WEIGHTS: " << w[0] << " " << w[1] << endl;
		sign1 = Signal(K, w);
		sign2 = Signal(R, w);
		i++;
	}
	cout << "\n Learning to recognize the letters K and P is completed! " << endl;
}
int Signal(bykva& B, int w[]) {
	int R, Or = 0, i;
	R = Iteration(B, w);
	if (R > Or) R = 1;
	else R = -1;
	if (R < B.signal)
	{
		for (i = 0; i < 2; i++) if (B.X[i] > 0) w[i] = w[i] + 1;
	}
	else if (R > B.signal)
	{
		for (i = 0; i < 2; i++) if (B.X[i] > 0) w[i] = w[i] - 1;
	}
	cout << endl << " Reaction of neuron: " << R << " Need reaction: " << B.signal << endl;
	if (R != B.signal) cout << " WEIGHTS have changed: " << w[0] << " " << w[1] << endl;
	else cout << " WEIGHTS have not changed: " << w[0] << " " << w[1] << endl;
	return R;
}

int Iteration(bykva& B, int w[]) {
	int Oa = 0, S = 0, i;
	for (i = 0; i<2; i++)
	{
		if (B.A[i] > Oa) B.X[i] = 1;
		else B.X[i] = 0;
		S += w[i] * B.X[i];
	}
	return S;
}

void ElementsA(bykva& B) {
	int ves1[] = { -1, 1, 1, -1, -1, -1, 1, 1, 1, 1, 1, 1, 1, 0, 1, -1 };
	int ves2[] = { 1, 1, 1, 1, 0, 1, -1, 1, -1, 1, 1, 1, 1, 0, 1, -1 };
	int A1 = 0, A2 = 0, i;
	for (i = 0; i < sizeof(B.kod) / sizeof(B.kod[0]); i++)
	{
		A1 += B.kod[i] * ves1[i];
		A2 += B.kod[i] * ves2[i];
	}
	B.A[0] = A1;
	B.A[1] = A2;
}