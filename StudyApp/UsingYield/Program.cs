using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace UsingYield
{
    class MyEumerator
    {
        int[] numbers = { 1, 2, 3, 4, 5 };

        public IEnumerator GetEnumerator()
        {
            yield return numbers[0];
            yield return numbers[1];
            yield return numbers[2];
            yield break;
            yield return numbers[3];
            yield return numbers[4];
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new MyEumerator();

            foreach (int i in obj) WriteLine(i);

        }
    }
}
