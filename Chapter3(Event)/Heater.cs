using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3_Event_
{
    public class Heater
    {
        private int temperature;
        public delegate void BoilHandler(int param);

        //事件的作用
        //1. 实现了对委托的封装，当声明为事件后，不管委托在类内部是是public还是其他，均被视为private；且事件可以通过 += -=来注册或注销函数。
        //2. 当声明为事件后，不管委托在类内部是是public还是其他，均被视为private，故而实现了限制在客户端 触发 事件。
        public event BoilHandler BoilHandlerEvent;

        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;

                if (temperature > 95)
                {
                    BoilHandlerEvent(temperature);
                }
            }
        }


    }

    public class Alarm
    {
        public void MakeAlert(int param)
        {
            Console.WriteLine("滴滴响：水温 " + param + " 度");
        }
    }
    public class Display
    {
        public static void ShowMsg(int param)
        {
            Console.WriteLine("水要烧开了，当前水温" + param + "度");
        }
    }
}
