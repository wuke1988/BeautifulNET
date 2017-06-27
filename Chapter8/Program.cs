using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter8
{
    class Program
    {
        static void Main(string[] args)
        {
            //COPYFILEHelper copyer = new COPYFILEHelper();

            //copyer.Test();

            //CompressionHelper helper = new CompressionHelper();

            //helper.Test();

            WrapperHelper helper = new WrapperHelper();

            helper.Test();            

            Console.ReadLine();
        }
    }
}
