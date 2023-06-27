using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сверточные_сети
{
    class Program
    {
        int[,] Karta;
        int[,] A;
        static Program[] carts1;
        public Program(int[,] Karta, int[,] A)
        {
            this.Karta = Karta;
            this.A = A;
        }
        public static void PrintMat(int[,]arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write("  ");
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }
        public static void Yadro(int[,] matrix, Program carts, int strading, int sizeYadro, int type)
        {
            int k1 = 0, k2 = 0;
            int n1, n2;
            if (sizeYadro == 0)
            {
                n1 = carts.A.GetLength(0);
                n2 = carts.A.GetLength(0);
            }
            else
            {
                n1 = sizeYadro;
                n2 = sizeYadro;
            }

            for (int i = 0; i < carts.Karta.GetLength(0); i++)
            {
                for(int j=0; j< carts.Karta.GetLength(1); j++)
                {
                    carts.Karta[i, j] = Matrix(matrix, carts, k1, n1, k2, n2, sizeYadro, type, strading, i, j);
                    k1=k1+ strading;
                    n1=n1+ strading;
                }
                k2=k2+ strading;
                n2=n2+ strading;
                k1 = 0;
                if (sizeYadro == 0) n1 = carts.A.GetLength(0);
                else n1 = sizeYadro;
            }
        }
        public static int Matrix(int[,] matrix, Program carts, int k1, int n1, int k2, int n2, int sizeYadro, int type, int strading, int a3, int a4)
        {
            int S = 0;
            int max = matrix[k2, k1];
            for (int i = k2, a1 = 0; i< n2; i++, a1++)
            {
                for(int j =k1, a2 = 0; j< n1; j++, a2++)
                {
                    if (sizeYadro == 0) S += matrix[i, j] * carts.A[a1, a2];
                    else
                    {
                        if (type == 1)
                        {
                            if (matrix[i, j] > max) max = matrix[i, j];
                        }
                        else S += matrix[i, j];
                    }
                }
            }
            if (type == 1)  carts.A[a3, a4] = max;
            if (type == 2)  carts.A[a3, a4] = (int)Math.Round((double)S / carts.Karta.GetLength(1), 0, MidpointRounding.AwayFromZero);
            return S;
        }
        public static void PrintMatrix(Program carts)
        {
            Console.WriteLine();
            for(int i=0; i< carts.Karta.GetLength(0); i++)
            {
                Console.Write("\t");
                for (int j = 0; j < carts.Karta.GetLength(1); j++)
                {
                    Console.Write(carts.Karta[i, j]+ " ");
                }
                Console.WriteLine();
            }
        }
        public static int[,] Padding(int[,] matrix, int padd )
        {
            int padding = padd * 2;
            int[,] matrixNew = new int[matrix.GetLength(0) + padding, matrix.GetLength(0) + padding];
            int m = 0, n = 0;
            for (int i = 0; i < (matrix.GetLength(0) + padding); i++)
            {
                for (int j = 0; j <( matrix.GetLength(0) + padding); j++)
                {
                    if (i < padd || i >= matrix.GetLength(0) + padd)
                    {
                        matrixNew[i, j] = 0;
                    }
                    else
                    {
                        if (j < padd || j >= matrix.GetLength(0) + padd)
                        {
                            matrixNew[i, j] = 0;
                        }
                        else
                        {
                            matrixNew[i, j] = matrix[m, n];
                            n++;
                        }
                    }
                }
                n = 0;
                if (i >= padd && i <= matrix.GetLength(0) + padd)  m++;

            }
            return matrixNew;
        }
        public static void ThreeYadra(int[,] Karta, int strading, int[,] matrix, int[,] A1, int[,] A2, int[,] A3)
        {
            int sizeYadro = 0;
            int type = 0;
            if(strading == 2) Karta = new int[matrix.GetLength(0)/ strading -1, matrix.GetLength(0)/ strading -1];
            if (strading == 3) Karta = new int[matrix.GetLength(0) / strading, matrix.GetLength(0) / strading];
            carts1 = new Program[3];
            carts1[0] = new Program(Karta, A1);
            carts1[1] = new Program(Karta, A2);
            carts1[2] = new Program(Karta, A3);
            Console.Clear();
            Console.WriteLine("\n\t Three matrices");
            for (int i = 0; i < 3; i++)
            {
                Yadro(matrix, carts1[i], strading, sizeYadro, type);
                PrintMatrix(carts1[i]);
            }
            if (strading == 3 || strading == 2)
            {
                Console.WriteLine(" 1. Back\n");
            }
            else
            {
                Console.WriteLine("\n 1. Pulling of max");
                Console.WriteLine(" 2. Pulling of average");
                Console.WriteLine(" 3. Back\n");
            }
            Console.WriteLine(" Choose an operation ");
            Console.Write(" Select: "); int YourChoice = Convert.ToInt32(Console.ReadLine());
            switch (YourChoice)
            {
                case 1:
                    if (strading == 3 || strading == 2)
                       Strading(strading);
                    else
                    ChoicePulling(matrix, strading, 1);
                    break;
                case 2:
                        ChoicePulling(matrix, strading, 2);
                    break;
                case 3:
                    Strading(strading);
                    break;
                default:
                    Console.WriteLine(" Wrong number");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
            ThreeYadra(Karta, strading, matrix, A1, A2, A3);
        }
        public static void CreatePaddingKarta(int[,] matrix, int strading)
        {
            int[,] A1 = new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            int[,] A2 = new int[,] { { 0, 0, 1 }, { 0, 1, 0 }, { 1, 0, 0 } };
            int[,] A3 = new int[,] { { 1, 1, 1 }, { 0, 0, 1 }, { 0, 0, 1 } };
            int[,] Karta = new int[matrix.GetLength(0) - A1.GetLength(0) + 1, matrix.GetLength(1) - A1.GetLength(1) + 1];
            ThreeYadra(Karta, strading, matrix, A1, A2, A3);
        }
        public static void Pulling(int[,] matrix, int strading, int type, int sizeYadro, Program[] carts1)
        {
            int[,] Karta;
            int[,] A1; 
            A1 = new int[(carts1[0].Karta.GetLength(0) - sizeYadro) / strading + 1, (carts1[0].Karta.GetLength(0) - sizeYadro) / strading + 1];
            Karta = new int[carts1[0].Karta.GetLength(0) - sizeYadro + 1, carts1[0].Karta.GetLength(1) - sizeYadro + 1];
            Program[] carts2 = new Program[3];
            carts2[0] = new Program(Karta, A1);
            carts2[1] = new Program(Karta, A1);
            carts2[2] = new Program(Karta, A1);
            for (int i = 0; i < 3; i++)
            {
               Yadro(matrix, carts1[i], strading, 0, 0);            
               Yadro(carts1[i].Karta, carts2[i], strading, sizeYadro, type);
               PrintMat(carts2[i].A);
             }
        }
        public static void ChoicePulling(int[,] matrix, int strading, int type)
        {
            int sizeYadro;
            Console.Clear();
            Console.WriteLine("\n 1. Core size = 2");
            Console.WriteLine(" 2. Core size = 3");
            Console.WriteLine(" 3. Back\n");
            Console.WriteLine(" Choose an operation ");
            Console.Write(" Select: "); int YourChoice = Convert.ToInt32(Console.ReadLine());
            switch (YourChoice)
            {
                case 1:
                    sizeYadro = 2;
                    Pulling(matrix, strading, type, sizeYadro, carts1);
                    break;
                case 2:
                    sizeYadro = 3;
                    Pulling(matrix, strading, type, sizeYadro, carts1);
                    break;
                case 3:
                    Strading(strading);
                    break;
                default:
                    Console.WriteLine(" Wrong number");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
            ChoicePulling(matrix, strading, type);
        }

        public static void Strading(int strading)
        {
            int padd = (3 - 1) / 2;
            int paddfull = 3 - 1;
            int[,] matrix = new int[,] { { 8, 8, 6, 3, 2, 1, 0, 9 }, { 0, 1, 2, 2, 5, 1, 1, 0 }, { 1, 0, 6, 1, 2, 9, 0, 1 }, { 0, 9, 1, 1, 0, 0, 9, 3 }, { 0, 1, 8, 1, 1, 7, 0, 1 }, { 1, 0, 1, 11, 6, 1, 2, 1 }, { 1, 1, 0, 9, 6, 5, 1, 1 }, { 3, 2, 6, 9, 1, 6, 1, 0 } };
            int[,] matrixNew = Padding(matrix, padd);
            int[,] matrixNewFull = Padding(matrix, paddfull);
            Console.Clear();
            Console.WriteLine(" 1. Without padding");
            Console.WriteLine(" 2. Half  padding");
            Console.WriteLine(" 3. Full padding");
            Console.WriteLine(" 4. Back\n");
            Console.WriteLine(" Choose an operation ");
            Console.Write(" Select: "); int YourChoice = Convert.ToInt32(Console.ReadLine());
            switch (YourChoice)
            {
                case 1:
                    CreatePaddingKarta(matrix, strading);
                    break;
                case 2:
                    CreatePaddingKarta(matrixNew, strading);
                    break;
                case 3:
                    CreatePaddingKarta(matrixNewFull, strading);
                    break;
                case 4:
                    Start();
                    break;
                default:
                    Console.WriteLine(" Wrong Number");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
            Strading(strading);
        }
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("\n 1. Strading: 1");
            Console.WriteLine(" 2. Strading: 2");
            Console.WriteLine(" 3. Strading: 3");
            Console.WriteLine(" 4. Exit\n");
            Console.WriteLine(" Choose an operation ");
            Console.Write(" Select: "); int YourChoice = Convert.ToInt32(Console.ReadLine());
            switch (YourChoice)
            {
                case 1:
                    Strading(1);
                    break;
                case 2:
                    Strading(2);
                    break;
                case 3:
                    Strading(3);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(" Wrong number");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
            Start();
        }
        static void Main(string[] args)
        {
            Start();
        }
    }
}
