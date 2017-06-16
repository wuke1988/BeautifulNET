using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulNET
{
    class BoiledEventArgs
    {
        private int temperature;
        private string type;
        private string area;

        public int Temperature { get { return temperature; } }

        public string Type { get { return type; } }

        public string Area { get { return area; } }

        public BoiledEventArgs(int temperature, string type, string area)
        {
            this.temperature = temperature;
            this.type = type;
            this.area = area;
        }


    }
}
