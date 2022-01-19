using System;
using System.Threading;
using System.Timers;

namespace MURPHY_Benoit_TP3_ST2TRD
{
    public class Ex2
    {
        private static Mutex m = new Mutex();
        private const int nbIt = 1;
        private const int nbThreads = 3;
        public static System.Threading.Timer timer1;

        public static void Space()
        {
            Thread emptySpace = new Thread(new ThreadStart(() => Threadbis(' ', 50))); 
            emptySpace.Start();
            emptySpace.Join(10000);

            Thread star = new Thread(new ThreadStart(() => Threadbis('*', 40)));
            star.Start();
            star.Join(11000);

            Thread comma = new Thread(new ThreadStart(() => Threadbis('°', 20)));
            comma.Start();
            comma.Join(9000);

            Thread.Sleep(11000);

            static void Threadbis(char a, double p)
            {
                var start = TimeSpan.Zero;
                var period = TimeSpan.FromMilliseconds(p);

                var t = new System.Threading.Timer((e) => { UseResource(a); }, null, start, period);
            }

            static void UseResource(char x)
            {
                m.WaitOne();
                Console.Write(x);
                m.ReleaseMutex();
            }
        }
    }
}