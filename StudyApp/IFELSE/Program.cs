using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFELSE
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("숫자 입력 : ");
            string input = ReadLine();
            int number;
            if (int.TryParse(input, out number)) WriteLine(number);
            else WriteLine("숫자 ㄴㄴ");
            
        }
    }
}
