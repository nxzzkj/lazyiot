using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scada_udp_server
{
    public class ScadaUDPServer
    {
        /// <summary>
        /// 接收消息委托
        /// </summary>
        /// <param name="body"></param>
        public delegate void EventHandler(ScadaUDPAsyncServer server, ScadaUDPEventArgs args);


        private static IDictionary<string, ScadaUDPAsyncServer> servers = new Dictionary<string, ScadaUDPAsyncServer>();
        private static IDictionary<string, ScadaUDPSyncServer> syncServers = new Dictionary<string, ScadaUDPSyncServer>();

        public static ScadaUDPAsyncServer CreateUDPServer(string name,int port)
        {
            if (servers.ContainsKey(name))
            {
                throw new Exception("UDP Server :"+name+" is exists!");
            }
            ScadaUDPAsyncServer server = new ScadaUDPAsyncServer(port);
            server.Name = name;
            servers.Add(name,server);
            return server;
        }

        public static void Delete(string name)
        {
            if (servers.ContainsKey(name))
            {
                servers.Remove(name);
            }
            if (syncServers.ContainsKey(name))
            {
                syncServers.Remove(name);
            }
        }

        public static ScadaUDPAsyncServer GetServer(string name)
        {
            if (servers.ContainsKey(name))
            {
                return servers[name];
            }
            return null;
        }

        public static ScadaUDPSyncServer CreateUDPSyncServer(string name, int port)
        {
            if (servers.ContainsKey(name))
            {
                throw new Exception("UDP Server :" + name + " is exists!");
            }
            ScadaUDPSyncServer server = new ScadaUDPSyncServer(port);
            server.Name = name;
            syncServers.Add(name, server);
            return server;
        }

        public static ScadaUDPSyncServer GetSyncServer(string name)
        {
            if (syncServers.ContainsKey(name))
            {
                return syncServers[name];
            }
            return null;
        }
    }

    public enum UDPServerType
    {
        ASCII,BYTE,
    }
}
