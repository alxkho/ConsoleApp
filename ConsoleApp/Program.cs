using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name ");
            var name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}!");
            Console.ReadLine();
        }
    }
}
