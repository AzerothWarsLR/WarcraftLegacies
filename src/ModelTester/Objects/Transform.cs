using System.Runtime.InteropServices;
using ModelTester.Parsers;

namespace ModelTester.Objects {
    public struct Transform<T> : IDataRW, IOptionalBlock where T : unmanaged {
        public LocalProperties Properties;
        public Track<T>[] Tracks;
        public TrackInter<T>[] TracksInter;

        void IDataRW.ReadFrom(DataStream ds) {
            var tracksCount = ds.ReadStruct<uint>();
            ds.ReadStruct(ref Properties);

            if((uint)Properties.InterpolationType > 1)
                TracksInter = ds.ReadStructArray<TrackInter<T>>(tracksCount);
            else
                Tracks = ds.ReadStructArray<Track<T>>(tracksCount);
        }

        void IDataRW.WriteTo(DataStream ds) {
            if((uint)Properties.InterpolationType > 1)
                ds.WriteStruct((uint)TracksInter.Length);
            else
                ds.WriteStruct((uint)Tracks.Length);

            ds.WriteStruct(ref Properties);

            if((uint)Properties.InterpolationType > 1)
                ds.WriteStructArray(TracksInter, false);
            else
                ds.WriteStructArray(Tracks, false);
        }

        bool IOptionalBlock.HasData => ((uint)Properties.InterpolationType > 1) ? (TracksInter?.Length > 0) : (Tracks?.Length > 0);

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct LocalProperties {
            public InterpolationType InterpolationType;
            public int GlobalSequenceId;
        }

        public enum InterpolationType : uint {
            None,
            Linear,
            Hermite,
            Bezier,
        }
    }
}
