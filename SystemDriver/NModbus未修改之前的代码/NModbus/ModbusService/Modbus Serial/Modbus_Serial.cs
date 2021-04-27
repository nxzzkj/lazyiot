
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using ZZSCADA.Model;
using System.Net.Sockets;
using IScadaDriver;
using System.IO.Ports;
using System.Threading;
using Modbus.Device;

namespace Modbus
{
    public class RealData
    {
        public string DEVICEID
        {
            set;get;
        }
        public IO_DEVICE Device = null;
        public string SlaveId
        {
            set;
            get;
        }
 


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
    public enum SerialCheck
    {
        无=1,
        偶校验=2,
        奇校验=3,
        常1=4,
        常0=5



    }
    public class Modbus_Serial_PARA
    {
        /// <summary>
        /// 串口名称
        /// </summary>
        public string SerialPort = "";
        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate = 19200;
        /// <summary>
        /// 校验
        /// </summary>
        public SerialCheck SerialCheck = SerialCheck.无;
        /// <summary>
        /// 数据位
        /// </summary>
        public int DataBits = 8;
        /// <summary>
        /// 停止位
        /// </summary>
        public StopBits StopBits = StopBits.One;
        /// <summary>
        /// STR保持时间
        /// </summary>
        public int RSTSendPreKeeyTime = 15;
        public int RTSSendAfterKeeyTime = 15;
        /// <summary>
        /// 是否连续采集3次失败
        /// </summary>
        public bool ContinueCollect = false;
        public int CollectFaultsNumber = 3;
        /// <summary>
        /// 采集初始化计数
        /// </summary>
        public int Counting = 0;
        /// <summary>
        /// 最大包长
        /// </summary>
        public int PackMaxSize = 64;
        /// <summary>
        /// 偏移间隔
        /// </summary>
        public int OffsetInterval = 10;
        /// <summary>
        /// 支持6号命令
        /// </summary>
        public bool SixCommmand = false;
        /// <summary>
        /// 支持16号命令
        /// </summary>
        public bool SixteenCommmand = false;
        public bool RTSEnable = false;
    }

    /// <summary>
    /// Modbus 串口通讯
    /// </summary>
    public class Modbus_Serial : CommunicateDriver
    {
        private   const string mGuid = "310AA8D3-DBCE-43F8-81A9-DFFD9C5D7D3A";
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

        private string mTitle = " Modbus 串口通讯";
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
                    CommunicationControl = new Modbus_Serial_Ctrl();
                    CommunicationControl.SetUIParameter(communication.IO_COMM_PARASTRING);
                }
                //构造获取数据命令的字节数组,Modbus
                for (int i = 0; i < this.IODevices.Count; i++)
                {

                    RealData mRealData = new RealData();
                    mRealData.Device = this.IODevices[i];
                    DeviceDrive driverDll = DeviceDrives.Find(x => x.DeviceDriverID == this.IODevices[i].DEVICE_DRIVER_ID);
                    if (driverDll != null)
                    {
                        driverDll.InitDrive(IOServer, IOCommunication, this.IODevices[i], null, this.IODevices[i].DriverInfo);
                        //IO_DEVICE_ADDRESS中存储的是DTU编号
                        mRealData.SlaveId = this.IODevices[i].IO_DEVICE_ADDRESS;
                        //数据库中系统编号
                        mRealData.DEVICEID = this.IODevices[i].IO_DEVICE_ID;
                        
                        //获取下发命令的参数
                        mRealData.ReadSendByte = driverDll.GetDataCommandBytes(this.IOServer, this.IOCommunication, this.IODevices[i], this.IODevices[i].IOParas, null);
                    }
                    if (mRealData.ReadSendByte != null && mRealData.ReadSendByte.Count > 0)
                    {
                        RealDevices.Add(mRealData);
                    }

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
       

        #region 串口服务相关
        List<RealData> RealDevices = new List<RealData>();
        private const string NewLine = "\r\n";
        private SerialPort _serialPort;

        Modbus_Serial_PARA Serial_PARA = null;
        private bool Send(IO_DEVICE device, byte[] datas, out string error)
        {
            error = "";
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
               
                    master.WriteMultipleRegisters(device.IO_DEVICE_ADDRESS)
                }
                return true;
            }
            catch
            {
                return false;
            }
        
        }
        IModbusSerialMaster master = null;
        protected override void Start()
        {
            if(master!=null)
            {
                master.Dispose();
            }
            if(_serialPort!=null)
            {
                _serialPort.Close();
                _serialPort.Dispose();
                _serialPort = null;
            }

            try
            {
            
                Serial_PARA = new Modbus_Serial_PARA();
                byte[] array = new byte[8];
                if (_serialPort == null)
                    _serialPort = new SerialPort(Serial_PARA.SerialPort);
                #region
                {
                    _serialPort.BaudRate = Serial_PARA.BaudRate;
                    _serialPort.DataBits = Serial_PARA.DataBits;
                    switch (Serial_PARA.SerialCheck)
                    {
                        case SerialCheck.无:
                            {
                                _serialPort.Parity = Parity.None;
                            }
                            break;
                        case SerialCheck.奇校验:
                            {
                                _serialPort.Parity = Parity.Odd;
                            }
                            break;
                        case SerialCheck.偶校验:
                            {
                                _serialPort.Parity = Parity.Even;
                            }
                            break;
                        case SerialCheck.常0:
                            {
                                _serialPort.Parity = Parity.Space;
                            }
                            break;
                        case SerialCheck.常1:
                            {
                                _serialPort.Parity = Parity.Mark;
                            }
                            break;
                    }

                    _serialPort.StopBits = Serial_PARA.StopBits;
                    _serialPort.ReadTimeout = 1000;
                    _serialPort.WriteTimeout = 1000;
                    _serialPort.RtsEnable = Serial_PARA.RTSEnable;
                    _serialPort.NewLine = NewLine;
                    _serialPort.Open();
                     master = ModbusSerialMaster.CreateRtu(_serialPort);
                    Thread.Sleep(800);
                    //此处采用多线程技术创建一个实时读取数据的任务
                    for (int i = 0; i < this.RealDevices.Count; i++)
                    {
                        RealData mRealData = this.RealDevices[i];
                        //创建一个子任务
                        Task.Run(() =>
                        {
                            while (true && this.ServerIsRun)
                            {
                                if (this.ServerIsSuspend)
                                    continue;
                                if (mRealData.ReadSendByte.Count > 0)
                                {
                                    for (int c = 0; c < mRealData.ReadSendByte.Count; c++)
                                    {
                                        try
                                        {
                                            //发送获取数据的命令
                                            string error = "";
                                            if (!this.Send(mRealData.Device, mRealData.ReadSendByte[c], out error))
                                            {
                                                this.DeviceException("ERROR=Modbus_Serial_10001," + error);
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            this.DeviceException("ERROR=Modbus_Serial_10002," + e.Message);
                                        }
                                    }


                                }
                                //更新周期
                                Thread.Sleep(mRealData.Device.IO_DEVICE_UPDATECYCLE);
                            }
                        });
                    }

                    this.CommunctionStartChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "启动服务");
                    //实时接收数据
                    Task.Run(() => {
                        while (true)
                        {
                            try
                            {
                                //判断串口是否处于打开状态，如果不在打开状态，则重新打开
                                if (!_serialPort.IsOpen)
                                    _serialPort.Open();
                                //读取数据
                                if (_serialPort.BytesToRead > 0)
                                {

                                }
                            }
                            catch (Exception emx)
                            {
                                //处理异常
                                this.DeviceException("ERROR=Modbus_Serial_10006," + emx.Message);
                                //等待10秒
                                Thread.Sleep(10000);
                                //重新初始化
                                if (Serial_PARA.Counting >= Serial_PARA.CollectFaultsNumber)
                                {
                                    Start();
                                    return;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }

                    });
                }
                #endregion

            }
            catch (Exception emx)
            {

            }
        }
        protected override void Close()
        {
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                    _serialPort.Close();
                this.CommunctionCloseChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "关闭串口服务");
            }
            catch (Exception emx)
            {
                this.DeviceException("ERROR=Modbus_Serial_10006," + emx.Message);
                this.CommunctionStopChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "关闭串口服务失败");
            }
        }

        protected override void Pause()
        {
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                    _serialPort.Close();

                this.CommunctionPauseChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "暂停串口服务");
            }
            catch (Exception emx)
            {
                this.DeviceException("ERROR=Modbus_Serial_10005," + emx.Message);
                this.CommunctionStopChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "暂停串口服务失败");
            }
        }
        protected override void Continue()
        {
            try { 
            if (_serialPort != null && !_serialPort.IsOpen)
                _serialPort.Open();
            this.CommunctionContinueChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "继续串口服务");
            }
            catch (Exception emx)
            {
                this.DeviceException("ERROR=Modbus_Serial_10003," + emx.Message);
                this.CommunctionStopChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "继续串口服务失败");
            }
        }
        protected override void Stop()
        {


            try
            {

                if(_serialPort!=null&& _serialPort.IsOpen)
                _serialPort.Close();
                this.CommunctionStopChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "停止串口服务");


            }
            catch (Exception emx)
            {
                this.DeviceException("ERROR=Modbus_Serial_10003," + emx.Message);
                this.CommunctionStopChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "停止串口服务失败");
            }
            
        }
        #endregion


    }
}
