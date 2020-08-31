using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Parent
    {
        protected string Name { get; set; }

        public Parent(string name)
        {
            Name = name;
            WriteLine($"{Name}.Base()");
        }

        public void BaseMethod()
        {
            WriteLine($"{Name}.BaseMethod()");
        }
    }

    class Child : Parent
    {
        public Child(string name) : base(name)
        {
            WriteLine($"{this.Name}.Child()");
        }

        public void DeriveMethod()
        {
            base.BaseMethod();
            WriteLine($"{Name}.DerivedMethod()");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Parent p = new Parent("p");
            p.BaseMethod();
            WriteLine("----------------");
            Child c = new Child("C");
            c.BaseMethod();
            WriteLine("----------------");
            c.DeriveMethod();
        }
    }
}
