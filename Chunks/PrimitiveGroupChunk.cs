using System.IO;
using System.Text;

namespace Pure3D.Chunks
{
    [ChunkType(65538)]
    public class PrimitiveGroupChunk : Chunk
    {
        public uint Version;
        public string ShaderName;
        public PrimitiveTypes PrimitiveType;
        public VertexTypes VertexType;
        public uint NumVertices;
        public uint NumIndices;
        public uint NumMatrices;

        public PrimitiveGroupChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            this.Version = reader.ReadUInt32();
            this.ShaderName = Util.ReadString(reader);
            this.PrimitiveType = (PrimitiveTypes)reader.ReadUInt32();
            this.VertexType = (VertexTypes)reader.ReadUInt32();
            this.NumVertices = reader.ReadUInt32();
            this.NumIndices = reader.ReadUInt32();
            this.NumMatrices = reader.ReadUInt32();
        }

        public override string ToString()
        {
            return $"Primitive Group {ShaderName}";
        }

        public enum PrimitiveTypes : uint
        {
            TriangleList,
            TriangleStrip,
            LineList,
            LineStrip,
        }

        [System.Flags]
        public enum VertexTypes : uint
        {
            UVs = 1U,
            UVs2 = 2U,
            UVs3 = 4U,
            UVs4 = 8U,
            Normals = 16U,
            Colours = 32U,
            Matrices = 128U,
            Weights = 256U,
            Unknown = 8192U,
        }
    }
}
