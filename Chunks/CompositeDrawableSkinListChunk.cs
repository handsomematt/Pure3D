using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(17683)]
    public class CompositeDrawableSkinListChunk : Chunk
    {
        public uint NumElements;

        public CompositeDrawableSkinListChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            this.NumElements = new BinaryReader(stream).ReadUInt32();
        }

        public override string ToString()
        {
            return $"Composite Drawable Skin List (Elements: {NumElements})";
        }
    }
}
