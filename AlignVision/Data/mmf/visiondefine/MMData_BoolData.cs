using System;
using System.IO.MemoryMappedFiles;

namespace AlignVision
{
    internal sealed class MMData_BoolData : IDisposable
    {
        private MemoryMappedFile _memMap;

        private MemoryMappedViewAccessor _memView;

        /// <summary>
        /// Kichs thước kiểu byte
        /// </summary>
        private readonly int _typeSize = 1;

        private long _mapOffset;

        private long _mapSize;

        public bool this[int idx]
        {
            get
            {
                int position = getPosition(idx);
                _memView.Read<bool>(position, out var structure);
                return structure;
            }
            set
            {
                int position = getPosition(idx);
                _memView.Write(position, value);
            }
        }

        /// <summary>
        /// Hàm khởi tạo lớp dữ liệu kiểu bool.
        /// </summary>
        /// <param name="memMap">Lớp Memory Mapped File</param>
        /// <param name="offset">Vị trí bắt đầu Memory Map (byte)</param>
        /// <param name="size">Kích thước Memory Map (byte)</param>
        /// <param name="access">Quyền truy cập</param>
        public MMData_BoolData(MemoryMappedFile memMap, long offset, long size, MemoryMappedFileAccess access)
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

        public void Copy(MMData_BoolData sourceData)
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



