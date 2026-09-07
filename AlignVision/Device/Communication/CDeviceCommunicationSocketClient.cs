using Cognex.VisionPro.ImageFile;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlignVision
{
    class CDeviceCommunicationSocketClient : CDeviceCommunicationAbstract
    {
        private bool m_bIsConnected = false;
        private bool m_bThreadExit = false;


        private Thread m_ThreadConnect;
        private Socket m_objSocket;

        private byte[] m_byteReceivedData = new byte[4096];

        CDeviceCommunicationAbstract.CInitializeParameter m_objInitializeParameter;
        private CallBackFuntionReceiveData m_objCallback = null;


        public override bool SocketInitialize(CDeviceCommunicationAbstract.CInitializeParameter objInitializeParameter)
        {
            bool bReturn = false;

            m_objInitializeParameter = objInitializeParameter;
            if (m_objInitializeParameter.eType != CInitializeParameter.EType.TYPE_SOCKET_CLIENT)
            {
                return bReturn;
            }
            Connect();

            // Khởi tạo luồng kết nối lại khi mất kết nối
            m_ThreadConnect = new Thread(ThreadConnect);
            m_ThreadConnect.Start(this);

            bReturn = true;
            return bReturn;
        }

        /// <summary>
        /// Hàm thực hiện ngắt kết nối và giải phóng tài nguyên
        /// </summary>
        public override void SocketDeInitialize()
        {
            m_bThreadExit = true;
            m_ThreadConnect.Join();
            Disconnect();
        }

        /// <summary>
        /// Kiểm tra trạng thái kết nối của socket
        /// </summary>
        /// <returns></returns>
        public override bool SocketIsConnected()
        {
            return m_bIsConnected;
        }

        public override void SetReceiveDataCallbackFunction(CallBackFuntionReceiveData objReceiveData)
        {
            m_objCallback = objReceiveData;
        }

        /// <summary>
        /// Gửi dữ liệu dạng string
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public override bool SocketSend(string strData)
        {
            bool bReturn = false;
            if (m_objSocket == null || m_bIsConnected == false)
            {
                return bReturn;
            }

            lock (this)
            {
                try
                {
                    byte[] byteData = Encoding.Default.GetBytes(strData);

                    // Việc truyền dữ liệu dựa trên loại mã hóa dữ liệu
                    Encoding enc;
                    if (CInitializeParameter.EDataEncoding.ENCODING_DEFAULT == m_objInitializeParameter.eDataEncoding)
                    {
                        enc = Encoding.Default;
                    }
                    else if (CInitializeParameter.EDataEncoding.ENCODING_UCS2 == m_objInitializeParameter.eDataEncoding)
                    {
                        enc = Encoding.GetEncoding("ucs-2");
                    }
                    else
                    {
                        enc = Encoding.Default;
                    }

                    byte[] byteSendData = Encoding.Convert(Encoding.Default, enc, byteData);

                    //new AsyncCallback(OnSend) (Tham số 5 - callback): Đây chính là "lời dặn dò".
                    //Bạn đăng ký hàm OnSend vào đây để hệ điều hành biết rằng: "Ngay khi tiến trình gửi dữ liệu hoàn tất (bất kể thành công hay thất bại),
                    //hãy tự động gọi hàm OnSend để tôi xử lý kết quả".
                    m_objSocket.BeginSend(byteSendData, 0, byteSendData.Length, SocketFlags.None, new AsyncCallback(OnSend), byteSendData);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Socket Send Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            bReturn = true;
            return bReturn;
        }

        /// <summary>
        /// Gửi dữ liệu dạng byte
        /// </summary>
        /// <param name="byteData"></param>
        /// <returns></returns>
        public override bool SocketSend(byte[] byteData)
        {
            bool bReturn = false;
            if (m_objSocket == null || m_bIsConnected == false)
            {
                return bReturn;
            }

            lock (this)
            {
                try
                {
                    m_objSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), byteData);
                }
                catch (Exception ex)
                {
                    Trace.Write("-----Socket Client info : " + ex.Message + "\n");
                }
            }
            bReturn = true;
            return bReturn;
        }

        private void Connect()
        {
            try
            {
                IPAddress ipSever = IPAddress.Parse(m_objInitializeParameter.strSocketIPAddress);

                m_objSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                m_objSocket.NoDelay = true;
                m_objSocket.Connect(new IPEndPoint(ipSever, m_objInitializeParameter.iSocketPortNumber));
                m_objSocket.BeginReceive(m_byteReceivedData, 0, m_byteReceivedData.Length, SocketFlags.None, new AsyncCallback(OnReceived), this);
                m_bIsConnected = true;
            }

            catch (Exception e)
            {
                MessageBox.Show("Socket Connect Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_bIsConnected = false;
            }
        }
        private void Disconnect()
        {
            try
            {
                if (m_objSocket != null)
                {
                    m_objSocket.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Socket Disconnect Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hàm callback được gọi khi quá trình gửi dữ liệu hoàn tất, bất kể thành công hay thất bại. 
        /// Trong hàm này, bạn có thể kiểm tra kết quả của việc gửi dữ liệu và thực hiện các hành động cần thiết dựa trên kết quả đó.
        /// </summary>
        /// <param name="result"></param>
        private void OnSend(IAsyncResult result)
        {
            byte[] byteSendData = (byte[])result.AsyncState;
            try
            {
                int Size = m_objSocket.EndSend(result);
                if (Size == 0)
                {
                    Disconnect();
                }
            }
            catch (Exception ex)
            {
                Trace.Write("-----Socket Client info : " + ex.Message + "\n");
                Disconnect();
                m_bIsConnected = false;
            }
        }

        /// <summary>
        /// Hàm callback được gọi khi có dữ liệu mới được nhận về. 
        /// Trong hàm này, bạn có thể xử lý dữ liệu nhận được và thực hiện các hành động cần thiết dựa trên nội dung của dữ liệu đó.
        /// </summary>
        /// <param name="result"></param>
        private void OnReceived(IAsyncResult result)
        {
            bool bReceiveData = true;
            try
            {
                int iReceivedByteCount = m_objSocket.EndReceive(result);
                if (iReceivedByteCount <= 0)
                {
                    return;
                }

                string strReceiveData = string.Empty;
                byte[] byteReceiveData;

                // Lựa chọn bảng mã hoá
                Encoding enc;
                if (CInitializeParameter.EDataEncoding.ENCODING_DEFAULT == m_objInitializeParameter.eDataEncoding)
                {
                    enc = Encoding.Default;
                    byteReceiveData = Encoding.Convert(enc, Encoding.Default, m_byteReceivedData, 0, iReceivedByteCount);
                }
                else if (CInitializeParameter.EDataEncoding.ENCODING_UCS2 == m_objInitializeParameter.eDataEncoding)
                {
                    enc = Encoding.GetEncoding("ucs-2");
                    byteReceiveData = Encoding.Convert(enc, Encoding.Default, m_byteReceivedData, 0, iReceivedByteCount);
                }
                else
                {
                    enc = Encoding.Default;
                    byteReceiveData = (byte[])m_byteReceivedData.Clone();
                }

                // Lấy dữ liệu nhận về
                try
                {
                    strReceiveData = enc.GetString(byteReceiveData).Substring(0, iReceivedByteCount);
                }
                catch (Exception)
                {
                    bReceiveData = false;
                }

                if (m_objCallback != null && bReceiveData == true)
                {
                    CReceiveData objData = new CReceiveData();
                    objData.strData = strReceiveData;
                    objData.byteReceiveData = byteReceiveData;
                    objData.iByteLength = iReceivedByteCount;
                    m_objCallback(objData);

                }

            }
            catch (Exception ex)
            {
                Trace.Write("-----Socket Client info : " + ex.Message + "\n");
            }
            finally
            {
                try
                {
                    Array.Clear(m_byteReceivedData, 0, m_byteReceivedData.Length);
                    m_objSocket.BeginReceive(m_byteReceivedData, 0, m_byteReceivedData.Length, SocketFlags.None, new AsyncCallback(OnReceived), this);
                }
                catch (System.Exception ex)
                {
                    Trace.Write("-----Socket Client info : " + ex.Message + "\n");
                    Disconnect();
                    m_bIsConnected = false; ;

                }

            }
        }

        /// <summary>
        /// Hàm thực hiện kết nối lại khi mất kết nối
        /// </summary>
        /// <param name="obj"></param>
        private static void ThreadConnect(object obj)
        {
            CDeviceCommunicationSocketClient objSocketClient = (CDeviceCommunicationSocketClient)obj;
            while (false == objSocketClient.m_bThreadExit)
            {
                if (objSocketClient.m_objSocket != null)
                {
                    try
                    {
                        if (objSocketClient.m_bIsConnected == false)
                        {
                            // đóng các kết nối hiện có
                            objSocketClient.m_objSocket.Close();
                            objSocketClient.m_objSocket = null;
                            // thực hiện kết nối lại
                            objSocketClient.Connect();
                        }

                    }
                    catch (Exception ex)
                    {
                        Trace.Write("-----Socket Client info : " + ex.Message + "\n");
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
}
