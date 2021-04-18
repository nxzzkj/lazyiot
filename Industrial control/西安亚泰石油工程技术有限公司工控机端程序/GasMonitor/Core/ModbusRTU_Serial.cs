using Modbus;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GasMonitor
{
    
    public class SerialConfig
    {
        /// <summary>
        /// 串口名称
        /// </summary>
        public string SerialPort = "";
        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate = 9600;
        /// <summary>
        /// 校验
        /// </summary>
        public Parity SerialCheck = Parity.None;
        /// <summary>
        /// 数据位
        /// </summary>
        public int DataBits = 8;
        /// <summary>
        /// 停止位
        /// </summary>
        public StopBits StopBits = StopBits.None;
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
        /// 最大包长
        /// </summary>
        public int PackMaxSize = 64;
        /// <summary>
        /// 偏移间隔
        /// </summary>
        public int OffsetInterval = 10;
 
        public bool RTSEnable = false;
        public int ReadTimeout = 1000;
        public int WriteTimeout = 1000;
        public string ModbusType = "RTU";
        public int UpdateCycle = 5;//秒
        public List<ChannelElement> Chanels = null;//当前要读取的通道
        public List<ModbusPara> ModbusParas = null;
    }
    public   class Modbus_Serial
    {
        public Action<string> LogOutput;
        public Action<List<RealData>> ReadDataSuccessed;
        public Modbus_Serial(SerialConfig serialConfig)
        {
            Serial_PARA = serialConfig;

        }
        public SerialConfig Serial_PARA = null;
        private const string NewLine = "\r\n";
    
        IModbusSerialMaster master = null;
        private SerialPort serialPort = null;
        private void InitSerialPort()
        {
            try
            {
                if (master != null)
                {
                    master.Dispose();
                }
                if (serialPort != null)
                {
                    serialPort.Close();
                    serialPort.Dispose();
                    serialPort = null;
                }
                if (serialPort == null)
                    serialPort = new SerialPort(Serial_PARA.SerialPort);

                serialPort.BaudRate = Serial_PARA.BaudRate;

                serialPort.DataBits = Serial_PARA.DataBits;

                serialPort.Parity = Serial_PARA.SerialCheck;

                serialPort.StopBits = Serial_PARA.StopBits;

                serialPort.ReadTimeout = Serial_PARA.ReadTimeout;

                serialPort.WriteTimeout = Serial_PARA.WriteTimeout;

                serialPort.RtsEnable = Serial_PARA.RTSEnable;
                serialPort.PortName = Serial_PARA.SerialPort;
                serialPort.NewLine = NewLine;
                if (!serialPort.IsOpen)
                    try
                    {
                        serialPort.Open();
                    }
                    catch (Exception exm)
                    {
                        LogOutput(exm.Message);
                    }
            }
            catch(Exception exm)
            {
                LogOutput(exm.Message);
            }
        }
        public Task Start()
        {
           
            LogOutput("服务已经启动");
            InitSerialPort();
           
            LogOutput("串口初始化完成");
            if (Serial_PARA.ModbusType == "ASCII")
            {
                master = ModbusSerialMaster.CreateAscii(serialPort);
            }
            else
            {
                master = ModbusSerialMaster.CreateRtu(serialPort);
            }
            LogOutput("Modbus创建成功");
            //通用部分设置
           
            master.Transport.ReadTimeout = Serial_PARA.ReadTimeout;//读取数据超时1000ms
            master.Transport.WriteTimeout = Serial_PARA.WriteTimeout;//写入数据超时1000ms
            master.Transport.Retries = Serial_PARA.CollectFaultsNumber;//重试次数
            if (master.Transport.Retries < 0)
                master.Transport.Retries = 0;
                master.Transport.WaitToRetryMilliseconds = Serial_PARA.CollectFaultsInternal;//重试间隔                
            master.Transport.RetryOnOldResponseThreshold = Convert.ToUInt32(Serial_PARA.CollectFaultsNumber);
            master.Transport.SlaveBusyUsesRetryCount = Serial_PARA.ContinueCollect;
            master.Transport.WaitToRetryMilliseconds = Serial_PARA.CollectFaultsInternal;
            LogOutput("Modbus从机属性配置");
            Thread.Sleep(100);
            var task = Task.Run(() =>
            {
                try
                {

                   

                    #region
                    {
                      
                        //此处采用多线程技术创建一个实时读取数据的任务
                        while (true)
                        {
                            try
                            {
                          
                               
                                if (!serialPort.IsOpen)
                                {
                                    serialPort.Open();
                                 
                                }
                                for (int i = 0; i < Serial_PARA.Chanels.Count; i++)
                                {
                                  
                                    if (Serial_PARA.Chanels[i].BindingArress.Trim() == "")
                                        continue;
                                    //以下开始读取4气体检测的值
                                    List<RealData> receivedatas = new List<RealData>();
                                    foreach( ModbusPara para in Serial_PARA.ModbusParas)
                                    {
                                        RealData realData = new RealData();
                                        try
                                        {
                                            if (para.Enable == 0)
                                                continue;
                                           
                                            realData.Address = Serial_PARA.Chanels[i].BindingArress;
                                            realData.Fragment = new ModbusFragment()
                                            {
                                                Code = para.ModbusCode,
                                                DataType = "uint",
                                                RegisterNum = Convert.ToByte(para.RegisterNum),
                                                StartRegister = Convert.ToByte(para.StartRegister)
                                            };
                                        
                                            realData.ParaName = para.Name;
                                            realData.SlaveId = Serial_PARA.Chanels[i].Id;
                                     
                                            var datas = RequestData(realData).Result;
                                      
                                            if (datas.Count>0)
                                            {
                                                realData.ReadSendByte = datas.ToArray();
                                                receivedatas.Add(realData);
                                            }
                                           
                                        }
                                        catch
                                        {
                                            if (LogOutput != null)
                                            {
                                                LogOutput(realData.ParaName + " 没有获取到数据");
                                            }
                                        }

                                    }
                                
                                    if (ReadDataSuccessed != null)
                                    {
                                        ReadDataSuccessed(receivedatas);
                                    }

                                }
                                Thread.Sleep(Serial_PARA.UpdateCycle * 1000);
                               
                            }
                            catch(Exception emx)
                            {
                                if (LogOutput != null)
                                {
                                    LogOutput(emx.Message+" ERROR=02");
                                }
                                ///出现异常则5秒后再进行读取
                                Thread.Sleep(5000);

                            }
                         
                        }
                      


                    }
                    #endregion

                }
                catch (Exception emx)
                {
                    if (LogOutput != null)
                    {
                        LogOutput(emx.Message + " ERROR=03");
                    }
                }
            });
            return task;
        }

        /// <summary>
        /// 请求获取数据的命令，并且返回请求结果数据的字节数组
        /// </summary>
        /// <param name="device"></param>
        /// <param name="realData"></param>
        /// <param name="error"></param>
        /// <param name="fragment">当前请求的modbus地址分段</param>
        /// <returns></returns>
        public Task<List<byte>> RequestData(RealData read)
        {
            List<byte> allbytes = new List<byte>();

            var task = Task.Run<List<byte>>(() =>
            {
                try
                {
                    if (serialPort != null && serialPort.IsOpen)
                    {
                        //分段读取数据，如果是读取整个寄存器的话，一次只能最多读取123个，
                        //如果是读取线圈的话最大只能读取1999个，因此要分段进行数据的读取
                            //增加了一个写入后返回消息
                            master.Transport.WriteMessage = new Action<byte[]>((s) =>
                            {

                                if (LogOutput != null)
                                    LogOutput(ModbusConvert.ByteToHexStr(s));

                            });
                            master.Transport.CheckFrame = true;
                            ModbusFragment fragment = read.Fragment;
                            switch (fragment.Code)
                            {
                                case "01":// 01和05是一个码 可写可读
                                    {
                                        //返回的线圈状态,由于线圈是按位操作，转换也是按位转换
                                        Task<bool[]> result = master.ReadCoilsAsync(byte.Parse(read.Address), fragment.StartRegister, fragment.RegisterNum);

                                        byte[] bytes = ModbusConvert.BoolToByte(result.Result);

                                        allbytes.AddRange(bytes);

                                    }
                                    break;
                                case "02"://只读属性
                                    {
                                        //返回的线圈状态
                                        Task<bool[]> result = master.ReadInputsAsync(byte.Parse(read.Address), fragment.StartRegister, fragment.RegisterNum);
                                        byte[] bytes = ModbusConvert.BoolToByte(result.Result);

                                        allbytes.AddRange(bytes);
                                    }
                                    break;
                                case "03"://HR保持寄存器，可写可读
                                    {

                                        //返回的数据全部是ushort 需要将ushort 转换为byte在进行传递
                                        Task<ushort[]> result = master.ReadHoldingRegistersAsync(byte.Parse(read.Address), fragment.StartRegister, fragment.RegisterNum);
                                        byte[] bytes = ModbusConvert.Ushorts2Bytes(result.Result);
                                        allbytes.AddRange(bytes);
                                    }
                                    break;
                                case "04"://只读属性
                                    {

                                        //返回的数据全部是ushort 需要将ushort 转换为byte在进行传递
                                        Task<ushort[]> result = master.ReadInputRegistersAsync(byte.Parse(read.Address), fragment.StartRegister, fragment.RegisterNum);
                                        byte[] bytes = ModbusConvert.Ushorts2Bytes(result.Result);

                                        allbytes.AddRange(bytes);
                                    }
                                    break;
                            }


 
                    }
                    return allbytes;
                }
                catch
                {
                    return allbytes;
                }

            });

            return task;

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
        public Task<bool> ResponseData(string SlaveId,string Address, ModbusFragment para, string value)
        {
            var task = Task.Run<bool>(()=>{


                if (para == null)
                    return false;

                //设备地址不能为空
                if (Address == "")
                    return false;
                try
                {
                    //获取参数中的
                    if (serialPort != null && serialPort.IsOpen && master != null)
                    {

                        ushort offset = para.StartRegister;
                        switch (para.Code)
                        {
                            case "01":
                                {
                                    ///写入单个线圈
                                    if (ushort.Parse(value) > 0)
                                    {
                                        master.WriteSingleCoil(byte.Parse(Address), offset, true);
                                    }
                                    else
                                    {
                                        master.WriteSingleCoil(byte.Parse(Address), offset, false);
                                    }

                                }
                                break;
                            case "02"://此类型只能查询，不能写入
                                {


                                }
                                break;
                            case "03":
                                {

                                    switch (para.DataType)
                                    {
                                        case "float"://单精度浮点型
                                            {
                                                ushort[] buff = new ushort[2];
                                                float WriteValue = float.Parse(value);
                                                ModbusConvert.SetReal(buff, 0, WriteValue);
                                                master.WriteMultipleRegisters(byte.Parse(Address), offset, buff);
                                            }
                                            break;
                                        case "double"://双精度浮点数64位
                                            {
                                                ushort[] buff = new ushort[4];
                                                double WriteValue = double.Parse(value);
                                                ModbusConvert.SetDouble(buff, 0, WriteValue);
                                                master.WriteMultipleRegisters(byte.Parse(Address), offset, buff);
                                            }
                                            break;
                                        case "string"://字符型
                                            {
                                                ushort[] buff = new ushort[para.charsize];
                                                string WriteValue = value;
                                                if (value.Length > para.charsize)
                                                    WriteValue = value.Substring(0, para.charsize);
                                                if (value.Length < para.charsize)
                                                    WriteValue = value.PadRight(para.charsize, ' ');
                                                ModbusConvert.SetString(buff, 0, WriteValue);
                                                master.WriteMultipleRegisters(byte.Parse(Address), offset, buff);

                                            }
                                            break;

                                        case "byte"://无符号整数8位:
                                            {
                                                ushort[] buff = new ushort[1];
                                                byte WriteValue = byte.Parse(value);
                                                ModbusConvert.SetByte(buff, 0, WriteValue, true);
                                                master.WriteSingleRegister(byte.Parse(Address), offset, buff[0]);
                                            }
                                            break;
                                        case "sbyte"://有符号整数8位:
                                            {
                                                ushort[] buff = new ushort[1];
                                                sbyte WriteValue = sbyte.Parse(value);
                                                ModbusConvert.SetSByte(buff, 0, WriteValue, true);
                                                master.WriteSingleRegister(byte.Parse(Address), offset, buff[0]);

                                            }
                                            break;
                                        case "uint16"://无符号整数16位:
                                            {

                                                ushort WriteValue = ushort.Parse(value);
                                                ushort[] buff = new ushort[1];
                                                ModbusConvert.SetUShort(buff, 0, WriteValue);
                                                master.WriteSingleRegister(byte.Parse(Address), offset, buff[0]);

                                            }
                                            break;
                                        case "int16"://有符号整数16位:
                                            {

                                                Int16 WriteValue = Int16.Parse(value);
                                                ushort[] buff = new ushort[1];
                                                ModbusConvert.SetShort(buff, 0, WriteValue);
                                                master.WriteSingleRegister(byte.Parse(Address), offset, buff[0]);

                                            }
                                            break;
                                        case "uint32"://无符号整数32位:
                                            {
                                                uint WriteValue = uint.Parse(value);
                                                ushort[] buff = new ushort[2];
                                                ModbusConvert.SetUInt(buff, 0, WriteValue);
                                                master.WriteMultipleRegisters(byte.Parse(Address), offset, buff);
                                            }
                                            break;
                                        case "int32"://有符号整数32位:
                                            {
                                                int WriteValue = int.Parse(value);
                                                ushort[] buff = new ushort[2];
                                                ModbusConvert.SetInt(buff, 0, WriteValue);
                                                master.WriteMultipleRegisters(byte.Parse(Address), offset, buff);
                                            }
                                            break;
                                    }

                                }
                                break;
                        }


                    }
                }
                catch 
                {
                    return false;
                }
                return true;

            });

            return task;
        }
        
        public   void Close()
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                    serialPort.Close();
                
            }
            catch 
            {
 
            }
        }
    }
}
