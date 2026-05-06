using System;
using System.IO;
using System.IO.MemoryMappedFiles;

namespace AlignVision
{

    // [Lớp cơ sở trang bản đồ bộ nhớ]
    //
    // 1. MMData_Base có kích thước cố định **1Page.
    // 2. Có thể truy cập từng kiểu dữ liệu như mảng.
    // 3. Các lớp kế thừa từ MMData_Base định nghĩa thuộc tính để dễ dàng truy cập mảng.
    // 4. Khi tạo lớp Memory Mapped File, sử dụng hàm CreateMemMap().
    // 
    // **1Page: Kích thước dữ liệu được định nghĩa trong MMData_Base, có kích thước cố định.
    //

    /// <summary>
    /// Lớp cơ sở bản đồ bộ nhớ (Memory Map Base).
    /// Khi kế thừa lớp này, sẽ tạo một khối bộ nhớ có kích thước cố định.
    /// </summary>
    internal class MMVisionData_PageBase : IDisposable
    {
        /// <summary>
        /// Lớp Memory Mapped file
        /// </summary>
        private MemoryMappedFile _memMap;

        /// <summary>
        /// Lớp dữ liệu kiểu byte
        /// </summary>
        private MMData_ByteData _byteData;

        /// <summary>
        /// Lớp dữ liệu kiêu bool
        /// </summary>
        private MMData_BoolData _boolData;

        /// <summary>
        /// Lớp dũ liệu kiểu short
        /// </summary>
        private MMData_ShortData _shortData;

        /// <summary>
        /// Lớp dữ liệu kiểu int
        /// </summary>
        private MMData_IntData _intData;

        /// <summary>
        /// Lớp dữ liệu kiểu float
        /// </summary>
        private MMData_FloatData _floatData;

        /// <summary>
        /// Lớp dữ liệu kiểu double
        /// </summary>
        private MMData_DoubleData _doubleData;

        /// <summary>
        /// Lớp dữ liệu kiểu string
        /// </summary>
        private MMData_StringData _stringData;


        public static readonly long ByteDataSize = 15728640L;

        public static readonly long BoolDataSize = 2048L;

        public static readonly long ShortDataSize = 1024L;

        public static readonly long IntDataSize = 2048L;

        public static readonly long FloatDataSize = 2048L;

        public static readonly long DoubleDataSize = 4096L;

        public static readonly long StringDataSize = 65536L;

        /// <summary>
        /// kích thước của 1 khối nhớ
        /// </summary>                                                                                                    
        public static readonly long PageSize = 15805440L;    // ByteDataSize + BoolDataSize + ShortDataSize + IntDataSize + FloatDataSize + DoubleDataSize + StringDataSize

        #region Truy cập dữ liệu
        /// <summary>
        /// Truy cập dữ liệu kiểu byte.
        /// </summary>
        public MMData_ByteData ByteData
        {
            get { return _byteData; }
            set { _byteData = value; }
        }
        /// <summary>
        /// Truy cập dữ liệu kiểu bool.
        /// </summary>
        public MMData_BoolData BoolData
        {
            get { return _boolData; }
            set { _boolData = value; }
        }
        /// <summary>
        /// Truy cập dữ liệu kiểu short.
        /// </summary>
        public MMData_ShortData ShortData
        {
            get { return _shortData; }
            set { _shortData = value; }
        }
        /// <summary>
        /// Truy cập dữ liệu kiểu int.
        /// </summary>
        public MMData_IntData IntData
        {
            get { return _intData; }
            set { _intData = value; }
        }
        /// <summary>
        /// Truy cập dữ liệu kiểu float.
        /// </summary>
        public MMData_FloatData FloatData
        {
            get { return _floatData; }
            set { _floatData = value; }
        }
        /// <summary>
        /// Truy cập dữ liệu kiểu double.
        /// </summary>
        public MMData_DoubleData DoubleData
        {
            get { return _doubleData; }
            set { _doubleData = value; }
        }
        /// <summary>
        /// Truy cập dữ liệu kiểu string.
        /// </summary>
        public MMData_StringData StringData
        {
            get { return _stringData; }
            set { _stringData = value; }
        }
        #endregion


        /// <summary>
        /// Hàm khởi tạo của lớp cơ sở bản đồ bộ nhớ.
        /// </summary>
        /// <param name="memMap">Tên file Memory Map. Nếu file cùng tên không tồn tại thì tạo mới, nếu có thì mở file.</param>
        /// <param name="pageIndex">Chỉ số khối bộ nhớ. Nếu chỉ số lớn hơn khối bộ nhớ, sẽ phát sinh ngoại lệ (exception).</param>
        /// <param name="pageCount">Số lượng khối bộ nhớ. Tạo file Memory Map dựa trên số lượng khối. Phải lớn hơn 0.</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        protected MMVisionData_PageBase(MemoryMappedFile memMap, uint pageIndex, uint pageCount)
        {
            // Mở file memory map
            _memMap = memMap;

            // Tính vị trí bắt đầu bộ nhớ. (byte)
            if (pageIndex >= pageCount)
            {
                throw new IndexOutOfRangeException();
            }

            // tạo lớp memory map view
            long num = PageSize * pageIndex;
            _byteData = new MMData_ByteData(_memMap, num, ByteDataSize, MemoryMappedFileAccess.ReadWrite);
            num += ByteDataSize;
            _boolData = new MMData_BoolData(_memMap, num, BoolDataSize, MemoryMappedFileAccess.ReadWrite);
            num += BoolDataSize;
            _shortData = new MMData_ShortData(_memMap, num, ShortDataSize, MemoryMappedFileAccess.ReadWrite);
            num += ShortDataSize;
            _intData = new MMData_IntData(_memMap, num, IntDataSize, MemoryMappedFileAccess.ReadWrite);
            num += IntDataSize;
            _floatData = new MMData_FloatData(_memMap, num, FloatDataSize, MemoryMappedFileAccess.ReadWrite);
            num += FloatDataSize;
            _doubleData = new MMData_DoubleData(_memMap, num, DoubleDataSize, MemoryMappedFileAccess.ReadWrite);
            num += DoubleDataSize;
            _stringData = new MMData_StringData(_memMap, num, StringDataSize, MemoryMappedFileAccess.ReadWrite);
        }

        /// <summary>
        /// Mở file Memory Map có kích thước chỉ định. Nếu file không tồn tại thì tạo mới.
        /// </summary>
        /// <param name="fileName">Tên file Memory Map</param>
        /// <param name="mapName">Tên Memory Map</param>
        /// <param name="pageCount">Số lượng trang (quyết định tổng kích thước file Memory Map.)</param>
        /// <returns>Lớp Memory Mapped File</returns>
        public static MemoryMappedFile CreateMemMap(string fileName, string mapName, uint pageCount)
        {
            // tính kích thước file Memory map
            long capacity;
            if (pageCount >= 1)
            {
                capacity = PageSize * pageCount;
            }
            else
            {
                capacity = PageSize;
            }

            // Kiểm tra thư mục, nếu không tồn tại thì tạo mới.
            string directoryName = Path.GetDirectoryName(fileName);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            try
            {
                using (MemoryMappedFile.OpenExisting(mapName))
                {
                }
            }
            catch (FileNotFoundException)
            {
                return MemoryMappedFile.CreateFromFile(fileName, FileMode.OpenOrCreate, mapName, capacity, MemoryMappedFileAccess.ReadWriteExecute);
            }
            return MemoryMappedFile.OpenExisting(mapName, MemoryMappedFileRights.ReadWrite);
        }

        /// <summary>
        /// Sao chép dữ liệu đầu vào vào lớp dữ liệu nội bộ.
        /// </summary>
        /// <param name="sourceData">Dữ liệu cần sao chép</param>
        public void Copy(MMVisionData_PageBase sourceData)
        {
            _byteData.Copy(sourceData.ByteData);
            _boolData.Copy(sourceData.BoolData);
            _shortData.Copy(sourceData.ShortData);
            _intData.Copy(sourceData.IntData);
            _floatData.Copy(sourceData.FloatData);
            _doubleData.Copy(sourceData.DoubleData);
            _stringData.Copy(sourceData.StringData);
        }

        /// <summary>
        /// Xóa dữ liệu nội bộ.
        /// </summary>
        public void Clear()
        {
            _byteData.Clear();
            _boolData.Clear();
            _shortData.Clear();
            _intData.Clear();
            _floatData.Clear();
            _doubleData.Clear();
            _stringData.Clear();
        }

        /// <summary>
        /// Gọi Dispose() sẽ giải phóng bộ nhớ.
        /// </summary>
        public void Dispose()
        {
            _stringData.Dispose();
            _doubleData.Dispose();
            _floatData.Dispose();
            _shortData.Clear();
            _intData.Dispose();
            _boolData.Dispose();
            _byteData.Dispose();
            _memMap.Dispose();
        }
    }

}

