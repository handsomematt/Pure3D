using System.IO;
using System.Text;

namespace Pure3D.Chunks
{
    [ChunkType(65541)]
    public class PositionList : Chunk
    {
        public Vector3[] Positions;

        public PositionList(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            uint len = reader.ReadUInt32();
            Positions = new Vector3[len];
            for (int i = 0; i < len; i++)
                Positions[i] = Util.ReadVector3(reader);
        }

        public override string ToString()
        {
            return $"Position List ({Positions.Length})";
        }
    }
}
