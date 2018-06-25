using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(17687)]
    public class CompositeDrawableEffectListChunk : Chunk
    {
        public uint NumElements; // should be # of children.

        public CompositeDrawableEffectListChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            this.NumElements = new BinaryReader(stream).ReadUInt32();
        }

        public override string ToString()
        {
            return $"Composite Drawable Effect List ({NumElements} Elements)";
        }
    }
}
