﻿using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(117510176)]
    public class PhysicsJointChunk : Chunk
    {
        public uint Index;
        public float Volume;
        public float Stiffness;
        public float MaxAngle;
        public float MinAngle;
        public uint DOF;

        public PhysicsJointChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            this.Index = reader.ReadUInt32();
            this.Volume = reader.ReadSingle();
            this.Stiffness = reader.ReadSingle();
            this.MaxAngle = reader.ReadSingle();
            this.MinAngle = reader.ReadSingle();
            this.DOF = reader.ReadUInt32();
        }

        public override string ToString()
        {
            return $"Physics Joint {Index}";
        }
    }
}