﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PNGSample.Chunk.PNG
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct IEND
    {
        public uint Length;
        public uint ChunkType;
        public uint CRC;
    }
}
