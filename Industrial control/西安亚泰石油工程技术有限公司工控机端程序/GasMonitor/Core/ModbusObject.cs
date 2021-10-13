using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMonitor
{
    public class RealData
    {
        public string ParaName { set; get; }
        /// <summary>
        /// 设备地址
        /// </summary>
        public string Address
        {
            set;get;
        }
 

        //丛机ID号
        public string SlaveId
        {
            set;
            get;
        }


        /// <summary>
        /// 读取或者接收的数据
        /// </summary>
        public byte[] ReadSendByte
        {

            set;
            get;
        }
        public ModbusFragment Fragment = null;
        
      
    }
    /// <summary>
    ///     Defines constants related to the Modbus protocol.
    /// </summary>
    internal static class Modbus
    {
        // supported function codes
        //读取DO的状态
        public const byte ReadCoils = 1;
        //读取DI的状态
        public const byte ReadInputs = 2;
        //读取AO的值
        public const byte ReadHoldingRegisters = 3;
        //读取AI的值
        public const byte ReadInputRegisters = 4;
        //写入值到DO
        public const byte WriteSingleCoil = 5;
        //写入值到AO
        public const byte WriteSingleRegister = 6;
        //诊断
        public const byte Diagnostics = 8;
        public const ushort DiagnosticsReturnQueryData = 0;
        //写多线圈寄存器
        public const byte WriteMultipleCoils = 15;
        //写多个保持寄存器
        public const byte WriteMultipleRegisters = 16;
        //读写多个保持寄存器
        public const byte ReadWriteMultipleRegisters = 23;



        public const int MaximumDiscreteRequestResponseSize = 2040;
        public const int MaximumRegisterRequestResponseSize = 127;

        // modbus slave exception offset that is added to the function code, to flag an exception
        //添加到功能代码以标记异常的modbus从异常偏移量
        public const byte ExceptionOffset = 128;

        // modbus slave exception codes
        public const byte IllegalFunction = 1;
        public const byte IllegalDataAddress = 2;
        public const byte Acknowledge = 5;
        public const byte SlaveDeviceBusy = 6;

        // default setting for number of retries for IO operations
        //IO操作重试次数的默认设置
        public const int DefaultRetries = 3;

        // default number of milliseconds to wait after encountering an ACKNOWLEGE or SLAVE DEVIC BUSY slave exception response.
        // 遇到ACKNOWLEGE或从属设备忙从属异常响应后等待的默认毫秒数。
        public const int DefaultWaitToRetryMilliseconds = 250;

        // default setting for IO timeouts in milliseconds
        //O超时的默认设置（毫秒）
        public const int DefaultTimeout = 1000;

        // smallest supported message frame size (sans checksum)
        //支持的最小消息帧大小（无校验和）
        public const int MinimumFrameSize = 2;

        public const ushort CoilOn = 0xFF00;
        public const ushort CoilOff = 0x0000;

        // IP slaves should be addressed by IP
        public const byte DefaultIpSlaveUnitId = 0;


        // An existing connection was forcibly closed by the remote host
        public const int ConnectionResetByPeer = 10054;

        // Existing socket connection is being closed
        public const int WSACancelBlockingCall = 10004;

        // used by the ASCII tranport to indicate end of message
        public const string NewLine = "\r\n";
    }
    /// <summary>
    ///   NModbus提供的对寄存器读写方法，只包括ushort类型，需要对ushort进行进行转换。封装转换类型
    /// </summary>

    public abstract class ModbusConvert
    { /// <summary>
      /// 带空格的16进制字符串
      /// </summary>
      /// <param name="da"></param>
      /// <returns></returns>
        public static string ByteToHexStr(byte[] da)
        {
            string str = "";
            for (int i = 0; i < da.Length; i++)
            {
                str = str + Convert.ToString(da[i], 0x10).PadLeft(2, '0') + " ";
            }
            return str;
        }
        public static object BytesToBit(byte[] ndatas, Type type)
        {
            //当前电脑是高位字节在前低位字节在后
            if (ndatas.Length <= 0)//必须大于0
                return -9999;
            if (ndatas.Length % 2 != 0)
            {
                return -9999;
            }

            byte[] data = new byte[ndatas.Length];

            data = ndatas;

            if (type == typeof(byte))
            {
                if (data.Length == 2)
                {


                    return BitConverter.ToInt16(data, 0);
                }



            }
            else if (type == typeof(sbyte))
            {

                if (data.Length == 2)
                {

                    return BitConverter.ToInt16(data, 0);
                }

            }
            else if (type == typeof(Int16))
            {
                if (data.Length == 2)
                {

                    return BitConverter.ToInt16(data, 0);

                }

            }
            else if (type == typeof(UInt16))
            {

                if (data.Length == 2)
                {

                    return BitConverter.ToUInt16(data, 0);

                }

            }

            return null;
        }
        /// <summary>
        /// 赋值string
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetString(ushort[] src, int start, string value)
        {
            byte[] bytesTemp = Encoding.UTF8.GetBytes(value);
            ushort[] dest = Bytes2Ushorts(bytesTemp);
            dest.CopyTo(src, start);
        }

        /// <summary>
        /// 获取string
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string GetString(ushort[] src, int start, int len)
        {
            ushort[] temp = new ushort[len];
            for (int i = 0; i < len; i++)
            {
                temp[i] = src[i + start];
            }
            byte[] bytesTemp = Ushorts2Bytes(temp);
            string res = Encoding.UTF8.GetString(bytesTemp).Trim(new char[] { '\0' });
            return res;
        }

        /// <summary>
        /// 赋值Real类型数据
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <param name="value"></param>
        public static void SetReal(ushort[] src, int start, float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            ushort[] dest = Bytes2Ushorts(bytes);

            dest.CopyTo(src, start);
        }

        /// <summary>
        /// 获取float类型数据
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static float GetReal(ushort[] src, int start)
        {
            ushort[] temp = new ushort[2];
            for (int i = 0; i < 2; i++)
            {
                temp[i] = src[i + start];
            }
            byte[] bytesTemp = Ushorts2Bytes(temp);
            float res = BitConverter.ToSingle(bytesTemp, 0);
            return res;
        }

        /// <summary>
        /// 赋值int类型数据
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <param name="value"></param>
        public static void SetInt(ushort[] src, int start, int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            ushort[] dest = Bytes2Ushorts(bytes);

            dest.CopyTo(src, start);
        }

        /// <summary>
        /// 获取int类型数据
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static int GetInt(ushort[] src, int start)
        {
            ushort[] temp = new ushort[2];
            for (int i = 0; i < 2; i++)
            {
                temp[1 - i] = src[i + start];
            }
            byte[] bytesTemp = Ushorts2Bytes(temp);
            int res = BitConverter.ToInt32(bytesTemp, 0);
            return res;
        }
        /// <summary>
        /// 赋值int类型数据
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <param name="value"></param>
        public static void SetUInt(ushort[] src, int start, uint value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            ushort[] dest = Bytes2Ushorts(bytes);

            dest.CopyTo(src, start);
        }

        /// <summary>
        /// 获取int类型数据
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static uint GetUInt(ushort[] src, int start)
        {
            ushort[] temp = new ushort[2];
            for (int i = 0; i < 2; i++)
            {
                temp[1-i] = src[i + start];
            }
            byte[] bytesTemp = Ushorts2Bytes(temp);
            uint res = BitConverter.ToUInt32(bytesTemp, 0);
            return res;
        }
        /// <summary>
        /// 赋值Real类型数据
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <param name="value"></param>
        public static void SetDouble(ushort[] src, int start, Double value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            ushort[] dest = Bytes2Ushorts(bytes);

            dest.CopyTo(src, start);
        }

        /// <summary>
        /// 获取Double(类型数据
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static Double GetDouble(ushort[] src, int start)
        {
            ushort[] temp = new ushort[4];
            for (int i = 0; i < 4; i++)
            {
                temp[i] = src[i + start];
            }
            byte[] bytesTemp = Ushorts2Bytes(temp);
            double res = BitConverter.ToDouble(bytesTemp, 0);
            return res;
        }
        /// <summary>
        /// 赋值byte类型数据
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <param name="value"></param>
        public static void SetByte(ushort[] src, int start, byte value, bool ishight)
        {

            byte[] bytes = new byte[2];
            if (ishight)
            {
                bytes[0] = value;
                bytes[1] = 0;
            }
            else
            {
                bytes[0] = 0;
                bytes[1] = value;
            }

            ushort[] dest = Bytes2Ushorts(bytes);

            dest.CopyTo(src, start);
        }
        /// <summary>
        /// 获取byte类型数据
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static byte GetByte(ushort[] src, int start, bool ishight)
        {
            ushort[] temp = new ushort[1];
            temp[0] = src[start];
            byte[] bytesTemp = Ushorts2Bytes(temp);
            if (ishight)
            {
                return bytesTemp[0];
            }
            else
            {
                return bytesTemp[1];
            }

        }
        /// <summary>
        /// 赋值byte类型数据
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <param name="value"></param>
        public static void SetSByte(ushort[] src, int start, sbyte value, bool ishight)
        {

            sbyte[] bytes = new sbyte[2];
            if (ishight)
            {
                bytes[0] = value;
                bytes[1] = 0;
            }
            else
            {
                bytes[0] = 0;
                bytes[1] = value;
            }
            byte[] arr = new byte[2];
            Buffer.BlockCopy(bytes, 0, arr, 0, bytes.Length);
            ushort[] dest = Bytes2Ushorts(arr);
            dest.CopyTo(src, start);
        }
        /// <summary>
        /// 获取byte类型数据
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static sbyte GetSByte(ushort[] src, int start, bool ishight)
        {
            ushort[] temp = new ushort[1];
            temp[0] = src[start];
            byte[] bytesTemp = Ushorts2Bytes(temp);
            sbyte[] arr = new sbyte[2];
            Buffer.BlockCopy(bytesTemp, 0, arr, 0, bytesTemp.Length);
            if (ishight)
            {
                return arr[0];
            }
            else
            {
                return arr[1];
            }

        }
        /// <summary>
        /// 赋值Short类型数据
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <param name="value"></param>
        public static void SetShort(ushort[] src, int start, short value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            ushort[] dest = Bytes2Ushorts(bytes);

            dest.CopyTo(src, start);
        }
        /// <summary>
        /// 获取short类型数据
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static short GetShort(ushort[] src, int start)
        {
            ushort[] temp = new ushort[1];
            temp[0] = src[start];
            byte[] bytesTemp = Ushorts2Bytes(temp);
            short res = BitConverter.ToInt16(bytesTemp, 0);
            return res;
        }
        /// <summary>
        /// 赋值UShort类型数据
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <param name="value"></param>
        public static void SetUShort(ushort[] src, int start, ushort value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            ushort[] dest = Bytes2Ushorts(bytes);

            dest.CopyTo(src, start);
        }

        public static ushort GetUShort(ushort[] src, int start)
        {
            ushort[] temp = new ushort[1];
            temp[0] = src[start];
            byte[] bytesTemp = Ushorts2Bytes(temp);
            ushort res = BitConverter.ToUInt16(bytesTemp, 0);
            return res;
        }

        public static bool[] GetBools(ushort[] src, int start, int num)
        {
            ushort[] temp = new ushort[num];
            for (int i = start; i < start + num; i++)
            {
                temp[i] = src[i + start];
            }
            byte[] bytes = Ushorts2Bytes(temp);

            bool[] res = Bytes2Bools(bytes);

            return res;
        }

        private static bool[] Bytes2Bools(byte[] b)
        {
            bool[] array = new bool[8 * b.Length];

            for (int i = 0; i < b.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    array[i * 8 + j] = (b[i] & 1) == 1;//判定byte的最后一位是否为1，若为1，则是true；否则是false
                    b[i] = (byte)(b[i] >> 1);//将byte右移一位
                }
            }
            return array;
        }

        private static byte Bools2Byte(bool[] array)
        {
            if (array != null && array.Length > 0)
            {
                byte b = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (array[i])
                    {
                        byte nn = (byte)(1 << i);//左移一位，相当于×2
                        b += nn;
                    }
                }
                return b;
            }
            return 0;
        }

        public static ushort[] Bytes2Ushorts(byte[] src, bool reverse = false)
        {
            int len = src.Length;

            byte[] srcPlus = new byte[len + 1];
            src.CopyTo(srcPlus, 0);
            int count = len >> 1;

            if (len % 2 != 0)
            {
                count += 1;
            }

            ushort[] dest = new ushort[count];
            if (reverse)
            {
                for (int i = 0; i < count; i++)
                {
                    dest[i] = (ushort)(srcPlus[i * 2] << 8 | srcPlus[2 * i + 1] & 0xff);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    dest[i] = (ushort)(srcPlus[i * 2] & 0xff | srcPlus[2 * i + 1] << 8);
                }
            }

            return dest;
        }

        public static byte[] Ushorts2Bytes(ushort[] src, bool reverse = false)
        {

            int count = src.Length;
            byte[] dest = new byte[count << 1];
            if (reverse)
            {
                for (int i = 0; i < count; i++)
                {
                    dest[i * 2] = (byte)(src[i] >> 8);
                    dest[i * 2 + 1] = (byte)(src[i] >> 0);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    dest[i * 2] = (byte)(src[i] >> 0);
                    dest[i * 2 + 1] = (byte)(src[i] >> 8);
                }
            }
            return dest;
        }

        /// <summary>
        /// 将布尔值的变量转换成对应的位byte
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static byte[] BoolToByte(bool[] bools)
        {
            byte[] bytes = new byte[bools.Length];
            for (int i = 0; i < bools.Length; i++)
            {
                if (bools[i])
                {
                    bytes[i] = 1;

                }
                else
                {
                    bytes[i] = 0;
                }

            }
            return bytes;
        }
        /// <summary>
        /// 写入测试
        /// </summary>
        //private void WriteExecute()
        //{
        //    try
        //    {
        //        if (VariableType == "real")
        //        {
        //            ushort[] buff = new ushort[2];
        //            float value = float.Parse(WriteValue);
        //            MODBUS.SetReal(buff, 0, value);
        //            modbus.WriteMultipleRegisters(SlaveID, WriteAddress, buff);
        //        }
        //        else if (VariableType == "string")
        //        {
        //            ushort[] buff = new ushort[10];
        //            MODBUS.SetString(buff, 0, WriteValue);
        //            modbus.WriteMultipleRegisters(SlaveID, WriteAddress, buff);
        //        }
        //        else if (VariableType == "Int16")
        //        {
        //            ushort[] buff = new ushort[1];
        //            short value = short.Parse(WriteValue);
        //            MODBUS.SetShort(buff, 0, value);
        //            modbus.WriteMultipleRegisters(SlaveID, WriteAddress, buff);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Msg.Info(ex.Message);
        //    }
        //}
        /// <summary>
        /// 读取测试
        /// </summary>
        //private void ReadExecute()
        //{
        //    try
        //    {
        //        if (VariableType == "real")
        //        {
        //            ushort[] buff = modbus.ReadHoldingRegisters(SlaveID, ReadAddress, 2);
        //            float value = MODBUS.GetReal(buff, 0);
        //            ReadValue = value.ToString();
        //        }
        //        else if (VariableType == "string")
        //        {
        //            ushort[] buff = modbus.ReadHoldingRegisters(SlaveID, ReadAddress, 10);
        //            ReadValue = MODBUS.GetString(buff, 0, 10);
        //        }
        //        else if (VariableType == "Int16")
        //        {
        //            ushort[] buff = modbus.ReadHoldingRegisters(SlaveID, ReadAddress, 1);
        //            short value = MODBUS.GetShort(buff, 0);
        //            ReadValue = value.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Msg.Info(ex.Message);
        //    }
        //}
    }
    /// <summary>
    /// Modbus分段
    /// </summary>
    public class ModbusFragment
    {
        public ushort StartRegister = 5;
        //一次最小读取8个单元
        public ushort RegisterNum = 8;
        /// <summary>
        /// 命令
        /// </summary>
        public string Code = "03";
     
      
        public string DataType = "uint";
        /// <summary>
        /// 如果是字符串类型的,则要求固定字符串长度
        /// </summary>
        public int charsize = 6;
    }
    /// <summary>
    /// modbus分段存储的方法
    /// </summary>
    public class ModbusFragmentStore
    {
        public string StoredCode = "";
        public List<ModbusFragment> Fragments = new List<ModbusFragment>();
        public List<ushort> Units = new List<ushort>();
        public void MakeFragment()
        {
            //先进行排序
            for (int i = 0; i < Units.Count; i++)
            {
                ushort temp = Units[i];
                int j = i;
                while ((j > 0) && (Units[j - 1] > temp))
                {
                    Units[j] = Units[j - 1];
                    --j;
                }
                Units[j] = temp;
            }
            int maxnum = 123;
            if (StoredCode == "03" || StoredCode == "04")
                maxnum = 123;
            else
                maxnum = 1999;
            Fragments = new List<ModbusFragment>();
            ModbusFragment fragment = null;
            bool iscreate = true;
            for (int i = 0; i < Units.Count; i++)
            {
                if (iscreate)
                {
                    fragment = new ModbusFragment();
                    fragment.Code = this.StoredCode;
                    fragment.StartRegister = Units[i];
                    Fragments.Add(fragment);
                    iscreate = false;
                }
                else
                {
                    ushort num = Convert.ToUInt16(Units[i] - fragment.StartRegister + 9);
                    ushort num2 = Convert.ToUInt16(Units[i - 1] - fragment.StartRegister + 9);
                    if (num >= maxnum)
                    {
                        if (num == maxnum)
                        {
                            fragment.RegisterNum = num;
                        }
                        else if (num2 <= maxnum)
                        {
                            fragment.RegisterNum = num2;
                            i--;

                        }
                        iscreate = true;
                    }
                    else
                    {
                        fragment.RegisterNum = num;
                        iscreate = false;
                    }

                }

            }
        }
    }
}
