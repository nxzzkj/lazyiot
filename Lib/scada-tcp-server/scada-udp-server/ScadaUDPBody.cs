using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace scada_udp_server
{
    public class ScadaUDPBody
    {
        public byte[] BodyBytes { get; set; }
        public string IpAddr => Remote.Address.ToString();

        public int Port => Remote.Port;

        public IPEndPoint Remote { get; set; }

        public ScadaUDPBody(byte[] bodyBytes)
        {
            BodyBytes = bodyBytes;
        }

        public ScadaUDPBody(byte[] bodyBytes, IPEndPoint remote)
        {
            BodyBytes = bodyBytes;
            Remote = remote;
        }


        public ScadaUDPBody()
        {
        }
    }
}
