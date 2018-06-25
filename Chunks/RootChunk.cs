using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pure3D.Chunks
{
    public class RootChunk : Chunk
    {
        public RootChunk(File file, uint type) : base(file, type)
        {
        }

        public override void ReadHeader(Stream stream, long length)
        {
        }

        public override string ToString()
        {
            return "Root";
        }
    }
}
