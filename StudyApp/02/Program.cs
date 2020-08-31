using System;
using System.Diagnostics.CodeAnalysis;
using static System.Console;


namespace _02
{
    
    class Program
    {
        static void Main(string[] args)
        {
            double mean = 0;

            Mean(1, 2, 3, 4, 5,out mean);

            WriteLine($"평균 : {mean}");
        }

        public static void Mean(double a,double b,double c ,double d, double e ,out double mean)
        {
            mean = (a + b + c + d + e) / 5; 
        }
    }
}
