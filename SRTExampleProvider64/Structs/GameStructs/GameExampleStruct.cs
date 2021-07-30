using System.Runtime.InteropServices;

namespace SRTExampleProvider64.Structs.GameStructs
{
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 0x8)]

    public struct GameExampleStruct
    {
        [FieldOffset(0x0)] private float field1;
        [FieldOffset(0x4)] private float field2;

        public float Property1 => field1;
        public float Property2 => field2;
    }
}