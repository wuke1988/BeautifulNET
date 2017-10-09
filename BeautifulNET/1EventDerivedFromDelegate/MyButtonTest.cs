using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulNET._1EventDerivedFromDelegate
{
    public class MyButton
    {
        public delegate void Clicked(object sender, EventArgs args);
        //public Clicked Click;

        //事件源自对委托的封装
        public event Clicked Click;

        public string Name { get; set; }

        //事件必须由主体（发布者）引发
        public void DoClick()
        {
            EventArgs args = new EventArgs();
            
            Click(this,args);
        }
    }
    public class MyButtonTest
    {
        private MyButton button;
        public void OnClick1(object sender, EventArgs args)
        {
            //execute click business logic
            Console.WriteLine($"{((MyButton)sender).Name} Click1 execute");
        }
        public void OnClick2(object sender, EventArgs args)
        {
            //execute click business logic
            Console.WriteLine($"{((MyButton)sender).Name} Click2 execute");
        }
        public MyButtonTest()
        {
            button = new MyButton();
            button.Click += OnClick1;
            button.Click += OnClick2;
        }
        public void Test()
        {
            //事件客户端通知主体引发事件
            button.DoClick();
            
            //button.Click(this,new EventArgs());
        }
    }
}
