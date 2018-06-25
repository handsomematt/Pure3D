using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(117510144)]
    public class PhysicsObjectChunk : NamedChunk
    {
        public uint Version;
        public string MaterialName;
        public uint NumJoints;
        public float Volume;
        public float RestingSensitivity;

        public PhysicsObjectChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            base.ReadHeader(stream, length);
            this.Version = reader.ReadUInt32();
            this.MaterialName = Util.ReadString(reader);
            this.NumJoints = reader.ReadUInt32();
            this.Volume = reader.ReadSingle();
            this.RestingSensitivity = reader.ReadSingle();
        }

        public override string ToString()
        {
            return $"Physics Object: {Name}";
        }
    }
}
