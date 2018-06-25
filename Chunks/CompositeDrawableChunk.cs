using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(17682)]
    public class CompositeDrawableChunk : NamedChunk
    {
        public string SkeletonName;

        public CompositeDrawableChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            base.ReadHeader(stream, length);
            this.SkeletonName = Util.ReadString(new BinaryReader(stream));
        }

        public override string ToString()
        {
            return $"Composite Drawable: {Name} (Skeleton: {SkeletonName})";
        }
    }
}
