using System;

/// <summary>
/// this class will transofamation into externel module
/// </summary>
    public class Car
    {
        public string Name { get; set; }
        public double Speed { get; set; }
        
        public void Run()
        {
            Console.WriteLine("tuuuuu-tuuuu");
        }
    
        public override string ToString()
        {
            return $"{this.Name}: {this.Speed}";
        }
    }
