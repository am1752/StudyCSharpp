using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;

namespace SimpleLambda
{
    class Program
    {
        delegate int Calculate(int a, int b);
        delegate string Concatnate(string[] args);
        
        static int Plus(int a,int b)
        {
            return a + b;
        }
        
        static string StrJoin(string[] arr)
        {
            string result = string.Empty;
            foreach (var item in arr)
            {
                result += $"{item}";
            }

            return result;
        }

        static void Main(string[] args)
        {
            Calculate calc = (a, b) => a + b;
            WriteLine(calc(3, 4));


            #region
            //Concatnate concat = (arr) =>
            //{
            //    string result = string.Empty;
            //    foreach (var item in arr)
            //    {
            //        result += $"{item}";
            //    }

            //    return result;
            //};
            #endregion

            Concatnate concat = new Concatnate(StrJoin);

            Write(concat(args));
        }
    }
}
