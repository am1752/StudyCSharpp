using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BasicThread
{
    class Program
    {
        static void DoSomething()
        {
            for (int i = 0; i < 5; i++)
            {
                WriteLine($"DoSomething : {i}");
                Thread.Sleep(1000);
            }
        }

        static void DoAnything()
        {
            for (int i = 0; i < 15; i++)
            {
                WriteLine($"DoAnything : {i}");
                Thread.Sleep(300);
            }
        }

        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(DoSomething));
            Thread thread1 = new Thread(new ThreadStart(DoAnything));

            thread.Start();
            thread1.Start();

            for(int i = 0; i < 5; i++)
            {
                WriteLine($"Main : {i}");
                Thread.Sleep(500);

            }

            thread.Join();
            thread1.Join();
        }
    }
}
