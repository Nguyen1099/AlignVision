using System;

namespace AlignVision
{
    class CDeviceCommunicationVirtual : CDeviceCommunicationAbstract
    {
        private byte[] m_byteReceivedData = new byte[4096];

        CDeviceCommunicationAbstract.CInitializeParameter m_objInitializeParameter;
        private CallBackFuntionReceiveData m_objCallback = null;

        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// <param name="objInitializeParameter"></param>
        /// <returns></returns>
        public override bool SocketInitialize(CDeviceCommunicationAbstract.CInitializeParameter objInitializeParameter)
        {
            bool bReturn = false;

            do
            {
                m_objInitializeParameter = objInitializeParameter;

                bReturn = true;
            } while (false);

            return bReturn;
        }

        /// <summary>
        /// Giải phóng
        /// </summary>
        public override void SocketDeInitialize()
        {
        }

        /// <summary>
        /// Kiểm tra kết nối
        /// </summary>
        /// <returns></returns>
        public override bool SocketIsConnected()
        {
            return true;
        }


        /// <summary>
        /// Kết nối callback
        /// </summary>
        /// <param name="objReceiveData"></param>
        public override void SetReceiveDataCallbackFunction(CallBackFuntionReceiveData objReceiveData)
        {
            m_objCallback = objReceiveData;
        }

        /// <summary>
        /// SEND
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public override bool SocketSend(string strData)
        {
            bool bReturn = false;

            do
            {

                bReturn = true;
            } while (false);

            return bReturn;
        }

        /// <summary>
        /// SEND
        /// </summary>
        /// <param name="byteData"></param>
        /// <returns></returns>
        public override bool SocketSend(byte[] byteData)
        {
            bool bReturn = false;

            do
            {

                bReturn = true;
            } while (false);

            return bReturn;
        }

    }
}
