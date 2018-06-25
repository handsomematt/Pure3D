using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(8704)]
    public class CameraChunk : NamedChunk
    {
        public uint Version;
        public float FieldOfView;
        public float AspectRatio;
        public float NearClip;
        public float FarClip;
        public Vector3 Position;
        public Vector3 Look;
        public Vector3 Up;

        public CameraChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            base.ReadHeader(stream, length);
            this.Version = reader.ReadUInt32();
            this.FieldOfView = reader.ReadSingle();
            this.AspectRatio = reader.ReadSingle();
            this.NearClip = reader.ReadSingle();
            this.FarClip = reader.ReadSingle();
            this.Position = Util.ReadVector3(reader);
            this.Look = Util.ReadVector3(reader);
            this.Up = Util.ReadVector3(reader);
        }

        public override string ToString()
        {
            return $"Camera: {Name}";
        }
    }
}
