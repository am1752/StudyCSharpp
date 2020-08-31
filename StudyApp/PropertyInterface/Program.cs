using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyInterface
{
    interface INamedValue
    {
        string Name { get; set; }
        string Value { get; set; }
        string GetOtherValue();
    }

    class NamedValue : INamedValue
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public string GetOtherValue()
        {
            return "Value";
        }
    }

    abstract class Product
    {
        private static int Serial = 0;

        public string SerialID
        {
            get { return String.Format($"{Serial++:d5}"); }
        }

        abstract public DateTime ProductDate { get; set; }
    }

    class MyProdcut : Product
    {
        public override DateTime ProductDate { get; set; }
    }
}

namespace PropertyInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            NamedValue name = new NamedValue
            {
                Name = "이름",
                Value = "성면건"

            };

            NamedValue height = new NamedValue
            {
                Name = "키",
                Value = "180cm"

            };

            NamedValue weight = new NamedValue
            {
                Name = "몸무게",
                Value = "75kg"

            };


        }
    }
}
