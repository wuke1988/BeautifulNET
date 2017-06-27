using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter8
{
    /// <summary>
    /// 工具类File中添加了大量流处理的方法
    /// </summary>
     class HelpClass
    {
        public void Test()
        {
            FileStream stream = File.OpenRead("636341071291115751Compressd.log");
            
        }
    }
}
