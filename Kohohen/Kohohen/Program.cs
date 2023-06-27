using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Kohohen
{
    class Koh
    {
        double[,] xRandom = new double[20, 7];
        double[,] x = new double[20, 7];
        double[,] vesa = new double[4, 7];
        List<List<int>> klasters = new List<List<int>>(4);
        List<int> klaster;
        public void StartKoh()
        {
            DataExample();
            Era(0.3, 0.5, 1);
            Console.WriteLine(" Веса после первой эпохи");
            PrintExample(vesa);
            Console.WriteLine(" Все кластеры заполнены");
            PrintKlasters(klasters);
            klasters.Clear();
            Era(0.25, 0.5, 2);
            Console.WriteLine(" Веса после второй эпохи");
            PrintExample(vesa);
            Era(0.2, 0.5, 3);
            Console.WriteLine(" Веса после третьей эпохи");
            PrintExample(vesa);
            Console.WriteLine(" Все кластеры заполнены");
            PrintKlasters(klasters);
        }
        public void Era(double v, double d, int q)
        {
            for (int i = 0; i < x.GetLength(0); i++) Example(i, v);
            if (q != 2)
            {
                double s = 0, R, bin = 0;
                for (int ves = 0; ves < vesa.GetLength(0); ves++)
                {
                    Console.WriteLine(" № \tR \t\tR-0.5 \t        Принадлежность кластеру №" + (ves + 1));
                    klaster = new List<int> { };
                    for (int i = 0; i < x.GetLength(0); i++)
                    {
                        for (int j = 0; j < x.GetLength(1); j++)
                        {
                            s += (x[i, j] - vesa[ves, j]) * (x[i, j] - vesa[ves, j]);
                        }
                        R = s - d;
                        if (R < 0) { klaster.Add(i + 1); bin = 1; }
                        Console.WriteLine(" " + (i + 1) + " \t" + s + " \t" + R + " \t" + bin);
                        s = 0;
                        bin = 0;
                    }
                    Console.WriteLine("\n");
                    klasters.Add(klaster);
                }
            }
        }
        public void PrintKlasters(List<List<int>> klasters)
        {
            for (int i = 0; i < klasters.Count; i++)
            {
                Console.Write(" В " + (i + 1) + "-й кластер вошли следующие примеры: ");
                for (int j = 0; j < klasters[i].Count; j++)
                {
                    Console.Write(klasters[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }
        public void Example(int n, double v)
        {
            double[] distance = new double[4];
            for (int i = 0; i < vesa.GetLength(0); i++)
            {
                for (int j = 0; j < vesa.GetLength(1); j++)
                {
                    distance[i] += (xRandom[n, j] - vesa[i, j]) * (xRandom[n, j] - vesa[i, j]);
                }
                distance[i] = Convert.ToDouble(Math.Sqrt(distance[i]));
            }
            double min = distance[0];
            int klaster = 0;
            for (int i = 0; i < distance.Length; i++)
            {
                if (distance[i] < min)
                {
                    min = distance[i];
                    klaster = i;
                }
            }
            for (int j = 0; j < vesa.GetLength(1); j++)
            {
                vesa[klaster, j] = Math.Round(vesa[klaster, j] + v * (xRandom[n, j] - vesa[klaster, j]), 3, MidpointRounding.AwayFromZero);
            }
        }
        public void PrintExample(double[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }
        public void DataExample()
        {
            Excel.Application ObjExcel = new Excel.Application();
            System.Diagnostics.Process excelProc = System.Diagnostics.Process.GetProcessesByName("EXCEL").Last();
            Excel.Workbook ObjWorkBook = ObjExcel.Workbooks.Open(@"C:\Users\Programmist\Desktop\list", 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Excel.Worksheet ObjWorkSheet;
            ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1];
            for (int i = 0, n = 0, m = 0; i < 44; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i <= 19) xRandom[i, j] = double.Parse(ObjWorkSheet.Cells[i + 1, j + 1].Text);
                    else if (i <= 23 && i > 19) vesa[n, j] = double.Parse(ObjWorkSheet.Cells[i + 1, j + 1].Text);
                    else if (i > 23) x[m, j] = double.Parse(ObjWorkSheet.Cells[i + 1, j + 1].Text);
                }
                if (i > 19 && i < 24) n++;
                else if (i > 23) m++;
            }
            ObjWorkBook.Close();
            ObjExcel.Application.Quit();
            excelProc.Kill();
        }
        static void Main(string[] args)
        {
            Koh Student = new Koh();
            Student.StartKoh();
            Console.ReadKey();
        }
    }
}
