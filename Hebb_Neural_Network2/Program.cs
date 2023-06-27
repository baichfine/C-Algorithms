using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hebb_Neural_Network2
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
            int y1 = 0, y2 = -1, S1, S2;
            while (y1 == 0 || y2 == -1)
            {
                Ves(w, k);
                Ves(w, r);
                S1 = Ostanov(w, k);
                S2 = Ostanov(w, r);
                if (S1 > 0) { y1 = 1; Console.WriteLine(" Letter K " + S1); }
                if (S2 < 0) { y2 = 0; Console.WriteLine(" Letter R " + S2); }
            }

        }

        public static void Ves(int[] w, Letter let)
        {
            int dw, x0=1;
            if ((x0 * let.kor) == 1) dw = 1;
            else if (x0 != 0 && let.kor == 0) dw = -1;
            else dw = 0;
            w[0] = w[0] + dw;
            Console.Write(w[0] + " ");
            for (int i = 1; i <= let.code.Length; i++)
            {
                if ((let.code[i - 1] * let.kor) == 1) dw = 1;
                else if (let.code[i - 1] != 0 && let.kor == 0) dw = -1;
                else  dw = 0;
                w[i] = w[i] + dw;
                Console.Write(w[i] + " ");
            }
            Console.WriteLine();
        }

        public static int Ostanov(int[] w, Letter let)
        {
            int S = 0;
            for (int i = 1; i < let.code.Length; i++)
            {
                S += let.code[i - 1] * w[i];
            }
            S += w[0];
            return S;
        }

        static void Main(string[] args)
        {
            int[] code1 = { 1, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
            int[] code2 = { 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0 };
            Letter k = new Letter(code1, 1);
            Letter r = new Letter(code2, 0);
            Progon(k, r);
            Console.ReadKey();

        }
    }
}

