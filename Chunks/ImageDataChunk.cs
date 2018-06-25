using System.IO;

namespace Pure3D.Chunks
{
    [ChunkType(102402)]
    public class ImageDataChunk : Chunk
    {
        public byte[] Data;

        public ImageDataChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
            BinaryReader reader = new BinaryReader(stream);
            uint len = reader.ReadUInt32();
            this.Data = reader.ReadBytes((int)len);
        }

        public override string ToString()
        {
            return $"Image Data (Header: {Data[0].ToString("X")} {Data[1].ToString("X")} {Data[2].ToString("X")} {Data[3].ToString("X")}) (Len: {Data.Length})";
        }
    }
}
