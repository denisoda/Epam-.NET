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
            People vasya = new People() { Name = "Vasya", Age = 13 };

            clock.Ring += Clock_Ring;
            clock.Ring += vasya.GetUp;

            clock.Set(new TimeSpan(0, 0, 30));
            //var ar = action.BeginInvoke(null, null);
            //while (!ar.IsCompleted)
            //{
            //    Console.WriteLine("sleeeeeep");
            //}
        }

        private static void Clock_Ring(object sender, RingEventArgs e)
        {
            Console.WriteLine($"\t{e.Time.ToString()} is gone. {e.Message}");
        }
    }
}
