using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3_Event_
{
    class Program
    {
        static void Main(string[] args)
        {
            Heater heater = new Heater();
            heater.BoilHandlerEvent += new Alarm().MakeAlert;
            heater.BoilHandlerEvent += Display.ShowMsg;

            heater.BoilWater();


            Console.ReadLine();
        }
    }
}
