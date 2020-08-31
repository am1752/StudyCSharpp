using System;
using static System.Console;


namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("수 입력 : ");
            string input = ReadLine();
            double arg = Convert.ToDouble(input);

            WriteLine($"결과 : {Square(arg)}");
        }

        private static object Square(double arg)
        {
            return arg * arg;            
        }
    }
}
