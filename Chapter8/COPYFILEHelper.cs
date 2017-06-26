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
    /// 基础流：文件流
    /// </summary>
    class COPYFILEHelper
    {

        public void CopyFile(string sourcePath,string outPath)
        {
            int bufferSize = 10240;

            //读入文件流
            Stream source = new FileStream(sourcePath, FileMode.Open,FileAccess.Read);
            //输出文件流
            Stream target = new FileStream(outPath,FileMode.OpenOrCreate,FileAccess.Write);

            byte[] buffer = new byte[bufferSize];

            int bytesRead = 0;

            do
            {
                bytesRead = source.Read(buffer, 0, buffer.Length);
                target.Write(buffer, 0, buffer.Length);

            } while (bytesRead > 0);

            source.Dispose();
            target.Dispose();
        }

        public void Test()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            CopyFile("log636339153387509518.log", DateTime.Now.Ticks + "copyfile.log");
            watch.Stop();

            Console.WriteLine("耗时:" + watch.ElapsedMilliseconds);
        }  
    }
}
