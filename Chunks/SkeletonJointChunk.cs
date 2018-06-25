using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(17665)]
    public class SkeletonJointChunk : NamedChunk
    {
        public uint SkeletonParent;
        public int DOF;
        public int FreeAxis;
        public int PrimaryAxis;
        public int SecondaryAxis;
        public int TwistAxis;
        public Matrix RestPose;

        public SkeletonJointChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            base.ReadHeader(stream, length);
            this.SkeletonParent = reader.ReadUInt32();
            this.DOF = reader.ReadInt32();
            this.FreeAxis = reader.ReadInt32();
            this.PrimaryAxis = reader.ReadInt32();
            this.SecondaryAxis = reader.ReadInt32();
            this.TwistAxis = reader.ReadInt32();
            this.RestPose = Util.ReadMatrix(reader);
        }

        public override string ToString()
        {
            return $"Skeleton Joint: {Name}";
        }
    }
}
