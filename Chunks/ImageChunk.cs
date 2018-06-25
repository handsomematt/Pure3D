using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(102401)]
    public class ImageChunk : NamedChunk
    {
        public uint Version;
        public uint Width;
        public uint Height;
        public uint Bpp;
        public uint Palettized;
        public uint HasAlpha;
        public Formats Format;

        public ImageChunk(File file, uint type) : base(file, type)
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
            this.Palettized = reader.ReadUInt32();
            this.HasAlpha = reader.ReadUInt32();
            this.Format = (Formats)reader.ReadUInt32();
        }

        public override string ToString()
        {
            return $"Image Chunk: {Name} ({Format}) ({Width}x{Height})";
        }

        public enum Formats : uint
        {
            PNG = 1,
            DXT1 = 6,
            DXT3 = 8,
            DXT5 = 10,
            P3DI = 11,
            P3DI2 = 25,
        }
    }
}
