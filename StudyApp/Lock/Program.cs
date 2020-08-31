using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lock
{
    class Counter
    {
        const int LOOP_COUNT = 1000;

        readonly object thisLock;

        public int Count { get; set; }

        public Counter()
        {
            thisLock = new object();
            Count = 0;
        }

        public void Increased()
        {
            int loopcount = LOOP_COUNT;
            while (loopcount-- > 0)
            {
                lock (thisLock)
                {
                    Count++;
                    WriteLine($"Inc : {Count}");
                }
                Thread.Sleep(1);

            }

        }

        public void Decreased()
        {
            int loopcount = LOOP_COUNT;
            while (loopcount-- > 0)
            {
                lock (thisLock)
                {
                    Count--;
                    WriteLine($"Dec : {Count}");
                }
                Thread.Sleep(1);

            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();

            Thread incThread = new Thread(new ThreadStart(counter.Increased));
            Thread decThread = new Thread(new ThreadStart(counter.Decreased));

            incThread.Start();
            decThread.Start();

            incThread.Join();
            decThread.Join();
        }
    }
}
