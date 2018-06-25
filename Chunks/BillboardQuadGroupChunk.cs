using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(94210)]
    public class BillboardQuadGroupChunk : NamedChunk
    {
        public uint Version;
        public string Shader;
        public uint ZTest;
        public uint ZWrite;
        public uint Fog;
        public uint NumQuads;

        public BillboardQuadGroupChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            this.Version = reader.ReadUInt32(); // version before name, rare case.
            base.ReadHeader(stream, length);
            this.Shader = Util.ReadString(reader);
            this.ZTest = reader.ReadUInt32();
            this.ZWrite = reader.ReadUInt32();
            this.Fog = reader.ReadUInt32();
            this.NumQuads = reader.ReadUInt32();
        }

        public override string ToString()
        {
            return $"Billboard Quad Group: {Name}";
        }
    }
}
