using System.IO;
using System.Text;

namespace Pure3D.Chunks
{
    [ChunkType(1184004)]
    public class Vector3Channel : Chunk
    {
        public uint Version;
        public uint NumberOfFrames;
        public string Parameter;
        public Vector3[] Values;
        public ushort[] Frames;

        public Vector3Channel(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            Version = reader.ReadUInt32();
            Parameter = Util.ZeroTerminate(Encoding.ASCII.GetString(reader.ReadBytes(4)));
            NumberOfFrames = reader.ReadUInt32();

            Frames = new ushort[NumberOfFrames];
            for (int i = 0; i < NumberOfFrames; i++)
            {
                Frames[i] = reader.ReadUInt16();
            }

            Values = new Vector3[NumberOfFrames];
            for (int i = 0; i < NumberOfFrames; i++)
            {
                Values[i] = Util.ReadVector3(reader);
            }
        }

        public override string ToString()
        {
            return $"Vector3 Channel: {Parameter}, {NumberOfFrames} Frames";
        }
    }
}
