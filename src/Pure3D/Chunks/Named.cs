using System.IO;

namespace Pure3D.Chunks
{
    /// <summary>
    /// Base class for any chunk that has a string of it's name attached.
    /// Useful for searching by name.
    /// </summary>
    public class Named : Chunk
    {
        public string Name;

        public Named(File file, uint type) : base(file, type)
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
