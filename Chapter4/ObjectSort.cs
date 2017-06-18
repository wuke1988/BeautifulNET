using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    //了解 Icomparable接口，也可以作为List.sort函数的参数
    public class Order1 : IComparable<Order1>
    {
        public string Country { get; set; }
        public DateTime Date { set; get; }
        public string Name { get; set; }

        public int CompareTo(Order1 other)
        {
            return (this.Date > other.Date) ? 1 : 0;
        }
    }
    
    public class Order2
    {
        public string Country { get; set; }
        public DateTime Date { set; get; }
        public string Name { get; set; }

        //创建内部类，实现实体的比较器
        //了解Icomparer接口
        public class Order2Comparer : IComparer<Order2>
        {
            private Sorter sorter;

            public Order2Comparer(Sorter sort)
            {
                this.sorter = sort;
            }

            public int Compare(Order2 x, Order2 y)
            {
                return  Compare(x,y,sorter.Field,sorter.Direction);
                
            }
            public int Compare(Order2 x, Order2 y, SortField field, SortDirection direction)
            {
                int result = 0;

                switch (field)
                {
                    case SortField.Country:
                        if (field == SortField.Country)
                            result = x.Country.CompareTo(y.Country);
                        break;
                    case SortField.Date:
                        if (field == SortField.Date)
                            result = x.Date.CompareTo(y.Date);
                        break;
                    case SortField.Name:
                        if (field == SortField.Name)
                            result = x.Name.CompareTo(y.Name);
                        break;
                }
                return result;
            }            
        }
        public static Order2Comparer GetComparer(SortField field, SortDirection direction)
        {
            return new Order2Comparer(new Sorter { Direction = direction, Field = field });
        }

    }

    



    public struct Sorter
    {
        public SortDirection Direction { get; set; }
        public SortField Field { get; set; }

        public Sorter(SortDirection direction,SortField field)
        {
            this.Direction = direction;
            this.Field = field;
        }

    }

    public enum SortDirection
    {
        Ascending =0,
        Descending
    }
    public enum SortField
    {
        Date,
        Country,
        Name
    }




}
