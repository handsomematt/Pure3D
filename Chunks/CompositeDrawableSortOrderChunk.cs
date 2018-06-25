using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(17689)]
    public class CompositeDrawableSortOrderChunk : Chunk
    {
        public float SortOrder;

        public CompositeDrawableSortOrderChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            this.SortOrder = new BinaryReader(stream).ReadSingle();
        }

        public override string ToString()
        {
            return $"Composite Drawable Sort Order ({SortOrder})";
        }
    }
}
