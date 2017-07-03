using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chapter12
{
    class Program
    {
        static void Main(string[] args)
        {
            //Type t = typeof(BookStatue);
            //foreach (FieldInfo field in t.GetFields())
            //{
            //    if(!field.IsSpecialName)
            //        Console.WriteLine( field.Name+" "+field.GetRawConstantValue());
            //}


            //Type type = typeof(Demo);
            //MethodInfo[] methods = type.GetMethods();
            //foreach (MethodInfo method in methods)
            //    Console.WriteLine(method.Name);

            //PropertyInfo[] propertys = type.GetProperties();
            //foreach (PropertyInfo property in propertys)
            //    Console.WriteLine(property.Name);


            Demo2 demo2 = new Demo2();
            demo2.Test();

            Console.ReadLine();
        }
    }

    public enum BookStatue
    {
        未提交,
        已提交,
        已取消,
        已订阅
    }

    public delegate void Notify(string name);
    public class Demo 
    {
        public String Name { get; set; }

        public event Notify NotifyEvent;

        public Demo()
        {
            NotifyEvent += fun1;
        }

        public void fun1(string str)
        {
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            //判断两个对象的类型是否相同
            Type type = obj.GetType();
            Type type2 = this.GetType();

            if (type != type2)
                return false;

            //判断两个对象是否能按位比较
            Object a = this;

            if (CanCompareBits(a))
                return FastEqualsCheck(a,obj);

            //反射字段比较两个对象
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic|BindingFlags.Public|BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                object obj3 = field.GetValue(obj);
                object obj4 = field.GetValue(a);

                if (obj3 == null)
                {
                    if (obj4 == null)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (obj3.Equals(obj4))
                        return true;
                    return false;
                }
            }
            return false;
        }
        public bool CanCompareBits(Object a)
        {
            return false;
        }
        public bool FastEqualsCheck(Object a,Object b)
        {
            return false;
        }
    }
}
