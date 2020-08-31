using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = ("슈퍼맨", 999);
            WriteLine($"{a.Item1},{a.Item2}");

            var b = (Name: "박서준", Age: 33, HOME : "서울");
            WriteLine($"{b.Age}, {b.Name}, {b.HOME}");

        }
    }
}
