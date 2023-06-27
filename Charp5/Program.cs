using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charp5
{
    class Set
    {
        //Поля
        int count;
        int[] elements;
        static int[] array;

        //Конструкторы
        public Set()
        {
            this.count = Vvod();
            this.elements = Fill(this.count);
        }

        public Set(int[] array)
        {
            this.count = array.Length;
            this.elements = array;
        }
        
        
        //Индексатор
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index <= array.Length)
                    return elements[index];
                Console.WriteLine(" Wrong element ");
                return 0;
            }
            set
            {
                if (index >= 0 && index <= array.Length)
                    elements[index] = value;
                else Console.WriteLine(" Wrong element ");
            }
        }

        //Методы
        public static int Vvod()
        {
            Console.Write(" Enter number: "); int n = Convert.ToInt32(Console.ReadLine());
            return n;
        }
       
        public static int[] Fill(int count)
        {
            int[] elementsArr = new int[count];
            for (int i = 0; i < count; i++)
            {
            reroll1:
                int j = 0;
                Console.Write(" Number " + (i+1) + ": ");
                elementsArr[i] = Convert.ToInt32(Console.ReadLine());
                for (j = 0; j < i; j++)
                {
                    if (elementsArr[j] == elementsArr[i]) goto reroll1;
                }
            }
           return elementsArr;
        }
        
        public static int[] Random()
        {
            int count = Vvod();
            Console.WriteLine(" Enter number of array Range: [ M, N ] ");
            Console.Write(" M: "); int M = Convert.ToInt32(Console.ReadLine());
            Console.Write(" N: "); int N = Convert.ToInt32(Console.ReadLine());
            if (M > N || (N - M) < count)
            {
                Console.Write(" Wrong Range: [ M, N ] ");
                Random();
            }
            int[] elementsArr = new int[count];
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
            reroll:
                int j = 0;
               elementsArr[i] = rnd.Next(M, N);
                for (j = 0; j < i; j++)
                {
                    if (elementsArr[j] == elementsArr[i]) goto reroll;
                }
            }
            return elementsArr;
        }
        public static int IndexOf(int Value, Set set)
        {
            for (int i = 0; i < set.count; i++)
            {
                if (set.elements[i] == Value)
                {
                    return 1;
                }
            }
            return -1;
        }
        public static void ShowSet(Set set)
        {
            for (int i = 0; i < set.count; i++)
            {
               Console.Write(set.elements[i] + "  ");
            }
            Console.WriteLine("\n");
        }

        public static void Add(int NewElement, Set set)
        {
            Array.Resize(ref set.elements, set.elements.Length + 1);
            set.count = set.elements.Length;
            set.elements[set.elements.Length-1] = NewElement;
        }
        public static Set operator ++(Set set1)
        {
            Set set = new Set(set1.elements);
            for (int i=0; i < set1.count; i++)
            {
                set.elements[i] = set1.elements[i] + 1;
            }
            return set;
        }
        public static Set operator +(Set set1, Set set2)
        {
            int n=0;
            Set set = new Set(set1.elements);
            for (int i = 0; i < set2.count; i++)
            {
                n = IndexOf(set2.elements[i], set1);
                if (n == -1)
                {
                    Add(set2.elements[i], set);
                }   
            }
            return set;
        }

        public static Set operator *(Set set1, Set set2)
        {
            int n = 0;
            int[] array = new int[n];
            Set set = new Set(array);
            for (int i = 0; i < set1.count; i++)
            {
                n = IndexOf(set1.elements[i], set2);
                if (n == 1)
                {
                    Add(set1.elements[i], set);
                }
            }
            return set;
        }

        public static Set operator /(Set set1, Set set2)
        {
            int n = 0;
            int[] array = new int[n];
            Set set = new Set(array);
            for (int i = 0; i < set1.count; i++)
            {
                n = IndexOf(set1.elements[i], set2);
                if (n == -1)
                {
                    Add(set1.elements[i], set);
                }
            }
            return set;
        }
        
        public static bool operator <(Set set1, Set set2)
        {
            if (set1.count < set2.count)
            {
                return true;
            }
            return false;
        }

        public static bool operator >(Set set1, Set set2)
        {
            if (set1.count > set2.count)
            {
                return true;
            }
            return false;
        }
        public static Set ChoiceArr()
        {
            choice:
            Console.WriteLine(" Would you prefer: \n1. Enter elements in the console \n2. Enter elements random ");
            Console.Write(" Number: "); int YourChoice = Convert.ToInt32(Console.ReadLine());
            switch (YourChoice)
            {
                case 1:
                    Set set1 = new Set();
                    return set1;

                case 2:
                    array = Random();
                    Set set2 = new Set(array);
                    return set2;
                default:
                    Console.WriteLine(" Wrong number");
                    goto choice;
            }
        }
        public static void StartProgramm(Set set1, Set set2)
        {
            Console.Write("Set №1: "); ShowSet(set1);
            Console.Write("Set №2: "); ShowSet(set2);
            Console.WriteLine(" 1. ++     4. /");
            Console.WriteLine(" 2. +      5. < and >");
            Console.WriteLine(" 3. *      6. Exit\n");

            Console.WriteLine(" Select array and enter number ");
            Console.Write(" Number: "); int YourChoice = Convert.ToInt32(Console.ReadLine());
            switch (YourChoice)
            {
                case 1:
                    Console.Write("Set №1: "); ShowSet(set1++);
                    Console.Write("Set №2: "); ShowSet(set2++);
                    break;
                case 2:
                    Console.Write(" Set containing the following elements: "); ShowSet(set1 + set2);
                    break;
                case 3:
                    Console.Write(" Set containing the following elements: "); ShowSet(set1 * set2);
                    break;
                case 4:
                    Console.Write(" Set containing the following elements: "); ShowSet(set1/set2);
                    break;
                case 5:
                    if (set1 > set2) Console.WriteLine(" Set №1 more then Set №2 ");
                    else if (set1 < set2) Console.WriteLine(" Set №2 more elements then Set №1 ");
                    else Console.WriteLine(" Set №2 = Set №1 ");
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(" Wrong number");
                    StartProgramm(set1, set2);
                    break;
            }
            Console.ReadLine();
            Console.Clear();
            StartProgramm(set1, set2);
        }

        static void Main(string[] args)
        {
            Set set1 = ChoiceArr();
            Set set2 = ChoiceArr();
            Console.Clear();
            StartProgramm(set1,set2);
            Console.ReadLine();
        }
    }
}
