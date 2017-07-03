using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter12
{
    /// <summary>
    /// 声明一个说明特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Struct|AttributeTargets.Enum|AttributeTargets.Constructor|AttributeTargets.Method|AttributeTargets.Property|AttributeTargets.Field
        |AttributeTargets.Event|AttributeTargets.Interface|AttributeTargets.Delegate,Inherited =false,AllowMultiple =true)]
    [Serializable]
    public class RecordAttribute:Attribute
    {
        public RecordAttribute(string recordType,string author,string date)
        {
            this.RecordType = recordType;
            this.Author = author;
            this.Date = Convert.ToDateTime(date);
        }
        //位置属性
        public string RecordType { get; }
        //位置属性
        public string Author { get; }
        //位置属性
        public DateTime Date { get; }
        //命名属性
        public string MeMo
        { get; set; }

        public override string ToString()
        {
            return RecordType+ Author+ Date;
        }
    }
    [Record("Chapter12.Test","wuke","2017-7-3")]
    public class Test
    {
        [Record("Chapter12.Test.Method","wuke", "2017-7-3")]
        public void Method()
        {
            Console.WriteLine("BlaBla...");
        }

    }

    public class Demo2
    {
        public void Test()
        {
            Type t = typeof(Test);

            //反射获取所有的用户自定义特性声明
            object[] objs = t.GetCustomAttributes(typeof(RecordAttribute),false);

            foreach (object obj in objs)
            {
                Console.WriteLine(obj);
            }
            Console.ReadLine();
        }
    }
}
