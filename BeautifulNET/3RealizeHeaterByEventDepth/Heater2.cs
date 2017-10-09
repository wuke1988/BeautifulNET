using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulNET._3RealizeHeaterByEventDepth
{
    /// <summary>
    /// 处理多个返回结果和异常
    /// </summary>
    public class Heater2
    {
        //.NET编程规范 委托类型的名称必须以EventHandler结尾
        public delegate void BoiledEventHandler(object sender, BoiledEventArgs args);

        //事件
        public event BoiledEventHandler Boiled;

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
                //获取事件中委托数组
                Delegate[] delegates = Boiled.GetInvocationList();
                foreach (Delegate del in delegates)
                {
                    try
                    {
                        //动态执行
                        del.DynamicInvoke(this, new BoiledEventArgs(temperature));
                    }
                    catch (Exception ex)
                    { }
                }
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
