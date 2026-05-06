using System;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;

namespace AlignVision
{
    internal sealed class MMData_StringData : IDisposable
    {
        private MemoryMappedFile _memMap;

        private MemoryMappedViewAccessor _memView;

        private readonly int _typeSize = 1;

        private readonly int _stringLength = 512;

        private long _mapOffset;

        private long _mapSize;

        public string this[int idx]
        {
            get
            {
                int position = getPosition(idx);
                byte[] array = new byte[_stringLength];
                _memView.ReadArray(position, array, 0, _stringLength);
                string text = Encoding.UTF8.GetString(array);
                char[] trimChars = new char[1];
                return text.Trim(trimChars);
            }
            set
            {
                int position = getPosition(idx);
                byte[] array = new byte[_stringLength];
                _memView.WriteArray(position, array, 0, array.Count());
                byte[] bytes = Encoding.UTF8.GetBytes(value);
                _memView.WriteArray(position, bytes, 0, bytes.Count());
            }
        }

        public MMData_StringData(MemoryMappedFile memMap, long offset, long size, MemoryMappedFileAccess access)
        {
            _memMap = memMap;
            _memView = _memMap.CreateViewAccessor(offset, size, access);
            _mapOffset = offset;
            _mapSize = size;
        }

        private int getPosition(int idx)
        {
            int num = _typeSize * _stringLength * idx;
            if (num + _typeSize * _stringLength >= _memView.Capacity)
            {
                throw new IndexOutOfRangeException();
            }
            return num;
        }

        public void Copy(MMData_StringData sourceData)
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

