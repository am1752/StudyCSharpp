using System;
using System.CodeDom;
using System.Globalization;
using static System.Console;

namespace StringSearchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string g = "Good Morning";
            /*WriteLine(g);

            WriteLine($"IndexOf 'Good' : {g.IndexOf("Good")}"); //Indexof는 같은 단어 중복 시 첫 단어 시작점 인덱스 반환 실패시 -1 반환
            WriteLine($"LastIndexof 'Good' : {g.LastIndexOf("Good")}"); //LastIndexof는 같은 단어 중복시 마지막 단어 시작점 인덱스 반환 실패시 -1 반환

            WriteLine($"Indexof 'n' : {g.IndexOf('n')}");
            WriteLine($"LastIndexof 'n' : {g.LastIndexOf('n')}");

            //StartWith
            WriteLine($"StartsWith 'Good' {g.StartsWith("Good")}"); //Good으로 시작하는지 안하는지 판별
            WriteLine($"StartsWith 'Good' {g.StartsWith("Morning")}");

            //Contains
            WriteLine($"Contains 'Good' : {g.Contains("Good")}"); // 포함 여부

            //Replace
            WriteLine($"Replace 'Morning' to 'Evening' : " + $"{g.Replace("Morning", "Evening")}");

            //ToLower ToUpper
            WriteLine($"ToLower : {g.ToLower()}");
            WriteLine($"ToUpper : {g.ToUpper()}");

            //Insert
            WriteLine($"Insert : {g.Insert(g.IndexOf("Morning")-1, "nice")}");

            WriteLine($"Remove : '{"I don't Love You.".Remove(2,6)}'");
            WriteLine($"Trim : '{" No Space ".TrimStart()}'");
            WriteLine($"Trim : '{" No Space ".TrimEnd()}'");
            
            //문자열 분할
            string codes = "Good,Nice,Mom,Dad,Hi,Hello";

            var result = codes.Split(',');

            foreach (var code in result)
            {
                WriteLine(code);
            }

            WriteLine($"substring : {g.Substring(0, 4)}");
            WriteLine(g.Substring(5)); //5부터 끝까지
            */

            WriteLine(string.Format("{0}DEF", "ABC"));
            WriteLine(string.Format("{0,10}DEF", "ABC"));
            WriteLine(string.Format("{0,-10}DEF", "ABC"));
            
            DateTime dt = DateTime.Now;
            WriteLine(string.Format("{0:yyyy-MM-dd HH:mm:ss}",dt));
            WriteLine(string.Format("{0: y yy yyy yyyy}",dt));
            WriteLine(string.Format("{0: M MM MMM MMMM}", dt));

            decimal mvalue = 27000000m;
            WriteLine(string.Format("princ {0:C}", mvalue));

            WriteLine(dt.ToString("0:yyyy-MM-dd HH:mm:ss", new CultureInfo("ko-KR")));
            WriteLine(dt.ToString("0:yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US")));
        }


    }
}
 