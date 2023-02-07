using System.Runtime.InteropServices;

namespace ModelTester {
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vec2 {
        public float X, Y;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vec3 {
        public float X, Y, Z;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vec4 {
        public float X, Y, Z, W;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Color {
        public float B, G, R;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Extent {
        public float BoundsRadius;
        public Vec3 Minimum, Maximum;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GlobalSequence {
        public uint Duration;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Pivot {
        public Vec3 Position;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Track<T> where T : unmanaged {
        public int Frame;
        public T Value;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TrackInter<T> where T : unmanaged {
        public int Frame;
        public T Value, ValueIn, ValueOut;
    }
}
