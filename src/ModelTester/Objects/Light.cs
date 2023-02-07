using System.Runtime.InteropServices;
using ModelTester.Parsers;

namespace ModelTester.Objects {
    using static OptionalBlocks;
    using Transforms = System.Collections.Generic.Dictionary<OptionalBlocks, IOptionalBlocksParser<Light>>;

    public unsafe struct Light : IDataRW {
        public Node node;
        public LocalProperties Properties;
        public Transform<uint> AttenuationStartTransform, AttenuationEndTransform;
        public Transform<Color> ColorTransform, AmbientColorTransform;
        public Transform<float> IntensityTransform, AmbientIntensityTransform, VisibilityTransform;

        void IDataRW.ReadFrom(DataStream ds) {
            var end = ds.Offset + ds.ReadStruct<uint>();
            ds.ReadData(ref node);
            ds.ReadStruct(ref Properties);
            ds.ReadOptionalBlocks(ref this, _knownTransforms, end);
        }

        void IDataRW.WriteTo(DataStream ds) {
            var offset = ds.Offset;
            ds.Skip(sizeof(uint));
            ds.WriteData(ref node);
            ds.WriteStruct(ref Properties);
            ds.WriteOptionalBlocks(ref this, _knownTransforms);
            ds.SetValueAt(offset, ds.Offset - offset);
        }

        static readonly Transforms _knownTransforms = new Transforms {
            [KLAS] = new OptionalBlockParser<Transform<uint>, Light>((ref Light p) => ref p.AttenuationStartTransform),
            [KLAE] = new OptionalBlockParser<Transform<uint>, Light>((ref Light p) => ref p.AttenuationEndTransform),
            [KLAC] = new OptionalBlockParser<Transform<Color>, Light>((ref Light p) => ref p.ColorTransform),
            [KLAI] = new OptionalBlockParser<Transform<float>, Light>((ref Light p) => ref p.IntensityTransform),
            [KLBI] = new OptionalBlockParser<Transform<float>, Light>((ref Light p) => ref p.AmbientIntensityTransform),
            [KLBC] = new OptionalBlockParser<Transform<Color>, Light>((ref Light p) => ref p.AmbientColorTransform),
            [KLAV] = new OptionalBlockParser<Transform<float>, Light>((ref Light p) => ref p.VisibilityTransform),
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct LocalProperties {
            public Type Type;
            public float AttenuationStart, AttenuationEnd;
            public Color Color;
            public float Intensity;
            public Color AmbientColor;
            public float AmbientIntensity;
        }

        public enum Type : uint {
            Omni,
            Directional,
            Ambient,
        }
    }
}
