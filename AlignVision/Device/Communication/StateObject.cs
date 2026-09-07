using System.Net.Sockets;
using System.Text;

namespace AlignVision
{
    sealed class StateObject
    {
        public int ID
        {
            get
            {
                return mID;
            }
        }
        public bool IsClose { get; set; }
        public int BufferSize
        {
            get
            {
                return BUFFER_SIZE;
            }
        }
        public byte[] Buffer
        {
            get
            {
                return mBuffer;
            }
        }
        public Socket Listener
        {
            get
            {
                return mListener;
            }
        }
        public string Text
        {
            get
            {
                return mSB.ToString();
            }
        }
        private const int BUFFER_SIZE = 4096;
        private readonly byte[] mBuffer = new byte[BUFFER_SIZE];
        private readonly Socket mListener;
        private readonly int mID;
        private StringBuilder mSB;

        public StateObject(Socket listener, int id = -1)
        {
            mListener = listener;
            mID = id;
            IsClose = false;
            Reset();
        }

        public void AppendText(string text)
        {
            mSB.Append(text);
        }

        public void Reset()
        {
            mSB = new StringBuilder();
        }
    }
}
