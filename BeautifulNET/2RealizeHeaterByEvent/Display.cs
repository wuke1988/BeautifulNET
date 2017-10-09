using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulNET._2RealizeHeaterByEvent
{
    public class Display
    {
        public void ShowMessage(object sender, _2RealizeHeaterByEvent.Heater.BoiledEventArgs args)
        {
            Console.WriteLine($"当前水温： {args.temperature}");
        }
    }
}
