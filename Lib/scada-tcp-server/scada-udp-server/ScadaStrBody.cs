using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace scada_udp_server
{
    public class ScadaStrBody:ScadaUDPBody
    {
        public string Content { get; set; }

        public ScadaStrBody(string content) : base()
        {
            Content = content;
        }

        public ScadaStrBody(byte[] bits, IPEndPoint remote)
        {
            base.BodyBytes = bits;
            Remote = remote;
            Content = Encoding.ASCII.GetString(BodyBytes);
        }
    }
}
