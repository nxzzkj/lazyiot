
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Scada.Model;
using System.Net.Sockets;
using Scada.Kernel;
using Modbus.Device;
using Modbus.Globel;
using System.Threading;
using Modbus.Data;

namespace Modbus.ModbusService
{

    public class Modbus_TCP_PARA
    {
       
        /// <summary>
        /// 模拟端口
        /// </summary>
        public string SimulatorTCP_Port = "";
        /// <summary>
        /// 模拟IP
        /// </summary>
        public string SimulatorTCP_IP = "";

        /// <summary>
        /// 本地端口
        /// </summary>
        public string LocalTCP_Port = "";
        /// <summary>
        /// 本地IP
        /// </summary>
        public string LocalTCP_IP = "";
 
        /// <summary>
        /// 是否连续采集3次失败
        /// </summary>
        public bool ContinueCollect = false;
        public int CollectFaultsNumber = 3;
        public int CollectFaultsInternal = 15;
        public int ReadTimeout = 1000;
        public int WriteTimeout = 1000;
        public int ReadBufferSize = 2048;
        public int WriteBufferSize = 2048;
    }

    /// <summary>
    /// Modbus TCP 通讯
    /// </summary>
    public class Modbus_TCP : ScadaCommunicateKernel
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
        ModbusIpMaster master = null;
        List<RealData> RealDevices = new List<RealData>();
        ParaPack TcpParaPack = null;
        Modbus_TCP_PARA Tcp_PARA = null;
        TcpClient tcpClient = null;
        protected override bool InitCommunicateKernel(IO_SERVER server, IO_COMMUNICATION communication, List<IO_DEVICE> ioDevices, SCADA_DRIVER driver)
        {
           
                if (IsCreateControl)
                {
                    CommunicationControl = new Modbus_TCP_Ctrl();
                    if (communication != null)
                        CommunicationControl.SetUIParameter(communication.IO_COMM_PARASTRING);
                }
                Tcp_PARA = new Modbus_TCP_PARA();
                if (communication != null)
                {


                    TcpParaPack = new ParaPack(communication.IO_COMM_PARASTRING);
                    Tcp_PARA.CollectFaultsInternal = Convert.ToInt32(TcpParaPack.GetValue("重试间隔"));
                    Tcp_PARA.CollectFaultsNumber = Convert.ToInt32(TcpParaPack.GetValue("重试次数"));
                    Tcp_PARA.ContinueCollect = TcpParaPack.GetValue("重试") == "1" ? true : false;
                    Tcp_PARA.LocalTCP_Port = TcpParaPack.GetValue("本地端口");
                    Tcp_PARA.LocalTCP_IP = TcpParaPack.GetValue("本地IP");
                    Tcp_PARA.SimulatorTCP_Port = TcpParaPack.GetValue("模拟设备端口");
                    Tcp_PARA.SimulatorTCP_IP = TcpParaPack.GetValue("模拟设备IP");
                    Tcp_PARA.WriteTimeout = int.Parse(TcpParaPack.GetValue("写超时时间"));
                    Tcp_PARA.ReadTimeout = int.Parse(TcpParaPack.GetValue("读超时时间"));
                    Tcp_PARA.WriteBufferSize = int.Parse(TcpParaPack.GetValue("写缓存"));
                    Tcp_PARA.ReadBufferSize = int.Parse(TcpParaPack.GetValue("读缓存"));

                    //构造获取数据命令的字节数组,Modbus
                    for (int i = 0; i < this.IODevices.Count; i++)
                    {
                        object fragment = new ModbusFragmentStore();
                        RealData mRealData = new RealData();
                        mRealData.Device = this.IODevices[i];
                    ScadaDeviceKernel driverDll = DeviceDrives.Find(x => x.DeviceDriverID == this.IODevices[i].DEVICE_DRIVER_ID);
                        if (driverDll != null)
                        {
                            driverDll.InitKernel(IOServer, IOCommunication, this.IODevices[i], null, this.IODevices[i].DriverInfo);
                            //IO_DEVICE_ADDRESS中存储的是DTU编号
                            mRealData.SlaveId = this.IODevices[i].IO_DEVICE_ADDRESS;
                            //数据库中系统编号
                            mRealData.DEVICEID = this.IODevices[i].IO_DEVICE_ID;
                            ////获取下发命令的参数,注意此次要进心分段存储，因为modbus一次不能超过123个寄存器地址
                            //mRealData.ReadSendByte = driverDll.GetDataCommandBytes(this.IOServer, this.IOCommunication, this.IODevices[i], this.IODevices[i].IOParas, null, ref fragment);
                        }
                        mRealData.Fragment = (ModbusFragmentStore)fragment;
                        RealDevices.Add(mRealData);


                    }
                }
           
            return true;


        }
        private bool RequestData(IO_DEVICE device, RealData realData, out string error, ModbusFragmentStore fragmentstore)
        {
            error = "";
            try
            {
                if (tcpClient != null && tcpClient.Connected)
                {
                    //分段读取数据，如果是读取整个寄存器的话，一次只能最多读取123个，
                    //如果是读取线圈的话最大只能读取1999个，因此要分段进行数据的读取
                    List<byte> allbytes = new List<byte>();
                    try
                    {
                        for (int i = 0; i < fragmentstore.Fragments.Count; i++)
                        {
                            ModbusFragment fragment = fragmentstore.Fragments[i];
                            switch (fragment.Code)
                            {
                                case "01":// 01和05是一个码 可写可读
                                    {
                                        //返回的线圈状态,由于线圈是按位操作，转换也是按位转换
                                        Task<bool[]> result = master.ReadCoilsAsync(byte.Parse(device.IO_DEVICE_ADDRESS), fragment.StartRegister, fragment.RegisterNum);

                                        byte[] bytes = ModbusConvert.BoolToByte(result.Result);
                                        fragment.StartIndex = allbytes.Count;
                                        fragment.Length = bytes.Length;
                                        allbytes.AddRange(bytes);

                                    }
                                    break;
                                case "02"://只读属性
                                    {
                                        //返回的线圈状态
                                        Task<bool[]> result = master.ReadInputsAsync(byte.Parse(device.IO_DEVICE_ADDRESS), fragment.StartRegister, fragment.RegisterNum);
                                        byte[] bytes = ModbusConvert.BoolToByte(result.Result);
                                        fragment.StartIndex = allbytes.Count;
                                        fragment.Length = bytes.Length;
                                        allbytes.AddRange(bytes);
                                    }
                                    break;
                                case "03"://HR保持寄存器，可写可读
                                    {
                                        //返回的数据全部是ushort 需要将ushort 转换为byte在进行传递
                                        Task<ushort[]> result = master.ReadHoldingRegistersAsync(byte.Parse(device.IO_DEVICE_ADDRESS), fragment.StartRegister, fragment.RegisterNum);
                                        byte[] bytes = ModbusConvert.Ushorts2Bytes(result.Result);
                                        fragment.StartIndex = allbytes.Count;
                                        fragment.Length = bytes.Length;
                                        allbytes.AddRange(bytes);
                                    }
                                    break;
                                case "04"://只读属性
                                    {

                                        //返回的数据全部是ushort 需要将ushort 转换为byte在进行传递
                                        Task<ushort[]> result = master.ReadInputRegistersAsync(byte.Parse(device.IO_DEVICE_ADDRESS), fragment.StartRegister, fragment.RegisterNum);
                                        byte[] bytes = ModbusConvert.Ushorts2Bytes(result.Result);
                                        fragment.StartIndex = allbytes.Count;
                                        fragment.Length = bytes.Length;
                                        allbytes.AddRange(bytes);
                                    }
                                    break;
                            }

                        }

                    }
                    catch  
                    {
                        //读取异常处理
                        this.DeviceStatus(this.IOServer, this.IOCommunication, device, null, "0");//tag为1表示上线，如果为0表示下线

                    }
                    //将数据返回到采集客户端
                    if (allbytes.Count > 0)
                    {
                        device.IO_DEVICE_STATUS = 1;
                        ReceiveData(this.IOServer, this.IOCommunication, device, allbytes.ToArray(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), fragmentstore);
                        //设置设备状态
                        this.DeviceStatus(this.IOServer, this.IOCommunication, device, null, "1");//tag为1表示上线，如果为0表示下线

                    }
                    else
                    {
                        device.IO_DEVICE_STATUS = 0;
                        //设置设备状态
                        this.DeviceStatus(this.IOServer, this.IOCommunication, device, null, "0");//tag为1表示上线，如果为0表示下线

                    }


                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool ResponseData(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, IO_PARA para, string value)
        {
            if (para == null)
                return false;
            if (para.IO_POINTTYPE == "计算值" || para.IO_POINTTYPE == "关系数据库值")
            {
                return false;
            }
            //设备地址不能为空
            if (device.IO_DEVICE_ADDRESS == "")
                return false;
            try
            {
                //通过设备驱动进行数据解析，并生成下置的数据bytes
                if (device.DeviceDrive != null)
                {
                    ScadaDeviceKernel Driver = (ScadaDeviceKernel)device.DeviceDrive;

                    //获取参数中的
                    if (tcpClient != null && tcpClient.Connected && master != null)
                    {


                        ParaPack paraPack = new ParaPack(para.IO_PARASTRING);
                        if (paraPack.Count > 0)
                        {
                            ushort offset = ushort.Parse(paraPack.GetValue("偏置"));
                            switch (paraPack.GetValue("内存区"))
                            {
                                case "01":
                                    {
                                        if (ushort.Parse(value) > 0)
                                        {
                                            master.WriteSingleCoil(byte.Parse(device.IO_DEVICE_ADDRESS), offset, true);
                                        }
                                        else
                                        {
                                            master.WriteSingleCoil(byte.Parse(device.IO_DEVICE_ADDRESS), offset, false);
                                        }

                                    }
                                    break;
                                case "02"://此类型只能查询，不能写入
                                    {


                                    }
                                    break;
                                case "03":
                                    {
                                        Modbus_Type datatype = (Modbus_Type)Enum.Parse(typeof(Modbus_Type), paraPack.GetValue("数据类型"));
                                        bool ishigh = paraPack.GetValue("存储位置") == "高八位" ? true : false;
                                        int charsize = int.Parse(paraPack.GetValue("字节长度"));
                                        bool isposition = paraPack.GetValue("按位存取") == "1" ? true : false;
                                        int dataposition = int.Parse(paraPack.GetValue("数据位"));
                                        switch (datatype)
                                        {
                                            case Modbus_Type.单精度浮点数32位:
                                                {
                                                    ushort[] buff = new ushort[2];
                                                    float WriteValue = float.Parse(value);
                                                    ModbusConvert.SetReal(buff, 0, WriteValue);
                                                    master.WriteMultipleRegisters(byte.Parse(device.IO_DEVICE_ADDRESS), offset, buff);
                                                }
                                                break;
                                            case Modbus_Type.双精度浮点数64位:
                                                {
                                                    ushort[] buff = new ushort[4];
                                                    double WriteValue = double.Parse(value);
                                                    ModbusConvert.SetDouble(buff, 0, WriteValue);
                                                    master.WriteMultipleRegisters(byte.Parse(device.IO_DEVICE_ADDRESS), offset, buff);
                                                }
                                                break;
                                            case Modbus_Type.字符型:
                                                {
                                                    ushort[] buff = new ushort[charsize];
                                                    string WriteValue = value;
                                                    if (value.Length > charsize)
                                                        WriteValue = value.Substring(0, charsize);
                                                    if (value.Length < charsize)
                                                        WriteValue = value.PadRight(charsize, ' ');
                                                    ModbusConvert.SetString(buff, 0, WriteValue);
                                                    master.WriteMultipleRegisters(byte.Parse(device.IO_DEVICE_ADDRESS), offset, buff);

                                                }
                                                break;
                                            case Modbus_Type.无符号整数8位:
                                                {
                                                    ushort[] buff = new ushort[1];
                                                    byte WriteValue = byte.Parse(value);
                                                    ModbusConvert.SetByte(buff, 0, WriteValue, ishigh);
                                                    master.WriteSingleRegister(byte.Parse(device.IO_DEVICE_ADDRESS), offset, buff[0]);
                                                }
                                                break;
                                            case Modbus_Type.有符号整数8位:
                                                {
                                                    ushort[] buff = new ushort[1];
                                                    sbyte WriteValue = sbyte.Parse(value);
                                                    ModbusConvert.SetSByte(buff, 0, WriteValue, ishigh);
                                                    master.WriteSingleRegister(byte.Parse(device.IO_DEVICE_ADDRESS), offset, buff[0]);
                                                }
                                                break;
                                            case Modbus_Type.无符号整数16位:
                                                {
                                                    if (isposition)
                                                    {
                                                        //获取当前寄存器的值
                                                        ushort[] datas = master.ReadHoldingRegisters(byte.Parse(device.IO_DEVICE_ADDRESS), offset, 1);
                                                        ushort dataValue = ModbusConvert.GetUShort(datas, 0);

                                                        if (short.Parse(value) > 0)
                                                        {
                                                            dataValue = Convert.ToUInt16(dataValue >> dataposition & 1);
                                                        }
                                                        else
                                                        {
                                                            dataValue = Convert.ToUInt16(dataValue >> dataposition & 0);
                                                        }
                                                        //新发送的值

                                                        ushort[] datas2 = new ushort[1];
                                                        ModbusConvert.SetUShort(datas2, 0, dataValue);
                                                        master.WriteSingleRegister(byte.Parse(device.IO_DEVICE_ADDRESS), offset, datas2[0]);
                                                    }
                                                    else
                                                    {
                                                        ushort WriteValue = ushort.Parse(value);
                                                        ushort[] buff = new ushort[1];
                                                        ModbusConvert.SetUShort(buff, 0, WriteValue);
                                                        master.WriteSingleRegister(byte.Parse(device.IO_DEVICE_ADDRESS), offset, buff[0]);
                                                    }
                                                }
                                                break;
                                            case Modbus_Type.有符号整数16位:
                                                {
                                                    if (isposition)
                                                    {
                                                        //获取当前寄存器的值
                                                        ushort[] datas = master.ReadHoldingRegisters(byte.Parse(device.IO_DEVICE_ADDRESS), offset, 1);
                                                        short dataValue = ModbusConvert.GetShort(datas, 0);

                                                        if (short.Parse(value) > 0)
                                                        {
                                                            dataValue = Convert.ToInt16(dataValue >> dataposition & 1);
                                                        }
                                                        else
                                                        {
                                                            dataValue = Convert.ToInt16(dataValue >> dataposition & 0);
                                                        }
                                                        //新发送的值

                                                        ushort[] datas2 = new ushort[1];
                                                        ModbusConvert.SetShort(datas2, 0, dataValue);
                                                        master.WriteSingleRegister(byte.Parse(device.IO_DEVICE_ADDRESS), offset, datas2[0]);
                                                    }
                                                    else
                                                    {
                                                        Int16 WriteValue = Int16.Parse(value);
                                                        ushort[] buff = new ushort[1];
                                                        ModbusConvert.SetShort(buff, 0, WriteValue);
                                                        master.WriteSingleRegister(byte.Parse(device.IO_DEVICE_ADDRESS), offset, buff[0]);
                                                    }
                                                }
                                                break;
                                            case Modbus_Type.无符号整数32位:
                                                {
                                                    uint WriteValue = uint.Parse(value);
                                                    ushort[] buff = new ushort[2];
                                                    ModbusConvert.SetUInt(buff, 0, WriteValue);
                                                    master.WriteMultipleRegisters(byte.Parse(device.IO_DEVICE_ADDRESS), offset, buff);
                                                }
                                                break;
                                            case Modbus_Type.有符号整数32位:
                                                {
                                                    int WriteValue = int.Parse(value);
                                                    ushort[] buff = new ushort[2];
                                                    ModbusConvert.SetInt(buff, 0, WriteValue);
                                                    master.WriteMultipleRegisters(byte.Parse(device.IO_DEVICE_ADDRESS), offset, buff);
                                                }
                                                break;
                                        }

                                    }
                                    break;
                            }
                        }

                    }

                }
            }
            catch  
            {
                return false;
            }
            return true;
        }
 
        protected override ScadaResult IOSendCommand(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, IO_PARA para, string value)
        {
            ScadaResult res = new ScadaResult(false, "");
            if (device == null)
                return res;

            //用户发送一条命令后要及时获取最新的数据，主要是因为有些命令需要及时判断命令是否成功，
            if (ResponseData(server, comm, device, para, value))
            {
                RealData realData = this.RealDevices.Find(x => x.Device == device);
                string error = "";
                if (RequestData(realData.Device, realData, out error, realData.Fragment))
                {
                    res = new ScadaResult(true, "数据请求成功");
                }

            }
            DataSended(server, comm, device, para, value, res.Result);
            return res;
        }
        protected override void Start()
        {
            if (master != null)
            {
                master.Dispose();
            }


            if (tcpClient != null)
            {
                tcpClient.Close();
                tcpClient.Dispose();
                tcpClient = null;
            }

            if (tcpClient == null)
                tcpClient = new TcpClient(new IPEndPoint(IPAddress.Parse(Tcp_PARA.LocalTCP_IP), int.Parse(Tcp_PARA.LocalTCP_Port)));
            tcpClient.ReceiveTimeout = 1000;
            tcpClient.SendTimeout = 1000;
            tcpClient.SendBufferSize = Tcp_PARA.WriteBufferSize;
            tcpClient.ReceiveBufferSize = Tcp_PARA.ReadBufferSize;
            master = ModbusIpMaster.CreateIp(tcpClient);
            //通用部分设置
            master.Transport.ReadTimeout = Tcp_PARA.ReadTimeout ;//读取数据超时1000ms
            master.Transport.WriteTimeout = Tcp_PARA.WriteTimeout ;//写入数据超时1000ms
            master.Transport.Retries = Tcp_PARA.CollectFaultsNumber;//重试次数
            master.Transport.WaitToRetryMilliseconds = Tcp_PARA.CollectFaultsInternal;//重试间隔     
        
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

                        try
                        {

                            Task.Run(() =>
                            {
                                //发送获取数据的命令
                                string error = "";
                                if (!this.RequestData(mRealData.Device, mRealData, out error, mRealData.Fragment))
                                {
                                    this.DeviceException("ERROR=Modbus_Serial_10001," + error);
                                }
                            });
                        }
                        catch (Exception e)
                        {
                            this.DeviceException("ERROR=Modbus_Serial_10002," + e.Message);
                        }


                        //更新周期
                        Thread.Sleep(mRealData.Device.IO_DEVICE_UPDATECYCLE * 1000);
                    }
                });
            }

            this.CommunctionStartChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "启动服务");

        }
        protected override void Close()
        {
          
            try
            {
                if (master != null)
                {
                    master.Dispose();
                }


                if (tcpClient != null)
                {
                    tcpClient.Close();
                    tcpClient.Dispose();
                    tcpClient = null;
                }
                this.CommunctionCloseChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "关闭网络服务");
            }
            catch (Exception emx)
            {
                this.DeviceException("ERROR=Modbus_Tcp_10006," + emx.Message);
                this.CommunctionStopChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "关闭网络服务失败");
            }
        }
        protected override void Continue()
        {
            try
            {

                this.CommunctionContinueChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "继续网络服务");
            }
            catch (Exception emx)
            {
                this.DeviceException("ERROR=Modbus_Tcp_10003," + emx.Message);
                this.CommunctionStopChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "继续网络服务失败");
            }
        }
        protected override void Pause()
        {
            try
            {

                this.CommunctionPauseChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "暂停网络服务");
            }
            catch (Exception emx)
            {
                this.DeviceException("ERROR=Modbus_Tcp_10005," + emx.Message);
                this.CommunctionStopChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "暂停网络服务失败");
            }
        }
        protected override void Stop()
        {
            try
            {


                this.CommunctionStopChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "停止网络服务");


            }
            catch (Exception emx)
            {
                this.DeviceException("ERROR=Modbus_Tcp_10003," + emx.Message);
                this.CommunctionStopChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "停止网络服务失败");
            }


        }

        #region 模拟器模拟下位机
        List<ModbusSlave> slaves = new List<ModbusSlave>();
        private int SimulatorUpdateCycle = 5;//默认是秒
        private TcpListener _simularorListener;
        //模拟器初始化
        public override  void Simulator(int times, bool IsSystem)
        {
       
            SimulatorClose();
            _simularorListener = new TcpListener(new IPEndPoint(IPAddress.Parse(Tcp_PARA.SimulatorTCP_IP), int.Parse(Tcp_PARA.SimulatorTCP_Port)));
            SimulatorUpdateCycle = times;
            for (int i = 0; i < this.IODevices.Count; i++)
            {
                try
                {

                    ModbusSlave DeviceSlave = ModbusTcpSlave.CreateTcp(byte.Parse(this.IODevices[i].IO_DEVICE_ADDRESS), _simularorListener);
                    slaves.Add(DeviceSlave);

                }
                catch (Exception emx)
                {
                    this.SimulatorAppendLog("创建设备模拟器失败 " + this.IODevices[i].IO_DEVICE_NAME + " " + emx.Message);

                }
            }


        }
        public override void SimulatorClose()
        {

            try
            {

                for (int i = 0; i < slaves.Count; i++)
                {

                    slaves[i].Dispose();
                    slaves[i] = null;

                }
                slaves.Clear();
                if (_simularorListener != null)
                {
                    _simularorListener.Stop();
                    _simularorListener = null;
                }
            }
            catch (Exception emx)
            {
                this.SimulatorAppendLog("关闭模拟器失败 " + emx.Message);
            }

        }
        public override async void SimulatorStart()
        {
            if (_simularorListener == null)
                return;
            await Task.Run(() =>
            {
                for (int i = 0; i < slaves.Count; i++)
                {
                    try
                    {

                        slaves[i].ModbusSlaveRequestReceived += Modbus_Serial_ModbusSlaveRequestReceived;
                        slaves[i].WriteComplete += Modbus_Serial_WriteComplete;

                        slaves[i].ListenAsync();
                    }
                    catch (Exception emx)
                    {
                        this.SimulatorAppendLog("启动模拟器失败 " + emx.Message);
                    }
                }
                Random rd = new Random();
                //初始化数据
                while (true)
                {
                    for (int i = 0; i < slaves.Count; i++)
                    {
                        slaves[i].DataStore = DataStoreFactory.CreateTestDataStore();


                    }
                    this.SimulatorAppendLog("所有从机初始化数据一次");
                    Thread.Sleep(SimulatorUpdateCycle * 1000);
                }


            });



        }

        /// <summary>
        /// 当从机收到写入命令的时候发生 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Modbus_Serial_WriteComplete(object sender, ModbusSlaveRequestEventArgs e)
        {
            this.SimulatorAppendLog("服务器请求从机要求写入数据");
        }

        /// <summary>
        /// 当从机收到数据请求时候发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Modbus_Serial_ModbusSlaveRequestReceived(object sender, ModbusSlaveRequestEventArgs e)
        {
            this.SimulatorAppendLog("服务器请求从机获取数据 ");
        }

        #endregion
    }
}
