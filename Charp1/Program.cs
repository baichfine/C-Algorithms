using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp1
{
    class Program
    {
        //Методы
        public static int Vvod()
        {
            Console.Write(" Enter number of array elements: "); //Ввод с консоли количества элементов массива
            int n = Convert.ToInt32(Console.ReadLine());
            return n;
        }

        public static double[] Range(int n, double[] a, ref int c)
        {
            Console.WriteLine(" Enter range [ A : B ] ");
            Console.Write(" A: "); double A = Convert.ToDouble(Console.ReadLine()); //Ввод с консоли диапазона вещественных чисел 
            Console.Write(" B: "); double B = Convert.ToDouble(Console.ReadLine());
            if (A > B)
            {
                Console.Write(" Wrong Range: [ A : B ] ");
                Range(n, a, ref c);
            }
            double[] array = new double[n];
            for (int i=0, j=0; i< n; i++)
            {
                if (a[i] >= A && a[i] <= B)
                {
                    array[j] = a[i];
                    c++;
                    j++;
                }
            }
            return array; //Возврат вещественного массива элементов, которые попали в заданный диапазон
        }

        public static double Sum(int n, double[] a, ref double max) //Сумма элементов, находящихся после максимального
        {
            max = a[0];
            int c=0;
            double S = 0;
            for (int i = 0; i < n; i++)
            {
                if (max < a[i])
                {
                    max = a[i];
                    c = i;
                }
            }
            for (int i = c+1; i < n; i++)
            {
                S+= a[i];
               
            }
            return S;
        }
        public static double[] Array(int n) //Инициализация массива и заполнение его случайными вещественными числами
        {
            Random rnd = new Random(); 
            double[] array = new double[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = Convert.ToDouble(rnd.Next(1000) / 1000.0);
            }
            return array;
        }
       
        public static void PrintArray(int n, double[] a) //Вывод массива на консоль
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + "  ");
            }
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            int n, c = 0;
            double max=0;
            n = Vvod();
            double[] a = Array(n);
            double[] b = Range(n, a, ref c);
            Console.Write("\t" + c + " elements are int the range [ A : B ] ");
            PrintArray(c, b);
            Console.WriteLine("\n\n" + Sum(n, a, ref max) + " sum of the elements after max element " + max);
            PrintArray(n, a);
            Console.ReadLine();
        }
    }
}


