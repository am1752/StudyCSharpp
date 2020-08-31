using Bogus;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BougusFakeWeatherApp
{
    class Program
    {
        static void Main()
        {
            var Rooms = new[] { "DiningRoom", "LivingRoom", "BathRoom", "BedRoom" };
            var SensorFaker = new Faker<SensorInfo>()
                              .RuleFor(s => s.Dev_Id, f => f.PickRandom(Rooms))
                              .RuleFor(s => s.Curr_Time, f => f.Date.Past(0).ToString("yyyy-MM-dd HH:mm:ss.ff"))
                              .RuleFor(s => s.Temp, f => float.Parse(f.Random.Float(19.0f, 35.9f).ToString("0.00")))
                              .RuleFor(s => s.Humind, f => f.Random.Float(40.0f, 63.9f))
                              .RuleFor(s => s.Press, f => f.Random.Float(800.0f, 999.9f));
            var thisValue = SensorFaker.Generate();
            thisValue.Temp = float.Parse(thisValue.Temp.ToString("0.00"));
            thisValue.Humind = float.Parse(thisValue.Humind.ToString("0.0"));
            thisValue.Press = float.Parse(thisValue.Press.ToString("0.0"));

            Console.WriteLine(JsonConvert.SerializeObject(thisValue, Formatting.Indented));
        }
    }
}
