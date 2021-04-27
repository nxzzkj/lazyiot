using CM_DTUCommunication;
using CommunicationBase;
using DeviceDriveBase;
using ZZSCADA.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZZSCADA.DBUtility;

namespace CM_DTUCommunication
{
    public class RealData
    {
        public string DTUID
        {
            set;
            get;
        }
        /// <summary>
        /// 当前设备
        /// </summary>
        public IO_DEVICE Device = null;


        public List<byte[]> ReadSendByte
        {

            set;
            get;
        }
        
         
        public Task Task
        {
            set;
            get;
        }
        
        public int StartAddress = 0;//当前数据的开始地址
        public int Addresslength = 100;//当前数据的结束地址
    }
    public  class CM_DTU: CommunicateDriver
    {
 
        #region 自定义属性和方法
     
  
        /// <summary>
        /// 
        /// </summary>
        List<RealData> RealDevices = new List<RealData>();
        /// <summary>
        /// 已经在线的DTU数量
        /// </summary>
        public int OnLineCount
        {
            get
            {
                if (svr != null)
                    return svr.Count;
                else
                    return 0;


            }

        }

        public Mode Mode
        {
            set { mode = value; }
            get { return mode; }
        }
        private Mode mode = Mode.全透明模式;
        /// <summary>
        /// DTU服务
        /// </summary>
        private Server svr;
        #endregion
        #region 接口方法实现
        public override bool InitDriver(IO_SERVER server, IO_COMMUNICATION communication, List<IO_DEVICE> ioDevices, COMM_DRIVER driver)
        {
            if (!base.InitDriver(server, communication, ioDevices, driver))
            {
                return false;
            }
            try
            {

                ///初始化驱动控件
                if (IsCreateControl)//主要是为了节省内存，在该用的地方创建
                {
                    this.CommunicationControl = new CMDTUControl();

                }
               
                //构造获取数据命令的字节数组
                for (int i = 0; i < this.IODevices.Count; i++)
                {

                    RealData mRealData = new RealData();
                    mRealData.Device = this.IODevices[i];
                    DeviceDrive driverDll = DeviceDrives.Find(x => x.DeviceDriverID == this.IODevices[i].DEVICE_DRIVER_ID);
                    if (driverDll != null)
                    {

                        driverDll.InitDrive(IOServer, IOCommunication, this.IODevices[i], null, this.IODevices[i].DriverInfo);
                        //IO_DEVICE_ADDRESS中存储的是DTU编号
                        mRealData.DTUID = this.IODevices[i].IO_DEVICE_ADDRESS;
                        //获取下发命令的参数
                        mRealData.ReadSendByte = driverDll.GetDataCommandBytes(this.IOServer, this.IOCommunication, this.IODevices[i], this.IODevices[i].IOParas, null);
                    }
                    if (mRealData.ReadSendByte!=null&&mRealData.ReadSendByte.Count > 0)
                    {
                        RealDevices.Add(mRealData);
                    }

                }
            }
            catch (Exception ex)
            {
                this.DeviceException("ERROR=10023," + ex.Message);
                return false;
            }
            return true;

          


        }
        protected override void Pause()
        {
        
            this.CommunctionContinueChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "暂停服务");
        }
        protected override void Continue()
        {
          
            this.CommunctionContinueChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "继续服务");
        }
        protected override void Stop()
        {

         
            try
            {
                for (int i = 0; i < RealDevices.Count; i++)
                {
                    if (RealDevices[i].Task != null)
                    {
                        RealDevices[i].Task.Dispose();
                        RealDevices[i].Task = null;
                    }
                }


                svr.Stop();

                svr.ReceiveData -= new Server.ZYBEvent(Svr_ReceiveData);//接手数据
                svr.ClientConnect -= new Server.ZYBEvent(Svr_ClientConnect);//DTU上线
                svr.ClientClose -= new Server.ZYBEvent(Svr_ClientClose);//DTU下线
                this.CommunctionStopChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "停止服务");


            }
            catch (Exception emx)
            {
                this.DeviceException("ERROR=10022," + emx.Message);
                this.CommunctionStopChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "停止服务失败");
            }
            finally
            {



            }

        }
        /// <summary>
        /// 启动通道
        /// </summary>
        protected override void Start()
        {
            try
            {
                int Port = 8888;
                int Timeout = 120;
                string parastring = this.CommunicationControl.ParameterString;
                char[] split = new char[2] { ':', ',' };
                string[] strs = parastring.Split(split);
                if (strs.Length != 8)
                {
                    this.DeviceException("ERROR=10001, DTU 驱动参数不正确");
                    return;
                }
                int.TryParse(strs[1], out Port);
                //初始化DTU服务
                svr = new Server(Port, Timeout, mode);
                //数据接收事件
                svr.ReceiveData += Svr_ReceiveData;
                //DTU连接事件
                svr.ClientConnect += Svr_ClientConnect;
                //DTU退出连接后的事件
                svr.ClientClose += Svr_ClientClose;
               

                svr.Start();
                //此处采用多线程技术
                for (int i = 0; i < this.RealDevices.Count; i++)
                {
                    RealData mRealData = this.RealDevices[i];
                    
                        //创建一个子任务
                        Task.Run(() =>
                        {
                            while (true&& this.ServerIsRun)
                            {
                                if (this.ServerIsSuspend)
                                    continue;
                                if (mRealData.ReadSendByte.Count > 0 && svr.Count > 0)
                                {
                                    for(int c=0;c< mRealData.ReadSendByte.Count;c++)
                                    {
                                        try
                                        {
                                            //发送获取数据的命令
                                            string error = "";
                                            if (!svr.Send(mRealData.DTUID, mRealData.ReadSendByte[c], out error, true))
                                            {
                                                this.DeviceException("ERROR=10004," + error);
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            this.DeviceException("ERROR=10002," + e.Message);
                                        }
                                    }
                                    

                                }
                                //更新周期
                                Thread.Sleep(mRealData.Device.IO_DEVICE_UPDATECYCLE);
                            }
                        });
                 
                   
                   
                }
             
                this.CommunctionStartChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "启动服务");
            }
            catch (Exception emx)
            {
                this.DeviceException("ERROR=10003," + emx.Message);
                this.CommunctionStartChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "启动服务失败");

            }
            finally
            {


            }

        }
        //用户发送下置命令
        public override bool SendCommand(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device, IO_PARA para, string value)
        {
       
            try
            {
       
                Dtu_Data data = new Dtu_Data();
                data.DeviceID = device.IO_DEVICE_ID;
                //获取value 的字节数组
                DeviceDrive driver = DeviceDrives.Find(x => x.DeviceDriverID == device.DEVICE_DRIVER_ID);
                if(driver!=null)
                {
                    data.datas =driver.GetSendValueBytes( server,this.IOCommunication, device, para,value);
                    this.DeviceException("error=10011,"+ device.IO_DEVICE_ADDRESS + "设备驱动不存在");
                }
                
                data.ParaID = para.IO_ID;

                data.DtuID = device.IO_DEVICE_ADDRESS;
                data.DataStatus = DataStatus.WriterData;

                string error = "";
                bool result = false;
                Thread.Sleep(100);//停止10秒，保证之前发送命令已经发送出去
                if (!svr.Send(data.DtuID, data.datas, out error, false))
                {
                    this.DeviceException("error=10010" + error);
                    result = false;

                }
                else
                {
                    result = true;
                }

                //信息发送完成的事件
                DataSended(server,this.IOCommunication, device, para,value, result);


                return true;
                ///接收的数据
            }
            catch (Exception emx)
            {

                
                return false;

            }
            finally
            {
             
            }

        }
        /// <summary>
        /// 设备断线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Svr_ClientClose(object sender, ZYBEventArgs e)
        {
            if (e == null)
                return;
            if (sender == null)
                return;
            if (e.DTU == null)
                return;
            lock (sender)
            {
                try
                {
                    ///接收的数据
                    Dtu_Data data = new Dtu_Data();
                    data.IP = e.DTU.IP;
                    data.ID = e.DTU.ID;
                    data.IsOnline = e.DTU.IsOnline;
                    data.LoginTime = e.DTU.LoginTime;
                    data.RefreshTime = e.DTU.RefreshTime;
                    data.PhoneNumber = e.DTU.PhoneNumber;
                    data.datas = e.DTU.DataByte;
                    data.DtuID = e.DTU.DtuID;
                    data.Msg = e.Msg;
                    IO_DEVICE currentDevice = this.IODevices.Find(x => x.IO_DEVICE_ADDRESS == data.ID);
                    if (currentDevice != null)
                    {
                        this.DownLine(this.IOServer,this.IOCommunication, currentDevice, null, data.ID);
                    }
                   
                 
                    
                }
                catch (Exception emx)
                {
                    this.DeviceException(("error=10008" + emx.Message));

                }

            }

          
        }

        private void Svr_ClientConnect(object sender, ZYBEventArgs e)
        {
            if (e == null)
                return;
            if (sender == null)
                return;
            if (e.DTU == null)
                return;
            lock (sender)
            {
                try
                {
                    ///接收的数据
                    Dtu_Data data = new Dtu_Data();
                    data.IP = e.DTU.IP;
                    data.ID = e.DTU.ID;
                    data.IsOnline = e.DTU.IsOnline;
                    data.LoginTime = e.DTU.LoginTime;
                    data.RefreshTime = e.DTU.RefreshTime;
                    data.PhoneNumber = e.DTU.PhoneNumber;
                    data.datas = e.DTU.DataByte;
                    data.DtuID = e.DTU.DtuID;
                    data.Msg = e.Msg;
                    IO_DEVICE currentDevice = this.IODevices.Find(x => x.IO_DEVICE_ADDRESS == data.ID);
                    if (currentDevice != null)
                    {
                        //设备上线
                        this.OnLine(base.IOServer,this.IOCommunication, currentDevice, null, data.ID);
                    }

                  

                }
                catch (Exception emx)
                {
                    this.DeviceException(("error=10008" + emx.Message));

                }

            }
        }
        private string GetID(byte[] by)
        {
            string str = "";
            for (int i = 3; i >= 0; i--)
            {
                str = str + Convert.ToString(by[i], 0x10).PadLeft(2, '0');
            }
            return str;
        }
        private void Svr_ReceiveData(object sender, ZYBEventArgs e)
        {
            if (e == null)
                return;
            if (sender == null)
                return;
            if (e.DTU == null)
                return;
            lock (sender)
            {

                if (e.DTU != null)
                {
                    try
                    {
                        //注意此处传过来的ID是16位字符串
                        string id = e.DTU.ID;
                        //  接收的数据
                        Dtu_Data data = new Dtu_Data();
                        data.IP = e.DTU.IP;
                        data.ID = e.DTU.ID;
                        IO_DEVICE currentDevice = this.IODevices.Find(x=>x.IO_DEVICE_ADDRESS== data.ID);
                        if (currentDevice == null)
                            return;
                        if (e.DTU.DtuID != "")
                        {

                            data.DtuID = e.DTU.DtuID;
                        }
                        else
                        {
                            data.DtuID = svr.InneridToId(int.Parse(e.DTU.ID));
                        }
                        data.IsOnline = e.DTU.IsOnline;
                        if (e.DTU.LoginTime != null)
                            data.LoginTime = e.DTU.LoginTime;
                        if (e.DTU.RefreshTime != null)
                            data.RefreshTime = e.DTU.RefreshTime;
                        data.PhoneNumber = e.DTU.PhoneNumber;

                        data.datas = e.DTU.DataByte;
                        data.Msg = e.Msg;
                        //针对接收的数据做两种状态，读命令的应答和写命令的应答

                        if (data.datas.Length == 1)//判断是不是心跳包
                        {
                            if (CVT.ByteToHexStr(data.datas) == "fe")
                            {
                                this.DeviceStatus(this.IOServer,this.IOCommunication, currentDevice, null, "fe");
                            }
                        }

                        else if (data.datas.Length >= 5 && data.datas.Length != 21)//判断是不是数据包
                        {

                            byte SlaveID = data.datas[0];//设备号
                            byte Code = data.datas[1];//设备号

                            if (Code == 0x03 || Code == 0x04 || Code == 0x01 || Code == 0x02)//用户读取的数据
                            {
                                data.DataStatus = DataStatus.ReadData;
                                //将接收的数据转换成字符串并发送
                                this.ReceiveData(this.IOServer,this.IOCommunication,currentDevice, data.datas,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            
                            }
                            else if (Code > 0x80)//出现的错误信息
                            {
                                data.DataStatus = DataStatus.ReadData;
                                //执行操作
                            }
                            else if (Code == 0x06 || Code == 0x10)//表示用户写入的数据和
                            {
                                data.DataStatus = DataStatus.WriterData;
                                //执行操作
                            }
                        }


                       
                    }
                    catch (Exception emx)
                    {
                        this.DeviceException(("error =10006," + emx.Message));

                    }
                }


            }
        }

        //系统控件
        public override CommunicationControl CommunicationControl
        {
            get
            {
                return base.CommunicationControl;
            }

            set
            {
                base.CommunicationControl = value;
            }
        }

        #endregion

    
    }
}
