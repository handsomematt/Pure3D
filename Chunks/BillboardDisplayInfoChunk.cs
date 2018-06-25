using System.IO;
using System.Text;

namespace Pure3D.Chunks
{
    [ChunkType(94211)]
    public class BillboardDisplayInfoChunk : Chunk
    {
        public uint Version;
        public Quaternion Rotation;
        public string CutOffMode;
        public Vector2 UVOffsetRange;
        public float SourceRange;
        public float EdgeRange;

        public BillboardDisplayInfoChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            this.Version = reader.ReadUInt32();
            this.Rotation = Util.ReadQuaternion(reader);
            this.CutOffMode = Util.ZeroTerminate(Encoding.ASCII.GetString(new BinaryReader(stream).ReadBytes(4)));
            this.UVOffsetRange = Util.ReadVector2(reader);
            this.SourceRange = reader.ReadSingle();
            this.EdgeRange = reader.ReadSingle();
        }

        public override string ToString()
        {
            return "Billboard Display Info";
        }
    }
}
