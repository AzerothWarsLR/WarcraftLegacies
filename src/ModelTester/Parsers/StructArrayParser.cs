namespace ModelTester.Parsers {
    class StructArrayParser<T> : IBlockParser where T : unmanaged {
        internal delegate ref T[] _getRef(MDX mdx);

        _getRef Get;

        internal StructArrayParser(_getRef get) => Get = get;

        public unsafe void ReadFrom(MDX mdx, DataStream ds, uint blockSize) {
            if((blockSize % sizeof(T)) > 0)
                throw new ParsingException();

            Get(mdx) = ds.ReadStructArray<T>(blockSize / (uint)sizeof(T));
        }

        public void WriteTo(MDX mdx, DataStream ds) => ds.WriteStructArray(Get(mdx), false);

        public bool HasData(MDX mdx) => Get(mdx)?.Length > 0;
    }
}
