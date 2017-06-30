using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Chapter8
{
    public class ObjectSerialization
    {
        public void Test()
        {
            //Product item = new Product(12398) {  Name="小米6"};

            string connectionstr = "Data Source:localhost;Intial Catalog=DB;User=admin;Pwd=admin";
            Product item = new Product(connectionstr);
            item.Name = "MyDBConnection1";


            using (FileStream outstream = new FileStream("Product.obj", FileMode.Create, FileAccess.Write))
            {
                IFormatter formatter = new BinaryFormatter();

                formatter.Serialize( outstream,item);
                
            }                          
        }

        public void Test2()
        {
            using (FileStream source = new FileStream("Product.obj", FileMode.Open, FileAccess.Read))
            {
                IFormatter formatter = new BinaryFormatter();
                Product item= (Product)formatter.Deserialize(source);

                Console.WriteLine(item.ToString());
            }
        }
    }

    /// <summary>
    /// 自定义序列化过程（自行实现ISerializable)
    /// </summary>
    [Serializable]
    public class Product : ISerializable
    {
        public string Name;

        private string connectionStr;

        [NonSerialized]
        public SqlConnection sqlConnection;

        public Product(string sqlconnection)
        {
            this.connectionStr = sqlconnection;
        }
        /// <summary>
        /// 接口方法实现：所有需要序列化的字段（属性），均需要手工在此函数 添加到SerializationInfo 对象中（使用add方法）
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            string encrypted = this.connectionStr.Replace("a","*");
            info.AddValue("encrypted",encrypted);
            info.AddValue("Name",Name);
        }
        /// <summary>
        /// 反序列化时，会自动调用此构造函数
        /// 在此函数中，手工的将序列化添加到SerializationInfo 对象中的属性或字段，重新（构造）赋值给属性或字段
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public Product(SerializationInfo info, StreamingContext context)
        {
            string encrypted = info.GetString("encrypted");
            this.connectionStr = encrypted.Replace("*","a");
            this.Name = info.GetString("Name");
        }

        public override string ToString()
        {
            return "Name:" + Name + ";ConnectionStr:" + connectionStr;
        }
    }
    /// <summary>
    /// IDeserializationCallback 接口为回调接口，
    /// 处理对象中反序列化无法构建的属性或字段
    /// 解决对象在序列化和反序列化后  前后对象不一致问题
    /// </summary>
    [Serializable]
    public class Product1 : IDeserializationCallback
    {
        private int id;


        public string Name { get; set; }

        public Product1(int id)
        {
            this.id = id;
        }
        public Product1()
        {

        }
        /// <summary>
        /// 回调方法
        /// </summary>
        /// <param name="sender"></param>
        public void OnDeserialization(object sender)
        {
            this.id = 10010;
        }


        /// <summary>
        /// 序列化事件，实现必要的业务逻辑
        /// </summary>
        [OnSerialized]
        public void OnSerializing()
        {

        }
        /// <summary>
        /// 序列化事件，实现必要的业务逻辑
        /// </summary>
        [OnDeserialized]
        public void OnDeserialized()
        {

        }

       
    }
}
