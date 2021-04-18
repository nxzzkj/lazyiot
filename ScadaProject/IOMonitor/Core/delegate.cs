using Scada.AsyncNetTcp.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scada.Model;

namespace IOMonitor.Core
{
    public enum TaskOperator
    {
        运行,
        暂停,
        停止,
        关闭

    }

    public delegate void MonitorException(Exception ex);
    public delegate void MonitorLog(string log);
    public delegate void MonitorOperator(TaskOperator Operator);
    /// <summary>
    /// 实时接收数据的事件
    /// </summary>
    /// <param name="server"></param>
    /// <param name="comm"></param>
    /// <param name="device"></param>
    public delegate void MonitorReceive(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, byte[] sourceBytes);
    /// <summary>
    /// 生成报警的事件
    /// </summary>
    /// <param name="server"></param>
    /// <param name="comm"></param>
    /// <param name="device"></param>
    /// <param name="arlarm"></param>
    public delegate void MonitorMakeAlarm(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, IO_PARAALARM arlarm);
    public delegate void MonitorSenCommand(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, IO_PARAALARM arlarm);
    ////TCPClient 事件
    public delegate void TcpClientEventHandle(AsyncTcpClient client, object sender, string msg);
 


}
