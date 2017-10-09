using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulNET._2RealizeHeaterByEvent
{
     class Test
    {
        
        public void Test1()
        {
            Heater heater = new Heater();
            heater.Boiled += (new Alarm()).Alert;
            heater.Boiled += (new Display()).ShowMessage;

            heater.BoilWater();

        }
    }
}
