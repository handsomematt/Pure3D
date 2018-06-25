using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(17668)]
    public class SkeletonJointBonePreserveChunk : Chunk
    {
        public uint PreserveBoneLengths;

        public SkeletonJointBonePreserveChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            this.PreserveBoneLengths = new BinaryReader(stream).ReadUInt32();
        }

        public override string ToString()
        {
            return "Skeleton Joint Bone Preserve";
        }
    }
}
