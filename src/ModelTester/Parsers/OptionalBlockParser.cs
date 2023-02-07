namespace ModelTester.Parsers {
    class OptionalBlockParser<T, P> : IOptionalBlocksParser<P> where T : struct, IDataRW, IOptionalBlock where P : struct, IDataRW {
        internal delegate ref T _getRef(ref P p);

        _getRef Get;

        internal OptionalBlockParser(_getRef get) => Get = get;

        public void ReadFrom(ref P p, DataStream ds) => ds.ReadData(ref Get(ref p));

        public void WriteTo(ref P p, DataStream ds) => ds.WriteData(ref Get(ref p));

        public bool HasData(ref P p) => Get(ref p).HasData;
    }

    interface IOptionalBlocksParser<P> where P : struct, IDataRW {
        void ReadFrom(ref P p, DataStream ds);
        void WriteTo(ref P p, DataStream ds);
        bool HasData(ref P p);
    }

    interface IOptionalBlock {
        internal bool HasData { get; }
    }
}
