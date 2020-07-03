using System;
using static System.Console;

namespace StringNumberConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            const int z = 20;
            //z = 21 값 const 이므로 못 바꿈

            int a = 12345;
            string b = a.ToString();
            WriteLine($"b = {b}");

            float c = 3.141592f;
            string d = c.ToString();
            WriteLine($"d = {d}");

            //string e = "12345";
            //int f = Convert.ToInt32(e);
            int f = 0;
            string e = "123456*";
            //bool result = int.TryParse(e,out f);
            //WriteLine($"result = {result}");
            //WriteLine($"f = {f}");

            if (int.TryParse(e, out f)) WriteLine($"f = {f}"); //TryParse 성공유무(반환값)에 따라 f값이 바뀌므로 out로 선언!!
            else WriteLine("f 변환시 에러발생, 문자열 확인요망!!");

            //string g = "3.141592";
            //float h = float.Parse(g);

            string g = "3:141592";
            float h;
            if(float.TryParse(g,out h)) WriteLine($"h = {h}");
            else WriteLine("h 변환시 에러발생, 문자열 확인요망!!");
        }
    }
}
