using DeviceDriveBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO_Structure;
using ZZSCADA.Model;
using System.Windows.Forms;

namespace ModbusDevice
{
   
    /// <summary>
    /// 采用 Modbus TCP/IP协议
    /// </summary>
    public class Modbus : DeviceDrive
    {
        private ModbusAnalysis ModbusAnalysis = null;

        public override bool InitDrive(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device, IO_PARA para, DEVICE_DRIVER driver)
        {
            //必须调用此方法
            if(!base.InitDrive(server, communication, device, para, driver))
            {
                return false;
            }
            ///初始化驱动控件
            if (IsCreateControl)
            {
                if (para != null)
                {
                  
                  
                   
                        this.ParaCtrl = new ModbusControl();
                        ParaCtrl.Dock = DockStyle.Fill;
                        ParaCtrl.SetUIParameter(server, device, para);
               
                }

                if (device != null)
                {
                 
                    
                        this.DeviceCtrl = new ModbusDeviceControl();
                        DeviceCtrl.Dock = DockStyle.Fill;
                        DeviceCtrl.SetUIParameter(server, device);
                  
                
                }

            }

            try
            {
                //设备参数格式
                //Modbus类型:ASCII,字节存储:高位字节在前,起开地址:0,寄存器数量:200
                string[] str = device.IO_DEVICE_PARASTRING.Split(new char[2] { ':', ',' });

                if (str.Length == 4)
                {
                    ModBusProtocol mbp = ModBusProtocol.RTU;
                    switch (str[1].Trim().ToUpper())
                    {
                        case "ASCII":
                            mbp = ModBusProtocol.ASCII;
                            break;
                        case "RTU":
                            mbp = ModBusProtocol.RTU;
                            break;
                        case "SERIAL"://串口模式下的
                            mbp = ModBusProtocol.Serial;
                            break;
                    }
                    ModbusAnalysis = new ModbusAnalysis(mbp);
                }
                else
                {
                    ModbusAnalysis = new ModbusAnalysis(ModBusProtocol.RTU);
                }


            }
            catch (Exception emx)
            {
                this.DeviceException(emx.Message);
                return false;
            }
            return true;
        }
        
        public override void Dispose()
        {
            if (ParaCtrl != null)
            {
                ParaCtrl.Dispose();
            }
            ParaCtrl = null;


        }
        /// <summary>
        /// 获取某个参数的解析数据,如果该参数还没有接收到数返回为null
        /// </summary>
        /// <param name="server"></param>
        /// <param name="device"></param>
        /// <param name="para"></param>
        /// <param name="datas"></param>
        /// <param name="datatime"></param>
        /// <returns></returns>
        protected override IOData Analysis(IO_SERVER server,IO_COMMUNICATION communication, IO_DEVICE device, IO_PARA para, byte[] datas, DateTime datatime)
        {
           
    
            try
            {


                //02号功能码 (DI离散输入量)
                //01号和05号功能码 (DI离散输入量)
                //03号功能码 (HR保持寄存器)
                //04号功能码 (AR保持寄存器)
                //08号功能码 (诊断)
                //15号功能码 (强制多个寄存器)
                //07号功能码 (读不正常状态)
                //构造字符串
                // 线圈状态 = 1,
                //读输入状态 = 2,
                //读保持型寄存器 = 3,
                //读输入型寄存器 = 4,
                //强制单个线圈 = 5,
                //写单个寄存器 = 6,
                //强制多个线圈 = 15,
                //写多个寄存器 = 16,
                //读变量 = 20,
                //写变量 = 21,
                //错误信息 = 80,
                //NONE
                string parastring = para.IO_PARASTRING;
                ModbusData analysisData = ModbusAnalysis.ReceiveAnalysis(datas);
                IOData data = new IOData();
                data.QualityStamp = QualityStamp.BAD;
                data.ParaValue = "-9999";
                data.Date = DateTime.Now;
                data.ID = para.IO_ID;
                data.CommunicationID = communication.IO_COMM_ID;
                data.ParaName = para.IO_NAME;
                data.ServerID = server.SERVER_ID;
                string[] paras = parastring.Split(',');//读取参数设置的所有参数格式
                if (paras.Length < 8)
                    return data;
                int function = int.Parse(paras[0].Split(':')[1].Trim());//功能码
                int deviation = int.Parse(paras[1].Split(':')[1].Trim());//偏置量
                if (Convert.ToInt32(analysisData.FunctionCode) > 30)//大于80标识返回的是错误信息
                {
                    base.DeviceException(analysisData.FunctionCode.ToString());
                }
                if (Convert.ToInt32(analysisData.FunctionCode) != function)//如果接收的数据功能码和参数功能码不一致，则放弃该数据，否则继续下步解析
                {
                    return data;
                }
                //判断寄存器存储的数据类型，不同的类型占用数据字节不一样
                Type datatype = typeof(short);
                int numunit = 1;//判读当前占用的字节
                switch (paras[2].Split(':')[1].Trim())
                {
                    case "8位有符号":
                        datatype = typeof(sbyte);
                        numunit = 2;
                        break;
                    case "8位无符号":
                        datatype = typeof(byte);
                        numunit = 2;
                        break;
                    case "16位有符号":
                        datatype = typeof(Int16);
                        numunit = 2;
                        break;
                    case "16位无符号":
                        datatype = typeof(UInt16);
                        numunit = 2;
                        break;
                    case "32位有符号":
                        datatype = typeof(Int32);
                        numunit = 4;
                        break;
                    case "32位无符号":
                        datatype = typeof(UInt32);
                        numunit = 4;
                        break;
                    case "字符型":
                        datatype = typeof(String);
                        break;
                    case "32位浮点型":
                        datatype = typeof(float);
                        numunit = 4;
                        break;
                    case "64位双精度浮点型":
                        datatype = typeof(double);
                        numunit = 8;
                        break;
                    default:
                        datatype = typeof(byte);
                        numunit = 2;
                        break;
                }
                bool isbanary = false;//是否按位读写
                int banarynumber = int.Parse(paras[6].Split(':')[1].Trim());
                if (paras[5].Split(':')[1].Trim() == "1")
                {
                    isbanary = true;
                }
                else
                {
                    isbanary = false;
                }


                if (paras.Length == 8)
                {
                    if (paras[7].Split('|')[1].Trim() == BitStoreMode.低位字节在前.ToString())
                    {
                        data.BitStoreMode = BitStoreMode.低位字节在前;
                    }
                    else
                    {
                        data.BitStoreMode = BitStoreMode.高位字节在前;
                    }
                }


                //判断当前返回寄存器的个数

                if (deviation<analysisData.StartAddress|| numunit> analysisData.MCount)
                {
                    //返回空值表示当前寄存器
                    return null;
                }

                if (isbanary == false)
                {
                    try
                    {
                        byte[] valuebyte = new byte[numunit];
                        int index = (deviation - 1) * 2 + 3;
                        if (index <= 0 || index >= analysisData.Data.Length)
                        {
                            base.DeviceException("error=10114 模拟量数据解析错误  数据点配置超过返回的数据点长度");

                        }
                        if (analysisData.Data.Length > numunit + index)
                        {

                            Array.Copy(analysisData.Data, index, valuebyte, 0, valuebyte.Length);//拷贝数据

                       
                            data.datas = valuebyte;
                            data.DataType = datatype;
                            data.Date = DateTime.Now;
                            data.ID = analysisData.SlaveID.ToString();                
                            data.ParaName = para.IO_NAME;

                            data.ParaValue = ConvertType.BytesToBit(valuebyte, datatype, data.BitStoreMode).ToString();
                            if (data.ParaValue == null)
                            {
                                data.ParaValue = "-9999";
                            }
                            data.ParaString = parastring;
                            if (data.ParaValue != "-9999")
                            {
                                data.QualityStamp = QualityStamp.GOOD;
                            }
                            else
                            {
                                data.QualityStamp = QualityStamp.BAD;
                            }
                        }
                    }
                    catch (Exception emx)
                    {

                        base.DeviceException("error HA111" + emx.Message);
                    }


                }
                else //如果按照位读取
                {

                    int index = (deviation - 1) * 2 + 3;
                    if (index <= 0 || index >= analysisData.Data.Length)
                    {
                        this.DeviceException("error= HA11115开关量数据解析错误  数据点配置超过返回的数据点长度");
                      
                    }

                    if (analysisData.Data.Length > 2 + index)
                    {

                        try
                        {
                            byte[] valuebyte = new byte[2];//按位读取的话，首先读取一个寄存器地址，并将该地址
                            Array.Copy(analysisData.Data, index, valuebyte, 0, valuebyte.Length);//拷贝数据

                            object num = ConvertType.BytesToBit(valuebyte, datatype, data.BitStoreMode).ToString();



                            if (datatype == typeof(UInt16))
                            {

                                data.ParaValue = string.Format("{0}", Convert.ToUInt16(num) >> banarynumber & 1);
                                data.QualityStamp = QualityStamp.GOOD;
                            }
                            else if (datatype == typeof(Int16))
                            {
                                data.ParaValue = string.Format("{0}", Convert.ToInt16(num) >> banarynumber & 1);
                                data.QualityStamp = QualityStamp.GOOD;

                            }
                            else if (datatype == typeof(sbyte))
                            {
                                data.ParaValue = string.Format("{0}", Convert.ToSByte(num) >> banarynumber & 1);
                                data.QualityStamp = QualityStamp.GOOD;

                            }
                            else if (datatype == typeof(byte))
                            {
                                data.ParaValue = string.Format("{0}", Convert.ToByte(num) >> banarynumber & 1);
                                data.QualityStamp = QualityStamp.GOOD;

                            }
                            else if (datatype == typeof(Int32))
                            {
                                data.ParaValue = string.Format("{0}", Convert.ToInt32(num) >> banarynumber & 1);
                                data.QualityStamp = QualityStamp.GOOD;

                            }
                            else if (datatype == typeof(UInt32))
                            {
                                data.ParaValue = string.Format("{0}", Convert.ToUInt32(num) >> banarynumber & 1);

                                data.QualityStamp = QualityStamp.GOOD;
                            }
                            if (banarynumber < 0 && banarynumber >= 16)
                            {

                                this.DeviceException("error=D10001  数据位数应该在0-15的范围内");
                                data.QualityStamp = QualityStamp.BAD;
                                data.ParaValue = "-9999";
                            }
                            data.datas = valuebyte;
                            data.DataType = datatype;
                            data.Date = DateTime.Now;
                            data.ID = analysisData.SlaveID.ToString();
                       
                            data.ParaName = para.IO_NAME;
                            data.ParaString = parastring;
                        }

                        catch (Exception emx)
                        {
                            this.DeviceException(emx.Message);

                        }

                    }
                }

                return data;
            }
            catch (Exception emx)
            {

                this.DeviceException(emx.Message);
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datastr"></param>
        /// <returns></returns>
        public override byte[] GetStringBytes(string datastr)
        {
          return  base.GetStringBytes(datastr);
        }
        /// <summary>
        /// 此处要处理读取命令，由于modbus报文最大读取123个寄存器地址，此处需要对寄存器进行分段读取
        /// </summary>
        /// <param name="server"></param>
        /// <param name="communication"></param>
        /// <param name="device"></param>
        /// <param name="paras"></param>
        /// <param name="currentpara"></param>
        /// <returns></returns>
        public override List<byte[]> GetDataCommandBytes(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device, List<IO_PARA> paras, IO_PARA currentpara)
        {
            if (device.IO_DEVICE_PARASTRING == null)
                device.IO_DEVICE_PARASTRING = "";
            string[] str = device.IO_DEVICE_PARASTRING.Split(new char[2] { ':', ',' });
            if (str.Length != 4)
                return null;
            List<byte[]> byteArray = new List<byte[]>();
            //设备参数格式
            //Modbus类型:ASCII,字节存储:高位字节在前,起开地址:0,寄存器数量:200
            int devadd = Convert.ToInt16(device.IO_DEVICE_ADDRESS);//设备地址


            #region 分段读取寄存器地址
            List<ModbusStore> stores = new List<ModbusStore>();
            int startunit = 9999999;
            int endunit = 0;
            string storecode = "03";
            foreach (IO_PARA para in paras)
            {

                if (para.IO_POINTTYPE != "计算值" && para.IO_PARASTRING.Trim() != "")
                {

                    string[] parastrs = para.IO_PARASTRING.Split(',');
                    if (parastrs.Length != 8)
                        continue;
                    storecode = parastrs[0].Split(':')[1].Trim();//读取存储区域
                    ModbusStore nowStored = stores.Find(x => x.StoredCode.Trim() == storecode);
                    if(nowStored==null)
                    {
                        nowStored = new ModbusStore();
                        nowStored.StoredCode = storecode;
                        stores.Add(nowStored);
                    }

                    startunit = Math.Min(int.Parse(parastrs[1].Split(':')[1]), startunit);
                    endunit = Math.Max(int.Parse(parastrs[1].Split(':')[1]), endunit);
                    if (!nowStored.Units.Contains(int.Parse(parastrs[1].Split(':')[1])))
                    {
                        nowStored.Units.Add(int.Parse(para.IO_PARASTRING.Split(',')[1].Split(':')[1]));
                    }
                }

            }
            ///进行寄存器地址分段处理
            for (int i = 0; i < stores.Count; i++)
            {
                stores[i].MakeFragment();
                foreach (ModbusRegisterFragment frag in stores[i].Fragments)
                {

                    switch (stores[i].StoredCode)
                    {
                        case "03":
                            {
                                byteArray.Add(ModbusAnalysis.ReadKeepReg(devadd, frag.StartRegister, frag.RegisterNum));
                            }
                            break;
                        case "04":
                            {
                                byteArray.Add(ModbusAnalysis.ReadInputReg(devadd, frag.StartRegister, frag.RegisterNum));
                            }

                            break;
                        case "02":
                            {
                                byteArray.Add(ModbusAnalysis.ReadInputStatus(devadd, frag.StartRegister, frag.RegisterNum));
                            }
                            break;
                        case "01":
                            {
                                byteArray.Add(ModbusAnalysis.ReadOutputStatus(devadd, frag.StartRegister, frag.RegisterNum));
                            }
                            break;



                    }


                }
            }
            #endregion
           


            return byteArray;


        }
        //获取要下发命令的数据字节
        public override byte[] GetSendValueBytes(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device, IO_PARA para, string setvalue)
        {
            try
            {
                string parastring = para.IO_PARASTRING;

                string[] paras = parastring.Split(',');//读取参数设置的所有参数格式
                if (paras.Length < 8)
                    return null;

                long deviation = long.Parse(paras[1].Split(':')[1].Trim());//偏置量

                //判断寄存器存储的数据类型，不同的类型占用数据字节不一样
                Type datatype = typeof(short);

                switch (paras[2].Split(':')[1].Trim())
                {
                    case "8位有符号":
                        datatype = typeof(sbyte);

                        break;
                    case "8位无符号":
                        datatype = typeof(byte);

                        break;
                    case "16位有符号":
                        datatype = typeof(Int16);

                        break;
                    case "16位无符号":
                        datatype = typeof(UInt16);

                        break;
                    case "32位有符号":
                        datatype = typeof(Int32);

                        break;
                    case "32位无符号":
                        datatype = typeof(UInt32);

                        break;
                    case "字符型":
                        datatype = typeof(String);
                        break;
                    case "32位浮点型":
                        datatype = typeof(float);

                        break;
                    case "64位双精度浮点型":
                        datatype = typeof(double);

                        break;
                    default:
                        datatype = typeof(byte);

                        break;


                }

                bool isbanary = false;//是否按位读写
                int banarynumber = int.Parse(paras[6].Split(':')[1].Trim());
                if (paras[5].Split(':')[1].Trim() == "1")
                {
                    isbanary = true;
                }
                else
                {
                    isbanary = false;
                }
                BitStoreMode BitStoreMode = BitStoreMode.低位字节在前;

                if (isbanary == false)//非按位值
                {


                    if (paras.Length == 8)
                    {
                        if (paras[7].Split(':')[1].Trim() == BitStoreMode.低位字节在前.ToString())
                        {
                            BitStoreMode = BitStoreMode.低位字节在前;
                        }
                        else
                        {
                            BitStoreMode = BitStoreMode.高位字节在前;
                        }
                    }
                }
                else
                {

                }
                if (deviation > 0)
                {
                    deviation--;
                }
                return ModbusAnalysis.PreSetKeepReg(int.Parse(device.IO_DEVICE_ADDRESS), deviation, setvalue, datatype, BitStoreMode);
            }
            catch (Exception emx)
            {
                base.DeviceException("error HA1004 " + emx.Message);
            }
            return new byte[0];
        }
      

    }
}
