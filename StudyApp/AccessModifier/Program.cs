using static System.Console;
using System;

namespace AccessModifier
{
    class WaterHeater
    {
        protected int temp;

        public void SetTemp(int temp)
        {
            if(temp < -5 || temp > 42)
            {
                throw new Exception("Out of temp range");
            }
            this.temp = temp;
        }

        internal void TurnOnWater()
        {
            WriteLine($"Turn on water : {temp}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WaterHeater heater = new WaterHeater();
                heater.SetTemp(20);
                heater.TurnOnWater();

                heater.SetTemp(-2);
                heater.TurnOnWater();

                heater.SetTemp(50);
                heater.TurnOnWater();


            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);                              
            }
            
            

        }
    }
}
