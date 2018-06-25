using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(50331904)]
    public class CarCameraDataChunk : Chunk
    {
        public uint Index;
        public float Unknown;
        public float Angle;
        public float Distance;
        public Vector3 Look;

        public CarCameraDataChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            this.Index = reader.ReadUInt32();
            this.Unknown = reader.ReadSingle();
            this.Angle = reader.ReadSingle();
            this.Distance = reader.ReadSingle();
            this.Look = Util.ReadVector3(reader);
        }

        public override string ToString()
        {
            return $"Car Camera Data ({Index})";
        }
    }
}
