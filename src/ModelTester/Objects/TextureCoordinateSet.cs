namespace ModelTester.Objects {
    using static InnerBlocks;

    public struct TextureCoordinateSet : IDataRW {
        public Vec2[] TextureCoordinates;

        void IDataRW.ReadFrom(DataStream ds) {
            ds.CheckTag(UVBS);
            TextureCoordinates = ds.ReadStructArray<Vec2>();
        }

        void IDataRW.WriteTo(DataStream ds) {
            ds.WriteStruct(UVBS);
            ds.WriteStructArray(TextureCoordinates);
        }
    }
}
