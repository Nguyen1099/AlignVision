using System;

namespace AlignVision
{
    abstract class CDeviceCommunicationAbstract
    {
        /// <summary>
        /// Lớp này dùng để lưu trữ các tham số khởi tạo cho việc kết nối thiết bị, bao gồm cả kết nối Socket và Serial. 
        /// Các tham số này sẽ được sử dụng trong quá trình khởi tạo kết nối và có thể được sao chép thông qua phương thức Clone() để tạo ra các đối tượng mới với cùng giá trị tham số.
        /// </summary>
        public class CInitializeParameter : ICloneable
        {
            /// <summary>
            /// Kiểu kết nối thiết bị (Socket Client, Socket Server, Serial)
            /// </summary>
            public enum EType
            {
                TYPE_SOCKET_CLIENT = 0,
                TYPE_SOCKET_SERVER,
                TYPE_SERIAL,
                TYPE_FINAL
            };

            /// <summary>
            /// Kiểu parity của cổng serial
            /// </summary>
            public enum ESerialPortParity
            {
                PARITY_NONE = 0,
                PARITY_ODD,
                PARITY_EVEN,
                PARITY_MARK,
                PARITY_SPACE
            };

            /// <summary>
            /// Kiểu stop bits của cổng serial
            /// </summary>
            public enum ESerialPortStopBits
            {
                STOP_BITS_NONE = 0,
                STOP_BITS_ONE,
                STOP_BITS_TWO,
                STOP_BITS_ONE_POINT_FIVE
            };

            /// <summary>
            /// Kiểu encoding của dữ liệu
            /// </summary>
            public enum EDataEncoding
            {
                ENCODING_NONE = 0,
                ENCODING_DEFAULT,
                ENCODING_UCS2,
                ENCODING_UTF8
            };

            public EDataEncoding eDataEncoding = EDataEncoding.ENCODING_UCS2;


            public EType eType;
            public string strSocketIPAddress;
            public int iSocketPortNumber;


            public string strSerialPortName;
            public int iSerialPortBaudrate;
            public int iSerialPortDataBits;
            public ESerialPortParity eParity;
            public ESerialPortStopBits eStopBits;

            public object Clone()
            {
                CInitializeParameter objInitializeParameter = new CInitializeParameter();
                objInitializeParameter.eDataEncoding = this.eDataEncoding;
                objInitializeParameter.eType = this.eType;
                objInitializeParameter.strSocketIPAddress = this.strSocketIPAddress;
                objInitializeParameter.iSocketPortNumber = this.iSocketPortNumber;

                objInitializeParameter.strSerialPortName = this.strSerialPortName;
                objInitializeParameter.iSerialPortBaudrate = this.iSerialPortBaudrate;
                objInitializeParameter.iSerialPortDataBits = this.iSerialPortDataBits;
                objInitializeParameter.eParity = this.eParity;
                objInitializeParameter.eStopBits = this.eStopBits;

                return objInitializeParameter;
            }
        }

        /// <summary>
        /// Lớp này dùng để lưu trữ dữ liệu nhận được từ thiết bị, bao gồm cả dữ liệu dạng chuỗi và dữ liệu dạng byte.
        /// </summary>
        public class CReceiveData : ICloneable
        {
            public string strData;
            public byte[] byteReceiveData = new byte[4096];
            public int iByteLength;

            public void Clear()
            {
                strData = "";
                Array.Clear(byteReceiveData, 0, byteReceiveData.Length);
                iByteLength = 0;
            }

            public object Clone()
            {
                CReceiveData objData = new CReceiveData();
                objData.strData = this.strData;
                objData.byteReceiveData = this.byteReceiveData;
                objData.iByteLength = this.iByteLength;
                return objData;
            }
        }

        /// <summary>
        /// Sự kiện được gọi khi kết nối thiết
        /// </summary>
        public Action OnConnect;

        /// <summary>
        /// Sự kiện được gọi khi ngắt kết nối thiết bị
        /// </summary>
        public Action OnDisconnect;

        /// <summary>
        /// Sự kiện được gọi khi có dữ liệu mới được nhận từ thiết bị, dữ liệu này sẽ được truyền vào thông qua đối tượng CReceiveData.
        /// </summary>
        /// <param name="objReceiveData"></param>
        public delegate void CallBackFuntionReceiveData(CReceiveData objReceiveData);

        /// <summary>
        /// Khởi tạo kết nối
        /// </summary>
        /// <param name="objInitializeParameter"></param>
        /// <returns></returns>
        public abstract bool SocketInitialize(CInitializeParameter objInitializeParameter);

        /// <summary>
        /// Ngắt kết nối và giải phóng tài nguyên
        /// </summary>
        public abstract void SocketDeInitialize();

        /// <summary>
        /// Gửi dữ liệu string
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public abstract bool SocketSend(string strData);

        /// <summary>
        /// Gui dữ liệu byte
        /// </summary>
        /// <param name="byteData"></param>
        /// <returns></returns>
        public abstract bool SocketSend(byte[] byteData);

        /// <summary>
        /// Kiểm tra kết nối socket
        /// </summary>
        /// <returns></returns>
        public abstract bool SocketIsConnected();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objReceiveData"></param>
        public abstract void SetReceiveDataCallbackFunction(CallBackFuntionReceiveData objReceiveData);

    }
}
