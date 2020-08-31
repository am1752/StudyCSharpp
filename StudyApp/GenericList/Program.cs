using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> intList = new List<int>();
            for (int i = 0; i < 5; i++) intList.Add(i);


            foreach (int e in intList) WriteLine(e);
        }
    }
}
