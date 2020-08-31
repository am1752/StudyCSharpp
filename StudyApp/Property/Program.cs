using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property
{
    class BirthdayInfo
    {
        private DateTime birthday;

        public string Name { get; set; }

        public DateTime Birthday
        {
            get
            {
                return birthday;
            }

            set
            {
                if (value.Year >= DateTime.Now.Year) birthday = DateTime.Now;
                else birthday = value;
            }

        }

        public int Age
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(birthday).Ticks).Year+1;
            }
        }

       
    }

    class Program
    {
        static void Main(string[] args)
        {
            BirthdayInfo info = new BirthdayInfo
            {
                Name = "박서준",
                Birthday = new DateTime(1988, 12, 16)
            };

            WriteLine($"{info.Name}은 {info.Birthday} 출생이며 {info.Age}살 입니다.");

        }
    }
}
