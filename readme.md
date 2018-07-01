# Pure3D

.NET library for loading the Pure3D file format, used in Radical Entertainment's
Pure3D game engine used most famously for the following games:

* The Simpsons: Road Rage
* The Simpsons: Hit & Run
* Crash Tag Team Racing

## Usage

```C#
static void Main(string[] args)
{
    var file = new Pure3D.File();
    file.Load("mrplo_v.p3d");
    PrintHierarchy(file.RootChunk, 0);
}

static void PrintHierarchy(Pure3D.Chunk chunk, int indent)
{
    Console.WriteLine("{1}{0}", chunk.ToString(), new String('\t', indent));
    foreach (var child in chunk.Children)
        PrintHierarchy(child, indent + 1);
}
```

## License
 
[The MIT License (MIT) - Copyright (c) 2018 Matt Stevens](license)