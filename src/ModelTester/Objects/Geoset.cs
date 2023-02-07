using System.Runtime.InteropServices;

namespace ModelTester.Objects {
    using static InnerBlocks;

    public struct Geoset : IDataRW {
        public Vec3[] VertexPositions, VertexNormals;
        public FaceTypeGroup[] FaceTypeGroups;
        public uint[] FaceGroups, MatrixGroups, MatrixIndices;
        public ushort[] Faces;
        public byte[] VertexGroups;
        public LocalProperties Properties;
        public Extent[] SequenceExtents;
        public TextureCoordinateSet[] TextureCoordinateSets;

        void IDataRW.ReadFrom(DataStream ds) {
            ds.Skip(sizeof(uint));

            ds.CheckTag(VRTX);
            VertexPositions = ds.ReadStructArray<Vec3>();

            ds.CheckTag(NRMS);
            VertexNormals = ds.ReadStructArray<Vec3>();

            ds.CheckTag(PTYP);
            FaceTypeGroups = ds.ReadStructArray<FaceTypeGroup>();

            ds.CheckTag(PCNT);
            FaceGroups = ds.ReadStructArray<uint>();

            ds.CheckTag(PVTX);
            Faces = ds.ReadStructArray<ushort>();

            ds.CheckTag(GNDX);
            VertexGroups = ds.ReadStructArray<byte>();

            ds.CheckTag(MTGC);
            MatrixGroups = ds.ReadStructArray<uint>();

            ds.CheckTag(MATS);
            MatrixIndices = ds.ReadStructArray<uint>();

            ds.ReadStruct(ref Properties);

            SequenceExtents = ds.ReadStructArray<Extent>();

            ds.CheckTag(UVAS);
            TextureCoordinateSets = ds.ReadDataArray<TextureCoordinateSet>();
        }

        void IDataRW.WriteTo(DataStream ds) {
            var offset = ds.Offset;
            ds.Skip(sizeof(uint));

            ds.WriteStruct(VRTX);
            ds.WriteStructArray(VertexPositions);

            ds.WriteStruct(NRMS);
            ds.WriteStructArray(VertexNormals);

            ds.WriteStruct(PTYP);
            ds.WriteStructArray(FaceTypeGroups);

            ds.WriteStruct(PCNT);
            ds.WriteStructArray(FaceGroups);

            ds.WriteStruct(PVTX);
            ds.WriteStructArray(Faces);

            ds.WriteStruct(GNDX);
            ds.WriteStructArray(VertexGroups);

            ds.WriteStruct(MTGC);
            ds.WriteStructArray(MatrixGroups);

            ds.WriteStruct(MATS);
            ds.WriteStructArray(MatrixIndices);

            ds.WriteStruct(ref Properties);

            ds.WriteStructArray(SequenceExtents);

            ds.WriteStruct(UVAS);
            ds.WriteDataArray(TextureCoordinateSets);

            ds.SetValueAt(offset, ds.Offset - offset);
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct LocalProperties {
            public int MaterialId;
            public uint SelectionGroup;
            public SelectionType SelectionType;
            public Extent Extent;
        }

        public enum FaceTypeGroup : uint {
            Points,
            Lines,
            LineLoop,
            LineStrip,
            Triangles,
            TriangleStrip,
            TriangleFan,
            Quads,
            QuadStrip,
            Polygons,
        }

        public enum SelectionType : uint {
            None,
            Unselectable = 4,
        }
    }
}
