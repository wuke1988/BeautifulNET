using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter8
{
    class CompressionHelper
    {
        public void CompressionFile(string sourcePath,string outPath)
        {
            using (FileStream source = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream compressedFileStream = new FileStream(outPath,FileMode.Create,FileAccess.Write))
                {
                    using (DeflateStream deflate = new DeflateStream(compressedFileStream, CompressionMode.Compress, true))
                    {
                        source.CopyTo(deflate);

                    }
                }
            }
        }
        

        public void Test()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            CompressionFile("log636339153387509518.log", DateTime.Now.Ticks + "Compressd.log");
            watch.Stop();

            Console.WriteLine("耗时:" + watch.ElapsedMilliseconds);
        }
    }
}
