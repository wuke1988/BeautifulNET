using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

[assembly: CLSCompliant(true)]
namespace Chapter1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ValPonit point;
            //point.x = 10;
            //point.y = 10;

            //point.Reset();

            //通过序列化和反序列化实现深度复制
            RefPoint rpoint = new RefPoint(1);
            ValPonit vpoint = new ValPonit(1);
            RefLine line = new RefLine(rpoint, vpoint);
            RefLine newline = (RefLine)line.Clone();

            line.rpoint.x = 10;

            Console.WriteLine(newline.rpoint.x);

            Console.ReadLine();
        }
        public string name;

        public string Name()
        {

            return "";
        }
        public uint GetValue()
        {
            return 0;
        }

        public string _Test()
        {
            return "";
        }


    }
    [Serializable]
    public struct ValPonit
    {
        public int x;
        public ValPonit(int x)
        {
            this.x = x;
        }
    }
    [Serializable]
    public class RefPoint
    {
        public int x;
        public RefPoint(int x)
        {
            this.x = x;
        }

    }
    [Serializable]
    public class RefLine : ICloneable
    {
        public RefPoint rpoint;
        public ValPonit vpoint;

        public RefLine(RefPoint rpoint, ValPonit vpoint)
        {
            this.rpoint = rpoint;
            this.vpoint = vpoint;
        }

        public object Clone()
        {
            BinaryFormatter format = new BinaryFormatter();
            MemoryStream memory = new MemoryStream();


            format.Serialize(memory, this);
            memory.Position = 0;

            return format.Deserialize(memory);
        }
    }

}
