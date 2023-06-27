using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Charp11
{
    public delegate void Del(object sender, DelEventArgs e);
    public class DelEventArgs
    {
        public int Number { get; set; }
        public int PingScore { get; set; }
        public int PongScore { get; set; }
        public DelEventArgs(int number, int pingScore, int pongScore)
        {
            Number = number;
            PingScore = pingScore;
            PongScore = pongScore;
        }
    }
    class Ping
    {
        public event Del ping;
        public void PingOops(int PingScore, int PongScore)
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 10); if (ping != null) ping(this, new DelEventArgs(number, PingScore, PongScore));
        }
        public void OnPing(object sender, DelEventArgs e)
        {   // Обработчик соб-я

            if (e.Number > 5) Console.WriteLine("\nPing beat off the pong!  Ping {0} {1} Pong", e.PingScore, e.PongScore);
            else {
                e.PongScore++;
                Console.WriteLine("\nPong hit ping! \t\t Ping {0} {1} Pong", e.PingScore, e.PongScore);
            }
            if (e.PongScore == 15)
            {
                Console.WriteLine("\n\t\tPong Won!\n ");
            }
            else {
                Thread.Sleep(1000);
                PingOops(e.PingScore, e.PongScore);
            }
        }

    }
    class Pong
    {
        public bool p = false;
        public event Del pong;
        public void PongOops(int PingScore, int PongScore)
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 10); if (pong != null) pong(this, new DelEventArgs(number, PingScore, PongScore));
        }
        public void OnPong(object sender, DelEventArgs e)
        {   // Обработчик соб-я
            if (e.Number > 5) Console.WriteLine("\nPong beat off the ping!  Ping {0} {1} Pong", e.PingScore, e.PongScore);
            else {
                e.PingScore++; p = true;
                Console.WriteLine("\nPing hit pong! \t\t Ping {0} {1} Pong", e.PingScore, e.PongScore);
            }
            if (e.PingScore == 15)
            {
                Console.WriteLine("\n\t\tPing Won!\n ");
            }
            else {
                Thread.Sleep(1000);
                PongOops(e.PingScore, e.PongScore);
            }
        }

        public bool PlusOne()
        {
            return p;
        }
    }
    class PingPong
    {
        static void Main(string[] args)
        {
            int s = 0;
            Ping pi = new Ping();
            Pong po = new Pong();
            pi.ping += po.OnPong;
            pi.PingOops(0, 0);
            if (po.PlusOne() == true) s = 1;
            po.pong += pi.OnPing;
            po.PongOops(s, 0);
            Console.ReadKey();
        }
    }
}
