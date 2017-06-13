using PNGSample.Chunk.PNG;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNGSample
{
    static class Program
    {
        static void Main(string[] args)
        {
            var bytes = new List<byte>();
            // シグネチャ
            bytes.AddRange(BitConverterEx.GetBytes((byte)0x89));
            bytes.AddRange(BitConverterEx.GetBytes(@"PNG"));
            bytes.AddRange(BitConverterEx.GetBytes("\r\n\x1a\n"));

            // http://d.hatena.ne.jp/ku-ma-me/20091003/p1

            // http://darkcrowcorvus.hatenablog.jp/entry/2017/02/12/235044#IDAT-%E3%82%A4%E3%83%A1%E3%83%BC%E3%82%B8%E3%83%87%E3%83%BC%E3%82%BF

            var a = new IHDR();
            a.Length = 13;

            a.ChunkType = BitConverterEx.ToUInt32(BitConverterEx.GetBytes(@"IHDR"));
            a.Width = 100;
            a.Height = 100;
            a.BitDepth = 8;
            a.ColorType = 2;
            a.CompressionMethod = 0;
            a.FilterMethod = 0;
            a.InterlaceMethod = 0;
            a.CRC = BitConverterEx.CalcCrc32(
                a.ChunkType,
                 a.Width,
                 a.Height,
                 a.BitDepth,
                 a.ColorType,
                 a.CompressionMethod,
                 a.FilterMethod,
                 a.InterlaceMethod);

            bytes.AddRange(BitConverterEx.StructToByte(a));

            var b = new IDAT();
            var bin = new List<byte>();
            for (int i = 0; i < 100; i++)
            {
                bin.Add(0);
                for (int j = 0; j < 100; j++)
                {
                    bin.AddRange(new byte[] { 0x00, 0xFF, 0x00 });
                }
            }
            b.ChunkType = BitConverterEx.ToUInt32(BitConverterEx.GetBytes(@"IDAT"));

            b.ChunkData = ZlibDeflate(bin.ToArray());
            b.CRC = BitConverterEx.CalcCrc32(b.ChunkType, b.ChunkData);
            b.Length = (uint)b.ChunkData.Length;
            bytes.AddRange(BitConverterEx.StructToByte(b));

            var c = new IEND();
            c.Length = 0;
            c.ChunkType = BitConverterEx.ToUInt32(BitConverterEx.GetBytes(@"IEND"));
            c.CRC = BitConverterEx.CalcCrc32(c.ChunkType);
            bytes.AddRange(BitConverterEx.StructToByte(c));

            File.WriteAllBytes("result.png", bytes.ToArray());
        }

        static byte[] ZlibDeflate(byte[] bytes)
        {
            // 入出力用のストリームを生成します 
            MemoryStream ms = new MemoryStream();
            DeflateStream CompressedStream = new DeflateStream(ms, CompressionMode.Compress, true);

            // ストリームに圧縮するデータを書き込みます 
            CompressedStream.Write(bytes, 0, bytes.Length);
            CompressedStream.Close();

            // 圧縮されたデータを バイト配列で取得します 
            return ms.ToArray();
        }
    }
}
