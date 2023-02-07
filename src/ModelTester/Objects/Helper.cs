namespace ModelTester.Objects {
    public struct Helper : IDataRW {
        public Node Node;

        void IDataRW.ReadFrom(DataStream ds) => ds.ReadData(ref Node);

        void IDataRW.WriteTo(DataStream ds) => ds.WriteData(ref Node);
    }
}
