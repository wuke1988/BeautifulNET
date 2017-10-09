using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulNET._2RealizeHeaterByEvent
{
    public class Alarm
    {
        public void Alert(object sender, _2RealizeHeaterByEvent.Heater.BoiledEventArgs args)
        {
            Console.WriteLine($"警告： 水温 {args.temperature}");
        }
    }
}
