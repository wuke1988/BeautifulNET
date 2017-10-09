using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulNET._3RealizeHeaterByEventDepth
{
    /// <summary>
    /// 约束 事件主体 只能有一个订阅者(事件访问器实现)
    /// </summary>
    public class Heater1
    {
        //.NET编程规范 委托类型的名称必须以EventHandler结尾
        public delegate void BoiledEventHandler(object sender, BoiledEventArgs args);
        
        //声明一个委托私有变量
        private  BoiledEventHandler boiled;

        //事件访问器
        public event BoiledEventHandler Boiled
        {
            add
            {
                boiled = value;

            }
            remove
            {
                boiled -= value;
            }
        }




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
