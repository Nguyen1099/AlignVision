using System;
using System.IO.MemoryMappedFiles;

namespace AlignVision
{
    // 
    internal sealed class MMData_ByteData : IDisposable
    {
        private MemoryMappedFile _memMap;

        private MemoryMappedViewAccessor _memView;

        private readonly int _typeSize = 1;

        private long _mapOffset;

        private long _mapSize;

        /// <summary>
        /// Hàm khởi tạo lớp dữ liệu kiểu byte.
        /// </summary>
        /// <param name="memMap">Lớp Memory Mapped File</param>
        /// <param name="offset">Vị trí bắt đầu Memory Map (byte)</param>
        /// <param name="size">Kích thước Memory Map (byte)</param>
        /// <param name="access">Quyền truy cập</param>
        public MMData_ByteData(MemoryMappedFile memMap, long offset, long size, MemoryMappedFileAccess access)
        {
            _memMap = memMap;
            _memView = _memMap.CreateViewAccessor(offset, size, access);
            _mapOffset = offset;
            _mapSize = size;
        }

        /// <summary>
        /// Indexer của dữ liệu kiểu byte.
        /// </summary>
        /// <param name="idx">Chỉ số của dữ liệu cần trả về</param>
        /// <returns>Giá trị tại vị trí chỉ số</returns>
        public byte this[int idx]
        {
            get
            {
                int position = getPosition(idx);
                _memView.Read<byte>(position, out var structure);
                return structure;
            }
            set
            {
                int position = getPosition(idx);
                _memView.Write(position, value);
            }
        }

        /// <summary>
        /// Tính vị trí bộ nhớ (byte) tương ứng với chỉ số.
        /// </summary>
        /// <param name="idx">Chỉ số dữ liệu</param>
        /// <returns>Vị trí bộ nhớ (byte)</returns>
        private int getPosition(int idx)
        {
            int num = _typeSize * idx;
            if (num + _typeSize >= _memView.Capacity)
            {
                throw new IndexOutOfRangeException();
            }
            return num;
        }

        public void Copy(MMData_ByteData sourceData)
        {
            byte[] array = sourceData.ToBytes();
            _memView.WriteArray(0L, array, 0, (int)_mapSize);
        }

        public void Copy(byte[] sourceData)
        {
            _memView.WriteArray(0L, sourceData, 0, sourceData.Length);
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

        public byte[] ToBytes(int iReadSize)
        {
            byte[] array = new byte[_mapSize];
            _memView.ReadArray(0L, array, 0, iReadSize);
            return array;
        }

        public void Dispose()
        {
            _memView.Dispose();
        }
    }

}

