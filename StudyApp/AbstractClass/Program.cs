using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{

    abstract class AbstractBase
    {
        protected void ProtectedMethodA()
        {
            WriteLine("AbstractBase.ProtectedMethodA()");
        }

        public void PubicMethodA()
        {
            WriteLine("AbstractBase.PublicMethodA()");
        }

        public abstract void AbstractedMethodA();
    }

    class Derived : AbstractBase
    {
        public override void AbstractedMethodA()
        {
            WriteLine("Drived.AbstractedMethodA()");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AbstractBase obj = new Derived();
            obj.PubicMethodA();
            obj.AbstractedMethodA();
        }
    }
}
