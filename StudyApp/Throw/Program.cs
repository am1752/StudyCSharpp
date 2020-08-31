using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Throw
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DoSomething(1);
                DoSomething(2);
                DoSomething(9);
                DoSomething(12);
            }
            catch (Exception ex)
            {
                WriteLine($"예외발생: {ex.Message}");
                WriteLine($"{ex.HelpLink} {ex.Source}");
            }
            finally
            {
                WriteLine("에러가 있든 없든 수행합니다.");
            }
        }

        private static void DoSomething(int arg)
        {
            if (arg < 10) WriteLine($"arg : {arg}");
            else
                throw new Exception("arg가 10보다 큼")
                {
                    HelpLink = "www.naver.com",
                    Source = "UsingThrow line 34"
                };
        }
    }

    
}
