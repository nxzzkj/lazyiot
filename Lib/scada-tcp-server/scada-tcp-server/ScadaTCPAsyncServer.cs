using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace scada_tcp_server
{
    public class ReadState
    {
        public string sessionId { get; set; }
        // Client  socket.
        public Socket workSocket = null;
        public ScadaTCPHeader header { get; set; }
        // Size of receive buffer.
        // Receive buffer.
        public byte[] HeaderBytes { get; set; }
        public byte[] BodyBytes { get; set; }
    }

    public class SendState
    {
        public Socket RemoteSocket { get; set; }
        public ScadaTCPMsg Msg { get; set; }

        public byte[] MsgBits { get; set; }

        public ScadaClient Client { get; set; }

        public bool CloseClient { get; set; }
    }

    public class ScadaTCPAsyncServer
    {
        private static ScadaLogManager LOG = ScadaLogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        

        public ScadaTCPServer.InstanceHeaderNeed InstanceHeader;
        public event ScadaTCPServer.MainNotifyHandler MainNotify;
        public event ScadaTCPServer.ReadErrorHandler ReadSocketError;
        public event ScadaTCPServer.SendErrorHandler SendSocketError;
        public event ScadaTCPServer.SendFinishHandler SendFinish;
        /// <summary>
        /// 获取和设置Header的长度
        /// </summary>
        public int HeaderLength { get; set; }
        public string Name { get; set; }

        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public bool PrintReceiveHex = false;
        public bool PrintSendHex = false;
        public bool Started = true;
        private Socket _socket;

        public void Start(int port)
        {
            //创建套接字  
            IPEndPoint ipe = new IPEndPoint(IPAddress.Any, port);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //绑定端口和IP  
            _socket.Bind(ipe);
            //设置监听  
            _socket.Listen(10);
            LOG.InfoFormat("({1}) Server start on port:{0}", port,Name);
            LOG.InfoFormat("Waiting for a connection");
            //连接客户端  
            while (Started)
            {
                // Set the event to nonsignaled state.
                allDone.Reset();

                // Start an asynchronous socket to listen for connections.
                _socket.BeginAccept(
                    new AsyncCallback(AcceptCallback),
                    _socket);

                // Wait until a connection is made before continuing.
                allDone.WaitOne();
            }
        }

        public void Stop()
        {
            Started = false;
            _socket.Close();
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            // Create the state object.
            ReadState readState = new ReadState();
            try
            {
                // Signal the main thread to continue.
                allDone.Set();

                // Get the socket that handles the client request.
                Socket listener = (Socket) ar.AsyncState;
                Socket handler = listener.EndAccept(ar);

                string sessionId = ScadaTCPClients.AssignSessionId();
                LOG.InfoFormat("({2}) New client:{0},sessionId:{1}", handler.RemoteEndPoint, sessionId,Name);

                ScadaClient client = new ScadaClient();
                client.socket = handler;
                client.SessionId = sessionId;
                ScadaTCPClients.Add(client.SessionId, client);
                LOG.InfoFormat("({1}) Clients count:{0}",ScadaTCPClients.ClientCount,Name);

                readState.workSocket = handler;
                readState.sessionId = client.SessionId;

                readState.HeaderBytes = new byte[HeaderLength];
                handler.BeginReceive(readState.HeaderBytes, 0, HeaderLength, SocketFlags.None, new AsyncCallback(ReadHeadCallback), readState);
            }
            catch (Exception e)
            {
                ReadException(e,readState);
            }
        }

        public void ReadHeadCallback(IAsyncResult ar)
        {
            ReadState readState = (ReadState)ar.AsyncState;
            try
            {
                Socket handler = readState.workSocket;
                if (!handler.Connected)
                {
                    LOG.InfoFormat("({0}) Connection closed!",Name);
                    return;
                }
                int bytesRead = handler.EndReceive(ar);
                if (bytesRead > 0)
                {
                    ScadaTCPHeader header = InstanceHeader?.Invoke();
                    if (header == null)
                    {
                        LOG.ErrorFormat("({0}) Not found instance ScadaHeader class",Name);
                        return;
                    }
                    header.bytes = readState.HeaderBytes;
                    header.RemoteSocket = handler;
                    header.Decode();
                    header.SessionId = readState.sessionId;
                    readState.header = header;
                    header.Debug();
                    header.Info();
                    LOG.InfoFormat("({2}) Read header from:{0},body len:{1}", handler.RemoteEndPoint, header.bodyLength, Name);
                    if (PrintReceiveHex)
                    {
                        PrintUtils.PrintHex(header.bytes);
                    }
                    
                    if (header.bodyLength > 0)
                    {
                        readState.BodyBytes = new byte[header.bodyLength];
                        handler.BeginReceive(readState.BodyBytes, 0, header.bodyLength, SocketFlags.None, new AsyncCallback(ReadCallback), readState);
                    }
                    else
                    {
                        MainNotify?.Invoke(header, null);
                        ResetState(handler, header);
                    }
                }
            }
            catch (Exception e)
            {
                ReadException(e,readState);
            }
        }

        public void ReadCallback(IAsyncResult ar)
        {
            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            ReadState readState = (ReadState)ar.AsyncState;
            try
            {
                Socket handler = readState.workSocket;

                // Read data from the client socket. 
                int bytesRead = handler.EndReceive(ar);
                ScadaTCPHeader header = readState.header;

                if (bytesRead > 0)
                {
                
                
                    if (PrintReceiveHex)
                    {
                        PrintUtils.PrintHex(readState.BodyBytes);
                    }

                    ScadaTCPBody body = header.InstanceBody();
                    body.BodyBytes = readState.BodyBytes;
                    body.Decode();
                    body.Debug();
                    body.Info();

                    MainNotify?.Invoke(header, body);
                    ScadaTCPMsg sendMsg = body.GetSendMsg();
                    if (sendMsg != null)
                    {
                        Send(header.SessionId, sendMsg, sendMsg.CloseClient);
                    }

                    ResetState(handler, header);
                }
            }
            catch (Exception e)
            {
                ReadException(e,readState);
            }
        }

        private void ResetState(Socket handler, ScadaTCPHeader header)
        {
//将客户端状态重置为接收状态
            ReadState readStateNew = new ReadState();
            readStateNew.workSocket = handler;
            readStateNew.sessionId = header.SessionId;
            readStateNew.HeaderBytes = new byte[HeaderLength];
            handler.BeginReceive(readStateNew.HeaderBytes, 0, HeaderLength, SocketFlags.None, new AsyncCallback(ReadHeadCallback), readStateNew);
        }

        public void Send(string sessionId,string msg,bool closeClient)
        {
            if (string.IsNullOrEmpty(sessionId))
            {
                throw new Exception("Session id is null!");
            }
            ScadaClient client = ScadaTCPClients.GetClient(sessionId);
            if (client == null)
            {
                throw new Exception("Not found client by session:" + sessionId);
            }
            LOG.DebugFormat("({2}) Send {0} bytes to {1}", msg.Length, client.socket.RemoteEndPoint, Name);
            if (PrintSendHex)
            {
                PrintUtils.PrintHex(msg);
            }
            SendState state = new SendState();
            state.CloseClient = closeClient;
            state.RemoteSocket = client.socket;
            state.Client = client;
            state.MsgBits = Encoding.ASCII.GetBytes(msg);
            // Begin sending the data to the remote device.
            client.socket.BeginSend(state.MsgBits, 0, state.MsgBits.Length, 0,
                new AsyncCallback(SendCallback), state);
        }

        public void Send(string sessionId, ScadaTCPMsg msg,bool closeClient)
        {

            try
            {
                // Convert the string data to byte data using ASCII encoding.
                //            byte[] byteData = Encoding.ASCII.GetBytes(data);
                if (string.IsNullOrEmpty(sessionId))
                {
                    throw new Exception("Session id is null!");
                }
                ScadaClient client = ScadaTCPClients.GetClient(sessionId);
                if (client == null)
                {
                    throw new Exception("Not found client by session:"+ sessionId);
                }
                LOG.DebugFormat("({2}) Send {0} bytes to {1}", msg.MsgBytes.Length, client.socket.RemoteEndPoint,Name);
                if (PrintSendHex)
                {
                    PrintUtils.PrintHex(msg.MsgBytes);
                }
                SendState state = new SendState();
                state.CloseClient = closeClient;
                state.RemoteSocket = client.socket;
                state.Client = client;
                state.Msg = msg;
                // Begin sending the data to the remote device.
                client.socket.BeginSend(msg.MsgBytes, 0, msg.MsgBytes.Length, 0,
                    new AsyncCallback(SendCallback), state);
            }
            catch (Exception e)
            {
                ReadException(e,null);
            }
        }


        private void SendCallback(IAsyncResult ar)
        {
            // Retrieve the socket from the state object.
            SendState handler = (SendState)ar.AsyncState;
            try
            {
                Socket socket = handler.RemoteSocket;
                // Complete sending the data to the remote device.
                int bytesSent = socket.EndSend(ar);
                LOG.DebugFormat("({2}) Sent {0} bytes to {1} finish!", bytesSent, socket.RemoteEndPoint,Name);
                SendFinish?.Invoke(handler);
                if (handler.CloseClient)
                {
                    ScadaTCPClients.Close(handler.Client.SessionId);
                    LOG.InfoFormat("({1}) Client :{0} closed!", handler.Client.SessionId,Name);
                }
            }
            catch (Exception e)
            {
                WriteException(e, handler);
            }
        }

        private void ReadException(Exception e, ReadState state)
        {
            LOG.Error("ScadaServer read error",e);
            ReadSocketError?.Invoke(e,state);
        }

        private void WriteException(Exception e, SendState state)
        {
            LOG.Error("ScadaServer write error", e);
            SendSocketError?.Invoke(e, state);
        }
    }
}
