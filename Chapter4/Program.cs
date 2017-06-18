using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class Program
    {
        static void Main(string[] args)
        {
            //ObjectMatch();

            ObjectSort();
            Console.ReadLine();
        }
        static void ObjectMatch()
        {
            List<Order> list = new List<Order>();
            list.Add(new Order { Country = "China", Date = DateTime.Now, Name="Jack" });
            list.Add(new Order {  Country="USA",Date=DateTime.Now,Name="Tom"});

            OrderFilter filter = new OrderFilter(new Order { Country ="China", Date=DateTime.Now });

            var result = list.FindAll(filter.MatchRule);
        }
        static void ObjectSort()
        {
            List<Order2> list = new List<Order2>();
            list.Add(new Order2 { Country = "China", Date = DateTime.Now.AddDays(2), Name = "Jack" });
            list.Add(new Order2 { Country = "USA", Date = DateTime.Now, Name = "Tom" });
            list.Sort(Order2.GetComparer(SortField.Date,SortDirection.Ascending));
            
        }
    }
}
