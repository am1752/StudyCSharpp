using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usingOut
{
    class Program
    {
        static void Divide(int a,int b,out int quontient, out int remainder)
        {
            quontient = a / b;
            remainder = a % b;
        }
        static void Main(string[] args)
        {
            int a = 20;
            int b = 3;

            Divide(a, b, out int c, out int d);

            WriteLine($"a = {a}, b = {b}, c = {c}, d = {d}");
        }
    }
}
