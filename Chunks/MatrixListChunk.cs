using System.IO;
using System.Text;

namespace Pure3D.Chunks
{
    [ChunkType(65547)]
    public class MatrixListChunk : Chunk
    {
        public Matrix[] Matrices;

        public MatrixListChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            uint len = reader.ReadUInt32();
            Matrices = new Matrix[len];
            for (int i = 0; i < len; i++)
                Matrices[i] = Util.ReadMatrix(reader);
        }

        public override string ToString()
        {
            return $"Matrix List ({Matrices.Length})";
        }
    }
}
