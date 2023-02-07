using System.Runtime.InteropServices;

namespace ModelTester.Objects {
    public struct Bone : IDataRW {
        public Node Node;
        public LocalProperties Properties;

        void IDataRW.ReadFrom(DataStream ds) {
            ds.ReadData(ref Node);
            ds.ReadStruct(ref Properties);
        }

        void IDataRW.WriteTo(DataStream ds) {
            ds.WriteData(ref Node);
            ds.WriteStruct(ref Properties);
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct LocalProperties {
            public int GeosetId, GeosetAnimationId;
        }
    }
}
