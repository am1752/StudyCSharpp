using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Runtime.CompilerServices;

namespace SWAPByValue
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            
            int x = 3;
            int y = 4;



            WriteLine($"x = {x} , y = {y}");

            SWAP(ref x,ref y);

            WriteLine($"x = {x} , y = {y}");
        }

        private static void SWAP(ref int a,ref int b)//ref 참조함수로 주소값 참조
        {

            int temp = a;
            a = b;
            b = temp;
        }
    }
}
