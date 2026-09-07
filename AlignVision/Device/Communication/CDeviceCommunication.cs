using System;

namespace AlignVision
{
    class CDeviceCommunication
    {
        CDeviceCommunicationAbstract m_objCommunication;
        CDeviceCommunicationAbstract.CInitializeParameter m_objInitializeParameter;

        /// <summary>
        /// Hành động kết nối
        /// </summary>
        public Action OnConnect;

        /// <summary>
        /// Hành động ngắt kết nối
        /// </summary>
        public Action OnDisconnect;

        /// <summary>
        /// Dữ liệu nhận.
        /// </summary>
        public CDeviceCommunicationAbstract.CReceiveData m_objReceiveData = new CDeviceCommunicationAbstract.CReceiveData();

        public delegate void CallBackFuntionReceiveData(CDeviceCommunicationAbstract.CReceiveData objReceiveData);
        private CallBackFuntionReceiveData m_objCallback = null;

        public CDeviceCommunication(CDeviceCommunicationAbstract objCommunication)
        {
            m_objCommunication = objCommunication;
        }

        public bool Initialize(CDeviceCommunicationAbstract.CInitializeParameter objInitializeParameter)
        {
            bool bResult = false;

            m_objInitializeParameter = (CDeviceCommunicationAbstract.CInitializeParameter)objInitializeParameter.Clone();
            m_objCommunication.SetReceiveDataCallbackFunction(ReceiveData);
            m_objCommunication.OnConnect += OnConnect;
            m_objCommunication.OnDisconnect += OnDisconnect;
            if (false == m_objCommunication.SocketInitialize(m_objInitializeParameter))
            {
                return bResult;
            }

            bResult = true;
            return bResult;
        }

        public void DeInitialize()
        {
            m_objCommunication.SocketDeInitialize();
        }

        public bool IsConnected()
        {
            return m_objCommunication.SocketIsConnected();
        }

        private void ReceiveData(CDeviceCommunicationAbstract.CReceiveData objReceiveData)
        {
            m_objReceiveData = (CDeviceCommunicationAbstract.CReceiveData)objReceiveData.Clone();

            if (null != m_objCallback)
            {
                m_objCallback(m_objReceiveData);
            }
        }

        public void SetCallbackFunction(CallBackFuntionReceiveData objCallback)
        {
            m_objCallback = objCallback;
        }

        /// <summary>
        /// Gửi dữ liệu string
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public bool Send(string strData)
        {
            bool bResult = false;
            if (false == m_objCommunication.SocketSend(strData))
            {
                return bResult;
            }
            bResult = true;
            return bResult;
        }

        /// <summary>
        /// Gửi dữ liệu byte
        /// </summary>
        /// <param name="byteData"></param>
        /// <returns></returns>
        public bool Send(byte[] byteData)
        {
            bool bResult = false;
            if (false == m_objCommunication.SocketSend(byteData))
            {
                return bResult;
            }
            bResult = true;
            return bResult;

        }
    }
}
