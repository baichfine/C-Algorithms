using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charp6
{
    class PrintEdition
    {
        //Поля
        private string name;
        //Конструкторы
        public PrintEdition()
        {
            this.Name = " Print ";
        }
        public PrintEdition(string name)
        {
            this.Name = name;
        }
        //Свойства
        public string Name
        {
            get { return name; }

            set
            {
                if (value.Length > 20)
                {
                    Console.WriteLine(" Title too long.");
                    value = " Name ";
                }
                else name = value;
            }
        }
        //Методы
       virtual public void Show()
        {
            Console.Write(name);
        }
        static void Main(string[] args)
        {
            PrintEdition[] print = new PrintEdition[4];
            print[0] = new PrintEdition(" PrintEdition\n");
            print[1] = new Journal(" Journal ", 5);
            print[2] = new Newspaper(" Newspaper", " Breaking news ");
            print[3] = new Book(" Book", " Pyshkin");

            for(int i=0; i<4; i++)
            {
                print[i].Show();
            }
            Console.ReadKey();
        }
    }
    //Производные классы
    class Journal : PrintEdition
    {
        //Поля
        private int number;
        //Конструкторы
        public Journal(): base()
        {
            Number = 1;
        }
        public Journal(string name, int number): base(name)
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
            Console.WriteLine(number);
        }
    }

    class Newspaper : PrintEdition
    {
        //Поля
        private string news;
        //Конструкторы
        public Newspaper(): base()
        {
            News = " Breaking news ";
        }
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
    }

    class Book: PrintEdition
    {
        //Поля
        private string autor;
        //Конструкторы
        public Book(): base()
        {
            Autor = " Autor ";
        }
        public Book(string name, string autor) : base(name)
        {
            this.Autor = autor;
        }
        //Свойства
        public string Autor
        {
            get { return autor; }

            set
            {
                if (value.Length > 20)
                {
                    Console.WriteLine(" Title too long.");
                    value = " Autor ";
                }
                else autor = value;
            }
        }
        //Методы
        override public void Show()
        {
            base.Show();
            Console.WriteLine(autor);
        }

    }
}
