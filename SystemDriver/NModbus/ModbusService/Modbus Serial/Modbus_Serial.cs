
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scada.Model;
using Scada.Kernel;
using System.IO.Ports;
using System.Threading;
using Modbus.Device;
using Modbus.Data;
using Modbus.Globel;

namespace Modbus.ModbusService
{
  
    public enum SerialCheck
    {
        无 = 1,
        偶校验 = 2,
        奇校验 = 3,
        常1 = 4,
        常0 = 5



    }
 
    public class Modbus_Serial_PARA
    {
        /// <summary>
        /// 串口名称
        /// </summary>
        public string SerialPort = "";
        /// <summary>
        /// 模拟串口
        /// </summary>
        public string SimulatorSerialPort = "";
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
        public int CollectFaultsInternal = 15;
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
        public int ReadTimeout = 1000;
        public int WriteTimeout = 1000;
        public ModbusType ModbusType = ModbusType.ASCII;
    }


    /// <summary>
    /// Modbus 串口通讯
    /// </summary>
    public class Modbus_Serial : ScadaCommunicateKernel
    {
        public Modbus_Serial()
        {

        }
        private const string mGuid = "310AA8D3-DBCE-43F8-81A9-DFFD9C5D7D3A";
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


        ParaPack comParaPack = null;
        protected override bool InitCommunicateKernel(IO_SERVER server, IO_COMMUNICATION communication, List<IO_DEVICE> ioDevices, SCADA_DRIVER driver)
        {

            if (IsCreateControl)
            {
                CommunicationControl = new Modbus_Serial_Ctrl();
                if (communication != null)
                    CommunicationControl.SetUIParameter(communication.IO_COMM_PARASTRING);
            }
            Serial_PARA = new Modbus_Serial_PARA();
            if (communication != null)
            {


                comParaPack = new ParaPack(communication.IO_COMM_PARASTRING);
                Serial_PARA.BaudRate = Convert.ToInt32(comParaPack.GetValue("波特率"));
                Serial_PARA.CollectFaultsInternal = Convert.ToInt32(comParaPack.GetValue("重试间隔"));
                Serial_PARA.CollectFaultsNumber = Convert.ToInt32(comParaPack.GetValue("重试次数"));
                Serial_PARA.ContinueCollect = comParaPack.GetValue("连续采集") == "1" ? true : false;
                Serial_PARA.DataBits = Convert.ToInt32(comParaPack.GetValue("数据位"));
                Serial_PARA.ModbusType = (ModbusType)Enum.Parse(typeof(ModbusType), comParaPack.GetValue("MODBUS类型"));
                Serial_PARA.OffsetInterval = Convert.ToInt32(comParaPack.GetValue("偏移间隔"));
                Serial_PARA.PackMaxSize = Convert.ToInt32(comParaPack.GetValue("包最大长度"));
                Serial_PARA.ReadTimeout = Convert.ToInt32(comParaPack.GetValue("读超时时间"));
                Serial_PARA.RSTSendPreKeeyTime = Convert.ToInt32(comParaPack.GetValue("发送前RTS保持时间"));
                Serial_PARA.RTSSendAfterKeeyTime = Convert.ToInt32(comParaPack.GetValue("发送后RTS保持时间"));
                Serial_PARA.RTSEnable = comParaPack.GetValue("RTS") == "1" ? true : false;
                Serial_PARA.SerialCheck = (SerialCheck)Enum.Parse(typeof(SerialCheck), comParaPack.GetValue("校验"));
                Serial_PARA.SerialPort = comParaPack.GetValue("串口");
                Serial_PARA.SimulatorSerialPort = comParaPack.GetValue("模拟器串口");
                Serial_PARA.SixCommmand = comParaPack.GetValue("支持6号命令") == "1" ? true : false;
                Serial_PARA.SixteenCommmand = comParaPack.GetValue("支持16号命令") == "1" ? true : false; ;
                Serial_PARA.StopBits = (StopBits)Enum.Parse(typeof(StopBits), comParaPack.GetValue("停止位"));
                Serial_PARA.WriteTimeout = Convert.ToInt32(comParaPack.GetValue("写超时时间"));

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
                        //获取下发命令的参数,注意此次要进心分段存储，因为modbus一次不能超过123个寄存器地址
                        mRealData.Fragment = (ModbusFragmentStore)fragment;
                        RealDevices.Add(mRealData);
                    }


                }
            }

            return true;
        }
        /// <summary>
        /// 发送写入命令
        /// </summary>
        /// <param name="server"></param>
        /// <param name="comm"></param>
        /// <param name="device"></param>
        /// <param name="para"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override ScadaResult IOSendCommand(IO_SERVER server, IO_COMMUNICATION comm, IO_DEVICE device, IO_PARA para, string value)
        {
            ScadaResult res = new ScadaResult(false, "");
            if (device == null)
                return new ScadaResult(false, "设备不存在");

            //用户发送一条命令后要及时获取最新的数据，主要是因为有些命令需要及时判断命令是否成功，
            if (ResponseData(server, comm, device, para, value))
            {
                RealData realData = this.RealDevices.Find(x => x.Device == device);
                string error = "";
                if (RequestData(realData.Device, realData, out error, realData.Fragment))
                {
                    res = new ScadaResult(true, "请求数据成功");
                }

            }

            DataSended(server, comm, device, para, value, res.Result);
            return res;
        }

        #region 串口服务相关
        List<RealData> RealDevices = new List<RealData>();
        private const string NewLine = "\r\n";
        private SerialPort _serialPort;

        Modbus_Serial_PARA Serial_PARA = null;
        /// <summary>
        /// 请求获取数据的命令，并且返回请求结果数据
        /// </summary>
        /// <param name="device"></param>
        /// <param name="realData"></param>
        /// <param name="error"></param>
        /// <param name="fragment">当前请求的modbus地址分段</param>
        /// <returns></returns>
        private   bool RequestData(IO_DEVICE device, RealData realData, out string error, ModbusFragmentStore fragmentstore)
        {
            error = "";
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
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
                                        Task<ushort[]> result  = master.ReadHoldingRegistersAsync(byte.Parse(device.IO_DEVICE_ADDRESS), fragment.StartRegister, fragment.RegisterNum);
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
        /// <summary>
        /// 写入操作,针对的数据类型只有 字符串量 计算值 关系数据库值
        /// </summary>
        /// <param name="server"></param>
        /// <param name="comm"></param>
        /// <param name="device"></param>
        /// <param name="para">要写入参数</param>
        /// <param name="value">要写入的值</param>
        /// <returns></returns>
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
                    if (_serialPort != null && _serialPort.IsOpen && master != null)
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

        IModbusSerialMaster master = null;
        private void InitSerialPort(ref SerialPort serialPort)
        {
            if (serialPort == null)
                serialPort = new SerialPort(Serial_PARA.SerialPort);
           
            serialPort.BaudRate = Serial_PARA.BaudRate;
            serialPort.DataBits = Serial_PARA.DataBits;
            switch (Serial_PARA.SerialCheck)
            {
                case SerialCheck.无:
                    {
                        serialPort.Parity = Parity.None;
                    }
                    break;
                case SerialCheck.奇校验:
                    {
                        serialPort.Parity = Parity.Odd;
                    }
                    break;
                case SerialCheck.偶校验:
                    {
                        serialPort.Parity = Parity.Even;
                    }
                    break;
                case SerialCheck.常0:
                    {
                        serialPort.Parity = Parity.Space;
                    }
                    break;
                case SerialCheck.常1:
                    {
                        serialPort.Parity = Parity.Mark;
                    }
                    break;
            }

            serialPort.StopBits = Serial_PARA.StopBits;
            serialPort.ReadTimeout = 1000;
            serialPort.WriteTimeout = 1000;
            serialPort.RtsEnable = Serial_PARA.RTSEnable;
            serialPort.NewLine = NewLine;
            if(!serialPort.IsOpen)
                serialPort.Open();
        }
        private void InitSmSerialPort(ref SerialPort serialPort)
        {
            if (string.IsNullOrEmpty(Serial_PARA.SimulatorSerialPort))
                return;
            if (serialPort == null)
                serialPort = new SerialPort(Serial_PARA.SimulatorSerialPort);

            serialPort.BaudRate = Serial_PARA.BaudRate;
            serialPort.DataBits = Serial_PARA.DataBits;
            switch (Serial_PARA.SerialCheck)
            {
                case SerialCheck.无:
                    {
                        serialPort.Parity = Parity.None;
                    }
                    break;
                case SerialCheck.奇校验:
                    {
                        serialPort.Parity = Parity.Odd;
                    }
                    break;
                case SerialCheck.偶校验:
                    {
                        serialPort.Parity = Parity.Even;
                    }
                    break;
                case SerialCheck.常0:
                    {
                        serialPort.Parity = Parity.Space;
                    }
                    break;
                case SerialCheck.常1:
                    {
                        serialPort.Parity = Parity.Mark;
                    }
                    break;
            }

            serialPort.StopBits = Serial_PARA.StopBits;
            serialPort.ReadTimeout = 1000;
            serialPort.WriteTimeout = 1000;
            serialPort.RtsEnable = Serial_PARA.RTSEnable;
            serialPort.NewLine = NewLine;
            if (!serialPort.IsOpen)
                serialPort.Open();
        }
        protected override void Start()
        {
            if (master != null)
            {
                master.Dispose();
            }
            if (_serialPort != null)
            {
                _serialPort.Close();
                _serialPort.Dispose();
                _serialPort = null;
            }

            try
            {

                byte[] array = new byte[8];

                #region
                {


                    InitSerialPort(ref _serialPort);



                    if (Serial_PARA.ModbusType == ModbusType.ASCII)
                    {
                        master = ModbusSerialMaster.CreateAscii(_serialPort);
                    }
                    else
                    {
                        master = ModbusSerialMaster.CreateRtu(_serialPort);
                    }
                    //通用部分设置
                    master.Transport.ReadTimeout = Serial_PARA.ReadTimeout;//读取数据超时1000ms
                    master.Transport.WriteTimeout = Serial_PARA.WriteTimeout ;//写入数据超时1000ms
                    master.Transport.Retries = Serial_PARA.CollectFaultsNumber;//重试次数
                    master.Transport.WaitToRetryMilliseconds = Serial_PARA.CollectFaultsInternal;//重试间隔                

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
                                Thread.Sleep(mRealData.Device.IO_DEVICE_UPDATECYCLE*1000);
                            }
                        });
                    }

                    this.CommunctionStartChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "启动服务");

                }
                #endregion

            }
            catch  
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
            try
            {

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


                this.CommunctionStopChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "停止串口服务");


            }
            catch (Exception emx)
            {
                this.DeviceException("ERROR=Modbus_Serial_10003," + emx.Message);
                this.CommunctionStopChanged(this.IOServer, this.IOServer.SERVER_IP + " " + this.IOServer.SERVER_NAME + "停止串口服务失败");
            }

        }
        #endregion

        #region 模拟器模拟下位机
        List<ModbusSlave> slaves = new List<ModbusSlave>();
        private int SimulatorUpdateCycle = 5;//默认是秒
        private SerialPort _simularorserialPort;
        //模拟器初始化
        public override   void Simulator(int times, bool IsSystem)
        {
            SimulatorClose();
            if (_simularorserialPort == null)
                InitSmSerialPort(ref _simularorserialPort);
            SimulatorUpdateCycle = times;
            for (int i = 0; i < this.IODevices.Count; i++)
            {
                try
                {

                    ModbusSlave DeviceSlave = null;
                    if (Serial_PARA.ModbusType == ModbusType.ASCII)
                    {
                        DeviceSlave = ModbusSerialSlave.CreateAscii(byte.Parse(this.IODevices[i].IO_DEVICE_ADDRESS), _simularorserialPort);

                    }
                    else
                    {
                        DeviceSlave = ModbusSerialSlave.CreateRtu(byte.Parse(this.IODevices[i].IO_DEVICE_ADDRESS), _simularorserialPort);
                    }



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
                if(_simularorserialPort!=null&& _simularorserialPort.IsOpen)
                {
                    _simularorserialPort.Close();
                    _simularorserialPort = null;
                }
            }
            catch (Exception emx)
            {
                this.SimulatorAppendLog("关闭模拟器失败 " + emx.Message);
            }

        }
        public override async void SimulatorStart()
        {
            if (_simularorserialPort != null && !_simularorserialPort.IsOpen)
                _simularorserialPort.Open();
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
