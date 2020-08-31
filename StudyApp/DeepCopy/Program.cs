using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepCopy
{
    class MyClass
    {
        public int MyField1;
        public int MyField2;

        public MyClass DCopy()
        {
            MyClass newcopy = new MyClass
            {
                MyField1 = MyField1,
                MyField2 = MyField2
            };
            return newcopy;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Shallow Copy");
            {
                MyClass source = new MyClass
                {
                    MyField1 = 10,
                    MyField2 = 20
                };
                MyClass target = source.DCopy();
                target.MyField2 = 300;
                WriteLine($"{source.MyField1},{source.MyField2}");
                WriteLine($"{target.MyField1},{target.MyField2}");
            }

            


        }


    }
}
