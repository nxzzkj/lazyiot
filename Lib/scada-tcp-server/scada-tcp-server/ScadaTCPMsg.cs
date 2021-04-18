using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scada_tcp_server
{
    public class ScadaTCPMsg
    {
        private ScadaTCPHeader header;
        private ScadaTCPBody body;

        public ScadaTCPHeader Header
        {
            get { return header; }
            set { header = value; }
        }

        public ScadaTCPBody Body
        {
            get { return body; }
            set { body = value; }
        }

        private byte[] headerBytes;
        private byte[] bodyBytes;

        public ScadaTCPMsg(ScadaTCPHeader header, ScadaTCPBody body)
        {
            this.header = header;
            this.body = body;
            this.body.Encode();
            bodyBytes = this.body.GetBytes();
            header.bodyLength = bodyBytes.Length;
            this.header.Encode();
            headerBytes = this.header.GetBytes();
            MsgBytes = new byte[headerBytes.Length+bodyBytes.Length];
            headerBytes.CopyTo(MsgBytes,0);
            bodyBytes.CopyTo(MsgBytes,headerBytes.Length);
        }
        

        public byte[] MsgBytes { get; }

        public bool CloseClient { get; set; }
    }
}
