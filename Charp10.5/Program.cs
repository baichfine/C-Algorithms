using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;

namespace Charp10
{
    //Базовый абстрактный класс
    abstract class PrintEdition
    {
        public delegate void Del(string message, string Name, int Number);
        public event Del ChangeHaracters;
        //Поля
        private string name;
        //Свойства
        public string Name { get; set; }
        //Конструкторы
        public PrintEdition()
        {
            this.Name = "Name";
        }
        public PrintEdition(string name)
        {
            this.Name = name;
        }
        //Методы
        virtual public void Show()
        {
            Console.Write(" " + Name + " ");
        }
        abstract public void Change();
        public void ChangeHaracter(string Name, int Number)
        {
            if (ChangeHaracters != null)
                ChangeHaracters("Parameters changed!\n Name = {0} \n Number = {1}", Name, Number);
        }
        public static void Show_Message(string message, string Name, int Number)
        {
            Console.WriteLine(message, Name, Number);
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
        public Journal(string name, int number) : base(name)
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
            this.ChangeHaracters += Show_Message;
            Console.Write(" Enter name of Journal: "); string name = Console.ReadLine();
            this.Name = name;
            Console.Write(" Enter number of Journal: "); number = Convert.ToInt32(Console.ReadLine());
            this.Number = number;   
            this.ChangeHaracter(Name, Number);
            this.ChangeHaracters -= Show_Message;
        }

    }

    //Класс содержащий коллекции производных от базового абстрактного класса
    class BookShop
    {
        public static PrintEdition AddObj()
        {
            PrintEdition obj1 = new Journal();
            obj1.Change();
            return obj1;
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
        public static void PrintObj(List<PrintEdition> List)
        {
            Console.Write("\n  ");
            for (int i = 0; i < List.Count; i++)
            {
                Console.Write((i + 1) + ". "); List[i].Show();
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
            Console.WriteLine(" 2. Delete object from collection                 5. Exit");
            Console.WriteLine(" 3. Information about objects in the collection\n");
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
            PrintEdition class1 = new Journal();
            List<PrintEdition> List1 = new List<PrintEdition>(3) { class1 };

            Menu(List1);
            Console.ReadKey();
        }
    }


}