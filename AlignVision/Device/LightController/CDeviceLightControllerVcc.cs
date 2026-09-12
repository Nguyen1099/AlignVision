using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlignVision
{
    public class CDeviceLightControllerVcc : CDeviceLightControllerAbstract
    {
        private CInitializeParameter m_objInitializeParameter = new CInitializeParameter();
        private CLightControllerError m_objError = new CLightControllerError();
        private CDeviceLightControllerVcc m_objLightController = new CDeviceLightControllerVcc();
        private CallBackFuntionReceiveData m_objCallback = null;

        private CReceiveData m_objData = new CReceiveData();

        private CDeviceCommunication m_objCommunication;
        private bool m_bReceived;

        public CDeviceLightControllerVcc()
        {
        }

        public override string GetVersion()
        {
            return m_objLightController.GetVersion();
        }

        public override bool Initialize(CInitializeParameter objInitializeParameter)
        {
            bool bReturn = false;
            m_objInitializeParameter = objInitializeParameter.Clone() as CInitializeParameter;
            if (CInitializeParameter.enumType.TYPE_SERIAL_PORT == m_objInitializeParameter.eType)
            {
                m_objCommunication = new CDeviceCommunication(new CDeviceCommunicationSerialPort());
            }
            else if (m_objInitializeParameter.eType == CInitializeParameter.enumType.TYPE_SOCKET_CLIENT)
            {
                m_objCommunication = new CDeviceCommunication(new CDeviceCommunicationSocketClient());
            }
            else if (CInitializeParameter.enumType.TYPE_SOCKET_SERVER == m_objInitializeParameter.eType)
            {
                m_objCommunication = new CDeviceCommunication(new CDeviceCommunicationSocketServer());
            }

            CDeviceCommunicationAbstract.CInitializeParameter objCommunicationParameter = new CDeviceCommunicationAbstract.CInitializeParameter();
            objCommunicationParameter.strSocketIPAddress = objInitializeParameter.strSocketIPAddress;
            objCommunicationParameter.iSocketPortNumber = objInitializeParameter.iSocketPortNumber;
            objCommunicationParameter.strSerialPortName = objInitializeParameter.strSerialPortName;
            objCommunicationParameter.iSerialPortBaudrate = objInitializeParameter.iSerialPortBaudrate;
            objCommunicationParameter.iSerialPortDataBits = objInitializeParameter.iSerialPortDataBits;
            objCommunicationParameter.eType = (CDeviceCommunicationAbstract.CInitializeParameter.EType)objInitializeParameter.eType;
            objCommunicationParameter.eParity = (CDeviceCommunicationAbstract.CInitializeParameter.ESerialPortParity)objInitializeParameter.eParity;
            objCommunicationParameter.eStopBits = (CDeviceCommunicationAbstract.CInitializeParameter.ESerialPortStopBits)objInitializeParameter.eStopBits;

            m_bReceived = false;
            m_objCommunication.SetCallbackFunction(ReceiveData);
            if (false == m_objCommunication.Initialize(objCommunicationParameter))
            {
                MakeErrorMessage("Vcc Initialize", 22000, "FAIL");
            }

            Thread.Sleep(1000);
            bReturn = true;
            return bReturn;
        }


        public override void DeInitialize()
        {
            m_objCommunication.DeInitialize();
        }

        public override bool IsConnected()
        {
            return m_objCommunication.IsConnected();
        }

        public override void SetCallbackFunction(CallBackFuntionReceiveData objReceiveData)
        {
            m_objCallback = objReceiveData;
        }

        /// <summary>
        /// Thiết lập cường độ ánh sáng cho kênh cụ thể
        /// </summary>
        /// <param name="iChannel"></param>
        /// <param name="iIntensity"></param>
        /// <returns></returns>
        public override bool SetLightIntensity(int iChannel, int iIntensity)
        {
            bool bReturn = false;

            try
            {
                string strData = $"N{iChannel}{iIntensity:D3}\r\n";
                m_objCommunication.Send(strData);
                if (false == WaitReceiveStatus())
                {
                    return bReturn;
                }
                bReturn = true;
            }
            catch (Exception)
            {
                MakeError();
            }
            return bReturn;
        }

        /// <summary>
        /// Thiết lập cường độ ánh sáng cho tất cả các kênh
        /// </summary>
        /// <param name="iChannel"></param>
        /// <param name="iIntensity"></param>
        /// <param name="iCount"></param>
        /// <returns></returns>
        public override bool SetLightIntensity(int[] iChannel, int[] iIntensity, int iCount)
        {
            bool result = true;
            m_bReceived = false;
            try
            {
                for (int i = 0; i < iCount; i++)
                {
                    string strData = $"N{iChannel[i]}{iIntensity[i]:D3}\r\n";
                    m_objCommunication.Send(strData);
                    if (false == WaitReceiveStatus())
                    {
                        result = false;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                MakeError();
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Thiết lập cường độ ánh sáng cho tất cả các kênh
        /// </summary>
        /// <param name="iIntensity"></param>
        /// <returns></returns>
        public override bool SetLightIntensityMultiChannel(int iChannel, int iIntensity, int iCount)
        {
            bool result = true;
            m_bReceived = false;
            try
            {
                string strData = $"NA{iIntensity:D3}\r\n";
                m_bReceived = false;
                m_objCommunication.Send(strData);
                if (false == WaitReceiveStatus(1000))
                {
                    result = false;
                }
            }
            catch (Exception)
            {
                MakeError();
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Tắt đèn
        /// </summary>
        /// <param name="iChannel"></param>
        /// <returns></returns>
        public override bool SetLightOff(int iChannel)
        {
            bool result = false;
            try
            {
                string strData = $"E{iChannel}\r\n";
                m_objCommunication.Send(strData);
                if (false == WaitReceiveStatus())
                {
                    return result;
                }
                result = true;
            }
            catch (Exception)
            {
                MakeError();
            }
            return result;
        }

        public override bool SetLightOffMultiChannel(int iChannel, int iChannelCount)
        {
            bool bResult = false;
            try
            {
                for (int i = 0; i < iChannelCount; i++)
                {
                    string strData = $"E{iChannel + i}\r\n";
                    m_objCommunication.Send(strData);
                    if (false == WaitReceiveStatus())
                    {
                        return bResult;
                    }
                }
                bResult = true;
            }
            catch (Exception)
            {
                MakeError();
            }
            return bResult;
        }

        public override bool SetLightOffAll(int iChannelCount)
        {
            bool bResult = false;
            try
            {
                for (int i = 0; i < iChannelCount; i++)
                {
                    string strData = $"E{i + 1}\r\n";
                    m_objCommunication.Send(strData);
                    if (false == WaitReceiveStatus())
                    {
                        return bResult;
                    }
                }
                bResult = true;
            }
            catch (Exception)
            {
                MakeError();
            }
            return bResult;
        }

        /// <summary>
        /// Hàm nhận dữ liệu từ thiết bị, sau khi nhận được dữ liệu sẽ gọi hàm callback để trả về dữ liệu cho người dùng.
        /// </summary>
        /// <param name="objReceiveData"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void ReceiveData(CDeviceCommunicationAbstract.CReceiveData objReceiveData)
        {
            try
            {
                m_bReceived = true;
                Thread.Sleep(10);
                if (m_objCallback != null)
                {
                    m_objCallback((CDeviceLightControllerAbstract.CReceiveData)m_objData.Clone());
                }
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Hàm chờ nhận dữ liệu từ thiết bị, nếu trong khoảng thời gian iTimeout mà 
        /// không nhận được dữ liệu thì trả về false, ngược lại trả về true.
        /// </summary>
        /// <param name="iTimeout"></param>
        /// <param name="iSleepPeriod"></param>
        /// <returns></returns>
        private bool WaitReceiveStatus(int iTimeout = 200, int iSleepPeriod = 5)
        {
            bool result = false;
            while (0 < iTimeout && !m_bReceived)
            {
                Thread.Sleep(iSleepPeriod);
                iTimeout -= iSleepPeriod;
            }

            if (0 < iTimeout)
            {
                result = true;
            }

            return result;
        }


        private void MakeError()
        {
            CLightControllerError objError = m_objLightController.HLGetErrorCode();
            m_objError.iReturnCode = objError.iReturnCode;
            m_objError.strEventTime = objError.strEventTime;
            m_objError.strFunctionName = objError.strFunctionName;
            m_objError.strMessage = objError.strMessage;
        }

        public override CLightControllerError HLGetErrorCode()
        {
            return (CLightControllerError)m_objError.Clone();
        }

        private CLightControllerError MakeErrorMessage(string strFunctionName, int iReturnCode, string strMessage = "")
        {
            m_objError.strEventTime = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            m_objError.strFunctionName = strFunctionName;
            m_objError.iReturnCode = iReturnCode;
            m_objError.strMessage = strMessage;
            if (m_objError.iReturnCode == 0)
            {
                m_objError.iReturnCode = 0;
            }

            return m_objError;
        }


    }
}
