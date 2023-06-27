#include <iostream>
#include <ctime>
#include <cstdlib>
#include <string> 

using namespace std;
int rand_people();
int main() {
	srand(time(NULL));
	int i, j, p, P=0, n;
	float max, min;
	string bestmonth;
	string worstmonth;
	string months[12] = { "January","February","March ","April ","May   ","June  ","July  ","August","September","October","November","December" };
	max = -std::numeric_limits<float>::infinity();
	min = std::numeric_limits<float>::infinity();
	for (i = 0; i < 12; i++) {
		cout << "  " << months[i];
		for (j = 0; j < 5; j++) {
			p = rand_people();
			cout << "\t Area N" << j+1 << " - " << p;
			P += p;
			if (p < min) {
				min = p;
				n = j + 1;
				worstmonth = months[i];
			}
		}
		cout << endl;
		if (P > max) {
			max = P;
			bestmonth = months[i];
		}
		P = 0;

	}
	cout << "\n\nBest month " << bestmonth << " attendance - " << max << endl;
	cout << "The worst month " << worstmonth << " Area N" << n << " worst attendance - " << min << endl;
	system("pause");
	return 0;
}

int rand_people() {
	return rand() % (2000 - 500 + 1) + 500;
};