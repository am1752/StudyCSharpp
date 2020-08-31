using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiInter
{
    class Program
    {
        interface IRunnable
        {
            void Run();
        }

        interface IFlyable
        {
            void Fly();
        }

        public class Vehicle
        {
            public int Year;
            public string Company;
            public float HorsePower;
        }

        class FlyingCar : Vehicle ,IRunnable, IFlyable
        {
            public void Run()
            {
                WriteLine("Run! Run!!");
            }

            public void Fly()
            {
                WriteLine("Fly! Fly!!");
            }

        }

       

        static void Main(string[] args)
        {
            FlyingCar car = new FlyingCar();
            car.Run();
            car.Fly();

            IRunnable runnable = car as IRunnable;
            runnable.Run();

            IFlyable flyable = car as IFlyable;
            flyable.Fly();

            car.Company = "Naver";
            car.HorsePower = 12.4f;
            car.Year = 1234;
            WriteLine($"{car.Company} {car.HorsePower} {car.Year}");
        }
    }
}
