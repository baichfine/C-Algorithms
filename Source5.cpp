#include <iostream> 
#include <ctime>
using namespace std;
int main()
{
	setlocale(LC_ALL, "rus");
	srand(time(NULL));

	int *array = new int[10], I, i, Rmax, Rmin, max, k = 0;
	float U, S = 0, Prod = 1, R;
	max = -std::numeric_limits<int>::infinity();
	cout << " ������� �������� ���� ���� I: "; cin >> I;
	cout << " ������� �������� ���������� � ���� U: "; cin >> U;
	cout << " ������� ����������� ��������� �������� �������������: "; cin >> Rmax;
	cout << " ������� ���������� ��������� �������� �������������: "; cin >> Rmin;
	for (i = 0; i < 10; i++) {
		array[i] = rand() % (Rmax - Rmin + 1) + Rmin;
		cout << "������������� � " << i + 1 << " ����� " << array[i] << endl;
		S += array[i];
		Prod *= array[i];
	}
	cout << endl << endl;
	do {
		S -= array[k];
		Prod /= array[k];
		R = Prod / S;
		if (k == 8 && I >= U / R) {
			cout << " ������� 9 ������������� �� 10, �������� ���� ���� " << U / R << " �� ��������� ��������� " << I << endl;
			goto reload;
		}
		if (I >= U / R)
			cout << "�������� " << k + 1 << "-�� �������������, �������� ���� ���� " << U / R << " �� ��������� ��������� " << I << endl;


		if (array[k] > max)
			max = array[k];
		k++;
	} while (I >= U / R);

	cout << "������, �������� " << k << "-�� �������������, �������� ���� ���� " << U / R << " ��������� ��������� " << I << endl;
reload:
	if (k == 8 && I >= U / R)
		k = k + 1;
	else
		k = k - 1;
	cout << endl << " ��������������� ����� ������� �� ���� " << k << " �������������! " << endl;
	cout << "������������ �������� ���������� �� ���� ������������� �����: " << max << endl;

	system("pause");
	return 0;
}