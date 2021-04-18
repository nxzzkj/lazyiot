namespace TcpNetworkBrige
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;

    public class TCPClient
    {
        private int buffersize = 0x10000;
        private Socket cli;
        private byte[] databuffer;

        public event ClientEvent mOnConnected;

        public event ClientErrorEvent mOnError;

        public event ClientOnDataInHandler OnDataIn;

        public event ClientEvent OnDisconnected;

        public TCPClient()
        {
            this.databuffer = new byte[this.buffersize];
        }

        public void Close()
        {
            this.cli.Shutdown(SocketShutdown.Both);
            this.cli.Close();
        }

        public void Connect(string ip, int port)
        {
            try
            {
        
                this.cli = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ip), port);
                this.cli.BeginConnect(remoteEP, new AsyncCallback(this.Connected), this.cli);
            }
            catch
            {

            }
        }

        private void Connected(IAsyncResult iar)
        {
            if (iar == null)
                return;
            if (iar.AsyncState == null)
                return;
            Socket asyncState = (Socket) iar.AsyncState;
            try
            {
                asyncState.EndConnect(iar);
            }
            catch (SocketException exception)
            {
                this.RaiseErrorEvent(exception);
                return;
            }
            if (this.mOnConnected != null)
            {
                this.mOnConnected(this);
            }
            this.StartWaitingForData(asyncState);
        }

        private void HandleConnectionData(IAsyncResult parameter)
        {
            if (parameter == null)
                return;
        
            if (parameter.AsyncState == null)
                return;
            try
            {
                Socket asyncState = (Socket)parameter.AsyncState;
                int length = asyncState.EndReceive(parameter);
                if (length == 0)
                {
              
                }
                else
                {
                    byte[] destinationArray = new byte[length];
                    Array.Copy(this.databuffer, 0, destinationArray, 0, length);
                    if (this.OnDataIn != null)
                    {
                        this.OnDataIn(this, destinationArray);
                    }
                    this.StartWaitingForData(asyncState);
                }
            }
            catch
            {

            }
        }

        private void HandleIncomingData(IAsyncResult parameter)
        {
            if (parameter == null)
                return;

            if (parameter.AsyncState == null)
                return;
            try
            {
                this.HandleConnectionData(parameter);
            }
            catch (ObjectDisposedException)
            {
               // this.RaiseDisconnectedEvent();
            }
            catch (SocketException exception)
            {
                if (exception.ErrorCode == 0x2746)
                {
            //       this.RaiseDisconnectedEvent();
                }
                this.RaiseErrorEvent(exception);
            }
        }

        private void HandleSendFinished(IAsyncResult parameter)
        {
            try
            {
                if (parameter == null)
                    return;

                if (parameter.AsyncState == null)
                    return;
                ((Socket)parameter.AsyncState).EndSend(parameter);
            }
            catch
            {

            }
        }

        private void RaiseDisconnectedEvent()
        {
            if (this.OnDisconnected != null)
            {
                this.OnDisconnected(this);
            }
        }

        private void RaiseErrorEvent(SocketException error)
        {
            if (this.mOnError != null)
            {
                this.mOnError(this, error);
            }
        }

        public void Send(byte[] buffer)
        {
            if (buffer.Length <= 0)
                return;
            try
            {
                this.cli.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(this.HandleSendFinished), this.cli);
            }
            catch (ObjectDisposedException)
            {
              //  this.RaiseDisconnectedEvent();
            }
            catch (SocketException exception)
            {
               // this.RaiseErrorEvent(exception);
            }
        }
       
        private void StartWaitingForData(Socket soc)
        {
            if (soc == null)
                return;
            if (this.buffersize <= 0)
                return;
          
          
            try
            {
                soc.BeginReceive(this.databuffer, 0, this.buffersize, SocketFlags.None, new AsyncCallback(this.HandleIncomingData), soc);
            }
            catch
            {
                
            }
        }
    }
}

