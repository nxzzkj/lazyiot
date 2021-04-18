
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using ZZSCADA.Model;
using System.Net.Sockets;
using IScadaDriver;

namespace Modbus
{



    /// <summary>
    /// Modbus TCP 通讯
    /// </summary>
    public class Modbus_TCP : CommunicateDriver
    {
        private const string mGuid = "11880EA3-AC18-4A3B-B0F6-713C34B1CAFB";
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
        private string mTitle = " Modbus TCP 通讯";
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


        public override string GetDeviceAddress(byte[] datas, EndPoint remotePoint, object tag)
        {
            return base.GetDeviceAddress(datas, remotePoint, tag);
        }
        public override bool InitDriver(IO_SERVER server, IO_COMMUNICATION communication, List<IO_DEVICE> ioDevices, SCADA_DRIVER driver)
        {
            try
            {


                base.InitDriver(server, communication, ioDevices, driver);
                if (IsCreateControl)
                {
                    CommunicationControl = new Modbus_TCP_Ctrl();
                }
            }
            catch
            {
                return false;
            }
            return true;

           
        }
        public override bool SendCommand(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, IO_PARA para, string value)
        {
            return base.SendCommand(server, comm, device, para, value);
        }

        protected override void Start()
        {
     
        }
        protected override void Close()
        { 
        }
        protected override void Continue()
        {
           
        }
        protected override void Pause()
        {
         
        }
        protected override void Stop()
        {
 
        }
    }
}
