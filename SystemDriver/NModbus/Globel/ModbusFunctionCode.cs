using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modbus.Globel
{
    public class ModbusFunctionCode
    {
        public string Function = "";
        public ReadWriteStatus ReadWriteStatus = ReadWriteStatus.None;
        public string Code = "";
        public override string ToString()
        {
            return Function.ToString();
        }

    }
    public class ModbusFunction
    {
        public List<ModbusFunctionCode> mFunctions = new List<ModbusFunctionCode>();
        public List<ModbusFunctionCode> Functions
        {
            set { mFunctions = value; }
            get { return mFunctions; }
        }
        public ModbusFunction()
        {
            mFunctions.Clear();
            mFunctions.Add(new ModbusFunctionCode()
            {
                Code = "02",
                Function = "02号功能码(DI离散输入量)",
                ReadWriteStatus = ReadWriteStatus.Read
            });
            mFunctions.Add(new ModbusFunctionCode()
            {
                Code = "01",
                Function = "01号和05号功能码(DO离散输出量)",
                ReadWriteStatus = ReadWriteStatus.ReadWrite
            });
            mFunctions.Add(new ModbusFunctionCode()
            {
                Code = "03",
                Function = "03号功能码(HR保持寄存器)",
                ReadWriteStatus = ReadWriteStatus.ReadWrite
            });
            mFunctions.Add(new ModbusFunctionCode()
            {
                Code = "04",
                Function = "04号功能码(AR保持寄存器)",
                ReadWriteStatus = ReadWriteStatus.Read
            });
        }

    }
    public enum Modbus_Type
    {
        无符号整数8位,
        有符号整数8位,
        无符号整数16位,
        有符号整数16位,
        无符号整数32位,
        有符号整数32位,
        单精度浮点数32位,
        双精度浮点数64位,
        字符型,

    }
    public class ModbusDataType
    {
        public Modbus_Type DataType = Modbus_Type.无符号整数8位;
        public int RegisterNumber = 1;
        public override string ToString()
        {
            return DataType.ToString();
        }
        public string Description
        {
            get { return "该类型需要" + RegisterNumber + "个寄存器存储"; }
        }
    }
    public class ModbusData
    {
        public ModbusData()
        {
            datatypes.Clear();
            datatypes.Add(new ModbusDataType() {
                 DataType= Modbus_Type.无符号整数8位,
                  RegisterNumber=1
            });
            datatypes.Add(new ModbusDataType()
            {
                DataType = Modbus_Type.有符号整数8位,
                RegisterNumber = 1
            });
            datatypes.Add(new ModbusDataType()
            {
                DataType = Modbus_Type.无符号整数16位,
                RegisterNumber = 1
            });
            datatypes.Add(new ModbusDataType()
            {
                DataType = Modbus_Type.有符号整数16位,
                RegisterNumber = 1
            });
            datatypes.Add(new ModbusDataType()
            {
                DataType = Modbus_Type.无符号整数32位,
                RegisterNumber = 2
            });
            datatypes.Add(new ModbusDataType()
            {
                DataType = Modbus_Type.有符号整数32位,
                RegisterNumber = 2
            });
            datatypes.Add(new ModbusDataType()
            {
                DataType = Modbus_Type.单精度浮点数32位,
                RegisterNumber = 2
            });
            datatypes.Add(new ModbusDataType()
            {
                DataType = Modbus_Type.双精度浮点数64位,
                RegisterNumber = 4
            });
            datatypes.Add(new ModbusDataType()
            {
                DataType = Modbus_Type.字符型,
                RegisterNumber = 4//默认是4个寄存器
            });
        }
        public List<ModbusDataType> datatypes = new List<ModbusDataType>();
        public List<ModbusDataType> DataTypes
        {
            set { datatypes = value; }
            get { return datatypes; }
        }

    }
    public enum ReadWriteStatus
    {
        Read,//只读
        Write,//只写
        ReadWrite,//可读可写
        All,//全部
        None//无
    }
}
