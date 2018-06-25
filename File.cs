using System;
using System.IO;

namespace Pure3D
{
    public class File
    {
        public readonly Chunk RootChunk;

        public File()
        {
            this.RootChunk = new Chunks.RootChunk(this, 0);
        }

        public void Load(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                this.Load((Stream)fileStream);
        }

        public void Load(Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream);
            FileTypes fileType = (FileTypes)reader.ReadUInt32();

            if (fileType == FileTypes.RZ)
            {
                throw new Exception("RZ Pure3D not supported yet.");
                // todo: this is just a deflate stream really
            }
            if (fileType == FileTypes.CompressedPure3D)
            {
                throw new Exception("Compressed Pure3D not supported yet.. weird compression");
                // todo: redirect the stream
            }
             
            this.RootChunk.Read(stream, true, stream.Length);
        }
    }

    public enum FileTypes : uint
    {
        RZ = 0x5A52, // 'RZ' zlib deflate
        CompressedPure3D = 0x5A443350, // 'P3DZ' proprietary compression
        Pure3D = 0xFF443350, // 'P3D' normal :) (most of the files are in this format)
    }
}
