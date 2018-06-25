using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(17684)]
    public class CompositeDrawablePropListChunk : Chunk
    {
        public uint NumElements;

        public CompositeDrawablePropListChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            this.NumElements = new BinaryReader(stream).ReadUInt32();
        }

        public override string ToString()
        {
            return $"Composite Drawable Prop List (Elements: {NumElements})";
        }
    }
}
