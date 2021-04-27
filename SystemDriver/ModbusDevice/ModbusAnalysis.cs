using IO_Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusDevice
{
    /// <summary>
    /// 接收的数据错误代码
    /// </summary>
    public enum ModbusErrorCode
    {
        不支持该功能码 = 1,
        越界 = 2,
        寄存器数量超出范围 = 3,
        读写错误 = 4,
        NONE
    }
    /// <summary>
    /// 接收到的数据信息
    /// </summary>
    public class ModbusData
    {
        /// <summary>
        /// 从机地址
        /// </summary>
        public byte SlaveID { get; set; }
        /// <summary>
        /// 功能码
        /// </summary>
        public byte Code { get; set; }

        /// <summary>
        /// 寄存器个数
        /// </summary>
        public int MCount { get; set; }
        /// <summary>
        /// 数值值列表
        /// </summary>
        public byte[] Data { get; set; }
        public ModbusErrorCode ModbusErrorCode
        {
            set;
            get;
        }
        public FunctionCode FunctionCode
        {
            set;
            get;
        }
        public byte[] CRCData { get; set; }
        public int StartAddress
        {
            set;
            get;
        }
        public int Hight
        {
            set;
            get;
        }
        /// <summary>
        /// 高8位
        /// </summary>
        public int High8Bit
        {
            set;
            get;
        }
        //低8位
        public int Low8Bit
        {
            set;
            get;
        }
        /// <summary>
        /// 数据长度
        /// </summary>
        public byte DataLength { get; set; }
    }

    /// <summary>
    /// 通讯协议
    /// </summary>
    public enum ModBusProtocol
    {
        Serial,//串口
        RTU,//RTU
        ASCII


    }
    /// <summary>
    /// 功能码
    /// </summary>
    public enum FunctionCode
    {
        读线圈状态 = 1,
        读输入状态 = 2,
        读保持型寄存器 = 3,
        读输入型寄存器 = 4,
        强制单个线圈 = 5,
        写单个寄存器 = 6,
        强制多个线圈 = 15,
        写多个寄存器 = 16,
        读变量 = 20,
        写变量 = 21,
        错误信息 = 80,
        NONE

    }
    //0E 83 02 F0 F2  
    /// <summary>
    ///
    /// </summary>
    public class ModbusAnalysis
    {

        private int CurrentAddr;//定义当前通讯设备的地址
        private byte[] bData = new byte[1024];//最大接受的1024个字节
        private string strErrMsg;//错误信息
        private string strUpData, strDownData;//定义上行及下行数据字符串
        private string mTempStr;
        public ModBusProtocol mRtuFlag = ModBusProtocol.Serial;//定义通讯协议
        private byte mReceiveByte;
        private int mReceiveByteCount;
        private long iMWordStartAddr, iMBitStartAddr;//保持寄存器及输出线圈的起始地址
        private int iMWordLen, iMBitLen;//保持寄存器及输出线圈长度
        private UInt16[,] MWordVaue = new UInt16[16, 256];//定义最大保持寄存器二维数组 
        private bool[,] MBitVaue = new bool[16, 256];//定义输出线圈二维数组
        private byte ucCRCHi = 0xFF;
        private byte ucCRCLo = 0xFF;


        public ModbusAnalysis(ModBusProtocol proctocl)
        {

            mRtuFlag = proctocl;

        }
        #region 校验码
        // LRC CHECK FROM CSDN MODIFY BY LIGUANG
        #region  LRC CHECK FROM CSDN MODIFY BY LIGUANG
        private string LRC(string strLRC)
        {
            int d_lrc = 0;
            string h_lrc = "";
            int l = strLRC.Length;
            for (int c = 0; c < l; c = c + 2)
            {
                string c_data = strLRC.Substring(c, 2);
                d_lrc = d_lrc + (Int32)Convert.ToByte(c_data, 16);
                //d_lrc = d_lrc + Convert.ToInt32(c_data);
            }
            if (d_lrc >= 255)
                d_lrc = d_lrc % 0x100;
            h_lrc = Convert.ToInt32(~d_lrc + 1).ToString("X");
            if (h_lrc.Length > 2)
                h_lrc = h_lrc.Substring(h_lrc.Length - 2, 2);
            return h_lrc;
        }
        #endregion
        //CRC校验 FROM Google 
        #region  CRC校验 FROM Google
        private static readonly byte[] aucCRCHi = {
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40
         };
        private static readonly byte[] aucCRCLo = {
             0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06, 0x07, 0xC7,
             0x05, 0xC5, 0xC4, 0x04, 0xCC, 0x0C, 0x0D, 0xCD, 0x0F, 0xCF, 0xCE, 0x0E,
             0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09, 0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9,
             0x1B, 0xDB, 0xDA, 0x1A, 0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 0x1D, 0x1C, 0xDC,
             0x14, 0xD4, 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,
             0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 0xF2, 0x32,
             0x36, 0xF6, 0xF7, 0x37, 0xF5, 0x35, 0x34, 0xF4, 0x3C, 0xFC, 0xFD, 0x3D,
             0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A, 0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38,
             0x28, 0xE8, 0xE9, 0x29, 0xEB, 0x2B, 0x2A, 0xEA, 0xEE, 0x2E, 0x2F, 0xEF,
             0x2D, 0xED, 0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
             0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 0x61, 0xA1,
             0x63, 0xA3, 0xA2, 0x62, 0x66, 0xA6, 0xA7, 0x67, 0xA5, 0x65, 0x64, 0xA4,
             0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F, 0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB,
             0x69, 0xA9, 0xA8, 0x68, 0x78, 0xB8, 0xB9, 0x79, 0xBB, 0x7B, 0x7A, 0xBA,
             0xBE, 0x7E, 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,
             0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 0x70, 0xB0,
             0x50, 0x90, 0x91, 0x51, 0x93, 0x53, 0x52, 0x92, 0x96, 0x56, 0x57, 0x97,
             0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C, 0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E,
             0x5A, 0x9A, 0x9B, 0x5B, 0x99, 0x59, 0x58, 0x98, 0x88, 0x48, 0x49, 0x89,
             0x4B, 0x8B, 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
             0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 0x43, 0x83,
             0x41, 0x81, 0x80, 0x40
         };
        private void Crc16(byte[] pucFrame, int usLen)
        {
            int i = 0;
            ucCRCHi = 0xFF;
            ucCRCLo = 0xFF;
            UInt16 iIndex = 0x0000;

            while (usLen-- > 0)
            {
                iIndex = (UInt16)(ucCRCLo ^ pucFrame[i++]);
                ucCRCLo = (byte)(ucCRCHi ^ aucCRCHi[iIndex]);
                ucCRCHi = aucCRCLo[iIndex];
            }

        }

        #endregion
        #endregion
        /// <summary>
        /// 解析接收到的数据
        /// </summary>
        /// <param name="bData"></param>
        /// <param name="mFunctionCode"></param>
        public ModbusData ReceiveAnalysis(byte[] bData)
        {
            ModbusData moddata = null;

            try
            {
                int mReceiveByteCount = bData.Length;



                
                    #region     接收到的数据
                    moddata = new ModbusData();
                    moddata.SlaveID = bData[0];//设备ID
                    moddata.Code = bData[1];//功能
                    moddata.FunctionCode = (FunctionCode)bData[1];
                    moddata.Data = bData;
                    moddata.FunctionCode = (FunctionCode)bData[1];
                 

                    moddata.DataLength = bData[2];//当前数据的字节数  
                    moddata.MCount = moddata.DataLength / 2;//返回的寄存器个数               
                     Array.Copy(bData, bData.Length - 3, moddata.CRCData, 0, 2);//拷贝校验码
                    #endregion

            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message.ToString();
            }
            return moddata;
        }
        #region MODBUS读取保持型寄存器地址
        /// <summary>
        /// MODBUS读取保持型寄存器地址
        /// </summary>
        /// <param name="iDevAdd"></param>
        /// <param name="iAddress"></param>
        /// <param name="iLength"></param>
        /// <returns></returns>
        public byte[] ReadKeepReg(int iDevAdd, long iAddress, int iLength)
        {
            if (mRtuFlag == ModBusProtocol.ASCII)
            {
                return ReadKeepRegAscii(iDevAdd, iAddress, iLength);
            }
            else if (mRtuFlag == ModBusProtocol.RTU)
            {
                return ReadKeepRegRtu(iDevAdd, iAddress, iLength);
            }
            else if (mRtuFlag == ModBusProtocol.Serial)//串口模式下的modbus读取方式
            {
                return ReadSerial_KeepReg(iDevAdd, iAddress, iLength);
            }
            else
            {
                return null;
            }
        }
        //串口模式
        //by liguang MODBUS读保持寄存器 iAddress 开始地址(0开始),iLength 寄存器数量
        //主站请求：01 03 00 00 00 06 70 08    0E 03 9c 40 00 64 
        //地址    1字节
        //功能码  1字节   0x03
        //起始寄存器地址  2字节   0x0000~0x0005
        //寄存器数量  2字节   0x01~0x06
        //CRC校验 2字节
        private byte[] ReadSerial_KeepReg(int iDevAdd, long iAddress, int iLength)
        {
            int i;
            iMWordStartAddr = iAddress;
            iMWordLen = iLength;

            byte[] SendCommand = new byte[8];

            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x03;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);
            SendCommand[3] = (byte)(iAddress % 256);
            SendCommand[4] = (byte)((iLength - iLength % 256) / 256);
            SendCommand[5] = (byte)(iLength % 256);
            Crc16(SendCommand, 6);
            SendCommand[6] = ucCRCLo;
            SendCommand[7] = ucCRCHi;
            //发送指令。


            return SendCommand;

        }
        /// <summary>
        ///  Ascii模式使用ASCII模式，消息以冒号（:）字符（ASCII码 3AH）开始，以回车换行符结束（ASCII码 0DH,0AH）。 
        ///  其它域可以使用的传输字符是十六进制的0...9,A...F。网络上的设备不断侦测“:”字符，
        ///  当有一个冒号接收到时，每个设备都解码下个域（地址域）来判断是否发给自己的。 
        ///  消息中字符间发送的时间间隔最长不能超过1秒，否则接收的设备将认为传输错误。
        ///  一个典型消息帧如下所示：
        ///  起始位 设备地址    功能代码  数据    LRC校验  结束符
        ///  1个字符 2个字符	 2个字符  n个字符	2个字符	 2个字符
        /// </summary>
        /// <param name="iDevAdd"></param>
        /// <param name="iAddress"></param>
        /// <param name="iLength"></param>
        /// <returns></returns>
        private byte[] ReadKeepRegAscii(int iDevAdd, long iAddress, int iLength)
        {
            int i;
            string strLRC;
            string strSendCommand;
            iMWordStartAddr = iAddress;
            iMWordLen = iLength;

            byte[] SendCommand = new byte[8];

            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x03;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);
            SendCommand[3] = (byte)(iAddress % 256);
            SendCommand[4] = (byte)((iLength - iLength % 256) / 256);
            SendCommand[5] = (byte)(iLength % 256);
            strSendCommand = "";
            for (i = 0; i < 6; i++)
            {

                strSendCommand = strSendCommand + " " + SendCommand[i].ToString("X2");

            }

            strLRC = LRC(strSendCommand);
            strSendCommand = ":" + strSendCommand + strLRC;
            strSendCommand = strSendCommand + "\r" + "\n";

            //发送指令。

            //strUpData = "";
            strDownData = "";
            strDownData = strSendCommand;
            byte[] b = Encoding.ASCII.GetBytes(strDownData);
            return b;
        }
        private byte[] ReadKeepRegRtu(int iDevAdd, long iAddress, int iLength)
        {
            int i;
            string strLRC;
            string strSendCommand;
            iMWordStartAddr = iAddress;
            iMWordLen = iLength;

            byte[] SendCommand = new byte[8];

            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x03;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);
            SendCommand[3] = (byte)(iAddress % 256);
            SendCommand[4] = (byte)((iLength - iLength % 256) / 256);
            SendCommand[5] = (byte)(iLength % 256);
            strSendCommand = "";
            for (i = 0; i < 6; i++)
            {

                strSendCommand = strSendCommand + " " + SendCommand[i].ToString("X2");

            }

            strLRC = LRC(strSendCommand);
            strSendCommand = ":" + strSendCommand + strLRC;
            strSendCommand = strSendCommand + "\r" + "\n";

            //发送指令。

            //strUpData = "";
            strDownData = "";
            strDownData = strSendCommand;
            byte[] b = Encoding.ASCII.GetBytes(strDownData);
            return b;
        }
        #endregion
        #region MODBUS读输入寄存器的命令
        /// <summary>
        /// MODBUS读输入寄存器
        /// </summary>
        /// <param name="iDevAdd"></param>
        /// <param name="iAddress"></param>
        /// <param name="iLength"></param>
        /// <param name="hex"></param>
        /// <returns></returns>
        public byte[] ReadInputReg(int iDevAdd, long iAddress, int iLength)
        {
            if (mRtuFlag == ModBusProtocol.ASCII)
            {
                return ReadInputRegAscii(iDevAdd, iAddress, iLength);
            }
            else if (mRtuFlag == ModBusProtocol.RTU)
            {
                return ReadSerialInputReg(iDevAdd, iAddress, iLength);
            }
            else if (mRtuFlag == ModBusProtocol.Serial)
            {
                return ReadSerialInputReg(iDevAdd, iAddress, iLength);
            }
            else
            {
                return null;
            }
        }
        //by liguang MODBUS读输入寄存器 iAddress 开始地址(0开始),iLength 寄存器数量
        //主站请求：01 04 00 00 00 06 70 08
        //地址    1字节
        //功能码  1字节   0x04
        //起始寄存器地址  2字节   0x0000~0x0005
        //寄存器数量  2字节   0x01~0x06
        //CRC校验 2字节
        private byte[] ReadSerialInputReg(int iDevAdd, long iAddress, int iLength)
        {


            byte[] SendCommand = new byte[8];

            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x04;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);
            SendCommand[3] = (byte)(iAddress % 256);
            SendCommand[4] = (byte)((iLength - iLength % 256) / 256);
            SendCommand[5] = (byte)(iLength % 256);
            Crc16(SendCommand, 6);
            SendCommand[6] = ucCRCLo;
            SendCommand[7] = ucCRCHi;

            return SendCommand;

        }
        private byte[] ReadInputRegAscii(int iDevAdd, long iAddress, int iLength)
        {
            int i;
            string strLRC;
            string strSendCommand;
            iMWordStartAddr = iAddress;
            iMWordLen = iLength;

            byte[] SendCommand = new byte[8];
            CurrentAddr = iDevAdd - 1;
            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x04;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);
            SendCommand[3] = (byte)(iAddress % 256);
            SendCommand[4] = (byte)((iLength - iLength % 256) / 256);
            SendCommand[5] = (byte)(iLength % 256);
            strSendCommand = "";
            for (i = 0; i < 6; i++)
            {

                strSendCommand = strSendCommand + " " + SendCommand[i].ToString("X2");

            }

            strLRC = LRC(strSendCommand);
            strSendCommand = ":" + strSendCommand + strLRC;
            strSendCommand = strSendCommand + "\r" + "\n";


            //strUpData = "";
            strDownData = "";
            strDownData = strSendCommand;
            byte[] b = Encoding.ASCII.GetBytes(strDownData);
            return b;

        }
        #endregion
        #region MODBUS读输出状态命令
        public byte[] ReadOutputStatus(int iDevAdd, long iAddress, int iLength)
        {
            if (mRtuFlag == ModBusProtocol.ASCII)
            {
                return ReadOutputStatusAscii(iDevAdd, iAddress, iLength);
            }
            else if (mRtuFlag == ModBusProtocol.RTU)
            {
                return ReadSerialOutputStatus(iDevAdd, iAddress, iLength);
            }
            else if (mRtuFlag == ModBusProtocol.Serial)
            {
                return ReadSerialOutputStatus(iDevAdd, iAddress, iLength);
            }
            else
            {
                return null;
            }
        }
        //by liguang MODBUS读输出状态 iAddress 开始地址(0开始),iLength 寄存器数量
        //主站请求：01 01 00 00 00 07 70 08
        //地址    1字节
        //功能码  1字节   0x01
        //起始寄存器地址  2字节   0x0000~0x0005
        //寄存器数量  2字节   0x01~0x06
        //CRC校验 2字节
        private byte[] ReadSerialOutputStatus(int iDevAdd, long iAddress, int iLength)
        {
            int i;
            //一个字节代表8个位状态
            //一个字节代表8个位状态
            if (iLength % 8 == 0)
            {
                iMBitLen = iLength / 8;
            }
            else
            {
                iMBitLen = iLength / 8 + 1;
            }
            iMBitStartAddr = iAddress;

            byte[] SendCommand = new byte[8];

            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x01;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);
            SendCommand[3] = (byte)(iAddress % 256);
            SendCommand[4] = (byte)((iLength - iLength % 256) / 256);
            SendCommand[5] = (byte)(iLength % 256);
            Crc16(SendCommand, 6);
            SendCommand[6] = ucCRCLo;
            SendCommand[7] = ucCRCHi;
            //发送指令。

            mReceiveByteCount = 0;
            //strUpData = "";
            strDownData = "";
            for (i = 0; i < 8; i++)
            {

                strDownData = strDownData + " " + SendCommand[i].ToString("X2");

            }
            return System.Text.Encoding.Default.GetBytes(strDownData);//字符转换成字节数组   
        }
        private byte[] ReadOutputStatusAscii(int iDevAdd, long iAddress, int iLength)
        {
            int i;
            //一个字节代表8个位状态
            //一个字节代表8个位状态
            if (iLength % 8 == 0)
            {
                iMBitLen = iLength / 8;
            }
            else
            {
                iMBitLen = iLength / 8 + 1;
            }
            string strLRC;
            string strSendCommand;
            iMBitStartAddr = iAddress;

            byte[] SendCommand = new byte[8];

            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x01;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);
            SendCommand[3] = (byte)(iAddress % 256);
            SendCommand[4] = (byte)((iLength - iLength % 256) / 256);
            SendCommand[5] = (byte)(iLength % 256);
            strSendCommand = "";
            for (i = 0; i < 6; i++)
            {

                strSendCommand = strSendCommand + " " + SendCommand[i].ToString("X2");

            }

            strLRC = LRC(strSendCommand);
            strSendCommand = ":" + strSendCommand + strLRC;
            strSendCommand = strSendCommand + "\r" + "\n";


            //strUpData = "";
            strDownData = "";
            strDownData = strSendCommand;
            byte[] b = Encoding.ASCII.GetBytes(strDownData);
            return b;
        }
        #endregion
        #region  MODBUS读输入状态
        public byte[] ReadInputStatus(int iDevAdd, long iAddress, int iLength)
        {
            if (mRtuFlag == ModBusProtocol.ASCII)
            {
                return ReadInputStatusAscii(iDevAdd, iAddress, iLength);
            }
            else if (mRtuFlag == ModBusProtocol.RTU)
            {
                return ReadSerialInputStatus(iDevAdd, iAddress, iLength);
            }
            else if (mRtuFlag == ModBusProtocol.Serial)
            {
                return ReadSerialInputStatus(iDevAdd, iAddress, iLength);
            }
            else
            {
                return null;
            }
        }
        //by liguang MODBUS读输入状态 iAddress 开始地址(0开始),iLength 寄存器数量
        //主站请求：01 02 00 00 00 07 70 08
        //地址    1字节
        //功能码  1字节   0x02
        //起始寄存器地址  2字节   0x0000~0x0005
        //寄存器数量  2字节   0x01~0x06
        //CRC校验 2字节
        private byte[] ReadSerialInputStatus(int iDevAdd, long iAddress, int iLength)
        {
            int i;
            //一个字节代表8个位状态
            //一个字节代表8个位状态
            if (iLength % 8 == 0)
            {
                iMBitLen = iLength / 8;
            }
            else
            {
                iMBitLen = iLength / 8 + 1;
            }
            iMBitStartAddr = iAddress;

            byte[] SendCommand = new byte[8];
            CurrentAddr = iDevAdd - 1;

            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x02;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);
            SendCommand[3] = (byte)(iAddress % 256);
            SendCommand[4] = (byte)((iLength - iLength % 256) / 256);
            SendCommand[5] = (byte)(iLength % 256);
            Crc16(SendCommand, 6);
            SendCommand[6] = ucCRCLo;
            SendCommand[7] = ucCRCHi;

            strDownData = "";
            for (i = 0; i < 8; i++)
            {

                strDownData = strDownData + " " + SendCommand[i].ToString("X2");

            }
            return System.Text.Encoding.Default.GetBytes(strDownData);//字符转换成字节数组   
        }
        private byte[] ReadInputStatusAscii(int iDevAdd, long iAddress, int iLength)
        {
            int i;
            //一个字节代表8个位状态
            if (iLength % 8 == 0)
            {
                iMBitLen = iLength / 8;
            }
            else
            {
                iMBitLen = iLength / 8 + 1;
            }
            string strLRC;
            string strSendCommand;
            iMBitStartAddr = iAddress;

            byte[] SendCommand = new byte[8];
            CurrentAddr = iDevAdd - 1;
            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x02;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);
            SendCommand[3] = (byte)(iAddress % 256);
            SendCommand[4] = (byte)((iLength - iLength % 256) / 256);
            SendCommand[5] = (byte)(iLength % 256);
            strSendCommand = "";
            for (i = 0; i < 6; i++)
            {

                strSendCommand = strSendCommand + " " + SendCommand[i].ToString("X2");

            }

            strLRC = LRC(strSendCommand);
            strSendCommand = ":" + strSendCommand + strLRC;
            strSendCommand = strSendCommand + "\r" + "\n";
            System.Diagnostics.Trace.WriteLine(strSendCommand);

            //strUpData = "";
            strDownData = "";
            strDownData = strSendCommand;

            byte[] b = Encoding.ASCII.GetBytes(strDownData);
            return b;

        }

        #endregion
        #region  MODBUS强制打开或者复位多个线圈 强制状态表示：1＝ON； 0＝OFF
        public byte[] ForceMulti(int iDevAdd, long iAddress, List<byte> states)
        {
            if (mRtuFlag == ModBusProtocol.ASCII)
            {
                return ForceMultiAscii(iDevAdd, iAddress, states);
            }
            else if (mRtuFlag == ModBusProtocol.RTU)
            {
                return ForceMultiSerial(iDevAdd, iAddress, states);
            }
            else if (mRtuFlag == ModBusProtocol.Serial)
            {
                return ForceMultiSerial(iDevAdd, iAddress, states);
            }
            else
            {
                return null;
            }
        }
        //by liguang MODBUS强制多线圈 iAddress 开始地址(0开始) ,强制状态表示：1＝ON； 0＝OFF
        // 1 从设备地址 1个字节 0x00 − 0xff
        //2 功能码 1个字节 0x10
        //3 起始寄存器地址 两个字节 高字节在前
        //4 寄存器个数 两个字节　 高字节在前
        //5 数据长度　 1个字节　 寄存器个数×2
        //6 数据 寄存器个数×2个字节 每个寄存器高字节在前
        //7 CRC 校验码　 两个字节　 低字节在前
        //CRC校验 2字节
        private byte[] ForceMultiSerial(int iDevAdd, long iAddress, List<byte> states)
        {
            int i;
            iMWordStartAddr = iAddress;
            //iMWordLen = 0;
            int number = Convert.ToInt16(states.Count.ToString(), 16);
            byte[] SendCommand = new byte[9 + number * 2];
            CurrentAddr = iDevAdd - 1;
            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x0f;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);//强制地址高8位
            SendCommand[3] = (byte)(iAddress % 256);//强制地址底8位
            SendCommand[4] = (byte)((number - number % 256) / 256); //强制数量高8位
            SendCommand[5] = (byte)(number % 256);//强制数量底8位
            SendCommand[6] = (byte)(number * 2);//寄存器个数×2个字节 每个寄存器高字节在前
            for (i = 0; i < states.Count; i++)
            {
                SendCommand[7 + i * 2] = (byte)((states[i] - states[i] % 256) / 256);
                SendCommand[7 + i * 2 + 1] = (byte)(states[i] % 256);
            }
            Crc16(SendCommand, 7 + number * 2);
            SendCommand[7 + number * 2] = ucCRCLo;
            SendCommand[7 + number * 2 + 1] = ucCRCHi;



            //strUpData = "";
            strDownData = "";
            for (i = 0; i < 9 + number * 2; i++)
            {
                strDownData = strDownData + " " + SendCommand[i].ToString("X2");

            }
            return System.Text.Encoding.Default.GetBytes(strDownData);//字符转换成字节数组   

        }
        private byte[] ForceMultiAscii(int iDevAdd, long iAddress, List<byte> states)
        {
            int i = 0;
            iMWordStartAddr = iAddress;
            //iMWordLen = 0;
            int number = Convert.ToInt16(states.Count.ToString(), 16);
            byte[] SendCommand = new byte[9 + number * 2];
            CurrentAddr = iDevAdd - 1;
            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x0f;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);//强制地址高8位
            SendCommand[3] = (byte)(iAddress % 256);//强制地址底8位
            SendCommand[4] = (byte)((number - number % 256) / 256); //强制数量高8位
            SendCommand[5] = (byte)(number % 256);//强制数量底8位
            SendCommand[6] = (byte)(number * 2);//寄存器个数×2个字节 每个寄存器高字节在前
            for (i = 0; i < states.Count; i++)
            {
                SendCommand[7 + i * 2] = (byte)((states[i] - states[i] % 256) / 256);
                SendCommand[7 + i * 2 + 1] = (byte)(states[i] % 256);
            }
            Crc16(SendCommand, 7 + number * 2);
            SendCommand[7 + number * 2] = ucCRCLo;
            SendCommand[7 + number * 2 + 1] = ucCRCHi;
            string strSendCommand = "";
            for (i = 0; i < 9 + number * 2; i++)
            {

                strSendCommand = strSendCommand + " " + SendCommand[i].ToString("X2");

            }

            string strLRC = LRC(strSendCommand);
            strSendCommand = ":" + strSendCommand + strLRC;
            strSendCommand = strSendCommand + "\r" + "\n";
            //System.Diagnostics.Trace.WriteLine(strSendCommand);

            //strUpData = "";
            strDownData = strSendCommand;
            byte[] b = Encoding.ASCII.GetBytes(strDownData);
            return b;
        }
        #endregion
        #region  MODBUS复位单线圈

        private byte[] ForceOff(int iDevAdd, long iAddress)
        {
            if (mRtuFlag == ModBusProtocol.ASCII)
            {
                return ForceOffAscii(iDevAdd, iAddress);
            }
            else if (mRtuFlag == ModBusProtocol.RTU)
            {
                return ForceOffSerial(iDevAdd, iAddress);
            }
            else if (mRtuFlag == ModBusProtocol.Serial)
            {
                return ForceOffSerial(iDevAdd, iAddress);
            }
            else
            {
                return null;
            }
        }
        //by liguang MODBUS复位单线圈 iAddress 开始地址(0开始)
        //主站请求：01 05 00 00 00 00 70 08
        //地址    1字节
        //功能码  1字节   0x05
        //起始寄存器地址  2字节   0x0000~0x0005
        //寄存器数量  2字节   0x01~0x06
        //CRC校验 2字节
        private byte[] ForceOffSerial(int iDevAdd, long iAddress)
        {
            int i;

            iMWordStartAddr = iAddress;

            byte[] SendCommand = new byte[8];
            CurrentAddr = iDevAdd - 1;
            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x05;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);
            SendCommand[3] = (byte)(iAddress % 256);
            SendCommand[4] = 0x00;
            SendCommand[5] = 0x00;
            Crc16(SendCommand, 6);
            SendCommand[6] = ucCRCLo;
            SendCommand[7] = ucCRCHi;

            //strUpData = "";
            strDownData = "";
            for (i = 0; i < 8; i++)
            {

                strDownData = strDownData + " " + SendCommand[i].ToString("X2");

            }
            return System.Text.Encoding.Default.GetBytes(strDownData);//字符转换成字节数组   
        }
        private byte[] ForceOffAscii(int iDevAdd, long iAddress)
        {
            int i;
            string strSendCommand, strLRC;
            iMWordStartAddr = iAddress;

            byte[] SendCommand = new byte[8];
            CurrentAddr = iDevAdd - 1;
            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x05;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);
            SendCommand[3] = (byte)(iAddress % 256);
            SendCommand[4] = 0x00;
            SendCommand[5] = 0x00;
            strSendCommand = "";
            for (i = 0; i < 6; i++)
            {

                strSendCommand = strSendCommand + " " + SendCommand[i].ToString("X2");

            }

            strLRC = LRC(strSendCommand);
            strSendCommand = ":" + strSendCommand + strLRC;
            strSendCommand = strSendCommand + "\r" + "\n";


            //strUpData = "";
            strDownData = strSendCommand;
            byte[] b = Encoding.ASCII.GetBytes(strDownData);
            return b;

        }
        #endregion
        #region  MODBUS强制打开单线圈
        public byte[] ForceOn(int iDevAdd, long iAddress)
        {
            if (mRtuFlag == ModBusProtocol.ASCII)
            {
                return ForceOnAscii(iDevAdd, iAddress);
            }
            else if (mRtuFlag == ModBusProtocol.RTU)
            {
                return ForceOnSerial(iDevAdd, iAddress);
            }
            else if (mRtuFlag == ModBusProtocol.Serial)
            {
                return ForceOnSerial(iDevAdd, iAddress);
            }
            else
            {
                return null;
            }
        }
        //by liguang MODBUS强制单线圈 iAddress 开始地址(0开始)
        //主站请求：01 05 00 00 FF 00 70 08
        //地址    1字节
        //功能码  1字节   0x05
        //起始寄存器地址  2字节   0x0000~0x0005
        //寄存器数量  2字节   0x01~0x06
        //CRC校验 2字节
        private byte[] ForceOnSerial(int iDevAdd, long iAddress)
        {
            int i;
            iMWordStartAddr = iAddress;
            //iMWordLen = 0;

            byte[] SendCommand = new byte[8];
            CurrentAddr = iDevAdd - 1;
            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x05;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);
            SendCommand[3] = (byte)(iAddress % 256);
            SendCommand[4] = 0xff;
            SendCommand[5] = 0x00;
            Crc16(SendCommand, 6);
            SendCommand[6] = ucCRCLo;
            SendCommand[7] = ucCRCHi;

            //strUpData = "";
            strDownData = "";
            for (i = 0; i < 8; i++)
            {

                strDownData = strDownData + " " + SendCommand[i].ToString("X2");

            }
            return System.Text.Encoding.Default.GetBytes(strDownData);//字符转换成字节数组   

        }
        private byte[] ForceOnAscii(int iDevAdd, long iAddress)
        {
            int i;
            string strSendCommand, strLRC;
            iMWordStartAddr = iAddress;
            //iMWordLen = 0;

            byte[] SendCommand = new byte[8];
            CurrentAddr = iDevAdd - 1;
            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x05;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);
            SendCommand[3] = (byte)(iAddress % 256);
            SendCommand[4] = 0xff;
            SendCommand[5] = 0x00;
            strSendCommand = "";
            for (i = 0; i < 6; i++)
            {

                strSendCommand = strSendCommand + " " + SendCommand[i].ToString("X2");

            }

            strLRC = LRC(strSendCommand);
            strSendCommand = ":" + strSendCommand + strLRC;
            strSendCommand = strSendCommand + "\r" + "\n";
            //System.Diagnostics.Trace.WriteLine(strSendCommand);

            //strUpData = "";
            strDownData = strSendCommand;
            byte[] b = Encoding.ASCII.GetBytes(strDownData);
            return b;
        }
        #endregion
        #region MODBUS预置寄存器,根据数据类型自动换算寄存器数量
        public byte[] PreSetKeepReg(int iDevAdd, long iAddress, string SetValue, Type valueType, BitStoreMode BitStoreMode)
        {
            return PreSetKeepRegSerial(iDevAdd, iAddress, SetValue, valueType, BitStoreMode);

        }
        //by liguang MODBUS预置单字寄存器 iAddress 开始地址(0开始),iHiValue 数据
        //主站请求：01 06 00 00 00 06 70 08
        //地址    1字节
        //功能码  1字节   0x06
        //起始寄存器地址  2字节   0x0000~0x0005
        //寄存器数量  2字节   0x01~0x06
        //CRC校验 2字节
        private byte[] PreSetKeepRegSerial(int iDevAdd, long iAddress, string SetValue, Type valueType, BitStoreMode BitStoreMode)
        {
            int i;
            iMWordStartAddr = iAddress;

            ///要设置的值转换为字节数组
            object valueObj = SetValue;
            if (valueType == typeof(sbyte))
            {
                valueObj = Convert.ToSByte(SetValue);
            }
            else if (valueType == typeof(byte))
            {
                valueObj = Convert.ToByte(SetValue);
            }
            else if (valueType == typeof(Int16))
            {
                valueObj = Convert.ToInt16(SetValue);
            }
            else if (valueType == typeof(UInt16))
            {
                valueObj = Convert.ToUInt16(SetValue);
            }
            else if (valueType == typeof(Int32))
            {
                valueObj = Convert.ToInt32(SetValue);
            }
            else if (valueType == typeof(UInt32))
            {
                valueObj = Convert.ToUInt32(SetValue);
            }
            else if (valueType == typeof(Int64))
            {
                valueObj = Convert.ToInt64(SetValue);
            }
            else if (valueType == typeof(UInt64))
            {
                valueObj = Convert.ToUInt64(SetValue);
            }
            else if (valueType == typeof(float))
            {
                valueObj = Convert.ToSingle(SetValue);
            }
            else if (valueType == typeof(double))
            {
                valueObj = Convert.ToDouble(SetValue);
            }
            int unit = 0;
            byte[] valuebyte = ConvertType.BitTobytes(valueObj, out unit, BitStoreMode);//返回寄存器地址
            byte[] SendCommand = new byte[9 + unit * 2];
            CurrentAddr = iDevAdd - 1;
            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x10;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);//寄存器开始地址
            SendCommand[3] = (byte)(iAddress % 256);//寄存器开始地址
            SendCommand[4] = (byte)((unit - unit % 256) / 256);  //寄存器个数
            SendCommand[5] = (byte)(unit % 256); //寄存器个数
            SendCommand[6] = (byte)(valuebyte.Length);//数据长度
            for (i = 0; i < valuebyte.Length; i++)
            {
                SendCommand[7 + i] = valuebyte[i];
            }
            Crc16(SendCommand, 7 + valuebyte.Length);
            SendCommand[7 + valuebyte.Length] = ucCRCLo;
            SendCommand[8 + valuebyte.Length] = ucCRCHi;


            return SendCommand;//返回字节数组
        }
        #endregion

        //字节变量返回8为二进制字符串
        public string ByteToBinary(byte bValue)
        {
            string strTemp;
            int i, strLen;
            strTemp = System.Convert.ToString(bValue, 2);

            if (strTemp.Length < 8)
            {
                strLen = strTemp.Length;
                for (i = 0; i < 8 - strLen; i++)
                {
                    strTemp = "0" + strTemp;
                }
            }
            return strTemp;
        }
        //字节变量赋值给bool型全局数组
        public void ByteToBArray(byte bValue, int iAddr, int pos)
        {
            string strBinary;
            int i;
            strBinary = ByteToBinary(bValue);
            for (i = 0; i < 8; i++)
            {
                if (strBinary.Substring(7 - i, 1) == "1")
                {
                    MBitVaue[iAddr, pos + i] = true;
                }
                else
                {
                    MBitVaue[iAddr, pos + i] = false;
                }
            }
            i = 10;

        }

    }
}
