using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    delegate int MyDelegate(int a, int b);

    class Calculator
    {
        public int Plus(int a, int b)
        {
            return a + b;
        }

        public int minus(int a,int b)
        {
            return a - b;
        }

        
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            Calculator Calc = new Calculator();
            MyDelegate Callback;

            Callback = new MyDelegate(Calc.Plus);
            WriteLine(Callback(3, 4));

            Callback = new MyDelegate(Calc.minus);
            WriteLine(Callback(7,5));

        }
    }
}
