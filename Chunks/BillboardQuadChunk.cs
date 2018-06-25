using System.IO;
using System.Text;

namespace Pure3D.Chunks
{
    [ChunkType(94209)]
    public class BillboardQuadChunk : NamedChunk
    {
        public uint Version;
        public string BillboardMode;
        public Vector3 Translation;
        public uint Colour;
        public Vector2 Uv0;
        public Vector2 Uv1;
        public Vector2 Uv2;
        public Vector2 Uv3;
        public float Width;
        public float Height;
        public float Distance;
        public Vector2 UVOffset;

        public BillboardQuadChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            this.Version = reader.ReadUInt32();
            base.ReadHeader(stream, length);
            this.BillboardMode = Util.ZeroTerminate(Encoding.ASCII.GetString(new BinaryReader(stream).ReadBytes(4)));
            this.Translation = Util.ReadVector3(reader);
            this.Colour = reader.ReadUInt32();
            this.Uv0 = Util.ReadVector2(reader);
            this.Uv1 = Util.ReadVector2(reader);
            this.Uv2 = Util.ReadVector2(reader);
            this.Uv3 = Util.ReadVector2(reader);
            this.Width = reader.ReadSingle();
            this.Height = reader.ReadSingle();
            this.Distance = reader.ReadSingle();
            this.UVOffset = Util.ReadVector2(reader);
        }

        public override string ToString()
        {
            return $"Billboard Quad: {Name}";
        }
    }
}
