using System.Runtime.InteropServices;
using ModelTester.Parsers;

namespace ModelTester.Objects {
    using static OptionalBlocks;
    using Transforms = System.Collections.Generic.Dictionary<OptionalBlocks, IOptionalBlocksParser<ParticleEmitter2>>;

    public unsafe struct ParticleEmitter2 : IDataRW {
        public Node Node;
        public LocalProperties Properties;
        public Transform<float> EmissionRateTransform, GravityTransform, LatitudeTransform, SpeedTransform, VisibilityTransform, VariationTransform, LengthTransform, WidthTransform;

        void IDataRW.ReadFrom(DataStream ds) {
            var end = ds.Offset + ds.ReadStruct<uint>();
            ds.ReadData(ref Node);
            ds.ReadStruct(ref Properties);
            ds.ReadOptionalBlocks(ref this, _knownTransforms, end);
        }

        void IDataRW.WriteTo(DataStream ds) {
            var offset = ds.Offset;
            ds.Skip(sizeof(uint));
            ds.WriteData(ref Node);
            ds.WriteStruct(ref Properties);
            ds.WriteOptionalBlocks(ref this, _knownTransforms);
            ds.SetValueAt(offset, ds.Offset - offset);
        }

        static readonly Transforms _knownTransforms = new Transforms {
            [KP2E] = new OptionalBlockParser<Transform<float>, ParticleEmitter2>((ref ParticleEmitter2 p) => ref p.EmissionRateTransform),
            [KP2G] = new OptionalBlockParser<Transform<float>, ParticleEmitter2>((ref ParticleEmitter2 p) => ref p.GravityTransform),
            [KP2L] = new OptionalBlockParser<Transform<float>, ParticleEmitter2>((ref ParticleEmitter2 p) => ref p.LatitudeTransform),
            [KP2S] = new OptionalBlockParser<Transform<float>, ParticleEmitter2>((ref ParticleEmitter2 p) => ref p.SpeedTransform),
            [KP2V] = new OptionalBlockParser<Transform<float>, ParticleEmitter2>((ref ParticleEmitter2 p) => ref p.VisibilityTransform),
            [KP2R] = new OptionalBlockParser<Transform<float>, ParticleEmitter2>((ref ParticleEmitter2 p) => ref p.VariationTransform),
            [KP2N] = new OptionalBlockParser<Transform<float>, ParticleEmitter2>((ref ParticleEmitter2 p) => ref p.LengthTransform),
            [KP2W] = new OptionalBlockParser<Transform<float>, ParticleEmitter2>((ref ParticleEmitter2 p) => ref p.WidthTransform),
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct LocalProperties {
            public float Speed, Variation, Latitude, Gravity, Lifespan, EmissionRate, Length, Width;
            public FilterMode FilterMode;
            public uint Rows, Columns;
            public HeadTailType HeadTailType;
            public float TailLength, Time;
            public SegmentColor SegmentColor;
            public SegmentAlpha SegmentAlpha;
            public Vec3 SegmentScaling;
            public Interval HeadInterval, HeadDecayInterval, TailInterval, TailDecayInterval;
            public int TextureId;
            public Squirt Squirt;
            public uint PriorityPlane;
            public int ReplaceableId;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SegmentColor {
            public Color Color1, Color2, Color3;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SegmentAlpha {
            public byte Alpha1, Alpha2, Alpha3;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Interval {
            public uint Start, End, Repeat;
        }

        public enum FilterMode : uint {
            Blend,
            Additive,
            Modulate,
            Modulate2x,
            AddAlpha,
        }

        public enum HeadTailType : uint {
            Head,
            Tail,
            Both,
        }

        public enum Squirt : uint {
            NoSquirt,
            Squirt,
        }
    }
}
