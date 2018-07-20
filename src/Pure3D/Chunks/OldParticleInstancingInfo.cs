using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(88075)]
    public class OldParticleInstancingInfo : Chunk
    {
        public byte[] Data;
        private uint unknownType;

        public OldParticleInstancingInfo(File file, uint type) : base(file, type)
        {
            unknownType = type;
        }

        public override void ReadHeader(Stream stream, long length)
        {
            Data = new BinaryReader(stream).ReadBytes((int)length);
        }

        public override string ToString()
        {
            return $"Unknown Chunk (TypeID: {unknownType}) (Len: {Data.Length})";
        }
    }
}
