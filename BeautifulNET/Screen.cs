using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulNET
{
    class Screen : IObserver
    {
        private bool isDisplayedType = false;
        public void Update()
        {
            Console.WriteLine("Screen".PadRight(7)+"：水快开了");
        }

        public void Update(IObservable obj)
        {
            Console.WriteLine("Screen".PadRight(7) + "：水快开了"+((Heater)obj).Temperature);
        }

        public void Update(BoiledEventArgs args)
        {
            if (!isDisplayedType)
            {
                Console.WriteLine("{0}-{1}", args.Area, args.Type);
                isDisplayedType = true;
            }
            Console.WriteLine("Screen".PadRight(7) + "：水快开了");
        }
    }
    class Alarm : IObserver
    {
        private bool isDisplayedType = false;
        public void Update()
        {
            Console.WriteLine("Alarm".PadRight(7) + "嘟嘟嘟：水快开了");
        }

        public void Update(IObservable obj)
        {
            Console.WriteLine("Alarm".PadRight(7) + "嘟嘟嘟：水快开了"+ ((Heater)obj).Temperature);
        }

        public void Update(BoiledEventArgs args)
        {
             
            if (!isDisplayedType)
            {
                Console.WriteLine("{0}-{1}", args.Area, args.Type);
                isDisplayedType = true;
            }
            Console.WriteLine("Alarm".PadRight(7) + "嘟嘟嘟：水快开了");
        }
    }
}
