using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(17686)]
    public class CompositeDrawableProp : Named
    {
        public uint IsTranslucent;
        public uint SkeletonJointID;

        public CompositeDrawableProp(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            base.ReadHeader(stream, length);
            IsTranslucent = reader.ReadUInt32();
            SkeletonJointID = reader.ReadUInt32();
        }

        public override string ToString()
        {
            return $"Composite Drawable Prop: {Name}";
        }
    }
}
