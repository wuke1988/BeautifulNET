using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulNET._2RealizeHeaterByEvent
{
    public class Heater
    {
        //.NET编程规范 委托类型的名称必须以EventHandler结尾
        public delegate void BoiledEventHandler(object sender, BoiledEventArgs args);

        //.NET编程规范 事件命名必须是以委托类型名称去掉EventHandler结尾
        public event BoiledEventHandler Boiled;

        public string Name = "Real Fire 001";

        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                if (i >= 95)
                {
                    OnBoiled(i);
                }
            }
        }
        /// <summary>
        /// 主体触发事件
        /// </summary>
        /// <param name="temperature"></param>
        public virtual void OnBoiled(int temperature)
        {
            if (Boiled != null)
            {
                Boiled(this, new BoiledEventArgs(temperature));
            }

        }

        //.NET编程规范 继承自EventArgs的类必须以EventArgs结尾
        public class BoiledEventArgs : EventArgs
        {
            public readonly int temperature;
            public BoiledEventArgs(int temperature)
            {
                this.temperature = temperature;
            }
        }
    }
}
