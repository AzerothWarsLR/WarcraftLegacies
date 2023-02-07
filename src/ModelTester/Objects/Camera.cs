using System.Runtime.InteropServices;
using ModelTester.Parsers;

namespace ModelTester.Objects {
    using static OptionalBlocks;
    using Transforms = System.Collections.Generic.Dictionary<OptionalBlocks, IOptionalBlocksParser<Camera>>;

    public unsafe struct Camera : IDataRW {
        public LocalProperties Properties;
        public Transform<Vec3> Translation, TargetTranslation;
        public Transform<uint> Rotation;

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
            [KCTR] = new OptionalBlockParser<Transform<Vec3>, Camera>((ref Camera p) => ref p.Translation),
            [KCRL] = new OptionalBlockParser<Transform<uint>, Camera>((ref Camera p) => ref p.Rotation),
            [KTTR] = new OptionalBlockParser<Transform<Vec3>, Camera>((ref Camera p) => ref p.TargetTranslation),
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct LocalProperties {
            const uint NAME_LEN = 80;

            fixed byte name[(int)NAME_LEN];
            public Vec3 Position, TargetPosition;
            public uint FiledOfView, FarClippingPlane, NearClippingPlane;

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
        }
    }
}
