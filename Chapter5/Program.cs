using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderCollection collection = InitialOrder();

            foreach (Order item in collection)
            {
                Console.WriteLine("CodeID:" + item.CodeID + " Country:" + item.Country + " Date:" + item.Date + " Name:" + item.Name);
            }

            Console.ReadLine();

            
        }

        static OrderCollection InitialOrder()
        {
            OrderCollection collection = new OrderCollection();
            collection.Add(new Order { CodeID="1", Country="USA" , Date=DateTime.Now, Name="Trump"});
            collection.Add(new Order { CodeID = "2", Country = "China", Date = DateTime.Now, Name = "Xi" });
            return collection;
            
        }
    }
}
