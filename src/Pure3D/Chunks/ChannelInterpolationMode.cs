using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(1184016)]
    public class ChannelInterpolationMode : Chunk
    {
        public uint Version;
        public uint Mode;

        public ChannelInterpolationMode(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            Version = reader.ReadUInt32();
            Mode = reader.ReadUInt32();
        }

        public override string ToString()
        {
            return $"Channel Interpolation Mode: {Mode}";
        }
    }
}
