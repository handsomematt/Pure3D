using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(65537)]
    public class SkinChunk : MeshChunk
    {
        public string SkeletonName;

        public SkinChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            base.ReadHeader(stream, length);
            this.Version = reader.ReadUInt32();
            this.SkeletonName = Util.ReadString(reader);
            this.NumPrimGroups = reader.ReadUInt32();
        }

        public override string ToString()
        {
            return $"Skin: {Name} (Skeleton: {SkeletonName}) ({NumPrimGroups} Prim Groups)";
        }
    }
}
