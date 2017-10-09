using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulNET
{
    interface IObserver
    {
        void Update();
        //实现推模式
        void Update(BoiledEventArgs args);
        //实现拉模式
        void Update(IObservable obj);
    }
}
