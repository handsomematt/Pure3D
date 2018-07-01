using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(65547)]
    public class MatrixList : Chunk
    {
        public byte[][] Matrices;

        public MatrixList(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            uint len = reader.ReadUInt32();
            Matrices = new byte[len][];
            for (int i = 0; i < len; i++)
            {
                Matrices[i] = new byte[4];
                Matrices[i][0] = reader.ReadByte();
                Matrices[i][1] = reader.ReadByte();
                Matrices[i][2] = reader.ReadByte();
                Matrices[i][3] = reader.ReadByte();
            }
        }

        public override string ToString()
        {
            return $"Matrix List ({Matrices.Length})";
        }
    }
}
