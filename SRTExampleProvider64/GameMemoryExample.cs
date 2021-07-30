using System;
using System.Globalization;
using System.Collections.Generic;
using SRTExampleProvider64.Structs;
using System.Diagnostics;
using System.Reflection;
using SRTExampleProvider64.Structs.GameStructs;

namespace SRTExampleProvider64
{
    public class GameMemoryExample : IGameMemoryExample
    {
        public string GameName => "Example Game Name";
        public string VersionInfo => FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

        public GameExampleStruct Example { get => _example; set => _example = value; }
        internal GameExampleStruct _example;
    }
}
