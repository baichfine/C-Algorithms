using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Charp3
{
    class book
    {
        string name, autor;
        private int pages;

        public book()
        {
            this.name = " Book";
            this.autor = " Autor";
            this.Pages = 0;
        }

        public book(string name, string autor, int pages)
        {
            this.name = name;
            this.autor = autor;
            this.Pages = pages;
        }        
        
        public int Pages
        {
            get { return pages; }

            set
            {
                if (value < 0) { Console.WriteLine(" Too few pages.");
                    pages = 0;
                }
                else pages = value;
            }
        }            

        public void ChangeData(string name, string autor, int pages)
        {
            this.name = name;
            this.autor = autor;
            this.Pages = pages;
        }
        public void ShowMe(book kniga)
        {
            Console.WriteLine(kniga.name +" " + kniga.autor + " " + kniga.pages);
        }
        public static void Сomparison(book kniga1, book kniga2)
        {
            if (kniga1 > kniga2)
                Console.WriteLine(kniga1.name + " has more pages than " + kniga2.name);
            else Console.WriteLine(kniga2.name + " has more pages than " + kniga1.name);
        }

        public void file(book kniga)
        {
            string path = @"C:\Users\Programmist\Desktop\Autors.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    string data = kniga.name + " " + kniga.autor + " " + kniga.pages;
                    sw.WriteLine(data);
                }                             
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    string data = kniga.name + " " + kniga.autor + " " + kniga.pages;
                    sw.WriteLine(data);
                }
            }
        }

        public static int operator +(book kniga1, book kniga2)
        {
            book kolvoStr = new book();
            kolvoStr.pages = kniga1.pages + kniga2.pages;
            return kolvoStr.pages;
        }
        public static bool operator >(book kniga1, book kniga2)
        {
            if (kniga1.pages > kniga2.pages)
                return true;
            else
                return false;
        }
        public static bool operator <(book kniga1, book kniga2)
        {
            if (kniga1.pages < kniga2.pages)
                return true;
            else
                return false;
        }

        static void Main(string[] args)
        {
            book pyskin = new book();
            pyskin.ShowMe(pyskin);
            pyskin.ChangeData(" Gold fish", " Sasha", 150);
            pyskin.ShowMe(pyskin);
            pyskin.file(pyskin);
            book Dostoevsky = new book(" Crime and Punishment", " Fedya", 300);
            Dostoevsky.Pages = -10;
            Dostoevsky.ShowMe(Dostoevsky);
            Dostoevsky.file(Dostoevsky);
            Console.WriteLine(" Number of pages in two books " + (pyskin + Dostoevsky));
            Сomparison(pyskin,Dostoevsky);
            Console.ReadLine();
        }
    }

}
