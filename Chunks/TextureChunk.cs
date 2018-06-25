using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(102400)]
    public class TextureChunk : NamedChunk
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

        public TextureChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            base.ReadHeader(stream, length);
            this.Version = reader.ReadUInt32();
            this.Width = reader.ReadUInt32();
            this.Height = reader.ReadUInt32();
            this.Bpp = reader.ReadUInt32();
            this.AlphaDepth = reader.ReadUInt32();
            this.NumMipMaps = reader.ReadUInt32();
            this.TextureType = reader.ReadUInt32();
            this.Usage = reader.ReadUInt32();
            this.Priority = reader.ReadUInt32();
        }

        public override string ToString()
        {
            return $"Texture: {this.Name} ({Width}x{Height})";
        }
    }
}
