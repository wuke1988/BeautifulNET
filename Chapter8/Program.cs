using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            CompressionHelper helper = new CompressionHelper();

            helper.Test();
            Console.ReadLine();
        }
    }
}
