using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overriding
{
    class ArmorSuite
    {
        public virtual void Initialize()
        {
            WriteLine("Amored");
        }
    }

    class IronMan : ArmorSuite
    {
        public override void Initialize()
        {
            base.Initialize();
            WriteLine("Repulsor Rays Armed");
        }
    }

    class WarMachine : ArmorSuite
    {
        public override void Initialize()
        {
            base.Initialize();
            WriteLine("Double-Barrel Cannons Armed");
            WriteLine("Micro-Rocket Launcher Armed");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Creating ArmorSuite...");

            ArmorSuite armorSuite = new ArmorSuite();
            armorSuite.Initialize();

            WriteLine("-----------------------");
            ArmorSuite ironman = new IronMan();
            ironman.Initialize();

            WriteLine("-----------------------");
            ArmorSuite warmachine = new WarMachine();
            warmachine.Initialize();
        }
    }
}
