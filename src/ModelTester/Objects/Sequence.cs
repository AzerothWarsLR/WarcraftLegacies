using System.Runtime.InteropServices;

namespace ModelTester.Objects {
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct Sequence {
        const uint NAME_LEN = 80;

        fixed byte name[(int)NAME_LEN];
        public uint IntervalStart, IntervalEnd;
        public float MoveSpeed;
        public LoopType Type;
        public float Rarity;
        public uint SyncPoint;
        public Extent Extent;

        public string Name {
            get {
                fixed(byte* n = name)
                    return BinaryString.Decode(n, NAME_LEN);
            }
            set {
                fixed(byte* n = name)
                    BinaryString.Encode(value, n, NAME_LEN);
            }
        }

        public enum LoopType : uint {
            Looping,
            NonLooping,
        }
    }
}
