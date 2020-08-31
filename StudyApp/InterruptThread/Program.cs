using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace InterruptThread
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
                WriteLine("Running Thread isn't gonna be interrupted");
                //Thread.SpinWait(1_000_000_000);

                while (count > 0)
                {
                    WriteLine($"{count--} left");
                    Thread.Sleep(10);
                }
                WriteLine("Count : 0");
            }
            catch (ThreadAbortException e)
            {

                WriteLine(e.Message);
                Thread.ResetAbort();
            }
            catch (ThreadInterruptedException e)
            {

                WriteLine(e.Message);
                
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
            SideTask task = new SideTask(500);

            Thread th = new Thread(new ThreadStart(task.KeepAlive));
            th.IsBackground = false;

            WriteLine();

            th.Start();
            Thread.Sleep(100);
            //th.Interrupt();
            th.Suspend();
            
            Thread.Sleep(3000);
            th.Resume();

            th.Join();
        }
    }
}
