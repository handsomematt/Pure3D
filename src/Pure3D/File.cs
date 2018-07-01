using System;
using System.IO;

namespace Pure3D
{
    public class File
    {
        public readonly Chunks.Root RootChunk;

        public File()
        {
            RootChunk = new Chunks.Root(this, 0);
        }

        public void Load(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                Load(fileStream);
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

            RootChunk.Read(stream, true, stream.Length);
        }
    }

    public enum FileTypes : uint
    {
        RZ = 0x5A52, // 'RZ' zlib deflate
        CompressedPure3D = 0x5A443350, // 'P3DZ' proprietary compression
        Pure3D = 0xFF443350, // 'P3D' normal :) (most of the files are in this format)
    }
}
