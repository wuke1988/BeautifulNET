using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulNET
{
    class Program
    {
        static void Main(string[] args)
        {

            Heater heater = new Heater();
            Alarm alarm = new Alarm();
            Screen screen = new Screen();
            heater.Register(alarm);
            heater.Register(screen);

            heater.BoilWater();

            Console.ReadLine();

        }
    }
}
