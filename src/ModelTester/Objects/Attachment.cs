using System.Runtime.InteropServices;
using ModelTester.Parsers;

namespace ModelTester.Objects {
    using static OptionalBlocks;
    using Transforms = System.Collections.Generic.Dictionary<OptionalBlocks, IOptionalBlocksParser<Attachment>>;

    public unsafe struct Attachment : IDataRW {
        public Node Node;
        public LocalProperties Properties;
        public Transform<float> VisibilityTransform;

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
            [KATV] = new OptionalBlockParser<Transform<float>, Attachment>((ref Attachment p) => ref p.VisibilityTransform),
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct LocalProperties {
            const uint PATH_LEN = 260;

            fixed byte name[(int)PATH_LEN];
            public int AttachmentId;

            public string Path {
                get {
                    fixed(byte* n = name)
                        return BinaryString.Decode(n, PATH_LEN);
                }
                set {
                    fixed(byte* n = name)
                        BinaryString.Encode(value, n, PATH_LEN);
                }
            }
        }
    }
}
