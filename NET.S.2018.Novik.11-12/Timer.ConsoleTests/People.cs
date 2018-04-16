using System;
using System.Collections.Generic;
using Logic.Clock;

namespace Timer.ConsoleTests
{
    class People
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void GetUp(object sender, RingEventArgs args)
        {
            Console.WriteLine($"{this.Name}, get up! You need to go to school");
        }

        
    }
}
