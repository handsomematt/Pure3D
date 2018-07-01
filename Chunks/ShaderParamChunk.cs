using System.IO;
using System.Text;

namespace Pure3D.Chunks
{
    public abstract class ShaderParamChunk : Chunk
    {
        public string Param;

        public ShaderParamChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            Param = Util.ZeroTerminate(Encoding.ASCII.GetString(new BinaryReader(stream).ReadBytes(4)));
        }

        public override string ToString()
        {
            return $"Shader Parameter: {Param}";
        }
    }

    [ChunkType(69634)]
    public class ShaderTextureParamChunk : ShaderParamChunk
    {
        public string Value;

        public ShaderTextureParamChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            base.ReadHeader(stream, length);
            Value = Util.ReadString(new BinaryReader(stream));
        }
    }

    [ChunkType(69635)]
    public class ShaderIntParamChunk : ShaderParamChunk
    {
        public uint Value;

        public ShaderIntParamChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            base.ReadHeader(stream, length);
            Value = new BinaryReader(stream).ReadUInt32();
        }
    }

    [ChunkType(69636)]
    public class ShaderFloatParamChunk : ShaderParamChunk
    {
        public float Value;

        public ShaderFloatParamChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            base.ReadHeader(stream, length);
            Value = new BinaryReader(stream).ReadSingle();
        }
    }

    [ChunkType(69637)]
    public class ShaderColourParamChunk : ShaderParamChunk
    {
        public uint Color;

        public ShaderColourParamChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            base.ReadHeader(stream, length);
            Color = new BinaryReader(stream).ReadUInt32();
        }
    }
}
