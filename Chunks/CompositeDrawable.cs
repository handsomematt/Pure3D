using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(17682)]
    public class CompositeDrawable : Named
    {
        public string SkeletonName;

        public CompositeDrawable(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            base.ReadHeader(stream, length);
            SkeletonName = Util.ReadString(new BinaryReader(stream));
        }

        public override string ToString()
        {
            return $"Composite Drawable: {Name} (Skeleton: {SkeletonName})";
        }
    }
}
