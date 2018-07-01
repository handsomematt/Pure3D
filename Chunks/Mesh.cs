using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(65536)]
    public class Mesh : Named
    {
        public uint Version;
        public uint NumPrimGroups; // should be equal to children.

        public Mesh(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            base.ReadHeader(stream, length);
            Version = reader.ReadUInt32();
            NumPrimGroups = reader.ReadUInt32();
        }

        public override string ToString()
        {
            return $"Mesh: {Name} ({NumPrimGroups} Prim Groups)";
        }
    }
}
