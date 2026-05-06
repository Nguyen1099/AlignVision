using System;
using System.IO.MemoryMappedFiles;

namespace AlignVision
{
    internal sealed class MMData_ShortData : IDisposable
    {
        private MemoryMappedFile _memMap;

        private MemoryMappedViewAccessor _memView;

        private readonly short _typeSize = 2;

        private long _mapOffset;

        private long _mapSize;

        public short this[int idx]
        {
            get
            {
                int position = getPosition(idx);
                _memView.Read<short>(position, out var structure);
                return structure;
            }
            set
            {
                int position = getPosition(idx);
                _memView.Write(position, value);
            }
        }

        public MMData_ShortData(MemoryMappedFile memMap, long offset, long size, MemoryMappedFileAccess access)
        {
            _memMap = memMap;
            _memView = _memMap.CreateViewAccessor(offset, size, access);
            _mapOffset = offset;
            _mapSize = size;
        }

        private int getPosition(int idx)
        {
            int num = _typeSize * idx;
            if (num + _typeSize >= _memView.Capacity)
            {
                throw new IndexOutOfRangeException();
            }
            return num;
        }

        public void Copy(MMData_ShortData sourceData)
        {
            byte[] array = sourceData.ToBytes();
            _memView.WriteArray(0L, array, 0, (short)_mapSize);
        }

        public void Clear()
        {
            byte[] array = new byte[_mapSize];
            _memView.WriteArray(0L, array, 0, (short)_mapSize);
        }

        public byte[] ToBytes()
        {
            byte[] array = new byte[_mapSize];
            _memView.ReadArray(0L, array, 0, (short)_mapSize);
            return array;
        }

        public void Dispose()
        {
            _memView.Dispose();
        }
    }

}

