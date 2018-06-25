using System.IO;
using System.Text;

namespace Pure3D.Chunks
{
    [ChunkType(69632)]
    public class ShaderChunk : NamedChunk
    {
        public uint Version;
        public string PddiShaderName;
        public uint HasTranslucency;
        public uint VertexNeeds;
        public uint VertexMask;
        protected uint NumParams; // Should match the number of children

        public ShaderChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            base.ReadHeader(stream, length);

            BinaryReader reader = new BinaryReader(stream);
            this.Version = reader.ReadUInt32();
            this.PddiShaderName = Util.ReadString(reader);
            this.HasTranslucency = reader.ReadUInt32();
            this.VertexNeeds = reader.ReadUInt32();
            this.VertexMask = reader.ReadUInt32();
            this.NumParams = reader.ReadUInt32();
        }

        public override string ToString()
        {
            return $"Shader: {Name} ({PddiShaderName})";
        }
    }
}
