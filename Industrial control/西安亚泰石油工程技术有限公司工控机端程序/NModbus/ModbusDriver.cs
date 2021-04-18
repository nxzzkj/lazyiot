using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZSCADA.Model;

namespace NModbus
{
  public  class ModbusDriver: DeviceDriveBase.DeviceDrive
    {
        public override List<byte[]> GetDataCommandBytes(IO_SERVER server, IO_COMMUNICATION Communication, IO_DEVICE device, List<IO_PARA> paras, IO_PARA currentpara)
        {
            return base.GetDataCommandBytes(server, Communication, device, paras, currentpara);
        }
        public override byte[] GetSendValueBytes(IO_SERVER server, IO_COMMUNICATION Communication, IO_DEVICE device, IO_PARA para, string setvalue)
        {
            return base.GetSendValueBytes(server, Communication, device, para, setvalue);
        }
        public override byte[] GetStringBytes(string datastr)
        {
            return base.GetStringBytes(datastr);
        }
        public override void InitDrive(IO_SERVER server, IO_COMMUNICATION Communication, IO_DEVICE device, IO_PARA para, DEVICE_DRIVER driver)
        {
            base.InitDrive(server, Communication, device, para, driver);
        }
    }
}
