using System.Runtime.InteropServices;

namespace ModelTester.Objects {
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ModelInfo {
        const uint
            NAME_LEN = 80,
            ANIM_LEN = 260;

        fixed byte name[(int)NAME_LEN], animationFile[(int)ANIM_LEN];
        public Extent Extent;
        public uint BlendTime;

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

        public string AnimationFile {
            get {
                fixed(byte* n = animationFile)
                    return BinaryString.Decode(n, ANIM_LEN);
            }
            set {
                fixed(byte* n = animationFile)
                    BinaryString.Encode(value, n, ANIM_LEN);
            }
        }
    }
}
