using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charp6
{
    //Базовый абстрактный класс
    abstract class PrintEdition
    {
        //Поля
        private string name;
        //Свойства
        public string Name
        {
            get { return name; }

            set
            {
                if (value.Length > 20)
                {
                    Console.WriteLine(" Title too long.");
                    value = " News ";
                }
                else name = value;
            }
        }
        //Конструкторы
        public PrintEdition(string name)
        {
            Name = name;
        }
        //Методы
        virtual public void Show()
        {
            Console.Write(" " + name + " ");
        }
        abstract public void Change();
    }
    //Производные классы
    class Journal : PrintEdition
    {
        //Поля
        private int number;
        //Конструкторы
        public Journal(string name, int number) : base(name)
        {
            this.Number = number;
        }
        //Свойства
        public int Number
        {
            get { return number; }

            set
            {
                if (value <= 0)
                {
                    Console.WriteLine(" Journal number must be positive.");
                    value = 1;
                }
                else number = value;
            }
        }
        //Методы
        override public void Show()
        {
            base.Show();
            this.Number = number;
            Console.WriteLine(number);
        }
        override public void Change()
        {
            Console.Write(" Enter name of Journal: "); string name = Convert.ToString(Console.ReadLine());
            this.Name = name;
            Console.Write(" Enter number of Journal: "); int number = Convert.ToInt32(Console.ReadLine());
            this.Number = number;
        }
    }

    class Newspaper : PrintEdition
    {
        //Поля
        private string news;
        //Конструкторы
        public Newspaper(string name, string news) : base(name)
        {
            this.News = news;
        }
        //Свойства
        public string News
        {
            get { return news; }

            set
            {
                if (value.Length > 20)
                {
                    Console.WriteLine(" Title too long.");
                    value = " News ";
                }
                else news = value;
            }
        }
        //Методы
        override public void Show()
        {
            base.Show();
            Console.WriteLine(news);
        }
        override public void Change()
        {
            Console.Write(" Enter name of Newspaper: "); string name = Convert.ToString(Console.ReadLine());
            this.Name = name;
            Console.Write(" Enter news: "); string news = Convert.ToString(Console.ReadLine());
            this.News = news;
        }
    }

    class Book : PrintEdition
    {
        //Поля
        private string author;
        //Конструкторы
        public Book(string name, string author) : base(name)
        {
            this.Author = author;
        }
        //Свойства
        public string Author
        {
            get { return author; }

            set
            {
                if (value.Length > 20)
                {
                    Console.WriteLine(" Title too long.");
                    value = " Author ";
                }
                else author = value;
            }
        }
        //Методы
        override public void Show()
        {
            base.Show();
            this.Author = author;
            Console.WriteLine(author);
        }
        override public void Change()
        {
            Console.Write(" Enter name of Book: "); string name = Convert.ToString(Console.ReadLine());
            this.Name = name;
            Console.Write(" Enter name of Author: "); string author = Convert.ToString(Console.ReadLine());
            this.Author = author;
        }
    }

    //Класс содержащий коллекции производных от базового абстрактного класса
    class BookShop
    {
        public static PrintEdition AddObj()
        {
        reroll:
            Console.Clear();
            Console.WriteLine(" 1. Add new object Journal");
            Console.WriteLine(" 2. Add new object Newspaper");
            Console.WriteLine(" 3. Add new object Book\n");
            Console.WriteLine(" Select action ");
            Console.Write(" Number: "); int Object = Convert.ToInt32(Console.ReadLine());
            switch (Object)
            {
                case 1:
                    PrintEdition obj1 = new Journal(" ", 1);
                    obj1.Change();
                    return obj1;
                case 2:

                    PrintEdition obj2 = new Newspaper(" ", " ");
                    obj2.Change();
                    return obj2;
                case 3:
                    PrintEdition obj3 = new Book(" ", " ");
                    obj3.Change();
                    return obj3;
                default:
                    Console.WriteLine(" Wrong number");
                    goto reroll;
            }

        }
        public static void RemoveObj(List<PrintEdition> List1)
        {
            Console.Write(" Which object do you want to delete: "); int n = Convert.ToInt32(Console.ReadLine());
            if (n >= 0 && n <= List1.Count)
            {
                List1.RemoveAt(n - 1);
            }
            else Console.Write(" Wrong number ");
        }
        public static void PrintObj(List<PrintEdition> List1)
        {
            Console.Write("\n  ");
            for (int i = 0; i < List1.Count; i++)
            {
                Console.Write((i + 1) + ". "); List1[i].Show();
                Console.Write("  ");
            }
            Console.WriteLine();
        }

        public static void ChangeProp(List<PrintEdition> List1)
        {
            Console.Write(" Which object do you want to change: "); int n = Convert.ToInt32(Console.ReadLine());
            if (n >= 0 && n <= List1.Count)
            {
                List1[n - 1].Change();
            }
            else Console.Write(" Wrong number ");
        }


        public static void Menu(List<PrintEdition> List1)
        {
            Console.WriteLine(" 1. Add new object in collection                  4. Change properties and filds");
            Console.WriteLine(" 2. Delete object from collection                 5. Print objects by category");
            Console.WriteLine(" 3. Information about objects in the collection   6. Exit\n");
            Console.WriteLine(" Select action ");
            Console.Write(" Number: "); int YourChoice = Convert.ToInt32(Console.ReadLine());
            switch (YourChoice)
            {
                case 1:
                    List1.Add(AddObj());
                    PrintObj(List1);
                    break;
                case 2:
                    PrintObj(List1);
                    RemoveObj(List1);
                    break;
                case 3:
                    PrintObj(List1);
                    break;
                case 4:
                    PrintObj(List1);
                    ChangeProp(List1);
                    break;
                case 5:
                    Print(List1);
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(" Wrong number");
                    break;
            }
            Console.ReadLine();
            Console.Clear();
            Menu(List1);
        }

        public static void Print(List<PrintEdition> List1)
        {
        reroll:
            Console.Clear();
            Console.WriteLine(" 1. Print objects Journal");
            Console.WriteLine(" 2. Print objects Newspaper");
            Console.WriteLine(" 3. Print objects Book\n");
            Console.WriteLine(" Select action ");
            Console.Write(" Number: "); int Object = Convert.ToInt32(Console.ReadLine());
            switch (Object)
            {
                case 1:
                    PrintEdition journal = new Journal(" ", 1);
                    PrintObj(Cort(List1, journal));
                    break;
                case 2:
                    PrintEdition newspaper = new Newspaper(" ", " ");
                    PrintObj(Cort(List1, newspaper));
                    break;
                case 3:
                    PrintEdition book = new Book(" ", " ");
                    PrintObj(Cort(List1, book));
                    break;
                default:
                    Console.WriteLine(" Wrong number");
                    goto reroll;
            }
        }
        public static List<PrintEdition> Cort(List<PrintEdition> List1, PrintEdition obj)
        {
            int j = 0;
            List<PrintEdition> cort = new List<PrintEdition>() { };
            for (int i = 0; i < List1.Count; i++)
            {
                if (List1[i].GetType() == obj.GetType())
                {
                    cort.Add(List1[i]);
                    j++;
                }
            }
            return cort;
        }
        static void Main(string[] args)
        {
            PrintEdition class1 = new Journal("Journal ", 5);
            PrintEdition class2 = new Newspaper("Newspaper", " Breaking news ");
            PrintEdition class3 = new Book("Book", " Pyshkin");
            List<PrintEdition> List1 = new List<PrintEdition>(3) { class1, class2, class3 };
            Menu(List1);
            Console.ReadKey();
        }
    }
}
