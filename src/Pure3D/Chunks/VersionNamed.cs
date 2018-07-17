using System.IO;

namespace Pure3D.Chunks
{
    // Base class for a lot of stuff, don't use directly.
    public class VersionNamed : Named
    {
        public uint Version;

        public VersionNamed(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            var reader = new BinaryReader(stream);
            Version = reader.ReadUInt32();
            Name = Util.ReadString(reader);
        }

        public override string ToString()
        {
            return $"Named Chunk: {Name}, Version {Version}";
        }
    }
}
