using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwithCaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            object obj = null;
            string s = ReadLine();
            if (int.TryParse(s, out int out_i)) obj = out_i;
            else if (float.TryParse(s,out float out_f)) obj = out_f;
            else obj = s;

            switch (obj)
            {
                case int i:
                    WriteLine($"{i}는 정수");
                    break;
                case float i:
                    WriteLine($"{i}는 실수");
                    break;
                default:
                    break;
            }
        }
    }
}
