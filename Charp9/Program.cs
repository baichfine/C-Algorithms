using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charp9
{
    delegate double Fx(double x);
    class MethodInHalf
    {
        public static double Func1(double x)
        {
            return x+1;
        }
        public static double Func2(double x)
        {
            return 8*x - 16;
        }
        public static void Solution( Fx fx)
        {
            const double eps = 0.0001;
            double a, b, t, f1, f2, x;
            Console.WriteLine(" Enter the segment where the root of the equation is supposedly located!");
            Console.Write(" Enter a = "); a = Convert.ToDouble(Console.ReadLine());
            Console.Write(" Enter b = "); b = Convert.ToDouble(Console.ReadLine());
            do
            {
                f1 = fx(a);
                t = (a + b) / 2.0;
                f2 = fx(t);
                if (f1 * f2 <= 0) b = t;
                else a = t;
            }
            while (Math.Abs(b - a) > eps);
            x = (a + b) / 2.0;
            f1 = fx(x);
            if (Math.Abs(f1) <= 0.0001)
            {
                Console.WriteLine(" \nThe root of the equation with error " + eps + ", X = " + x );
                Console.WriteLine(" \nFunction value F(X) = " + f1);
            }
            else Console.WriteLine(" In this segment, the root equation does not have!");
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
            Fx fx1 = (x) => Func1(x);
            Fx fx2 = (x) => Func2(x);
            Solution(fx1);
            Solution(fx2);
            Console.ReadKey();
        }
    }
}
