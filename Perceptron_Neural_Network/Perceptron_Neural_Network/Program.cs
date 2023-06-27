using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron_Neural_Network
{
    class Letter
    {
        int[] code;
        int[] Aelements;
        int[] Xelements;
        int reaction;
        public Letter(int[] code, int reaction, int[] Aelements, int[] Xelements)
        {
            this.code = code;
            this.Aelements = Aelements;
            this.Xelements = Xelements;
            this.reaction = reaction;
        }

        public static void Progon(Letter t, Letter n)
        {
            int[] w = { 0, 0 };
            int React1=0, React2=0, i=1;
            t.Aelements = SumA(t);
            n.Aelements = SumA(n);

            while (React1 != t.reaction || React2 != n.reaction)
            {
                Console.WriteLine("\n\t\t Iteration N" + i + "\n Starting WEIGHTS: ");
                React1 = Reaction(t, w);         
                React2 = Reaction(n, w);
                i++;
            }
            Console.WriteLine("\n Learning to recognize the letters K and P is completed! ");
        }
        public static int Reaction(Letter l, int[] w)
        {
            int R, Or = 0;
            R = Iteration(l, w);
            if (R > Or) R = 1;
            else R = -1;
            if (R < l.reaction)
            {
                for (int i = 0; i < 2; i++) if (l.Xelements[i] > 0) w[i] = w[i] + 1;
            }
            else if (R > l.reaction)
            {
                for (int i = 0; i < 2; i++) if (l.Xelements[i] > 0) w[i] = w[i] - 1;
            }
            Console.WriteLine("\n Reaction of neuron: " + R + " Need reaction: " + l.reaction);
            if (R != l.reaction) Console.WriteLine(" WEIGHTS have changed: " + w[0] + " " + w[1]);
            else Console.WriteLine(" WEIGHTS have not changed: " + w[0] + " " + w[1]);
            return R;
        }
        public static int Iteration(Letter l, int[] w)
        {
            int Oa = 0, S=0;
            for (int i=0; i<2; i++)
            {
                if (l.Aelements[i] > Oa) l.Xelements[i] = 1;
                else l.Xelements[i] = 0;
                S += w[i] * l.Xelements[i];
            }
            return S;
        }

        public static int[] SumA(Letter l)
        {
            int[] vesa1 = { -1, 1, 1, -1, -1, -1, 1, 1, 1, 1, 1, 1, 1, 0, 1, -1 };
            int[] vesa2 = { 1, 1, 1, 1, 0, 1, -1, 1, -1, 1, 1, 1, 1, 0, 1, -1 };
            int A1 = 0, A2 =0;
            for (int i=0; i < l.code.Length; i++)
            {
                A1 += l.code[i] * vesa1[i];
                A2 += l.code[i] * vesa2[i];
            }
            int[] A = {A1, A2};
            Console.WriteLine(A1 + " " + A2);
            return A;
        }

        static void Main(string[] args)
        {
            int[] code1 = { 1, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
            int[] code2 = { 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0 };
            int[] Aelements = { };
            int[] Xelements = {0, 0};
            Letter t = new Letter(code1, -1, Aelements, Xelements);
            Letter n = new Letter(code2, 1, Aelements, Xelements);
            Progon(t, n);
            Console.ReadKey();
        }
    }
}
