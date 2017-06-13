using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PNGSample.Chunk.PNG
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct IHDR
    {
        public uint Length;
        public uint ChunkType;
        public uint Width;
        public uint Height;
        public byte BitDepth;
        public byte ColorType;
        public byte CompressionMethod;
        public byte FilterMethod;
        public byte InterlaceMethod;
        public uint CRC;
    }
}
