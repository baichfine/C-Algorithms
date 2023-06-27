using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charp9
{
    delegate bool Sort(Product goods1, Product goods2);
    class Product
    {
        //Конструктор
        public Product(string name, double price, int skladNum, DateTime shelfLife)
        {
            this.Name = name;
            this.Price = price;
            this.SkladNum = skladNum;
            this.ShelfLife = shelfLife;
        }
        //Свойства
        public string Name { get; set; }
        public double Price { get; set; }
        public int SkladNum { get; set; }
        public DateTime ShelfLife { get; set; }

        //Методы
        public static void ShowGoods(Product[] goods)
        {
            Console.WriteLine("\tNumber \tTitle   \tPrice \tStock quantity \tExpiration date");
            for (int i=0; i< goods.Length; i++)
            {
                Console.WriteLine("\t{0}. \t{1}  \t{2} \t{3} \t\t{4}", i+1, goods[i].Name, goods[i].Price, goods[i].SkladNum, goods[i].ShelfLife);
            }
            Console.WriteLine("\n");
        }
        public static bool SortName(Product goods1, Product goods2)
        {
            for (int i = 0; i < (goods1.Name.Length > goods2.Name.Length ? goods2.Name.Length : goods1.Name.Length); i++)
            {
                if (goods1.Name.ToCharArray()[i] < goods2.Name.ToCharArray()[i]) return false;
                if (goods1.Name.ToCharArray()[i] > goods2.Name.ToCharArray()[i]) return true;
            }
            return false;
        }
        public static bool SortPrice(Product goods1, Product goods2)
        {
         if (goods1.Price > goods2.Price) return true;       
         return false;
        }
        public static bool SortSkladNum(Product goods1, Product goods2)
        {
            if (goods1.SkladNum < goods2.SkladNum) return true;
            return false;
        }
        public static bool SortShelfLife(Product goods1, Product goods2)
        {
            /* string s1 = goods1.ShelfLife.ToString();
             string s2 = goods2.ShelfLife.ToString();
             int pos1 = s1.LastIndexOf(' ');
             int pos2 = s2.LastIndexOf(' ');
             int[] date1 = Array.ConvertAll<string, int>(s1.Substring(0, pos1).Split('.'), int.Parse);
             int[] date2 = Array.ConvertAll<string, int>(s2.Substring(0, pos2).Split('.'), int.Parse);
             if ((date1[0] > date2[0] && date1[1] >= date2[1] && date1[2] >= date2[2]) || (date1[1] > date2[1] && date1[2] >= date2[2]) || (date1[2] > date2[2]))
             {
                 return false;
             }
             else return true;*/
             if (goods1.ShelfLife.CompareTo(goods2.ShelfLife) > 0){
                return true;
            }
            return false;

        }
        public static Product[] Sort(Product[] goods, Sort sort)
        {
            for (int i = 0; i < goods.Length; i++)
            {
                for (int j = 0; j < goods.Length - 1; j++)
                {
                    if (sort(goods[j], goods[j + 1]))
                    {
                        Product s = goods[j];
                        goods[j] = goods[j + 1];
                        goods[j + 1] = s;
                    }
                }
            }
            return goods;
        }
        public static void SelectSort(Product[] goods)
        {
            Sort sortName = (x, y) => SortName(x, y);
            Sort sortPrice = (x, y) => SortPrice(x, y);
            Sort sortSkladNum = (x, y) => SortSkladNum(x, y);
            Sort sortShelfLife = (x, y) => SortShelfLife(x, y);
        reroll:
            Console.Clear();
            Console.WriteLine(" 1. Sort by name ");
            Console.WriteLine(" 2. Sort by price ");
            Console.WriteLine(" 3. Sort by stock quantity ");
            Console.WriteLine(" 4. Sort by expiration date ");
            Console.WriteLine(" 5. Exit\n");
            Console.WriteLine(" Select operation ");
            Console.Write(" Select: "); int Object = Convert.ToInt32(Console.ReadLine());
            switch (Object)
            {
                case 1:
                    ShowGoods(Sort(goods, sortName));
                    break;
                case 2:
                    ShowGoods(Sort(goods, sortPrice));
                    break;
                case 3:
                    ShowGoods(Sort(goods, sortSkladNum));
                    break;
                case 4:
                    ShowGoods(Sort(goods, sortShelfLife));
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(" Wrong number");
                    goto reroll;
            }
            Console.ReadLine();
            SelectSort(goods);
        }
        static void Main(string[] args)
        {
            Product[] goods = new Product[8];
            goods[0] = new Product("Potatoes  ", 78.9, 10, new DateTime(2018, 4, 07));
            goods[1] = new Product("Carrot  ", 56.9, 54, new DateTime(2015, 5, 13));
            goods[2] = new Product("Cabbage   ", 567.9, 25, new DateTime(2019, 8, 09));
            goods[3] = new Product("Pizza     ", 27.9, 325, new DateTime(2019, 3, 31));
            goods[4] = new Product("Rice      ", 25.9, 23, new DateTime(2018, 1, 03));
            goods[5] = new Product("Bread     ", 32.9, 789, new DateTime(2015, 4, 24));
            goods[6] = new Product("Meat      ", 967.9, 254, new DateTime(2019, 2, 20));
            goods[7] = new Product("Cabi      ", 102.9, 12, new DateTime(2017, 1, 30));
            SelectSort(goods);
            Console.ReadKey();
        }
    }
}
