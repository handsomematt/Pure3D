using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Pure3D
{
    public abstract class Chunk
    {
        public uint Type;
        public List<Chunk> Children;
        public File File;
        public Chunk Parent;

        public bool IsRoot
        {
            get
            {
                return this == File.RootChunk;
            }
        }

        public Chunk(File file, uint type)
        {
            Children = new List<Chunk>();
            Type = type;
            File = file;
        }

        public T[] GetChildren<T>() where T : Chunk
        {
            return Children.FindAll(delegate (Chunk c) { return c is T; }).Cast<T>().ToArray();
        }

        public T[] GetChildrenByName<T>(string name) where T : Chunks.Named
        {
            return Children.FindAll(delegate (Chunk c) { return c is T && ((Chunks.Named)c).Name == name; }).Cast<T>().ToArray();
        }

        public void ReadChildren(Stream stream, long chunkEnd)
        {
            // todo: probably move all this logic to a seperate method.
            while (stream.Position < chunkEnd)
            {
                uint type = new BinaryReader(stream).ReadUInt32();
                Chunk chunk = NewChunkFromType(File, type);

                // sort hierarchy
                chunk.Parent = this;
                Children.Add(chunk);

                chunk.Read(stream, true, chunkEnd);
            }
        }

        public void Read(Stream stream, bool readChildren, long parentChunkEnd)
        {
            BinaryReader reader = new BinaryReader(stream);
            long chunkStart = stream.Position - 4;
            uint headerSize = reader.ReadUInt32();
            uint chunkSize = reader.ReadUInt32();

            if (headerSize > chunkSize)
                throw new Exception($"Header size {headerSize} greater then chunk size {chunkSize}.");

            if (!readChildren)
                headerSize = chunkSize;

            if ((stream.Position + chunkSize - 12) > parentChunkEnd)
                throw new Exception("Chunk size too high.");

            long chunkEnd = chunkStart + chunkSize;

            ReadHeader(stream, headerSize - 12);

            if (readChildren)
                ReadChildren(stream, chunkEnd);

            if (stream.Position != chunkEnd)
                throw new Exception($"Stream position expected {chunkEnd} but is {stream.Position}");
        }

        public abstract void ReadHeader(Stream stream, long length);

        protected static Dictionary<uint, Type> chunkTypeDictionary = null;
        public static Chunk NewChunkFromType(File file, uint type)
        {
            // cache the list
            if (chunkTypeDictionary == null)
            {
                chunkTypeDictionary = new Dictionary<uint, Type>();

                foreach (var chunk in ChunkType.GetSupported())
                {
                    ChunkType chunkAttr = (ChunkType)chunk.GetCustomAttribute(typeof(ChunkType), false);
                    chunkTypeDictionary[chunkAttr.TypeID] = chunk;
                }
            }

            if (!chunkTypeDictionary.ContainsKey(type))
                return new Chunks.Unknown(file, type);

            Type chunkType = chunkTypeDictionary[type];
            return (Chunk)Activator.CreateInstance(chunkType, new object[] { file, type });
        }
    }
}
