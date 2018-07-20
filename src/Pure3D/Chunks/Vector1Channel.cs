using System.IO;
using System.Text;

namespace Pure3D.Chunks
{
    [ChunkType(1184002)]
    public class Vector1Channel : Chunk
    {
        public uint Version;
        public uint NumberOfFrames;
        public ushort Mapping;
        public string Parameter;
        public float[] Values;
        public ushort[] Frames;
        public Vector3 Constants;

        public Vector1Channel(File file, uint type) : base(file, type)
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

            Values = new float[NumberOfFrames];
            for (int i = 0; i < NumberOfFrames; i++)
            {
                Values[i] = reader.ReadSingle();
            }
        }

        public override string ToString()
        {
            return $"Vector1 Channel: {Parameter}, {NumberOfFrames} Frames, Mapping {Mapping}, Constants {Constants}";
        }
    }
}
