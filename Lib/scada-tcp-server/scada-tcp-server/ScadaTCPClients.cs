using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace scada_tcp_server
{
    public class ScadaTCPClients
    {
        private static IDictionary<string, ScadaClient> clientSockets = new Dictionary<string, ScadaClient>();
        private static IDictionary<string,string> clientIds = new Dictionary<string, string>();

        public static void Add(string sessionId, ScadaClient socket)
        {
            clientSockets.Add(sessionId,socket);
        }

        public static int ClientCount
        {
            get { return clientSockets.Count; }
        }

        public static ScadaClient GetClient(string sessionId)
        {
            if (clientSockets.ContainsKey(sessionId))
            {
                return clientSockets[sessionId];
            }
            return null;
        }

        public static string AssignSessionId()
        {
            return Guid.NewGuid().ToString();
        }

        public static void Close(string sessionId)
        {
            if (clientSockets.ContainsKey(sessionId))
            {
                clientSockets[sessionId].socket.Shutdown(SocketShutdown.Both);
                clientSockets[sessionId].socket.Close();
                clientSockets.Remove(sessionId);
            }
        }

        /// <summary>
        /// 添加客户端ID（可以从Header或者Body是取出来）和SessionID关联
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="sessionId"></param>
        public static void SetClientId(string clientId, string sessionId)
        {
            if (string.IsNullOrEmpty(sessionId) || string.IsNullOrEmpty(clientId))
            {
                return;
            }
            if (clientIds.ContainsKey(clientId))
            {
                if (sessionId.Equals(clientIds[clientId]))
                {
                    return;
                }
                else
                {
                    clientIds.Remove(clientId);
                }
            }
            clientSockets[sessionId].ClientId = clientId;
            clientIds.Add(clientId,sessionId);
        }

        public static ScadaClient GetClientById(string clientId)
        {
            if (string.IsNullOrEmpty(clientId))
            {
                return null;
            }
            if (!clientIds.ContainsKey(clientId))
            {
                return null;
            }
            if (!clientSockets.ContainsKey(clientIds[clientId]))
            {
                return null;
            }
            return clientSockets[clientIds[clientId]];
        }
    }

    public class ScadaClient
    {
        public string SessionId { get; set; }
        public Socket socket { get; set; }
        public string ClientId { get; set; }
    }
}
