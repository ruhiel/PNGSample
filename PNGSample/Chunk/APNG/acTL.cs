using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNGSample.Chunk.APNG
{
    public struct acTL
    {
        public uint Length;
        public uint ChunkType;
        public uint NumFrames;
        public uint NumPlays;
        public uint CRC;
    }
}
