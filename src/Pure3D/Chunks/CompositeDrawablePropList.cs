using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(17684)]
    public class CompositeDrawablePropList : Chunk
    {
        public uint NumElements;

        public CompositeDrawablePropList(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            NumElements = new BinaryReader(stream).ReadUInt32();
        }

        public override string ToString()
        {
            return $"Composite Drawable Prop List (Elements: {NumElements})";
        }
    }
}
