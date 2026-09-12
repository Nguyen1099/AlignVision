using System;

namespace AlignVision
{
    public abstract class CDeviceLightControllerAbstract
    {
        /// <summary>
        /// Initialize Parameter
        /// </summary>
        public class CInitializeParameter : ICloneable
        {
            public enum enumType
            {
                TYPE_SOCKET_CLIENT = 0,
                TYPE_SOCKET_SERVER,
                TYPE_SERIAL_PORT,
                TYPE_FINAL
            };

            public enum enumSerialPortParity
            {
                PARITY_NONE = 0,
                PARITY_ODD,
                PARITY_EVEN,
                PARITY_MARK,
                PARITY_SPACE
            };

            public enum enumSerialPortStopBits
            {
                STOP_BITS_NONE = 0,
                STOP_BITS_ONE,
                STOP_BITS_TWO,
                STOP_BITS_ONE_POINT_FIVE
            };

            public enumType eType;
            public string strSocketIPAddress;
            public int iSocketPortNumber;


            public string strSerialPortName;
            public int iSerialPortBaudrate;
            public int iSerialPortDataBits;
            public enumSerialPortParity eParity;
            public enumSerialPortStopBits eStopBits;

            public object Clone()
            {
                CInitializeParameter objInitializeParameter = new CInitializeParameter();
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
        /// Light Controller Error Class
        /// </summary>
        public class CLightControllerError : ICloneable
        {
            // Event occurrence time
            public string strEventTime;

            // Function name that was executed
            public string strFunctionName;

            // Alarm return result
            public int iReturnCode;

            // Alarm message
            public string strMessage;

            public object Clone()
            {
                CLightControllerError objError = new CLightControllerError();
                objError.strEventTime = this.strEventTime;
                objError.strFunctionName = this.strFunctionName;
                objError.iReturnCode = this.iReturnCode;
                objError.strMessage = this.strMessage;

                return objError;
            }
        }

        /// <summary>
        /// Received data callback
        /// </summary>
        public class CReceiveData : ICloneable
        {
            public string strData;
            public byte[] byteReceiveData = new byte[4096];
            public int iByteLength;

            public void clear()
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

        // Delegate declaration
        public delegate void CallBackFuntionReceiveData(CReceiveData objReceiveData);

        public abstract bool Initialize(CInitializeParameter objInitializeParameter);

        public abstract void DeInitialize();

        public abstract string GetVersion();

        /// <summary>
        /// Kiểm tra kết nối với bộ điều khiển ánh sáng
        /// </summary>
        /// <returns></returns>
        public virtual bool IsConnected()
        {
            bool bReturn = false;

            do
            {
            } while (false);

            return bReturn;
        }

        /// <summary>
        /// Thiết lập hàm callback để nhận dữ liệu
        /// </summary>
        /// <param name="objReceiveData"></param>
        public virtual void SetCallbackFunction(CallBackFuntionReceiveData objReceiveData)
        {

        }

        /// <summary>
        /// Thiết lập cường độ ánh sáng cho kênh cụ thể
        /// </summary>
        /// <param name="iChannel"></param>
        /// <param name="iIntensity"></param>
        /// <returns></returns>
        public virtual bool SetLightIntensity(int iChannel, int iIntensity)
        {
            bool bReturn = false;

            do
            {

            } while (false);

            return bReturn;
        }

        /// <summary>
        /// Thiết lập cường độ ánh sáng cho tất cả các kênh
        /// </summary>
        /// <param name="iIntensity"></param>
        /// <returns></returns>
        public virtual bool SetLightIntensityPre(int iIntensity)
        {
            bool bReturn = false;

            do
            {
            } while (false);

            return bReturn;
        }

        /// <summary>
        /// Thiết lập cường độ ánh sáng tất cả các kênh
        /// </summary>
        /// <param name="iChannel"></param>
        /// <param name="iIntensity"></param>
        /// <param name="iCount"></param>
        /// <returns></returns>
        public virtual bool SetLightIntensityMultiChannel(int iChannel, int iIntensity, int iCount)
        {
            bool bReturn = false;

            do
            {
            } while (false);

            return bReturn;
        }

        /// <summary>
        /// Thiết lập cường độ ánh sáng cho nhiều kênh với mảng kênh và mảng cường độ
        /// </summary>
        /// <param name="iChannel"></param>
        /// <param name="iIntensity"></param>
        /// <param name="iCount"></param>
        /// <returns></returns>
        public virtual bool SetLightIntensity(int[] iChannel, int[] iIntensity, int iCount)
        {
            bool bReturn = false;

            do
            {

            } while (false);

            return bReturn;
        }

        /// <summary>
        /// Lấy nhiệt độ ánh sáng của kênh cụ thể
        /// </summary>
        /// <param name="iChannel"></param>
        /// <returns></returns>
        public virtual double GetLightTemperature(int iChannel)
        {
            double dTemperature = 0.0;

            do
            {

            } while (false);

            return dTemperature;
        }

        /// <summary>
        /// Thiết lập cường độ ánh sáng cho tất cả các kênh với mảng cường độ
        /// </summary>
        /// <param name="iIntensity"></param>
        /// <returns></returns>
        public virtual bool SetLightIntensity(int[] iIntensity)
        {
            bool bReturn = false;

            do
            {


            } while (false);

            return bReturn;
        }

        /// <summary>
        /// Thiết lập tắt ánh sáng cho kênh cụ thể
        /// </summary>
        /// <param name="iChannel"></param>
        /// <returns></returns>
        public virtual bool SetLightOff(int iChannel)
        {
            bool bReturn = false;

            do
            {

            } while (false);

            return bReturn;
        }
        
        /// <summary>
        /// Thiết lập tắt ánh sáng cho tất cả các kênh
        /// </summary>
        /// <param name="iChannelCount"></param>
        /// <returns></returns>
        public virtual bool SetLightOffAll(int iChannelCount)
        {
            bool bReturn = false;

            do
            {

            } while (false);

            return bReturn;
        }

        /// <summary>
        /// Thiết lập tắt ánh sáng cho nhiều kênh
        /// </summary>
        /// <param name="iChannel"></param>
        /// <param name="iChannelCount"></param>
        /// <returns></returns>
        public virtual bool SetLightOffMultiChannel(int iChannel, int iChannelCount)
        {
            bool bReturn = false;

            do
            {
            } while (false);

            return bReturn;
        }

        /// <summary>
        /// Thiết lập tắt ánh sáng cho tất cả các kênh (không có tham số)
        /// </summary>
        /// <returns></returns>
        public virtual bool SetLightOff()
        {
            bool bReturn = false;

            do
            {

            } while (false);

            return bReturn;
        }

        /// <summary>
        /// Thiết lập tắt ánh sáng trước khi thực hiện các thao tác khác
        /// </summary>
        /// <returns></returns>
        public virtual bool SetLightOffPre()
        {
            bool bReturn = false;

            do
            {

            } while (false);

            return bReturn;
        }

        /// <summary>
        /// Lấy mã lỗi hiện tại của bộ điều khiển ánh sáng
        /// </summary>
        /// <returns></returns>
        public virtual CLightControllerError HLGetErrorCode()
        {
            CLightControllerError objError = new CLightControllerError();
            return objError;
        }
    }
}
