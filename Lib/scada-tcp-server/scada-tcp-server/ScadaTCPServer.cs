using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace scada_tcp_server
{
    public class ScadaTCPServer
    {

        private static IDictionary<string,ScadaTCPAsyncServer> servers = new Dictionary<string, ScadaTCPAsyncServer>();
        /// <summary>
        /// 创建Header的委托
        /// </summary>
        /// <returns></returns>
        public delegate ScadaTCPHeader InstanceHeaderNeed();

        /// <summary>
        /// 消息处理的委托
        /// </summary>
        /// <param name="header"></param>
        /// <param name="body"></param>
        public delegate void MainNotifyHandler(ScadaTCPHeader header, ScadaTCPBody body);

        public delegate void SendFinishHandler(SendState state);

        public delegate void ReadErrorHandler(Exception e, ReadState clientState);
        public delegate void SendErrorHandler(Exception e, SendState clientState);
        

        /// <summary>
        /// 创建一个Server
        /// </summary>
        /// <param name="name"></param>
        /// <param name="instanceHeader">实例化Header的方法</param>
        /// <returns></returns>
        public static ScadaTCPAsyncServer CreateServer(string name, InstanceHeaderNeed instanceHeader)
        {
            if (servers.ContainsKey(name))
            {
                throw new Exception("TCP Server :" + name + " is exists!");
            }
            ScadaTCPAsyncServer asyncServer = new ScadaTCPAsyncServer();
            asyncServer.Name = name;
            servers.Add(name,asyncServer);
            asyncServer.InstanceHeader = instanceHeader;
            return asyncServer;
        }

        public static ScadaTCPAsyncServer GetServer(string name)
        {
            if (servers.ContainsKey(name))
            {
                return servers[name];
            }
            return null;
        }
        
    }
}
