using static System.Console;

namespace NullableApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int? a = null;
            double? b = null;
            float? c = null;
            string s = null;
            
            
            WriteLine(a.HasValue);
            //            WriteLine(a.Value); a가 null이므로 에러

            if (a.HasValue) WriteLine(a.Value);
            else WriteLine("a값은 null 입니다.");
            WriteLine(b == null);
            WriteLine(c.HasValue);
            WriteLine(string.IsNullOrEmpty(s)); //s == Null || s == ""
            WriteLine(string.IsNullOrWhiteSpace(s));//s == Null s == " "

            c = 3.14592F;

            if (c.HasValue) WriteLine($"c = {c}");

        }
    }
}
