using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter8
{
    /// <summary>
    /// 流包装器类（Wrapper）
    /// </summary>
    class WrapperHelper
    {
        public void WrapText(string sourcePath, string outPath)
        {
            using (Stream source = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                using (Stream target = new FileStream(outPath,FileMode.Create,FileAccess.Write))
                {
                    using (StreamReader reader = new StreamReader(source, Encoding.UTF8))
                    {
                        using (StreamWriter writer = new StreamWriter(target, Encoding.UTF8))
                        {
                            while (!reader.EndOfStream)
                            {
                                string str = reader.ReadLine();
                                writer.WriteLine(str + "WUKE");
                            }
                        }
                            
                    }
                }
            }
        }
        public void Test()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            WrapText("log636339153387509518.log", DateTime.Now.Ticks + "Wrapped.log");
            watch.Stop();

            Console.WriteLine("耗时:" + watch.ElapsedMilliseconds);
        }
    }
}
