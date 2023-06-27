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
	cout << " Введите значение силы тока I: "; cin >> I;
	cout << " Введите значение напряжения в цепи U: "; cin >> U;
	cout << " Введите максимально возможное значение сопротивления: "; cin >> Rmax;
	cout << " Введите минимально возможное значение сопротивления: "; cin >> Rmin;
	for (i = 0; i < 10; i++) {
		array[i] = rand() % (Rmax - Rmin + 1) + Rmin;
		cout << "Сопротивление № " << i + 1 << " равно " << array[i] << endl;
		S += array[i];
		Prod *= array[i];
	}
	cout << endl << endl;
	do {
		S -= array[k];
		Prod /= array[k];
		R = Prod / S;
		if (k == 8 && I >= U / R) {
			cout << " Удалено 9 сопротивлений из 10, значение силы тока " << U / R << " не превышает заданного " << I << endl;
			goto reload;
		}
		if (I >= U / R)
			cout << "Удаление " << k + 1 << "-го сопротивления, значение силы тока " << U / R << " не превышает заданного " << I << endl;


		if (array[k] > max)
			max = array[k];
		k++;
	} while (I >= U / R);

	cout << "Ошибка, Удаление " << k << "-го сопротивления, значение силы тока " << U / R << " превышает заданного " << I << endl;
reload:
	if (k == 8 && I >= U / R)
		k = k + 1;
	else
		k = k - 1;
	cout << endl << " Последовательно можно удалить из цепи " << k << " сопротивлений! " << endl;
	cout << "Максимальное значение удаленного из цепи сопротивления равно: " << max << endl;

	system("pause");
	return 0;
}