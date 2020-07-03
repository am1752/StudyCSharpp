using static System.Console;
/// <summary>
/// HelloApp 네임스페이스
/// </summary>


namespace HelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int val = 0;
            if(args.Length == 0)
            {
                WriteLine("ex : HelloApp.exe <이름>");
                return;
            }
            WriteLine($"Hello, {args[0]}!");
        }
    }
}
