using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BasicClass
{
    class Cat
    {
        public string Name;
        public Color Color;

        public Cat()
        {
            Name = "";
            Color = Color.Transparent;
        }

        ~Cat()
        {
            WriteLine("End");
        }

        public Cat(string name, Color color)
        {
            Name = name;
            Color = color;
        }

        public void Meow()
        {
            WriteLine($"{Name}, 야옹~");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cat kitty = new Cat();
            kitty.Name = "키티";
            kitty.Color = Color.Yellow;
            kitty.Meow();
            WriteLine($"{kitty.Name} : {kitty.Color}");

            Cat nero = new Cat("네로", Color.Red);
            nero.Meow();
            WriteLine($"{nero.Name} : {nero.Color}");
        }
    }
}
