using static System.Console;

namespace IntegerType
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            sbyte a = sbyte.MaxValue;
            byte b = byte.MinValue;

            short c = short.MinValue;
            ushort d = ushort.MaxValue;

            int e = int.MaxValue;
            uint f = uint.MinValue;

            long g = long.MaxValue;
            ulong h = ulong.MaxValue;
            ulong i = 200_000_000_000;

            WriteLine($"sbyte Max : {a}, byte Min : {b}, short Min : {c}, ushort Max : {d}");
            WriteLine($"int Max : {e}, uint Min : {f}, long max : {g}, ulong : {h}");
            WriteLine(i);
            */

            byte a = 255;
            WriteLine($"a = {a}");

            byte b = 0b1111_1111;
            WriteLine($"b = {b}");

            byte c = 0xFF;
            WriteLine($"c = {c}");


        }
    }
}
