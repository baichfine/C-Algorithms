using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charp4
{
    class Arrays
    {
        static int X = 0, Y = 0, max = 0;
        static string Str = " ";
        static double m = 0;
        static int rows, columns;

        //Методы Инициализации массивов
        //Одномерные массивы
        public static int[] Array()
        {
            int n = Vvod();
            Console.WriteLine(" Enter number of array Range: [ M, N ] ");
            Console.Write(" M: "); int M = Convert.ToInt32(Console.ReadLine());
            Console.Write(" N: "); int N = Convert.ToInt32(Console.ReadLine());
            if ( M > N)
            {
                Console.Write(" Wrong Range: [ M, N ] ");
                Array();
            }
            Random rnd = new Random();
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(M, N);
            }
            return array;
        }

        public static double[] Array(double m)
        {
            int n = Vvod();
            Random rnd = new Random();
            double[] array = new double[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = Convert.ToDouble(rnd.Next(1000) / 1000.0);
            }
            return array;
        }

        public static string[] Array(string a)
        {
            int n = Vvod();
            Random rnd = new Random();
            string[] array = new string[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = Console.ReadLine();
            }
            return array;
        }

        //Двумерные массивы
        public static void Array(int[,] array)
        {
            Console.WriteLine(" Enter number of array Range: [ M, N ] ");
            Console.Write(" M: "); int M = Convert.ToInt32(Console.ReadLine());
            Console.Write(" N: "); int N = Convert.ToInt32(Console.ReadLine());
            if (M > N)
            {
                Console.Write(" Wrong Range: [ M, N ] ");
                Array();
            }
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j= 0; j< array.GetLength(1); j++)
                {
                    array[i,j] = rnd.Next(M, N);
                }
            }

        }

        public static void Array(double [,] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i,j] = Convert.ToDouble(rnd.Next(1000) / 1000.0);
                }
            }
        }


        public static void Array(string [,] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i,j] = Console.ReadLine();
                }
            }
        }


        //Методы суммы элементов массивов
        //Одномерные массивы
        public static int Sum(int[] array)
        {
            int S = 0;
            for(int i=0; i< array.Length; i++)
               S+= array[i];
            return S;
        }
        public static double Sum(double[] array)
        {
            double S = 0;
            for (int i = 0; i < array.Length; i++)
                S += array[i];
            return S;
        }
        //Двумерные массивы
        public static int Sum(int[,] array)
        {
            int S = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    S += array[i, j];
                }
            }
            return S;
        }

        public static double Sum(double[,] array)
        {
            double S = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    S += array[i, j];
                }
            }
            return S;
        }


        //Методы произведения элементов массивов
        //Одномерные массивы
        public static int Prod(int[] array)
        {
            int P = 1;
            for (int i = 0; i < array.Length; i++)
                P *= array[i];
            return P;
        }

        public static double Prod(double[] array)
        {
            double P = 1;
            for (int i = 0; i < array.Length; i++)
                P *= array[i];
            return P;
        }



        //Двумерные массивы
        public static int Prod(int[,] array)
        {
            int P = 1;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    P *= array[i, j];
                }
            }
            return P;
        }
        public static double Prod(double[,] array)
        {
            double P = 1;
             for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                   P *= array[i, j];
                }
            }
            return P;
        }



        //Методы нахождения максимального элемента/строки
        //Одномерные массивы
        public static int Max(int[] array, ref int X)
        {
            int max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                    X = i+1;
                }
            }               
            return max;
        }

        public static double Max(double[] array, ref int X)
        {
            double max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                    X = i+1;
                }
            }
            return max;
        }

        public static string Max(string[] array, ref int X, ref int max)
        {
            string str = array[0];
            max = str.Length;
            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i].Length)
                {
                    max = array[i].Length;
                    str = array[i];
                    X = i+1;
                }
            }
            return str;
        }




        //Двумерные массивы
        public static int Max(int[,] array, ref int X, ref int Y)
        {
            int max = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (max < array[i, j])
                    {
                        max = array[i, j];
                        X = i+1;
                        Y = j+1;
                    }
                }
            }
            return max;
        }

        public static double Max(double[,] array, ref int X, ref int Y)
        {
            double max = array[0,0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (max < array[i, j])
                    {
                        max = array[i, j];
                        X = i+1;
                        Y = j+1;
                    }
                }
            }
            return max;
        }

        public static string Max(string[,] array, ref int X, ref int Y, ref int max)
        {
            string str = array[0,0];
            max = str.Length;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (max < array[i,j].Length)
                    {
                        max = array[i,j].Length;
                        str = array[i,j];
                        X = i;
                        Y = j;
                    }
                }
            }
            return str;
        }




        //Методы выведения массивов на консоль
        //Одномерные массивы
        public static void PrintArr(int[] array)
        {
            Console.Write("\tOne-dimensional integer array: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
            }
            Console.WriteLine("\n\n");
        }

        public static void PrintArr(double[] array)
        {
            Console.Write("\tOne-dimensional real array: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
            }
            Console.WriteLine("\n\n");
        }

        public static void PrintArr(string[] array)
        {
            Console.Write("\tOne-dimensional string array: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
            }
            Console.WriteLine("\n\n");
        }




        //Двумерные массивы
        public static void PrintArr(int[,] array)
        {
            Console.WriteLine("\tTwo-dimensional integer array: ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write("\t\t");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i,j] + "  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n");
        }

        public static void PrintArr(double[,] array)
        {
            Console.WriteLine("\tTwo-dimensional real array: ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write("\t\t");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n");
        }

        public static void PrintArr(string[,] array)
        {
            Console.WriteLine("\tTwo-dimensional string array: ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write("\t\t");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n");
        }




        //Методы выполнения всех функций к определенному типу массива
        //Одномерные массивы
        public static void Start(int[] a, ref int X)
        {
            int summa = Sum(a);
            Console.WriteLine(" Sum of elements One-dimensional integer array " + summa);
            int prod = Prod(a);
            Console.WriteLine(" Production of elements One-dimensional integer array " + prod);
            int max = Max(a, ref X);
            Console.WriteLine(" Max of elements One-dimensional integer array " + max + " and his number " + X + "\n");
            PrintArr(a);
            X = 0;
            Console.ReadLine();
            Console.Clear();
            StartProgramm(ref rows, ref columns);
        }

        public static void Start(double[] a, ref int X)
        {
            double summa = Sum(a);
            Console.WriteLine(" Sum of elements One-dimensional real array " + summa);
            double prod = Prod(a);
            Console.WriteLine(" Production of elements One-dimensional real array " + prod);
            double max = Max(a, ref X);
            Console.WriteLine(" Max of elements One-dimensional real array " + max + " and his number " + X + "\n");
            PrintArr(a);
            X = 0;
            Console.ReadLine();
            Console.Clear();
            StartProgramm(ref rows, ref columns);
        }

        public static void Start(string[] a, ref int X, ref int max)
        {
            string maxi = Max(a, ref X, ref max);
            Console.WriteLine(" Max maxgth string One-dimensional string array " + maxi + " and her length " + max + " and his number " + X + "\n");
            PrintArr(a);
            X = 0;
            Console.ReadLine();
            Console.Clear();
            StartProgramm(ref rows, ref columns);
        }




        //Двумерныее массивы
        public static void Start(int[,] a, ref int X, ref int Y)
        {
            int summa = Sum(a);
            Console.WriteLine(" Sum of elements Two-dimensional integer array " + summa);
            int prod = Prod(a);
            Console.WriteLine(" Production of elements Two-dimensional integer array " + prod);
            int max = Max(a, ref X,ref Y);
            Console.WriteLine(" Max of elements Two-dimensional integer array " + max + " and his coordinates [ " + X + " : " + Y + " ] \n");
            PrintArr(a);
            X = 0;
            Y = 0;
            Console.ReadLine();
            Console.Clear();
            StartProgramm(ref rows, ref columns);
        }

        public static void Start(double[,] a, ref int X, ref int Y)
        {
            double summa = Sum(a);
            Console.WriteLine(" Sum of elements Two-dimensional integer array " + summa);
            double prod = Prod(a);
            Console.WriteLine(" Production of elements Two-dimensional integer array " + prod);
            double max = Max(a, ref X, ref Y);
            Console.WriteLine(" Max of elements Two-dimensional integer array " + max + " and his coordinates [ " + X + " : " + Y + " ] \n");
            PrintArr(a);
            X = 0;
            Y = 0;
            Console.ReadLine();
            Console.Clear();
            StartProgramm(ref rows, ref columns);
        }

        public static void Start(string[,] a, ref int X, ref int Y, ref int max)
        {
            string maxi = Max(a, ref X, ref Y, ref max);
            Console.WriteLine(" Max of elements Two-dimensional string array " + maxi + " and her length " + max + "  and her coordinates[" + X + " : " + Y + "] \n");
            PrintArr(a);
            X = 0;
            Y = 0;
            Console.ReadLine();
            Console.Clear();
            StartProgramm(ref rows, ref columns);
        }



        //Метод ввода количества элементов
        static int Vvod()
        {
            Console.WriteLine(" Enter number of array elements: ");
            Console.Write(" Number: "); int n = Convert.ToInt32(Console.ReadLine());
            return n;
        }


        //Метод ввода столбцов и строк двумерного массива
        static void VvodRange(ref int rows, ref int columns)
        {
            Console.WriteLine(" Enter number of rows and columns: ");
            Console.Write(" Rows: "); rows = Convert.ToInt32(Console.ReadLine());
            Console.Write(" Columns: "); columns = Convert.ToInt32(Console.ReadLine());
        }



        //Метод запуска программы с выбором необходимого массива
        public static void StartProgramm(ref int rows, ref int columns)
        {
            Console.WriteLine(" 1. One-dimensional integer array \t 4. Two-dimensional integer array");
            Console.WriteLine(" 2. One-dimensional real array    \t 5. Two-dimensional real array");
            Console.WriteLine(" 3. One-dimensional string array  \t 6. Two-dimensional string array");
            Console.WriteLine(" 7. Exit \n");

            Console.WriteLine(" Select array and enter number ");
            Console.Write(" Number: "); int YourChoice = Convert.ToInt32(Console.ReadLine());
            switch (YourChoice)
            {
                case 1:
                    int[] a = Array();
                    Start(a, ref X);
                    break;
                case 2:
                    double[] b = Array(m);
                    Start(b, ref X);
                    break;
                case 3:
                    string[] c = Array(Str);
                    Start(c, ref X, ref max);
                    break;
                case 4:
                    VvodRange(ref rows, ref columns);
                    int[,] A = new int[rows, columns];
                    Array(A);
                    Start(A, ref X, ref Y);
                    break;
                case 5:
                    VvodRange(ref rows, ref columns);
                    double[,] B = new double[rows, columns];
                    Array(B);
                    Start(B, ref X, ref Y);
                    break;
                case 6:
                    VvodRange(ref rows, ref columns);
                    string[,] C = new string[rows, columns];
                    Array(C);

                    Start(C, ref X, ref Y, ref max);
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(" Wrong number");
                    StartProgramm(ref rows, ref columns);
                    break;
            }
        }
        static void Main(string[] args)
        {
           StartProgramm(ref rows, ref columns);
            Console.ReadLine();
        }
    }
}
