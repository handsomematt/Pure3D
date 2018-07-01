using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(102400)]
    public class Texture : Named
    {
        public uint Version;
        public uint Width;
        public uint Height;
        public uint Bpp;
        public uint AlphaDepth;
        public uint TextureType;
        public uint Usage;
        public uint Priority;
        public uint NumMipMaps;

        public Texture(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            base.ReadHeader(stream, length);
            Version = reader.ReadUInt32();
            Width = reader.ReadUInt32();
            Height = reader.ReadUInt32();
            Bpp = reader.ReadUInt32();
            AlphaDepth = reader.ReadUInt32();
            NumMipMaps = reader.ReadUInt32();
            TextureType = reader.ReadUInt32();
            Usage = reader.ReadUInt32();
            Priority = reader.ReadUInt32();
        }

        public override string ToString()
        {
            return $"Texture: {Name} ({Width}x{Height})";
        }
    }
}
