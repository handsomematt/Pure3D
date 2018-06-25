using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(117510145)]
    public class PhysicsInertiaMatrixChunk : Chunk
    {
        public Vector3 X;
        public Vector3 Y;

        public PhysicsInertiaMatrixChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            this.X = Util.ReadVector3(reader);
            this.Y = Util.ReadVector3(reader);
        }

        public override string ToString()
        {
            return "Physics Inertia Matrix";
        }
    }
}
