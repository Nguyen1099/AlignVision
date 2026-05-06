using System;
using System.IO.MemoryMappedFiles;

namespace AlignVision
{
    internal sealed class MMData_DoubleData : IDisposable
    {
        private MemoryMappedFile _memMap;

        private MemoryMappedViewAccessor _memView;

        private readonly int _typeSize = 8;

        private long _mapOffset;

        private long _mapSize;

        public double this[int idx]
        {
            get
            {
                int position = getPosition(idx);
                _memView.Read<double>(position, out var structure);
                return structure;
            }
            set
            {
                int position = getPosition(idx);
                _memView.Write(position, value);
            }
        }

        public MMData_DoubleData(MemoryMappedFile memMap, long offset, long size, MemoryMappedFileAccess access)
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

        public void Copy(MMData_DoubleData sourceData)
        {
            byte[] array = sourceData.ToBytes();
            _memView.WriteArray(0L, array, 0, (int)_mapSize);
        }

        public void Clear()
        {
            byte[] array = new byte[_mapSize];
            _memView.WriteArray(0L, array, 0, (int)_mapSize);
        }

        public byte[] ToBytes()
        {
            byte[] array = new byte[_mapSize];
            _memView.ReadArray(0L, array, 0, (int)_mapSize);
            return array;
        }

        public void Dispose()
        {
            _memView.Dispose();
        }
    }

}

