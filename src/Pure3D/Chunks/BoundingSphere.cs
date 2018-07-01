using System.IO;
using System.Text;

namespace Pure3D.Chunks
{
    [ChunkType(65540)]
    public class BoundingSphere : Chunk
    {
        public Vector3 Centre;
        public float Radius;

        public BoundingSphere(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            Centre = Util.ReadVector3(reader);
            Radius = reader.ReadSingle();
        }

        public override string ToString()
        {
            return "Bounding Sphere";
        }
    }
}
