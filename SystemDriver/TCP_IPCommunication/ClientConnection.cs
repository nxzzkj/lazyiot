namespace TcpNetworkBrige
{
    using System;
    using System.Net;
    using System.Net.Sockets;

    public class ClientConnection
    {
        private const int cBufferSize = 0x1000;
        public int ConnectionId;
        private byte[] mBuffer;
        private IPEndPoint mEndPoint;
        private System.Net.Sockets.Socket mSocket;

        public ClientConnection(System.Net.Sockets.Socket socket)
        {
            this.mSocket = socket;
            if (socket.RemoteEndPoint != null)
            {
                this.mEndPoint = (IPEndPoint)socket.RemoteEndPoint;
            }
            this.mBuffer = new byte[0x1000];
        }
        public void Connected()
        {

            if (this.mSocket != null && this.mEndPoint!=null)
            {

                if (!this.mSocket.Connected)
                {      
                    this.mSocket.Close();
                    this.mSocket.Connect(this.mEndPoint);
                
                }
            }
        }
        public byte[] Buffer
        {
            get
            {
                return this.mBuffer;
            }
        }

        public IPEndPoint EndPoint
        {
            get
            {
                return this.mEndPoint;
            }
        }

        public System.Net.Sockets.Socket Socket
        {
            get
            {
                return this.mSocket;
            }
        }
       
    }
}

