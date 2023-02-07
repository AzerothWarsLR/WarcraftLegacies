using System.Runtime.InteropServices;
using ModelTester.Parsers;

namespace ModelTester.Objects {
    using static OptionalBlocks;
    using Transforms = System.Collections.Generic.Dictionary<OptionalBlocks, IOptionalBlocksParser<RibbonEmitter>>;

    public unsafe struct RibbonEmitter : IDataRW {
        public Node Node;
        public LocalProperties Properties;
        public Transform<float> VisibilityTransform, HeightAboveTransform, HeightBelowTransform, AlphaTransform, ColorTransform, TextureSlotTransform;

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
            [KRVS] = new OptionalBlockParser<Transform<float>, RibbonEmitter>((ref RibbonEmitter p) => ref p.VisibilityTransform),
            [KRHA] = new OptionalBlockParser<Transform<float>, RibbonEmitter>((ref RibbonEmitter p) => ref p.HeightAboveTransform),
            [KRHB] = new OptionalBlockParser<Transform<float>, RibbonEmitter>((ref RibbonEmitter p) => ref p.HeightBelowTransform),
            [KRAL] = new OptionalBlockParser<Transform<float>, RibbonEmitter>((ref RibbonEmitter p) => ref p.AlphaTransform),
            [KRCO] = new OptionalBlockParser<Transform<float>, RibbonEmitter>((ref RibbonEmitter p) => ref p.ColorTransform),
            [KRTX] = new OptionalBlockParser<Transform<float>, RibbonEmitter>((ref RibbonEmitter p) => ref p.TextureSlotTransform),
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct LocalProperties {
            public float HeightAbove, HeightBelow, Alpha;
            public Color Color;
            public float Lifespan;
            public uint TextureSlot, EmissionRate, Rows, Columns;
            public int MaterialId;
            public float Gravity;
        }
    }
}
