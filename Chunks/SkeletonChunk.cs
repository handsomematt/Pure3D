﻿using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(17664)]
    public class SkeletonChunk : NamedChunk
    {
        public uint Version;
        protected uint NumJoints; // should be equal to # of children

        public SkeletonChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            base.ReadHeader(stream, length);
            Version = reader.ReadUInt32();
            NumJoints = reader.ReadUInt32();
        }

        public override string ToString()
        {
            return $"Skeleton: {Name}";
        }
    }
}
