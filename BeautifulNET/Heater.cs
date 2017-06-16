using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulNET
{
    class Heater:SubjectBase
    {
        private int temperature;
        
        private string type;
        public string Type { get { return type; } }

        private string area;
        public string  Area { get { return area; } }

        public Heater(string type ,string area)
        {
            this.type = type;
            this.area = area;
            this.temperature = 0;
        }

        public Heater() : this("Real Fire 001", "Xi'an")
        {

        }

        public virtual void OnBoiled()
        {
            base.Notify();
        }

        public void BoilWater()
        {
            for (temperature = 0; temperature <= 100; temperature++)
            {
                if(temperature>96)
                    OnBoiled();
            }
        }
        
    }
}
