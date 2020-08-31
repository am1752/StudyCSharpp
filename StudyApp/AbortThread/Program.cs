using static System.Console;
using System.Threading;
using System;

namespace AbortThread
{
    class SideTask
    {
        int count = 0;

        public SideTask(int count)
        {
            this.count = count;
        }

        public void KeepAlive()
        {           
            try
            {
                while (count > 0)
                {
                    WriteLine($"{count--} left");
                    Thread.Sleep(10);
                }
                WriteLine("Count : 0");
            }
            catch (Exception e)
            {

                WriteLine(e.Message);
                Thread.ResetAbort();
            }
            finally
            {
                WriteLine("Clearing resource...");
            }
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            SideTask task = new SideTask(1000);

            Thread th = new Thread(new ThreadStart(task.KeepAlive));
            th.IsBackground = false;

            WriteLine();
           
            th.Start();
            Thread.Sleep(100);
            th.Abort();
            th.Join();
        }
    }
}
