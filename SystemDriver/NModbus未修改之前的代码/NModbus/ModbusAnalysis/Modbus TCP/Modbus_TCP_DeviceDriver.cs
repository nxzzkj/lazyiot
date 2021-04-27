using IScadaDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZSCADA.Model;
using IO_Structure;
using System.ComponentModel;

namespace Modbus
{
 
    public class Modbus_TCP_DeviceDriver : DeviceDrive
    {
        private const string mGuid = "7D22423C-BC96-4771-AE32-7C00FD35B70E";
        /// <summary>
        /// 驱动唯一标识，采用系统GUID分配
        /// </summary>
        public override string GUID
        {
            get
            {
                return mGuid;
            }


        }
        private string mTitle = " Modbus TCP 协议";
        public override string Title
        {
            get
            {
                return mTitle;
            }

            set
            {
                mTitle = value;
            }
        }
        protected override IOData Analysis(IO_SERVER server, IO_COMMUNICATION Communication, IO_DEVICE device, IO_PARA para, byte[] datas, DateTime datatime)
        {
            return base.Analysis(server, Communication, device, para, datas, datatime);
        }
        public override bool InitDrive(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device, IO_PARA para, SCADA_DEVICE_DRIVER driver)
        {
            bool res = base.InitDrive(server, communication, device, para, driver);
            if (res)
            {
                if (IsCreateControl)
                {
                    if (para != null)
                        this.ParaCtrl = new TCP_IOParaCtrl();
                    this.DeviceCtrl = new TCP_IODeviceCtrl();

                }
            }
            return res;
        }
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
    }
}
