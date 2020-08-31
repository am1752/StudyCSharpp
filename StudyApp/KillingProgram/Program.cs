using System;

namespace KillingProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 };
            int x = 100, y = 0;

            try
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(arr[i]);
                }
                Console.WriteLine($"{x / y}");

                string origin = "RR";
                int Val = int.Parse(origin);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"인덱스 범위를 벗어났습니다.");
                ex.HelpLink = "https://docs.microsoft.com/ko-kr/dotnet/api/system.indexoutofrangeexception?view=netcore-3.1";
                Console.WriteLine($"도움말 링크 : {ex.HelpLink}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"예외발생: {ex.Message}");
            }

            catch(Exception ex)
            {
                Console.WriteLine($"에러 : {ex.Message}");

            }
        }
    }
}