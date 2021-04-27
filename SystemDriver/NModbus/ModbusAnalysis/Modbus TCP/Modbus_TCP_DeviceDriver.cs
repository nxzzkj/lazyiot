using Scada.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scada.Model;
using Scada.IOStructure;
using System.ComponentModel;
using Modbus.Globel;

namespace Modbus.ModbusAnalysis
{
 
    public class Modbus_TCP_DeviceDriver : ScadaDeviceKernel
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
        /// <summary>
        /// 解析数据
        /// </summary>
        /// <param name="server"></param>
        /// <param name="Communication"></param>
        /// <param name="device"></param>
        /// <param name="para"></param>
        /// <param name="datas"></param>
        /// <param name="datatime"></param>
        /// <param name="sender"></param>
        /// <returns></returns>
        protected override IOData Analysis(IO_SERVER server, IO_COMMUNICATION Communication, IO_DEVICE device, IO_PARA para, byte[] datas, DateTime datatime, object sender)
        {
            if (datas.Length > 0 && sender != null && para != null)
            {
                ParaPack paraPack = new ParaPack(para.IO_PARASTRING);
                ModbusFragmentStore modbusStore = (ModbusFragmentStore)sender;
                IOData data = new IOData();
                data.CommunicationID = Communication.IO_COMM_ID;
                data.ID = device.IO_DEVICE_ADDRESS;
                data.ParaName = para.IO_NAME;
                data.ServerID = server.SERVER_ID;
                data.Date = DateTime.Now;
                Modbus_Type dataType = (Modbus_Type)Enum.Parse(typeof(Modbus_Type), paraPack.GetValue("数据类型"));
                switch (dataType)
                {
                    case Modbus_Type.单精度浮点数32位:
                        data.DataType = typeof(float);
                        break;
                    case Modbus_Type.双精度浮点数64位:
                        data.DataType = typeof(double);
                        break;
                    case Modbus_Type.字符型:
                        data.DataType = typeof(string);
                        break;
                    case Modbus_Type.无符号整数16位:
                        data.DataType = typeof(UInt16);
                        break;
                    case Modbus_Type.无符号整数32位:
                        data.DataType = typeof(UInt32);
                        break;
                    case Modbus_Type.无符号整数8位:
                        data.DataType = typeof(byte);
                        break;
                    case Modbus_Type.有符号整数16位:
                        data.DataType = typeof(Int16);
                        break;
                    case Modbus_Type.有符号整数8位:
                        data.DataType = typeof(sbyte);
                        break;
                    case Modbus_Type.有符号整数32位:
                        data.DataType = typeof(int);
                        break;
                }
                data.datas = datas;
                data.ParaString = para.IO_PARASTRING;
                //获取数据值高八位,低八位
                int startaddr = int.Parse(paraPack.GetValue("偏置"));
                int charsize = int.Parse(paraPack.GetValue("字节长度"));
                string code = paraPack.GetValue("内存区");
                bool bitSave = paraPack.GetValue("按位存取") == "1" ? true : false;
                bool ishigh = paraPack.GetValue("存储位置") == "高八位" ? true : false;
                ModbusFragment fragment = modbusStore.Fragments.Find(x => x.Code == code && startaddr >= x.StartRegister && startaddr <= x.StartRegister + x.RegisterNum);
                if (fragment != null)
                {
                    switch (code)
                    {
                        case "01"://线圈
                            {
                                byte[] vdatas = new byte[fragment.Length];
                                Array.Copy(datas, fragment.StartIndex, vdatas, 0, fragment.Length);
                                data.ParaValue = vdatas[startaddr].ToString();
                            }
                            break;
                        case "02"://线圈只读
                            {
                                byte[] vdatas = new byte[fragment.Length];
                                Array.Copy(datas, fragment.StartIndex, vdatas, 0, fragment.Length);
                                data.ParaValue = vdatas[startaddr].ToString();
                            }
                            break;
                        case "03"://寄存器可读可写
                            {
                                //注意是否按位读取，
                                byte[] vdatas = new byte[fragment.Length];
                                Array.Copy(datas, fragment.StartIndex, vdatas, 0, fragment.Length);
                                ushort[] vals = ModbusConvert.Bytes2Ushorts(vdatas);//将字节数组转为ushort                     
                                switch (dataType)
                                {
                                    case Modbus_Type.单精度浮点数32位:
                                        {
                                            data.ParaValue = ModbusConvert.GetReal(vals, 0).ToString();
                                        }
                                        break;
                                    case Modbus_Type.双精度浮点数64位:
                                        {
                                            data.ParaValue = ModbusConvert.GetDouble(vals, 0).ToString();
                                        }
                                        break;
                                    case Modbus_Type.字符型:
                                        {
                                            data.ParaValue = ModbusConvert.GetString(vals, 0, charsize).ToString();
                                        }
                                        break;
                                    case Modbus_Type.无符号整数16位:
                                        {
                                            data.ParaValue = ModbusConvert.GetUShort(vals, 0).ToString();
                                        }
                                        break;
                                    case Modbus_Type.无符号整数32位:
                                        {
                                            data.ParaValue = ModbusConvert.GetUInt(vals, 0).ToString();
                                        }
                                        break;
                                    case Modbus_Type.无符号整数8位:
                                        {
                                            data.ParaValue = ModbusConvert.GetSByte(vals, 0, ishigh).ToString();
                                        }
                                        break;
                                    case Modbus_Type.有符号整数16位:
                                        {
                                            data.ParaValue = ModbusConvert.GetShort(vals, 0).ToString();
                                        }
                                        break;
                                    case Modbus_Type.有符号整数8位:
                                        {
                                            data.ParaValue = ModbusConvert.GetByte(vals, 0, ishigh).ToString();
                                        }
                                        break;
                                    case Modbus_Type.有符号整数32位:
                                        {
                                            data.ParaValue = ModbusConvert.GetInt(vals, 0).ToString();
                                        }
                                        break;
                                }

                            }
                            break;
                        case "04"://寄存器只读
                            {
                                //注意是否按位读取，
                                byte[] vdatas = new byte[fragment.Length];
                                Array.Copy(datas, fragment.StartIndex, vdatas, 0, fragment.Length);
                                ushort[] vals = ModbusConvert.Bytes2Ushorts(vdatas);//将字节数组转为ushort                     
                                switch (dataType)
                                {
                                    case Modbus_Type.单精度浮点数32位:
                                        {
                                            data.ParaValue = ModbusConvert.GetReal(vals, 0).ToString();
                                        }
                                        break;
                                    case Modbus_Type.双精度浮点数64位:
                                        {
                                            data.ParaValue = ModbusConvert.GetDouble(vals, 0).ToString();
                                        }
                                        break;
                                    case Modbus_Type.字符型:
                                        {
                                            data.ParaValue = ModbusConvert.GetString(vals, 0, charsize).ToString();
                                        }
                                        break;
                                    case Modbus_Type.无符号整数16位:
                                        {
                                            data.ParaValue = ModbusConvert.GetUShort(vals, 0).ToString();
                                        }
                                        break;
                                    case Modbus_Type.无符号整数32位:
                                        {
                                            data.ParaValue = ModbusConvert.GetUInt(vals, 0).ToString();
                                        }
                                        break;
                                    case Modbus_Type.无符号整数8位:
                                        {
                                            data.ParaValue = ModbusConvert.GetSByte(vals, 0, ishigh).ToString();
                                        }
                                        break;
                                    case Modbus_Type.有符号整数16位:
                                        {
                                            data.ParaValue = ModbusConvert.GetShort(vals, 0).ToString();
                                        }
                                        break;
                                    case Modbus_Type.有符号整数8位:
                                        {
                                            data.ParaValue = ModbusConvert.GetByte(vals, 0, ishigh).ToString();
                                        }
                                        break;
                                    case Modbus_Type.有符号整数32位:
                                        {
                                            data.ParaValue = ModbusConvert.GetInt(vals, 0).ToString();
                                        }
                                        break;
                                }

                            }
                            break;
                    }

                }

            }
            return null;
        }
        protected override bool InitDeviceKernel(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device, IO_PARA para, SCADA_DEVICE_DRIVER driver)
        {
                if (IsCreateControl)
                {
                    if (para != null)
                    {
                        this.ParaCtrl = new IOParaCtrl();
                        this.ParaCtrl.SetUIParameter(server, device, para);


                    }
                    this.DeviceCtrl = new IODeviceCtrl();
                    this.DeviceCtrl.SetUIParameter(server, device);
                }
                if (para != null)
                {
                    this.ParaString = para.IO_PARASTRING;
                }
                this.DeviceParaString = device.IO_DEVICE_PARASTRING;
            return true;
        }
        //由于此处Para里面设置的可能是不同命令的IO参数，所以需要返回不同命令的实时获取的数据,此处不需要返回Byte字节数组
        public   List<byte[]> GetDataCommandBytes(IO_SERVER server, IO_COMMUNICATION Communication, IO_DEVICE device, List<IO_PARA> paras, IO_PARA currentpara, ref object sender)
        {
            List<byte[]> cmmdBytes = new List<byte[]>();
            //必须Read的IO参数
            List<ModbusFragmentStore> modbusCodes = new List<ModbusFragmentStore>();
            for (int i = 0; i < paras.Count; i++)
            {
                ParaPack paraPack = new ParaPack(paras[i].IO_PARASTRING);
                if (!modbusCodes.Exists(x => x.StoredCode != paraPack.GetValue("内存区")) && paraPack.GetValue("内存区") != "")
                {
                    ModbusFragmentStore stored = new ModbusFragmentStore();
                    stored.StoredCode = paraPack.GetValue("内存区");
                    stored.Fragments = new List<ModbusFragment>();
                    stored.Units = new List<ushort>();
                }
                paraPack.Dispose();
                paraPack = null;
            }
            for (int i = 0; i < paras.Count; i++)
            {
                ParaPack paraPack = new ParaPack(paras[i].IO_PARASTRING);
                if (paraPack.GetValue("内存区") != "")
                {
                    if (modbusCodes.Exists(x => x.StoredCode != paraPack.GetValue("内存区")) && paraPack.GetValue("内存区") != "")
                    {
                        ModbusFragmentStore stored = modbusCodes.Find(x => x.StoredCode != paraPack.GetValue("内存区"));
                        if (paraPack.GetValue("偏置") != "")
                        {
                            ushort offset = 0;
                            if (ushort.TryParse(paraPack.GetValue("偏置"), out offset))
                            {
                                if (!stored.Units.Contains(offset))
                                    stored.Units.Add(offset);
                            }

                        }

                    }

                }

            }
            ModbusFragmentStore mainStored = new ModbusFragmentStore();
            //由于modbus获取寄存器最大数量是124个，所以要进行分段，最大线圈数量是1999个
            foreach (ModbusFragmentStore stored in modbusCodes)
            {
                stored.MakeFragment();
                mainStored.Fragments.AddRange(stored.Fragments);
            }
            //获取要解析的命令
            sender = mainStored;
            return cmmdBytes;
        }

    }
}
