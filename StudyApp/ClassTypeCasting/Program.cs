using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTypeCasting
{
    class Program
    {
        class Mammal
        {
            public void Nurse()
            {
                WriteLine("Nurse()");
            }
        }

        class Dog : Mammal
        {
            public void Bark()
            {
                WriteLine("Bark()");
            }
        }

        class cat : Mammal
        {
            public void Meow()
            {
                WriteLine("Meow()");
            }
        }

        static void Main(string[] args)
        {
            Mammal mammal = new Dog();
            Dog dog;

            if (mammal is Dog)
            {
                dog = mammal as Dog;
                dog.Bark();
            }
        }
    }
}
