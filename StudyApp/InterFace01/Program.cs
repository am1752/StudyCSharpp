using System;
using static System.Console;
using System.IO;

namespace InterFace01
{

    interface ILogger
    {
        void WriteLog(string message);
    }

    class ConsoleLogger : ILogger
    {
        public void WriteLog(string message)
        {
            WriteLine($"{DateTime.Now.ToLocalTime()},{message}");
        }
    }

    class FileLogger : ILogger
    {
        private StreamWriter writer;

        public FileLogger(string path)
        {
            writer = File.CreateText(path);
            writer.AutoFlush = true;
        }

        public void WriteLog(string message)
        {
            WriteLine($"{DateTime.Now.ToLocalTime()},{message}");
        }
    }

    class ClimateMonitor
    {
        private ILogger logger;

        public ClimateMonitor(ILogger logger)
        {
            this.logger = logger;
        }

        public void start()
        {
            while (true)
            {
                Write("온도 입력 : ");
                string temp = ReadLine();
                if (temp == "q") break;

                logger.WriteLog("현재 온도 : " + temp);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ClimateMonitor monitor = new ClimateMonitor(
                new FileLogger("Climate.log"));
            monitor.start();
        }
        
    }
}
