using System;
using System.Runtime.InteropServices;

namespace ModelTester.Objects {
    using static InnerBlocks;

    public struct Material : IDataRW {
        public LocalProperties Properties;
        public Layer[] Layers;

        void IDataRW.ReadFrom(DataStream ds) {
            ds.Skip(sizeof(uint));
            ds.ReadStruct(ref Properties);
            ds.CheckTag(LAYS);
            Layers = ds.ReadDataArray<Layer>();
        }

        void IDataRW.WriteTo(DataStream ds) {
            var offset = ds.Offset;
            ds.Skip(sizeof(uint));
            ds.WriteStruct(ref Properties);
            ds.WriteStruct(LAYS);
            ds.WriteDataArray(Layers);

            ds.SetValueAt(offset, ds.Offset - offset);
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct LocalProperties {
            public uint PriorityPlane;
            public Flags Flags;
        }
        
        [Flags]
        public enum Flags : uint {
            None = 0x0,
            ConstantColor = 0x1,
            SortPrimitivesFarZ = 0x10,
            FullResolution = 0x20,
        }
    }
}
