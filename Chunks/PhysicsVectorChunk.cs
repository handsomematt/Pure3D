using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(117510146)]
    public class PhysicsVectorChunk : Chunk
    {
        public Vector3 Vector;

        public PhysicsVectorChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            Vector = Util.ReadVector3(new BinaryReader(stream));
        }

        public override string ToString()
        {
            return $"Physics Vector";
        }
    }
}
