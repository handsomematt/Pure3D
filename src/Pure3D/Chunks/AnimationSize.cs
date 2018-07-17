using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(1183748)]
    public class AnimationSize : Chunk
    {
        public uint Version;
        public uint PC;
        public uint PS2;
        public uint Xbox;
        public uint GameCube;

        public AnimationSize(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            Version = reader.ReadUInt32();
            PC = reader.ReadUInt32();
            PS2 = reader.ReadUInt32();
            Xbox = reader.ReadUInt32();
            GameCube = reader.ReadUInt32();
        }

        public override string ToString()
        {
            return $"Animation Size: Version {Version}, PC {PC}, PS2 {PS2}, Xbox {Xbox}, GameCube {GameCube}";
        }
    }
}
