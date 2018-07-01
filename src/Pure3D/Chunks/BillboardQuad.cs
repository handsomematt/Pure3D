﻿using System.IO;
using System.Text;

namespace Pure3D.Chunks
{
    [ChunkType(94209)]
    public class BillboardQuad : Named
    {
        public uint Version;
        public string BillboardMode;
        public Vector3 Translation;
        public uint Colour;
        public Vector2 Uv0;
        public Vector2 Uv1;
        public Vector2 Uv2;
        public Vector2 Uv3;
        public float Width;
        public float Height;
        public float Distance;
        public Vector2 UVOffset;

        public BillboardQuad(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            Version = reader.ReadUInt32();
            base.ReadHeader(stream, length);
            BillboardMode = Util.ZeroTerminate(Encoding.ASCII.GetString(new BinaryReader(stream).ReadBytes(4)));
            Translation = Util.ReadVector3(reader);
            Colour = reader.ReadUInt32();
            Uv0 = Util.ReadVector2(reader);
            Uv1 = Util.ReadVector2(reader);
            Uv2 = Util.ReadVector2(reader);
            Uv3 = Util.ReadVector2(reader);
            Width = reader.ReadSingle();
            Height = reader.ReadSingle();
            Distance = reader.ReadSingle();
            UVOffset = Util.ReadVector2(reader);
        }

        public override string ToString()
        {
            return $"Billboard Quad: {Name}";
        }
    }
}
