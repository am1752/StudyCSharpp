using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace UsingarrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();


            for (int i = 0; i < 10; i++) list.Add(i);

            for (int i = 0; i < 10; i++) Write($"{list[i]} ");
            WriteLine();

            list.RemoveAt(2);

            list.Insert(7, 5);

            for (int i = 0; i < 10; i++) Write($"{list[i]} ");
            WriteLine();
        }
    }
}
