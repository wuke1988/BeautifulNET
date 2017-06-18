using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{

    //将涉及排序的属性创建为接口
    public interface IDate
    {
        DateTime Date { get; }
    }
    //排序实体需集成该接口
    public class Order : IDate
    {
        public string Country { get; set; }
        public DateTime Date
        {
            set; get;
        }
        public string Name { get; set; }
    }
    //创建泛型比较类（基类）
    public class DateFilter<T> where T:IDate
    {
        private int year;
        private int month;
        private int day;


        public DateFilter(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }
        public DateFilter() : this(0, 0, 0) { }

        public DateFilter(DateTime date) :
            this(date.Year,date.Month,date.Day)
        { }

        public virtual bool MatchRule(T item)
        {
            if (year != 0 && year != item.Date.Year)
                return false;
            if (month != 0 && month != item.Date.Month)
                return false;
            if (day != 0 && day != item.Date.Day)
                return false;
            return true;
        }
    }
    //创建具体比较类，继承基类的比较方法
    public class OrderFilter : DateFilter<Order>
    {
        private string Country;

        public OrderFilter(Order item)
            : base(item.Date)
        {
            this.Country = item.Country;
        }

        public virtual bool MatchRule(Order order)
        {
            if (Country != null && !Country.Equals(order.Country))
                return false;

            return base.MatchRule(order); ;
        }
    }
}
