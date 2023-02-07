using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace ModelTester {
    using static MainBlocks;

    public partial class MDX {
        const uint VERSION = 800u;

        public MDX() { }

        public MDX(string filePath) {
            using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 1, false);
            LoadFrom(stream, stream.Length);
        }

        public MDX(Stream stream) => LoadFrom(stream, stream.Length - stream.Position);

        public MDX(Stream stream, uint fileSize) => LoadFrom(stream, fileSize);

        unsafe void LoadFrom(Stream stream, long fileSize) {
            if(fileSize > int.MaxValue)
                throw new Exception("File is too large!");

            var mdxHeader = new MDXHeader();
            if((stream.Read(new Span<byte>(&mdxHeader, sizeof(MDXHeader))) < sizeof(MDXHeader)) || !mdxHeader.Check())
                throw new Exception("Not a MDX file!");

            if(mdxHeader.version != VERSION)
                throw new Exception("Not supported file version!");

            fileSize -= sizeof(MDXHeader);
            if(fileSize == 0)
                return;

            using var ds = new DataStream((uint)fileSize);
            stream.Read(new Span<byte>(ds.Pointer, (int)fileSize));

            var unknownBlocks = new List<BinaryBlock>();

            while(ds.Offset < ds.Size) {
                var blockHeader = ds.ReadStruct<BlockHeader>();
                ds.CheckReadBounds(blockHeader.size);

                _knownParsers.TryGetValue(blockHeader.tag, out var parser);

                if(parser is null)
                    unknownBlocks.Add(new BinaryBlock { Tag = blockHeader.tag, Data = ds.ReadStructArray<byte>(blockHeader.size) });
                else
                    parser.ReadFrom(this, ds, blockHeader.size);
            }

            if(unknownBlocks.Count > 0)
                UnknownBlocks = unknownBlocks.ToArray();
        }

        public void SaveTo(string filePath) {
            using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Write, 1, false);
            SaveTo(stream);
            stream.Flush(true);
        }

        public unsafe void SaveTo(Stream stream) {
            using var ds = new DataStream();

            var mdxHeader = new MDXHeader();
            mdxHeader.Default();
            mdxHeader.version = VERSION;

            ds.WriteStruct(ref mdxHeader);

            foreach(var parser in _knownParsers) {
                if(parser.Value.HasData(this)) {
                    ds.WriteStruct(parser.Key);

                    var offset = ds.Offset;
                    ds.Skip(sizeof(uint));

                    parser.Value.WriteTo(this, ds);

                    ds.SetValueAt(offset, ds.Offset - (offset + sizeof(uint)));
                }
            }

            if(UnknownBlocks?.Length > 0)
                foreach(var block in UnknownBlocks)
                    if(block?.Data?.Length > 0) {
                        ds.WriteStruct(block.Tag);
                        ds.WriteStructArray(block.Data);
                    }

            stream.Write(new ReadOnlySpan<byte>(ds.Pointer, (int)ds.Offset));
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct MDXHeader {
            internal MainBlocks header, versionHeader;
            internal uint versionSize, version;

            internal bool Check() => (header == MDLX) && (versionHeader == VERS) && (versionSize == sizeof(uint));

            internal void Default() {
                header = MDLX;
                versionHeader = VERS;
                versionSize = sizeof(uint);
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct BlockHeader {
            internal MainBlocks tag;
            internal uint size;
        }
    }

    public class BinaryBlock {
        public MainBlocks Tag;
        public byte[] Data;
    }
}
