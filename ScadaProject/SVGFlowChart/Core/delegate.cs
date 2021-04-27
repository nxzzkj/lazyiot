using Scada.AsyncNetTcp.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaFlowDesign.Core
{

    public delegate void FlowDesignException(Exception ex);
    public delegate void FlowDesignLogger(string log);
    public delegate void TcpClientEventHandle(AsyncTcpClient client, object sender, string msg, string ProjectID);
    public delegate void ExceptionHanped(Exception ex);
    public delegate void TCPClientLoged(string msg);

}
