using System;
using System.Collections.Generic;
using SRTExampleProvider64.Structs;
using SRTExampleProvider64.Structs.GameStructs;

namespace SRTExampleProvider64
{
    public interface IGameMemoryExample
    {
        string GameName { get; }
        string VersionInfo { get; }
        GameExampleStruct Example { get; set; }
    }
}
