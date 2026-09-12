using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace AlignVision
{
    class CDeviceCommunicationSerialPort : CDeviceCommunicationAbstract
    {
        private bool m_bThreadExit = false;
        private bool m_bIsConnected = false;

        SerialPort m_objSerial = new SerialPort();
        private object m_objLock = new object();
        Thread m_ThreadConnect;

        byte[] m_byteReceivedData = new byte[4096];

        CDeviceCommunicationAbstract.CInitializeParameter m_objInitializeParameter;
        private CallBackFuntionReceiveData m_objCallback = null;

        public override bool SocketInitialize(CInitializeParameter objInitializeParameter)
        {
            bool bResult = false;
            m_objInitializeParameter = (CInitializeParameter)objInitializeParameter.Clone();
            if (CInitializeParameter.EType.TYPE_SERIAL != m_objInitializeParameter.eType)
            {
                return bResult;
            }
            m_ThreadConnect = new Thread(ThreadConnect);
            m_ThreadConnect.Start(this);
            bResult = true;
            return bResult;
        }

        public override void SocketDeInitialize()
        {
            m_bThreadExit = true;
            Disconnect();
        }

        public override bool SocketIsConnected()
        {
            return m_bIsConnected;
        }

        public override void SetReceiveDataCallbackFunction(CallBackFuntionReceiveData objReceiveData)
        {
            m_objCallback = objReceiveData;
        }

        /// <summary>
        /// Gửi dữ liệu đến cổng Serial string
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public override bool SendData(string strData)
        {
            bool bReturn = false;

            lock (m_objLock)
            {
                try
                {
                    m_objSerial.DiscardInBuffer();
                    m_objSerial.DiscardOutBuffer();

                    m_objSerial.Write(strData);
                    m_objSerial.BaseStream.Flush();
                }
                catch (System.Exception ex)
                {
                    Trace.Write("-----Serial info : " + ex.Message + "\n");
                }
            }

            bReturn = true;
            return bReturn;
        }

        /// <summary>
        /// Gửi dữ liệu đến cổng Serial byte
        /// </summary>
        /// <param name="byteData"></param>
        /// <returns></returns>
        public override bool SendData(byte[] byteData)
        {
            bool bReturn = false;
            lock (m_objLock)
            {
                try
                {
                    m_objSerial.DiscardInBuffer();
                    m_objSerial.DiscardOutBuffer();
                    m_objSerial.Write(byteData, 0, byteData.Length);
                    m_objSerial.BaseStream.Flush();
                }
                catch (System.Exception ex)
                {
                    Trace.Write("-----Serial info : " + ex.Message + "\n");
                }
            }
            bReturn = true;
            return bReturn;
        }

        /// <summary>
        /// Luồng kết nối Serial
        /// </summary>
        /// <param name="state"></param>
        private static void ThreadConnect(Object state)
        {
            CDeviceCommunicationSerialPort pThis = (CDeviceCommunicationSerialPort)state;

            while (false == pThis.m_bThreadExit)
            {
                if (false == pThis.m_bIsConnected)
                {
                    pThis.Connect();
                }
                Thread.Sleep(2000);
            }
        }

        /// <summary>
        /// Kết nối đến cổng Serial dựa trên các thông số đã được khởi tạo trong m_objInitializeParameter
        /// </summary>
        private void Connect()
        {
            try
            {
                m_objSerial = new SerialPort();
                m_objSerial.PortName = m_objInitializeParameter.strSerialPortName;
                m_objSerial.BaudRate = m_objInitializeParameter.iSerialPortBaudrate;
                m_objSerial.Parity = (Parity)m_objInitializeParameter.eParity;
                m_objSerial.DataBits = m_objInitializeParameter.iSerialPortDataBits;
                m_objSerial.StopBits = (StopBits)m_objInitializeParameter.eStopBits;
                m_objSerial.Open();
                m_objSerial.DataReceived += m_objSerial_DataReceived;
                m_bIsConnected = true;
            }
            catch (System.Exception ex)
            {
                Trace.Write("-----Serial info : " + ex.Message + "\n");
                m_bIsConnected = false;
            }
        }

        /// <summary>
        /// Nhận dữ liệu từ cổng Serial và gọi hàm callback để thông báo rằng dữ liệu đã được nhận
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_objSerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int iReceivedByteCount = m_objSerial.Read(m_byteReceivedData, 0, m_byteReceivedData.Length);

            if (iReceivedByteCount <= 0)
            {
                Disconnect();
                return;
            }

            string strReceivedData = "";
            strReceivedData = Encoding.Default.GetString(m_byteReceivedData).Substring(0, iReceivedByteCount);

            // Call the callback function to notify that data has been received
            if (null != m_objCallback)
            {
                CDeviceCommunicationAbstract.CReceiveData objData = new CDeviceCommunicationAbstract.CReceiveData();
                objData.strData = strReceivedData;
                objData.byteReceiveData = (byte[])m_byteReceivedData.Clone();
                objData.iByteLength = iReceivedByteCount;
                m_objCallback(objData);
            }

            Array.Clear(m_byteReceivedData, 0, m_byteReceivedData.Length);
        }

        /// <summary>
        /// Disconnects the serial port connection
        /// </summary>
        private void Disconnect()
        {
            if (false == m_bIsConnected)
            {
                return;
            }

            try
            {
                m_objSerial.DataReceived -= m_objSerial_DataReceived;
                m_objSerial.Close();
            }
            catch (System.Exception ex)
            {
                Trace.Write("-----Serial info : " + ex.Message + "\n");
            }
            m_bIsConnected = false;

        }
    }
}

