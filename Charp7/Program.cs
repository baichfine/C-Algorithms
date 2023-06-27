using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Charp6
{ 
//Базовый абстрактный класс
abstract class PrintEdition : IComparable, ICloneable, IEnumerable
    {
        //Поля
        private string name;
        //Свойства
        public string Name { get; set; }
        public Many Currency { get; set; }

        //Конструкторы
        public PrintEdition()
        {
            this.Name = "Имя";
            this.Currency = new Many();
            this.Currency.Name = "Название RUB";
        }
        public PrintEdition(string name, Many currency)
        {
            this.Name = name;
            this.Currency = new Many();
            this.Currency.Name = currency.Name;
        }
        //Методы
        virtual public void Show()
        {
            Console.Write(" " + Name + " " + Currency.Name + " ");
        }
        abstract public void Change();
        abstract public int CompareTo(object obj);
        virtual public object Clone()
        {
            return this.MemberwiseClone();
        }
        abstract public object Clone(object obj);
        public IEnumerator GetEnumerator()
        {
            return name.GetEnumerator();
        }
        public IEnumerator GetEnumerator(List<PrintEdition> List1)
        {
            return new ListEnumerator(List1);
        }

    }
    //Производные классы
    class Journal : PrintEdition
    {
        //Поля
        private int number;
        //Конструкторы
        public Journal() : base()
        {
            this.Number = 1;
        }
        public Journal(string name, Many currency, int number) : base(name, currency)
        {
            this.Number = number; 
        }
        //Свойства
        public int Number { get; set; }
        //Методы
        override public void Show()
        {
            base.Show();
            Console.WriteLine(Number);
        }
        override public void Change()
        {
            Console.Write(" Enter name of Journal: "); string name = Console.ReadLine();
            this.Name = name;
            Console.Write(" Enter currency of Journal: "); string currency = Console.ReadLine();
            this.Currency.Name = currency;
            Console.Write(" Enter number of Journal: "); number = Convert.ToInt32(Console.ReadLine());
            this.Number = number;
        }
        override public int CompareTo(object obj)
        {
            Journal j = obj as Journal;
            if ( j != null)
            {
                if (this.Number > j.Number) return 1;
                else if (this.Number < j.Number) return -1;
                else return 0;
            }
            else throw new Exception("Невозможно сравнить два объекта");
        }
    override public object Clone(object obj)
        {
            Many valuta = new Many { Name = this.Currency.Name };
            return new Journal
            {
                Name = this.Name,
                Currency = valuta,
                Number = this.Number
            };
        }
    }

    class Newspaper : PrintEdition
    {
        //Поля
        private string news;
        //Конструкторы
        public Newspaper() : base()
        {
            this.News = "The Breaking Bad";
        }
        public Newspaper(string name, Many currency, string news) : base(name, currency)
        {
            this.News = news;
        }
        //Свойства
        public string News { get; set;}
        //Методы
        override public void Show()
        {
            base.Show();
            Console.WriteLine(News);
        }
        override public void Change()
        {
            Console.Write(" Enter name of Newspaper: "); string name = Console.ReadLine();
            this.Name = name;
            Console.Write(" Enter currency of Newspaper: "); string currency = Console.ReadLine();
            this.Currency.Name = currency;
            Console.Write(" Enter news: "); news = Console.ReadLine();
            this.News = news;
        }
        override public int CompareTo(object obj)
        {
            Newspaper n = obj as Newspaper;
            if (n != null)
            {
                if (this.News.Length > n.News.Length) return 1;
                else if (this.News.Length < n.News.Length) return -1;
                else return 0;
            }
            else throw new Exception("Невозможно сравнить два объекта");
        }
        override public object Clone(object obj)
        {
            Many valuta = new Many { Name = this.Currency.Name };
            return new Newspaper
            {
                Name = this.Name,
                Currency = valuta,
                News = this.News
            };
        }
    }

    class Book : PrintEdition
    {
        //Поля
        private string author;
        //Конструкторы
        public Book() : base()
        {
            this.Author = "Pyskin";
        }
        public Book(string name, Many currency, string author) : base(name, currency)
        {
            this.Author = author;
        }
        //Свойства
        public string Author { get; set; }
        //Методы
        override public void Show()
        {
            base.Show();
            Console.WriteLine(Author);
        }
        override public void Change()
        {
            Console.Write(" Enter name of Book: "); string name = Console.ReadLine();
            this.Name = name;
            Console.Write(" Enter currency of Book: "); string currency = Console.ReadLine();
            this.Currency.Name = currency;
            Console.Write(" Enter name of Author: "); author = Console.ReadLine();
            this.Author = author;
        }

        override public int CompareTo(object obj)
        {
            Book b = obj as Book;
            if (b != null)
            {
                return this.Author.CompareTo(b.Author);
            }
            else throw new Exception();
        }
        override public object Clone(object obj)
        {
            Many valuta = new Many { Name = this.Currency.Name };
            return new Book
            {
                Name = this.Name,
                Currency = valuta,
                Author = this.Author
            };
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
                    PrintEdition obj1 = new Journal();
                    obj1.Change(); 
                    return obj1;
                case 2:

                    PrintEdition obj2 = new Newspaper();
                    obj2.Change();
                    return obj2;
                case 3:
                    PrintEdition obj3 = new Book();
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
            if (n>=0 && n <= List1.Count)
            {
                List1.RemoveAt(n-1);
            }
            else Console.Write(" Wrong number ");
        }
        public static void PrintObj(List<PrintEdition> List)
        {
            Console.Write("\n  ");
            for (int i = 0; i < List.Count; i++)
            {
                Console.Write((i+1)+". "); List[i].Show();
                Console.Write("  ");
            }
            Console.WriteLine();
        }
        public static void ChangeProp(List<PrintEdition> List1)
        {
            Console.Write(" Which object do you want to change: "); int n = Convert.ToInt32(Console.ReadLine());
            if (n >= 0 && n <= List1.Count)
            {
                List1[n-1].Change();
            }
            else Console.Write(" Wrong number ");
        }
        public static void Menu(List<PrintEdition> List1)
        {
            Console.WriteLine(" 1. Add new object in collection                  4. Change properties and filds");
            Console.WriteLine(" 2. Delete object from collection                 5. Print and Sort objects by category");
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
        public static void Print(List<PrintEdition> List)
        {
        reroll:
            Console.Clear();
            Console.WriteLine(" 1. Print objects Journal");
            Console.WriteLine(" 2. Print objects Newspaper");
            Console.WriteLine(" 3. Print objects Book");
            Console.WriteLine(" 4. Back to select action\n");
            Console.WriteLine(" Select action ");
            Console.Write(" Number: "); int Object = Convert.ToInt32(Console.ReadLine());
            List<PrintEdition> newElements = new List<PrintEdition>() { };
            switch (Object)
            {
                case 1:
                    PrintEdition journal = new Journal();
                    List<PrintEdition> List1 = Cort(List, journal);
                    PrintObj(List1);
                    Interface(List1, List, newElements);
                    break;
                case 2:
                    PrintEdition newspaper = new Newspaper();
                    List<PrintEdition> List2 = Cort(List, newspaper);
                    PrintObj(List2);
                    Interface(List2, List, newElements);
                    break;
                case 3:
                    PrintEdition book = new Book();
                    List<PrintEdition> List3 = Cort(List, book);
                    PrintObj(List3);
                    Interface(List3, List, newElements);
                    break;
                case 4:
                    Console.Clear();
                    Menu(List);
                    break;
                default:
                    Console.WriteLine(" Wrong number");
                    goto reroll;
            }
        }
        public static void Interface(List<PrintEdition> listya, List<PrintEdition> List0, List<PrintEdition> newElements)
        {
            reroll:
            Console.Clear();
            Console.WriteLine(" 1. Sort objects   4. Foreach objects");
            Console.WriteLine(" 2. Surface copy   5. Back to select object");
            Console.WriteLine(" 3. Deep copy");
            Console.WriteLine(" Select action ");
            Console.Write(" Number: "); int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    listya.Sort();
                    PrintObj(listya);
                    Console.ReadLine();
                    Interface(listya,List0, newElements);
                    break;
                case 2:
                    int n = listya.Count;
                    for (int i = 0; i < n; i++)
                    {
                        PrintEdition List = (PrintEdition)listya[i].Clone();
                        List.Change(); 
                        newElements.Add(List);
                        listya.Add(List);
                        Console.WriteLine();
                    }
                    PrintObj(listya);
                    Interface(listya,List0, newElements);
                    break;
                case 3:
                    int N = listya.Count;
                    for (int i = 0; i < N; i++)
                    {
                        PrintEdition List = (PrintEdition)listya[i].Clone(listya);
                        List.Change();
                        newElements.Add(List);
                        listya.Add(List);
                        Console.WriteLine();
                    }
                    PrintObj(listya);
                    Interface(listya,List0, newElements);
                    break;
                case 4:
                    Console.WriteLine("\n");
                    IEnumerator ie = listya.GetEnumerator(); 
                    while (ie.MoveNext())   
                    {
                        PrintEdition item = (PrintEdition)ie.Current;    
                        item.Show();
                    }
                    ie.Reset();
                    Console.ReadKey();
                    Interface(listya, List0, newElements);
                    break;
                case 5:
                    List0.AddRange(newElements);
                    Print(List0);
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
                if (List1[i].GetType() == obj.GetType() )
                {
                    cort.Add(List1[i]);
                    j++;
                }
            }
            return cort;
        }
        static void Main(string[] args)
        {
            PrintEdition class1 = new Journal();
            PrintEdition class2 = new Newspaper();
            PrintEdition class3 = new Book();
            List<PrintEdition> List1 = new List<PrintEdition>(3) {class1, class2, class3 };
            Menu(List1);
            Console.ReadKey();
        }
    }

    class ListEnumerator : IEnumerator
    {
        List<PrintEdition> List1; int position = -1;
        public ListEnumerator(List<PrintEdition> List1) { this.List1 = List1; }
        public object Current
        {
            get
            {
                if (position == -1 || position >= List1.Count)
                    throw new InvalidOperationException();
                return List1[position];
            }
        }
        public bool MoveNext()
        {
            if (position < List1.Count - 1)
            { position++; return true; }
            else return false;
        }
        public void Reset() { position = -1; }
 }

    class PrintEditionComparer : IComparer<PrintEdition>
    {
        public int Compare(PrintEdition p1, PrintEdition p2)
        {
            if (p1.Name.Length > p2.Name.Length) return 1;
            else if (p1.Name.Length < p2.Name.Length) return -1;
            else return 0;
        }
    }

    class Many
    {
        public string Name { get; set; }

        public Many()
        {
            this.Name = "RUB";
        }
    }
}

