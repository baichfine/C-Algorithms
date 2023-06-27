using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hebb_Neural_Network
{
    class Letter
    {
        int[] code;
        int kor;
        public Letter(int[] code, int kor)
        {
            this.code = code;
            this.kor = kor;
        }

        public static void Progon(Letter k, Letter r)
        {
            int[] w = new int[k.code.Length + 1];
            int y1 = 0, y2 = 0, S1, S2;
            while (y1 == 0 || y2 == 0)
            {
                w[0] = w[0] + 1 * k.kor; Ves(w, k);
                w[0] = w[0] + 1 * r.kor; Ves(w, r);
                S1 = Ostanov(w, k);
                S2 = Ostanov(w, r);
                if (S1 > 0) { y1 = 1; Console.WriteLine(" Letter K " + S1 ); }
                if (S2 < 0) { y2 = -1; Console.WriteLine(" Letter R " + S2); }
            }

        }

        public static void Ves(int[] w, Letter let)
        {
            for (int i = 1; i <= let.code.Length; i++)
            {
                w[i] = w[i] + let.code[i - 1] * let.kor;
                Console.Write(w[i] + " ");
            }
            Console.WriteLine();
        }

        public static int Ostanov(int[] w, Letter let)
        {
            int S = 0;
            for (int i =1; i < let.code.Length; i++)
            {
                S += let.code[i - 1] * w[i];
            }
            S += w[0];
            return S;
        }

        static void Main(string[] args)
        {
            int[] code1 = { 1, -1, 1, 1, 1, 1, -1, -1, 1, -1, 1, -1, 1, -1, 1, 1 };
            int[] code2 = { 1, 1, 1, -1, 1, -1, -1, 1, 1, 1, 1, -1, 1, -1, -1, -1 };
            Letter k = new Letter(code1, 1);
            Letter r = new Letter(code2, -1);
            Progon(k, r);
            Console.ReadKey();

        }
    }
}
