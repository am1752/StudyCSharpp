using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverLoading
{
    class Program
    {

        /// <summary>
        /// 두 수 정수 덧셈을 구함
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int Plus(int a,int b)
        {
            return a + b;
        }

        /// <summary>
        /// 세 수 정수 덧셈을 구함
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>

        static int Plus(int a,int b,int c)
        {
            return a + b + c;
        }


        /// <summary>
        /// 두 수 double 덧셈을 구함
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>

        static double Plus(double a,double b)
        {
            return a + b;
        }


        /// <summary>
        /// 세 수 double 덧셈을 구함
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>

        static double Plus(double a,double b,double c)
        {
            return a + b + c;
        }

        /// <summary>
        /// 두 수 float 덧셈을 구함
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>

        static float Plus(float a, float b)
        {
            return a + b;
        }

        /// <summary>
        /// 세 수 float 덧셈을 구함
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>

        static float Plus(float a, float b, float c)
        {
            return a + b + c;
        }

        /// <summary>
        /// double + int 구함
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>

        static double Plus(double a,int b)
        {
            return a + b;
        }

        static int Sum(params int[] args)
        {
            int sum = 0;
            foreach (var item in args)
            {
                sum += item;
            }

            return sum;
        }

        static void MyMethod(string arg1 = "", string arg2 = "")
        {
            WriteLine("MyMethod A");
        }

        static void MyMethod()
        {
            WriteLine("MyMethod B");
        }
           
        static void Main(string[] args)
        {
            /*WriteLine(Plus(6,7));
            WriteLine(Plus(6.8f, 7.5f));
            WriteLine(Plus(5.4, 6));
            */

            //int sum = Sum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            //WriteLine($"sum = {sum}");


            MyMethod();
            MyMethod("HI", "Hello");
        }
    }
}
