using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Logic.Clock;

namespace Timer.ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            CoCoClock clock = new CoCoClock();
            clock.Ring += Clock_Ring;
            Thread thread = new Thread (() => clock.Set(new TimeSpan(1,0,0)));
            thread.Priority = ThreadPriority.Lowest;
            thread.Start();
            while (true)
            {
                Console.WriteLine("something doing");
                Thread.Sleep(10);
            }

        }

        private static void Clock_Ring(object sender, RingEventArgs e)
        {
            Console.WriteLine($"{e.Time.Milliseconds} is gone. {e.Message}");
        }
    }
}
