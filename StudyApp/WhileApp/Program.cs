using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhileApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List <string> strings = new List<string>();
            strings.Add("Hello");
            strings.Add("Bye");
            strings.Add("Hey~");

            List<string> subs = new List<string> {"Banana","Apple"};
            strings.AddRange(subs);

            foreach (var i in strings)
            {
                WriteLine(i);
            }
        }
    }
}
