using System.IO;
using System.Text;

namespace Pure3D.Chunks
{
    [ChunkType(1184003)]
    public class Vector2Channel : Chunk
    {
        public uint Version;
        public uint NumberOfFrames;
        public ushort Mapping;
        public string Parameter;
        public Vector2[] Values;
        public ushort[] Frames;
        public Vector3 Constants;

        public Vector2Channel(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            Version = reader.ReadUInt32();
            Parameter = Util.ZeroTerminate(Encoding.ASCII.GetString(reader.ReadBytes(4)));
            Mapping = reader.ReadUInt16();
            Constants = Util.ReadVector3(reader);
            NumberOfFrames = reader.ReadUInt32();

            Frames = new ushort[NumberOfFrames];
            for (int i = 0; i < NumberOfFrames; i++)
            {
                Frames[i] = reader.ReadUInt16();
            }

            Values = new Vector2[NumberOfFrames];
            for (int i = 0; i < NumberOfFrames; i++)
            {
                Values[i] = Util.ReadVector2(reader);
            }
        }

        public override string ToString()
        {
            return $"Vector2 Channel: {Parameter}, {NumberOfFrames} Frames, Mapping {Mapping}, Constants {Constants}";
        }
    }
}
