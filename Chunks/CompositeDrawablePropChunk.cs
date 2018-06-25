using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(17686)]
    public class CompositeDrawablePropChunk : NamedChunk
    {
        public uint IsTranslucent;
        public uint SkeletonJointID;

        public CompositeDrawablePropChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            base.ReadHeader(stream, length);
            this.IsTranslucent = reader.ReadUInt32();
            this.SkeletonJointID = reader.ReadUInt32();
        }

        public override string ToString()
        {
            return $"Composite Drawable Prop: {Name}";
        }
    }
}
