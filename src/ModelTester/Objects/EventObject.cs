namespace ModelTester.Objects {
    using static InnerBlocks;

    public struct EventObject : IDataRW {
        public Node Node;
        public int GlobalSequenceId;
        public uint[] Tracks;

        void IDataRW.ReadFrom(DataStream ds) {
            ds.ReadData(ref Node);
            ds.CheckTag(KEVT);
            var tracksCount = ds.ReadStruct<uint>();
            ds.ReadStruct(ref GlobalSequenceId);
            Tracks = ds.ReadStructArray<uint>(tracksCount);
        }

        void IDataRW.WriteTo(DataStream ds) {
            ds.WriteData(ref Node);
            ds.WriteStruct(KEVT);
            ds.WriteStruct((uint)Tracks.Length);
            ds.WriteStruct(GlobalSequenceId);
            ds.WriteStructArray(Tracks, false);
        }
    }
}
