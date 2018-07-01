using System.IO;
using System.Text;

namespace Pure3D.Chunks
{
    [ChunkType(65543)]
    public class UVList : Chunk
    {
        public uint Channel;
        public Vector2[] UVs;

        public UVList(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            uint len = reader.ReadUInt32();
            Channel = reader.ReadUInt32();
            UVs = new Vector2[len];
            for (int i = 0; i < len; i++)
                UVs[i] = Util.ReadVector2(reader);
        }

        public override string ToString()
        {
            return $"UV List (Channel: {Channel} - {UVs.Length})";
        }
    }
}
