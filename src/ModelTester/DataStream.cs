using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ModelTester.Parsers;

namespace ModelTester {
    interface IDataRW {
        internal void ReadFrom(DataStream ds);
        internal void WriteTo(DataStream ds);
    }

    unsafe class DataStream : IDisposable {
        IntPtr _ptr;
        MemoryBlock memory;

        internal byte* Pointer => (byte*)_ptr;
        internal uint Offset => (uint)(memory.current - Pointer);
        internal uint Size => (uint)(memory.end - Pointer);

        internal unsafe DataStream() : this(1024 * 1024) { }

        internal unsafe DataStream(uint size) {
            _ptr = Marshal.AllocHGlobal((IntPtr)size);
            GC.AddMemoryPressure(size);
            memory = new MemoryBlock { current = Pointer, end = Pointer + size };
        }

        unsafe void Realloc(uint bump) {
            var offset = memory.current - Pointer;
            var ensureSize = offset + bump;
            var size = Size;

            while(size < ensureSize)
                size *= 2;

            _ptr = Marshal.ReAllocHGlobal(_ptr, (IntPtr)size);
            GC.AddMemoryPressure(size - Size);
            memory.current = Pointer + offset;
            memory.end = Pointer + size;
        }

        internal void Skip(uint count) => memory.current += count;

        internal unsafe void CheckReadBounds(uint count) {
            if(memory.current + count > memory.end)
                throw new ParsingException();
        }

        unsafe void CheckWriteBounds(uint count) {
            if(memory.current + count > memory.end)
                Realloc(count);
        }

        internal unsafe void CheckTag(InnerBlocks tag) {
            CheckReadBounds(sizeof(InnerBlocks));
            if(*(InnerBlocks*)memory.current != tag)
                throw new ParsingException();
            memory.current += sizeof(uint);
        }

        internal unsafe void SetValueAt<T>(uint offset, T value) where T : unmanaged {
            var pos = Pointer + offset;
            if(pos < Pointer || pos + sizeof(T) > memory.end)
                throw new ParsingException();
            *(T*)pos = value;
        }

        internal unsafe void ReadStruct<T>(ref T dst) where T : unmanaged {
            CheckReadBounds((uint)sizeof(T));
            dst = *(T*)memory.current;
            memory.current += sizeof(T);
        }

        internal unsafe T ReadStruct<T>() where T : unmanaged {
            CheckReadBounds((uint)sizeof(T));
            var dst = *(T*)memory.current;
            memory.current += sizeof(T);
            return dst;
        }

        internal unsafe T[] ReadStructArray<T>() where T : unmanaged {
            CheckReadBounds(sizeof(uint));
            var count = *(uint*)memory.current;
            memory.current += sizeof(uint);
            return ReadStructArray<T>(count);
        }

        internal unsafe T[] ReadStructArray<T>(uint count) where T : unmanaged {
            var byteLen = count * (uint)sizeof(T);
            CheckReadBounds(byteLen);
            var arr = new T[count];
            fixed(void* p = arr)
                Buffer.MemoryCopy(memory.current, p, byteLen, byteLen);
            memory.current += byteLen;
            return arr;
        }

        internal unsafe void ReadUnmanagedArray<T>(T* dst, uint count) where T : unmanaged {
            var byteLen = count * (uint)sizeof(T);
            CheckReadBounds(byteLen);
            Buffer.MemoryCopy(memory.current, dst, byteLen, byteLen);
            memory.current += byteLen;
        }

        internal unsafe void ReadData<T>(ref T dst) where T : struct, IDataRW => dst.ReadFrom(this);

        internal unsafe T[] ReadDataArray<T>() where T : struct, IDataRW {
            CheckReadBounds(sizeof(uint));
            var arr = new T[*(uint*)memory.current];
            memory.current += sizeof(uint);
            for(var i = 0; i < arr.Length; i++)
                arr[i].ReadFrom(this);
            return arr;
        }

        internal unsafe T[] ReadDataArrayUnknownCount<T>(uint blockSize) where T : struct, IDataRW {
            var end = memory.current + blockSize;
            var arr = new T[100];
            var count = 0;
            while(memory.current < end) {
                if(count >= arr.Length) {
                    var old = arr;
                    arr = new T[arr.Length * 2];
                    Array.Copy(old, 0, arr, 0, old.Length);
                }
                arr[count].ReadFrom(this);
                count++;
            }
            if(count < arr.Length) {
                var old = arr;
                arr = new T[count];
                Array.Copy(old, 0, arr, 0, arr.Length);
            }
            return arr;
        }

        internal unsafe void ReadOptionalBlocks<T>(ref T dst, Dictionary<OptionalBlocks, IOptionalBlocksParser<T>> knownBlocks, uint endOffset) where T : struct, IDataRW {
            var end = Pointer + endOffset;
            while(memory.current < end) {
                knownBlocks.TryGetValue(ReadStruct<OptionalBlocks>(), out var block);

                if(block is null)
                    throw new ParsingException();

                block.ReadFrom(ref dst, this);
            }
        }

        internal unsafe void WriteStruct<T>(T src) where T : unmanaged {
            CheckWriteBounds((uint)sizeof(T));
            *(T*)memory.current = src;
            memory.current += sizeof(T);
        }

        internal unsafe void WriteStruct<T>(ref T src) where T : unmanaged {
            CheckWriteBounds((uint)sizeof(T));
            *(T*)memory.current = src;
            memory.current += sizeof(T);
        }

        internal unsafe void WriteStructArray<T>(T[] src, bool writeCount = true) where T : unmanaged {
            if(src is null)
                return;

            if(writeCount) {
                CheckWriteBounds(sizeof(uint));
                *(uint*)memory.current = (uint)src.Length;
                memory.current += sizeof(uint);
            }

            if(src.Length < 1)
                return;

            var byteLen = (uint)(src.Length * sizeof(T));
            CheckWriteBounds(byteLen);
            fixed(void* p = src)
                Buffer.MemoryCopy(p, memory.current, byteLen, byteLen);
            memory.current += byteLen;
        }

        internal unsafe void WriteUnmanagedArray<T>(T* src, uint count) where T : unmanaged {
            var byteLen = count * (uint)sizeof(T);
            CheckWriteBounds(byteLen);
            Buffer.MemoryCopy(src, memory.current, byteLen, byteLen);
            memory.current += byteLen;
        }

        internal unsafe void WriteData<T>(ref T src) where T : struct, IDataRW => src.WriteTo(this);

        internal unsafe void WriteDataArray<T>(T[] src, bool writeCount = true) where T : struct, IDataRW {
            if(src is null)
                return;

            if(writeCount) {
                CheckWriteBounds(sizeof(uint));
                *(uint*)memory.current = (uint)src.Length;
                memory.current += sizeof(uint);
            }

            if(src.Length < 1)
                return;

            for(var i = 0; i < src.Length; i++)
                src[i].WriteTo(this);
        }

        internal unsafe void WriteOptionalBlocks<T>(ref T src, Dictionary<OptionalBlocks, IOptionalBlocksParser<T>> knownBlocks) where T : struct, IDataRW {
            foreach(var block in knownBlocks) {
                if(block.Value.HasData(ref src)) {
                    WriteStruct(block.Key);
                    block.Value.WriteTo(ref src, this);
                }
            }
        }

        #region IDisposable
        public void Dispose() {
            if(_ptr == IntPtr.Zero)
                return;

            Marshal.FreeHGlobal(_ptr);
            _ptr = IntPtr.Zero;
            GC.RemoveMemoryPressure(Size);
            GC.SuppressFinalize(this);
        }

        ~DataStream() => Dispose();
        #endregion

        unsafe struct MemoryBlock {
            internal byte* current, end;
        }
    }
}
