using System.IO;
using System.Text;

namespace Pure3D.Chunks
{
    [ChunkType(65546)]
    public class IndexList : Chunk
    {
        public uint[] Indices;

        public IndexList(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            uint len = reader.ReadUInt32();
            Indices = new uint[len];
            for (int i = 0; i < len; i++)
                Indices[i] = reader.ReadUInt32();
        }

        public override string ToString()
        {
            return $"Indices List ({Indices.Length})";
        }
    }
}
