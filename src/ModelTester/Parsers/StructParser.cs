namespace ModelTester.Parsers {
    class StructParser<T> : IBlockParser where T : unmanaged {
        internal delegate ref T _getRef(MDX mdx);

        _getRef Get;

        internal StructParser(_getRef get) => Get = get;

        public unsafe void ReadFrom(MDX mdx, DataStream ds, uint blockSize) {
            if(blockSize != sizeof(T))
                throw new ParsingException();

            ds.ReadStruct(ref Get(mdx));
        }

        public void WriteTo(MDX mdx, DataStream ds) => ds.WriteStruct(ref Get(mdx));

        public bool HasData(MDX mdx) => true;
    }
}
