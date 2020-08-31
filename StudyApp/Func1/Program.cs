using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Func1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            //Func<int> func1 = () => { return 10; }; //Func<int> func1 = () => 10;
            //WriteLine($"func1() = {func1()}");

            //Func<int, int> func2 = (x) => { return x * 2; };

            //WriteLine($"func2() = {func2(4)}");

            //try
            //{
            //    Func<double, double, int> func3 = (x, y) => {
            //        if (y == 0) throw new Exception("Divide by Zero");
            //        return (int)(x / y);
            //    };
            //    WriteLine($"func3() = {func3(20, 4)}");

            //}
            //catch (Exception ex)
            //{

            //    WriteLine("ERR");
            //}

            #endregion

            Action act1 = () => { WriteLine("act1()"); };
            act1();

            int result = 0;
            Action<int> act2 = (x) => result = x * x;

            Action<double, double> act3 = (x, y) =>
              {
                  double pi = x / y;
                  WriteLine($"Action<T1, T2>({x}, {y}) = {pi}");
              };

            act3(27.0, 7.0);

        }
    }
}
