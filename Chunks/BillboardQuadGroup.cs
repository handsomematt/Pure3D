using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(94210)]
    public class BillboardQuadGroup : Named
    {
        public uint Version;
        public string Shader;
        public uint ZTest;
        public uint ZWrite;
        public uint Fog;
        public uint NumQuads;

        public BillboardQuadGroup(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            Version = reader.ReadUInt32(); // version before name, rare case.
            base.ReadHeader(stream, length);
            Shader = Util.ReadString(reader);
            ZTest = reader.ReadUInt32();
            ZWrite = reader.ReadUInt32();
            Fog = reader.ReadUInt32();
            NumQuads = reader.ReadUInt32();
        }

        public override string ToString()
        {
            return $"Billboard Quad Group: {Name}";
        }
    }
}
