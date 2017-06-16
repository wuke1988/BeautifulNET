using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulNET
{
    class Screen : IObserver
    {
        public void Update()
        {
            Console.WriteLine("Screen".PadRight(7)+"：水快开了");
        }
    }
    class Alarm : IObserver
    {
        public void Update()
        {
            Console.WriteLine("Alarm".PadRight(7) + "嘟嘟嘟：水快开了");
        }
    }
}
