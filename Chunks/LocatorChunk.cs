﻿using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(81920)]
    public class LocatorChunk : NamedChunk
    {
        public uint Version;
        public Vector3 Position;

        public LocatorChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            base.ReadHeader(stream, length);
            Version = reader.ReadUInt32();
            Position = Util.ReadVector3(reader);
        }

        public override string ToString()
        {
            return $"Locator: {Name}";
        }
    }
}
