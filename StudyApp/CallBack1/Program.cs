﻿using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallBack1
{
    delegate int Compare(int a, int b);
    class Program
    {
        static int Ascend(int a,int b)
        {
            if (a > b) return 1;
            else if (a == b) return 0;
            else return -1;
        }

        static int Descend(int a, int b)
        {
            if (a < b) return 1;
            else if (a == b) return 0;
            else return -1;
        }

        static void BubbleSort(int[] DataSet, Compare Comparer)
        {
            int i = 0;
            int j = 0;
            int temp = 0;

            for(i = 0; i < DataSet.Length - 1; i++)
            {
                for (j = 0; j < DataSet.Length - (i + 1); j++)
                {
                    if(Comparer(DataSet[j],DataSet[j+1]) > 0)
                    {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int[] array = { 3, 7, 4, 2, 10 };

            WriteLine("Sorting ascending...");
            BubbleSort(array, new Compare(Ascend));

            for (int i = 0; i < array.Length; i++) Write($"{array[i]} ");

            int[] array2 = { 7, 2, 8, 10, 11 };
            WriteLine("\nSorting descending...");
            BubbleSort(array2, new Compare(Descend));

            for (int i = 0; i < array2.Length; i++) Write($"{array2[i]} ");

            WriteLine();
        }
    }
}
