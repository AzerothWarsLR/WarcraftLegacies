using System;
using System.Runtime.InteropServices;
using ModelTester.Parsers;

namespace ModelTester.Objects {
    using static OptionalBlocks;
    using Transforms = System.Collections.Generic.Dictionary<OptionalBlocks, IOptionalBlocksParser<Layer>>;

    public struct Layer : IDataRW {
        public LocalProperties Properties;
        public Transform<int> MaterialTextureIdTransform;
        public Transform<float> MaterialAlphaTransform;

        void IDataRW.ReadFrom(DataStream ds) {
            var end = ds.Offset + ds.ReadStruct<uint>();
            ds.ReadStruct(ref Properties);
            ds.ReadOptionalBlocks(ref this, _knownTransforms, end);
        }

        void IDataRW.WriteTo(DataStream ds) {
            var offset = ds.Offset;
            ds.Skip(sizeof(uint));
            ds.WriteStruct(ref Properties);
            ds.WriteOptionalBlocks(ref this, _knownTransforms);
            ds.SetValueAt(offset, ds.Offset - offset);
        }

        static readonly Transforms _knownTransforms = new Transforms {
            [KMTF] = new OptionalBlockParser<Transform<int>, Layer>((ref Layer p) => ref p.MaterialTextureIdTransform),
            [KMTA] = new OptionalBlockParser<Transform<float>, Layer>((ref Layer p) => ref p.MaterialAlphaTransform),
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct LocalProperties {
            public FilterMode FilterMode;
            public ShadingFlags ShadingFlags;
            public int TextureId, TextureAnimationId, CoordId;
            public float Alpha;
        }

        public enum FilterMode : uint {
            None,
            Transparent,
            Blend,
            Additive,
            AddAlpha,
            Modulate,
            Modulate2x,
        }

        [Flags]
        public enum ShadingFlags : uint {
            Unshaded = 0x1,
            SphereEnvironmentMap = 0x2,
            TwoSided = 0x10,
            Unfogged = 0x20,
            NoDepthTest = 0x40,
            NoDepthSet = 0x80,
        }
    }
}
