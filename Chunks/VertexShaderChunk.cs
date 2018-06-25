using System.IO;
using System.Text;

namespace Pure3D.Chunks
{
    [ChunkType(65553)]
    public class VertexShaderChunk : Chunk
    {
        public string VertexShaderName;

        public VertexShaderChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            this.VertexShaderName = Util.ReadString(reader);
        }

        public override string ToString()
        {
            return $"Vertex Shader {VertexShaderName}";
        }
    }
}
