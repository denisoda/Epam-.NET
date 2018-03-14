using System;

/// <summary>
/// assembly that uses external module
/// </summary>
namespace MultiFileAssembly
{
    public class App
    {
        public static void Main()
        {
            SomeActionWithCar();
        }

        public static void SomeActionWithCar()
        {
            Car lamborgine = new Car() { Name = "Lamborgine", Speed = 10 };
            Console.WriteLine("*******SOME INFORMATION ABOUT CAR********");
            Console.WriteLine(lamborgine);
            Console.WriteLine("*******TRY TO GO ON********");
            lamborgine.Run();
        }
    }

    
}
