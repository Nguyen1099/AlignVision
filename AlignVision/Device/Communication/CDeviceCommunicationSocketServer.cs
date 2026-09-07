using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlignVision
{
    class CDeviceCommunicationSocketServer : CDeviceCommunicationAbstract
    {
        private bool m_bIsConnected = false;
        private bool m_bThreadExit = false;
        private byte[] m_buffer = new byte[4096];

        private Thread m_objThreadListening;
        private Socket m_objServerSocket;
        private Socket m_objLastAcceptedClientSocket;
        private CInitializeParameter m_objInitializeParameter;

        private CallBackFuntionReceiveData m_objReceiveDataCallback = null;
        private AsyncCallback m_objOnReceive;
        private AsyncCallback m_objOnSend;
        private AsyncCallback m_objOnAccept;    // nó được thực hiện tự động khi một client kết nối đến server, nó sẽ gọi hàm onAcceptedClient để xử lý kết nối với client đó.

        /// <summary>
        /// Sự kiện được gọi khi có dữ liệu log được tạo ra trong quá trình giao tiếp với thiết bị. 
        /// Dữ liệu log này sẽ được truyền vào thông qua đối tượng LogEventArgs.
        /// </summary>
        public event EventHandler<LogEventArgs> OnLogEvent;
        private ManualResetEvent mWaitOnAccepted = new ManualResetEvent(false);


        public override bool SocketInitialize(CInitializeParameter objInitializeParameter)
        {
            bool bResult = false;

            m_objInitializeParameter = objInitializeParameter;
            if (m_objInitializeParameter.eType != CInitializeParameter.EType.TYPE_SOCKET_SERVER)
            {
                return bResult;
            }

            m_objOnAccept = new AsyncCallback(onAcceptedClient);
            m_objOnSend = new AsyncCallback(onSentToClient);
            m_objOnReceive = new AsyncCallback(onReceivedFromClient);

            if (false == openServer())
            {
                return bResult;
            }

            bResult = true;
            return bResult;
        }

        public override void SocketDeInitialize()
        {
            closeServer();
        }

        /// <summary>
        /// Kiểm tra trạng thái kết nối của socket server.
        /// </summary>
        /// <returns></returns>
        public override bool SocketIsConnected()
        {
            return m_bIsConnected;
        }

        /// <summary>
        /// Thiết lập hàm callback để nhận dữ liệu từ client. Khi có dữ liệu được nhận từ client, 
        /// hàm callback này sẽ được gọi với dữ liệu nhận được.
        /// </summary>
        /// <param name="objReceiveData"></param>
        public override void SetReceiveDataCallbackFunction(CallBackFuntionReceiveData objReceiveData)
        {
            m_objReceiveDataCallback = objReceiveData;
        }

        /// <summary>
        /// Gửi dữ liệu dạng string
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public override bool SocketSend(string strData)
        {
            bool bResult = false;
            if (false == m_bIsConnected || null == m_objLastAcceptedClientSocket)
            {
                return bResult;
            }

            try
            {
                byte[] byteData = Encoding.Default.GetBytes(strData);

                Encoding enc;
                if (CInitializeParameter.EDataEncoding.ENCODING_DEFAULT == m_objInitializeParameter.eDataEncoding)
                {
                    enc = Encoding.Default;
                }
                else if (CInitializeParameter.EDataEncoding.ENCODING_UCS2 == m_objInitializeParameter.eDataEncoding)
                {
                    enc = Encoding.GetEncoding("ucs-2");
                }
                else if (CInitializeParameter.EDataEncoding.ENCODING_UTF8 == m_objInitializeParameter.eDataEncoding)
                {
                    enc = Encoding.GetEncoding("utf-8");
                }
                else
                {
                    enc = Encoding.Default;
                }

                var stateObject = new StateObject(m_objLastAcceptedClientSocket);
                var sendBytes = Encoding.Convert(Encoding.Default, enc, byteData);
                sendBytes.CopyTo(stateObject.Buffer, 0);
                stateObject.Listener.BeginSend(stateObject.Buffer, 0, sendBytes.Length, SocketFlags.None, m_objOnSend, stateObject);
                bResult = true;
            }
            catch (Exception ex)
            {
                Trace.Write("-----Socket info : " + ex.Message + "\n");
            }
            return bResult;
        }

        /// <summary>
        /// Gửi dữ liệu dạng byte
        /// </summary>
        /// <param name="byteData"></param>
        /// <returns></returns>
        public override bool SocketSend(byte[] byteData)
        {
            bool bResult = false;

            if (false == m_bIsConnected || null == m_objLastAcceptedClientSocket)
            {
                return bResult;
            }

            try
            {
                var stateObject = new StateObject(m_objLastAcceptedClientSocket);
                byteData.CopyTo(stateObject.Buffer, 0);
                stateObject.Listener.BeginSend(stateObject.Buffer, 0, byteData.Length, SocketFlags.None, m_objOnSend, stateObject);
                bResult = true;
            }
            catch (Exception ex)
            {
                Trace.Write("-----Socket info : " + ex.Message + "\n");
            }

            return bResult;
        }

        /// <summary>
        /// open Server
        /// </summary>
        /// <returns></returns>
        private bool openServer()
        {
            bool bResult = false;

            try
            {
                if (null == m_objServerSocket)
                {
                    m_bIsConnected = false;
                    IPAddress ipServer = IPAddress.Parse(m_objInitializeParameter.strSocketIPAddress);
                    IPEndPoint localEndPoint = new IPEndPoint(ipServer, m_objInitializeParameter.iSocketPortNumber);
                    m_objServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

                    m_objServerSocket.Bind(localEndPoint);
                    m_objServerSocket.Listen(100);
                }

                if (null == m_objThreadListening)
                {
                    m_bThreadExit = false;
                    m_objThreadListening = new Thread(threadListening);
                    m_objThreadListening.Start();
                }
                bResult = true;
            }
            catch (Exception ex)
            {
                Trace.Write("-----Socket info : " + ex.Message + "\n");
            }

            if (bResult == true)
            {
                var logEventHandler = OnLogEvent;
                if (null != logEventHandler)
                {
                    logEventHandler.Invoke(this, new LogEventArgs() { LogMessage = string.Format("SocketServerLog [OPEN][{0}:{1}]", m_objInitializeParameter.strSocketIPAddress, m_objInitializeParameter.iSocketPortNumber) });
                }
            }
            return bResult;
        }

        /// <summary>
        /// close Server
        /// </summary>
        private void closeServer()
        {
            try
            {
                m_bThreadExit = true;
                mWaitOnAccepted.Set();
                m_objThreadListening.Join();
                m_objServerSocket.Shutdown(SocketShutdown.Both);
            }
            catch (Exception ex)
            {
                Trace.Write("-----Socket info : " + ex.Message + "\n");
            }
            finally
            {
                m_objServerSocket.Close(0);
                m_objServerSocket = null;
                m_bIsConnected = false;
                var logEventHandler = OnLogEvent;
                if (null != logEventHandler)
                {
                    logEventHandler.Invoke(this, new LogEventArgs() { LogMessage = string.Format("SocketServerLog [CLOSE][{0}:{1}]", m_objInitializeParameter.strSocketIPAddress, m_objInitializeParameter.iSocketPortNumber) });
                }
            }
        }
        /// <summary>
        /// Tạo luồng lắng nghe kết nối client.
        /// </summary>
        private void threadListening()
        {
            while (false == m_bThreadExit)
            {
                try
                {
                    mWaitOnAccepted.Reset();
                    m_objServerSocket.BeginAccept(m_objOnAccept, m_objServerSocket);
                    mWaitOnAccepted.WaitOne();
                }
                catch (Exception ex)
                {
                    AlignVision.CDocument.Exception(ex);
                    Thread.Sleep(500);
                }
            }
        }

        /// <summary>
        /// Xử lý kết nối với client 
        /// </summary>
        /// <param name="ar"></param>
        private void onAcceptedClient(IAsyncResult ar)
        {
            mWaitOnAccepted.Set();
            try
            {
                if (null == m_objServerSocket)
                {
                    return;
                }
                m_objLastAcceptedClientSocket = m_objServerSocket.EndAccept(ar);

                var stateObject = new StateObject(m_objLastAcceptedClientSocket);
                stateObject.Listener.BeginReceive(stateObject.Buffer, 0, stateObject.BufferSize, SocketFlags.None, m_objOnReceive, stateObject);

                var logEventHandler = OnLogEvent;
                if (null != logEventHandler)
                {
                    logEventHandler.Invoke(this, new LogEventArgs() { LogMessage = string.Format("SocketServerLog [ACCEPTED][{0}]", stateObject.Listener.Handle.ToInt32()) });
                }
                m_bIsConnected = true;
            }
            catch (Exception ex)
            {
                Trace.Write("-----Socket info : " + ex.Message + "\n");
            }
        }

        /// <summary>
        /// Xử lý khi dữ liệu được gửi đến client
        /// </summary>
        /// <param name="ar"></param>
        private void onSentToClient(IAsyncResult ar)
        {
            var stateObject = (StateObject)ar.AsyncState;
            try
            {
                int sentByteCount = stateObject.Listener.EndSend(ar);
                if (sentByteCount <= 0)
                {
                    var logEventHandler = OnLogEvent;
                    if (null != logEventHandler)
                    {
                        logEventHandler.Invoke(this, new LogEventArgs() { LogMessage = string.Format("SocketServerLog [SentZeroByte][{0}]", stateObject.Listener.Handle.ToInt32()) });
                    }
                    closeClientSocket(stateObject);
                }
                else
                {
                    var sb = new StringBuilder();
                    sb.Append(string.Format("[SENT][{0}][", stateObject.Listener.Handle.ToInt32()));
                    for (int i = 0; i < sentByteCount; i++)
                    {
                        sb.Append(string.Format("{0} ", stateObject.Buffer[i]));
                    }
                    sb.Append("]");
                    var logEventHandler = OnLogEvent;
                    if (null != logEventHandler)
                    {
                        logEventHandler.Invoke(this, new LogEventArgs() { LogMessage = sb.ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.Write("-----Socket info : " + ex.Message + "\n");
                closeClientSocket(stateObject);
            }
        }

        /// <summary>
        /// Xử lý khi dữ liệu được nhận từ client
        /// </summary>
        /// <param name="ar"></param>
        private void onReceivedFromClient(IAsyncResult ar)
        {
            bool bReceiveData = true;
            var stateObject = (StateObject)ar.AsyncState;
            try
            {
                int iReceivedByteCount = stateObject.Listener.EndReceive(ar);
                if (iReceivedByteCount <= 0)
                {
                    var logEventHandler = OnLogEvent;
                    if (null != logEventHandler)
                    {
                        logEventHandler.Invoke(this, new LogEventArgs() { LogMessage = string.Format("SocketServerLog [ReceivedZeroByte][{0}]", stateObject.Listener.Handle.ToInt32()) });
                    }
                    closeClientSocket(stateObject);
                    return;
                }
                else
                {
                    var sb = new StringBuilder();
                    sb.Append(string.Format("SocketServerLog [RECV][{0}][", stateObject.Listener.Handle.ToInt32()));
                    for (int i = 0; i < iReceivedByteCount; i++)
                    {
                        sb.Append(string.Format("{0} ", stateObject.Buffer[i]));
                    }
                    sb.Append("]");
                    var logEventHandler = OnLogEvent;
                    if (null != logEventHandler)
                    {
                        logEventHandler.Invoke(this, new LogEventArgs() { LogMessage = sb.ToString() });
                    }
                }

                string strReceivedData = "";
                byte[] byteReceiveData;
                Encoding enc;
                if (CInitializeParameter.EDataEncoding.ENCODING_DEFAULT == m_objInitializeParameter.eDataEncoding)
                {
                    enc = Encoding.Default;
                    byteReceiveData = Encoding.Convert(enc, Encoding.Default, stateObject.Buffer, 0, iReceivedByteCount);
                }
                else if (CInitializeParameter.EDataEncoding.ENCODING_UCS2 == m_objInitializeParameter.eDataEncoding)
                {
                    enc = Encoding.GetEncoding("ucs-2");
                    byteReceiveData = Encoding.Convert(enc, Encoding.Default, stateObject.Buffer, 0, iReceivedByteCount);
                }
                else if (CInitializeParameter.EDataEncoding.ENCODING_UTF8 == m_objInitializeParameter.eDataEncoding)
                {
                    enc = Encoding.GetEncoding("utf-8");
                    byteReceiveData = Encoding.Convert(enc, Encoding.Default, stateObject.Buffer, 0, iReceivedByteCount);
                }
                else
                {
                    enc = Encoding.Default;
                    byteReceiveData = (byte[])stateObject.Buffer.Clone();
                }

                try
                {
                    strReceivedData = Encoding.Default.GetString(byteReceiveData).Substring(0, byteReceiveData.Length);
                }
                catch (Exception)
                {
                    bReceiveData = false;
                }

                CallBackFuntionReceiveData receiveCallback = m_objReceiveDataCallback;
                if (null != receiveCallback && true == bReceiveData)
                {
                    CReceiveData objData = new CReceiveData();
                    objData.strData = strReceivedData;
                    objData.byteReceiveData = (byte[])byteReceiveData.Clone();
                    objData.iByteLength = byteReceiveData.Length;
                    receiveCallback(objData);
                }
            }
            catch (Exception ex)
            {
                Trace.Write("-----Socket info : " + ex.Message + "\n");
            }
            finally
            {
                try
                {
                    if (false == stateObject.IsClose)
                    {
                        stateObject.Reset();
                        stateObject.Listener.BeginReceive(stateObject.Buffer, 0, stateObject.BufferSize, SocketFlags.None, m_objOnReceive, stateObject);
                    }
                }
                catch (Exception ex)
                {
                    Trace.Write("-----Socket info : " + ex.Message + "\n");
                }
            }
        }

        /// <summary>
        /// Đóng socket phía máy khách
        /// </summary>
        /// <param name="clientStateObject"></param>
        private void closeClientSocket(StateObject clientStateObject)
        {
            try
            {
                clientStateObject.Listener.Shutdown(SocketShutdown.Both);
                clientStateObject.Listener.Close();
            }
            catch (SocketException ex)
            {
                Trace.Write("-----Socket info : " + ex.Message + "\n");
            }
            finally
            {
                clientStateObject.IsClose = true;
                if (true == m_objLastAcceptedClientSocket.Equals(clientStateObject.Listener))
                {
                    var logEventHandler = OnLogEvent;
                    if (null != logEventHandler)
                    {
                        logEventHandler.Invoke(this, new LogEventArgs() { LogMessage = string.Format("SocketServerLog [DISCONNECT][{0}]", m_objLastAcceptedClientSocket.Handle.ToInt32()) });
                    }
                    m_objLastAcceptedClientSocket = null;
                    m_bIsConnected = false;
                }
            }
        }



    }
}

