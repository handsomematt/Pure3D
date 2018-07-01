using System.IO;

namespace Pure3D.Chunks
{
    // Base class for a lot of stuff, don't use directly.
    public class NamedChunk : Chunk
    {
        public string Name;

        public NamedChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            Name = Util.ReadString(new BinaryReader(stream));
        }

        public override string ToString()
        {
            return $"Named Chunk: {Name}";
        }
    }
}
