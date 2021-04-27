using Scada.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Kernel
{
    /// </summary>
    /// <param name="msg"></param>
    public delegate void DeviceDriveError(string msg);
    /// </summary>
    /// <param name="msg"></param>
    public delegate void CommunicationDriveError(string msg);
    public delegate void ShowFormLog(string msg);
    public delegate void DataReceived(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, byte[] receivedatas, string date, object sender = null);
    public delegate void DriverEvent(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, IO_PARA para, object tag);
    public delegate void CommunicationEvent(IO_SERVER server, IO_COMMUNICATION comm, object tag);
    public delegate void DeviceSendedEvent(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, IO_PARA para, string value, bool result);

}
