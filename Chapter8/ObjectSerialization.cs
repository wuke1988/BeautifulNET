using System;
using System.Collections.Generic;
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
            Product item = new Product(12398) {  Name="小米6"};
            using (FileStream outstream = new FileStream("Product.obj", FileMode.Create, FileAccess.Write))
            {
                IFormatter formatter = new BinaryFormatter();

                formatter.Serialize( outstream,item);
                
            }                          
        }
    }
    [Serializable]
    public class Product:IDeserializationCallback
    {
        private int id;

        
        public string Name { get; set; }

        public Product(int id)
        {
            this.id = id;
        }
        public Product()
        {

        }
        [OnSerialized]
        public void OnSerializing()
        {

        }
        [OnDeserialized]
        public void OnDeserialized()
        {

        }

        public void OnDeserialization(object sender)
        {
            this.id = 10010;
        }
    }
}
