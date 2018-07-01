using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pure3D
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new Pure3D.File();
            file.Load("marge_m.p3d");

            PrintHierarchy(file.RootChunk, 0);

            Console.ReadKey();
        }

        static void PrintHierarchy(Pure3D.Chunk chunk, int indent)
        {
            Console.WriteLine("{1}{0}", chunk.ToString(), new String('\t', indent));

            foreach (var child in chunk.Children)
                PrintHierarchy(child, indent + 1);
        }
    }
}
