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
        public virtual void Notify()
        {
            foreach (IObserver observer in container)
            {
                observer.Update();
            }
        }
    }
}
