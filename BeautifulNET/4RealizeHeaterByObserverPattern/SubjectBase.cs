using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulNET
{
     abstract class SubjectBase : IObservable
    {
        private List<IObserver> container = new List<IObserver>();

        public void Register(IObserver observer)
        {
            if (observer != null)
                container.Add(observer);
        }

        public void UnRegister(IObserver observer)
        {
            if (observer != null)
                container.Remove(observer);
        }
        //推模式
        public virtual void Notify(BoiledEventArgs e)
        {
            foreach (IObserver observer in container)
            {
                observer.Update(e);
            }
        }
        //拉模式
        public virtual void Notify(IObservable e)
        {
            foreach (IObserver observer in container)
            {
                observer.Update(this);
            }
        }
    }
}
