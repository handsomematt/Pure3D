using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(65537)]
    public class Skin : Mesh
    {
        public string SkeletonName;

        public Skin(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            base.ReadHeader(stream, length);
            Version = reader.ReadUInt32();
            SkeletonName = Util.ReadString(reader);
            NumPrimGroups = reader.ReadUInt32();
        }

        public override string ToString()
        {
            return $"Skin: {Name} (Skeleton: {SkeletonName}) ({NumPrimGroups} Prim Groups)";
        }
    }
}
