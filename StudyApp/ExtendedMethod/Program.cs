using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExtension;


namespace ExtendedMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"3^2 : {3.Square()}");
            WriteLine($"2^3 : {2.Power(3)}");
            WriteLine($"2^10 : {2.Power(10)}");

        }
    }
}
