using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charp2
{
    class Program
    {
        static void print(List<int> spisok) //Печать списка на консоль
        {
            for (int i=0; i < spisok.Count; i++) //Количество элементов в списке
            {
                Console.Write(spisok[i] + "  ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            List<int> spisok1 = new List<int>(5) { 1, 2, 3, 4, 5 }; 
            Console.Write("  List №1 with 5 elements: ");
            print(spisok1);
            spisok1.Add(6); //добавление 6-ого эелемента в список из 5-ти элементов
            Console.Write("  List №1 with 6 elements: ");
            print(spisok1);
            List<int> spisok2 = new List<int>(3) { 1, 2, 3 };
            Console.Write("  List №2 with 3 elements: ");
            print(spisok2);
            spisok1.InsertRange(3, spisok2); //Вставка списка №2 в список №1 начиная с 3 элемента
            Console.Write("  List №1 with List №2 elements: ");
            print(spisok1);
            Console.WriteLine("  Max element of elements List №1: " + spisok1.Max());
            Console.WriteLine("  Min element of elements List №1: " + spisok1.Min());
            int[] array = spisok2.ToArray(); //Приводит список №2 в вид одномерного массива
            Console.Write("  Array with List №2 elements: ");
            for (int i=0; i< array.Length; i++)
                Console.Write(array[i] + "  ");
            Console.WriteLine();
            spisok2.RemoveAt(1); //Удаляет в списке №2 элемент под номером 1
            Console.Write("  List №2 elements with remove element №2: ");
            print(spisok2);
            Console.ReadLine();
        }
    }
}
