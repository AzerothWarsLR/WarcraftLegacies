namespace ModelTester.Parsers {
    class DataArrayParser<T> : IBlockParser where T : struct, IDataRW {
        internal delegate ref T[] _getRef(MDX mdx);

        _getRef Get;

        internal DataArrayParser(_getRef get) => Get = get;

        public void ReadFrom(MDX mdx, DataStream ds, uint blockSize) => Get(mdx) = ds.ReadDataArrayUnknownCount<T>(blockSize);

        public void WriteTo(MDX mdx, DataStream ds) => ds.WriteDataArray(Get(mdx), false);

        public bool HasData(MDX mdx) => Get(mdx)?.Length > 0;
    }
}
