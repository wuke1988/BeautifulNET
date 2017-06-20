using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{

    public class Order
    {
        public string CodeID { get; set; }
        public string Country { get; set; }
        public DateTime Date { set; get; }
        public string Name { get; set; }
    }
    public  class OrderCollection:IEnumerable<Order>
    {
        private Hashtable hashTable;

        public OrderCollection()
        {
            hashTable = new Hashtable();
        }

        private string GetKey(int index)
        {
            int i = 0;
            foreach (string key in hashTable.Keys)
            {
                if (i == index)
                    return key;
                i++;
            }
            return null;
        }

        public Order this[int index]
        {
            get
            {
                string key = GetKey(index);
                return hashTable[key] as Order;
            }
            set
            {
                string key = GetKey(index);
                hashTable[key] = value;
            }

        }
        public Order this[string key]
        {
            get
            {
                return hashTable[key] as Order;
            }
            set
            {
                hashTable[key] = value;
            }
        }
        public void Add(Order item)
        {
            if (hashTable.ContainsKey(item.CodeID))
                throw new Exception("对象已存在");
            hashTable.Add(item.CodeID,item);
        }

        public bool Remove(Order item)
        {
            if (hashTable.ContainsKey(item.CodeID))
            {
                hashTable.Remove(item.CodeID);
                return true;

            }
            return false;
        }
        public bool RemoveAt(int index)
        {
            if (index >= hashTable.Keys.Count)
                throw new Exception("下标溢出");
            string key = GetKey(index);
            if (key != null)
            {
                hashTable.Remove(((Order)hashTable[key]).CodeID);
                return true;
            }
            return false;
        }

        public void Clear()
        {
            hashTable.Clear();
        }

        public IEnumerator<Order> GetEnumerator()
        {
            return new OrderEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new OrderEnumerator(this);
        }

        public int Count
        {
            get
            {
                return hashTable.Keys.Count;
            }
        }

        public class OrderEnumerator : IEnumerator<Order>
        {
            private OrderCollection collection;
            private int index = -1;

            public OrderEnumerator(OrderCollection collection)
            {
                this.collection = collection;
            }
            public Order Current
            {
                get
                {
                    return collection[index];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return collection[index];
                }
            }

            public void Dispose()
            {
               
            }

            public bool MoveNext()
            {
                if (index < collection.Count-1)
                {
                    index++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                index = -1;
            }
        }


    }
}
