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
    /// <summary>
    /// 装饰器流-基于Stream类，为所有的流添加功能
    /// </summary>
    class CompressionHelper
    {
        /// <summary>
        /// DeflateStream 构造函数 (Stream, CompressionLevel, Boolean)  stream:解压缩的文件流。bool 如果在释放 DeflateStream 对象之后打开流对象，则为 true；否则为 false。
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="outPath"></param>
        public void CompressionFile(string sourcePath,string outPath)
        {
            using (FileStream source = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream compressedFileStream = new FileStream(outPath,FileMode.Create,FileAccess.Write))
                {
                    using (DeflateStream deflate = new DeflateStream(compressedFileStream, CompressionLevel.Optimal, true))
                    {
                        source.CopyTo(deflate);

                    }
                }
            }
        }
        /// <summary>
        /// 解压缩时，DeflateStream 构造函数 (Stream, CompressionMode, Boolean),Stream 压缩的文件流
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="outPath"></param>
        public void DeCompressionFile(string sourcePath, string outPath)
        {
            using (FileStream source = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream decompressdFileStream = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                {
                    using (DeflateStream deflate = new DeflateStream(source, CompressionMode.Decompress,true))
                    {
                        deflate.CopyTo(decompressdFileStream);
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

        public void Test2()
        {

            Stopwatch watch = new Stopwatch();

            watch.Start();
            DeCompressionFile("636341071291115751Compressd.log", DateTime.Now.Ticks + "DeCompressd.log");
            watch.Stop();

            Console.WriteLine("耗时:" + watch.ElapsedMilliseconds);

        }
    }
}
