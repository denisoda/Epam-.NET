using System;
using System.Reflection;

[assembly: AssemblyKeyFile("keys.snk")]
namespace StrongAssembly
{
    public class App
    {
        public static void Main()
        {
            
        }

        public override string ToString()
        {
            return "i'm located in a assembly called strong name";
        }
    }
}
