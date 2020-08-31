using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    class InvalidArgumentException : Exception
    {
        public object Argument { get; set;}
        public string Range { get; set; }

        public InvalidArgumentException()
        {

        }

        public InvalidArgumentException(string message) : base(message)
        {

        }
    }

    class Program
    {
        static uint MergeARGB(uint alpha, uint red, uint green, uint blue)
        {
            uint[] args = new uint[] { alpha, red, green, blue };

            foreach (var item in args)
            {
                if (item > 255)
                    throw new InvalidArgumentException()
                    {
                        Argument = item,
                        Range = "0-255"
                    };
            }
            return (alpha << 24 & 0xFF000000) | (red << 16 & 0x00FF0000) | (green << 8 & 0x0000FF00) | (blue & 0x000000FF);
        }

        static void Main(string[] args)
        {
            try
            {
                WriteLine($"0x{MergeARGB(255,111,111,111):X}");
            
            }

            catch(InvalidArgumentException ex)
            {
                WriteLine($"예외발생 {ex.Message}");
            }

            catch (Exception ex)
            {

                WriteLine(ex.Message);
            }
            

        }
    }
}
