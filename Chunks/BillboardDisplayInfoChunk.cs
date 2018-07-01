﻿using System.IO;
using System.Text;

namespace Pure3D.Chunks
{
    [ChunkType(94211)]
    public class BillboardDisplayInfoChunk : Chunk
    {
        public uint Version;
        public Quaternion Rotation;
        public string CutOffMode;
        public Vector2 UVOffsetRange;
        public float SourceRange;
        public float EdgeRange;

        public BillboardDisplayInfoChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            Version = reader.ReadUInt32();
            Rotation = Util.ReadQuaternion(reader);
            CutOffMode = Util.ZeroTerminate(Encoding.ASCII.GetString(new BinaryReader(stream).ReadBytes(4)));
            UVOffsetRange = Util.ReadVector2(reader);
            SourceRange = reader.ReadSingle();
            EdgeRange = reader.ReadSingle();
        }

        public override string ToString()
        {
            return "Billboard Display Info";
        }
    }
}
