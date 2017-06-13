namespace PNGSample.Chunk.APNG
{
    public struct fcTL
    {
        public uint Length;
        public uint ChunkType;
        public uint SequenceNumber;
        public uint Width;
        public uint Height;
        public uint XOffset;
        public uint YOffset;
        public ushort DelayNum;
        public ushort DelayDen;
        public byte DisposeOp;
        public byte BlendOp;
        public uint CRC;
    }
}
