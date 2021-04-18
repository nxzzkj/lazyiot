using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scada_udp_server
{
    public class ScadaUDPMsg
    {

        public ScadaUDPBody MsgBody { get;private set;}
        public byte[] MsgBytes { get; private set; }

        public ScadaUDPMsg(byte[] bodyBytes)
        {
            this.MsgBytes = bodyBytes;
        }

        public ScadaUDPMsg(ScadaUDPBody msgBody)
        {
            MsgBody = msgBody;
        }
    }
}
