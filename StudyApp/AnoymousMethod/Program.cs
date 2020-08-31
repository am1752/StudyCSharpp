using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnoymousMethod
{
    delegate int Compare<T>(T a, T b);

    class Program
    {
        static void BubbleSort<T>(T[] DataSet, Compare<T> Comparer)
        {
            int i = 0, j = 0;
            T temp;
            for (i = 0; i < DataSet.Length - 1; i++)
            {
                for (j = 0; j < DataSet.Length - (i + 1); j++)
                {
                    if (Comparer(DataSet[j], DataSet[j + 1]) > 0)
                    {
                        temp = DataSet[j];
                        DataSet[j] = DataSet[j + 1];
                        DataSet[j + 1] = temp;

                    }
                }

            }
        }

        static void Main(string[] args)
        {
            int[] array = { 3, 7, 4, 2, 10 };

            WriteLine("Sorting Ascending...");
            BubbleSort<int>(array, delegate (int a, int b)
             {
                 return a.CompareTo(b);
             });

            foreach (var item in array) Write($"{item} ");

            WriteLine();
        }
    }
}
