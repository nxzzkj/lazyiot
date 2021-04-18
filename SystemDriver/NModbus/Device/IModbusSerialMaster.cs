namespace Modbus.Device
{
    using IO;

    /// <summary>
    ///     Modbus Serial Master device.
    /// </summary>
    public interface IModbusSerialMaster : IModbusMaster
    {
        /// <summary>
        ///     Transport for used by this master.
        /// </summary>
        new ModbusSerialTransport Transport { get; }

        /// <summary>
        ///     Serial Line only.
        ///     Diagnostic function which loops back the original data.
        ///     NModbus only supports looping back one ushort value, this is a
        ///     limitation of the "Best Effort" implementation of the RTU protocol.
        ///仅串行线。
        ///循环回原始数据的诊断函数。
        ///NModbus只支持循环回一个ushort值，这是
        ///RTU协议“尽最大努力”实现的限制。
        /// </summary>
        /// <param name="slaveAddress">Address of device to test.</param>
        /// <param name="data">Data to return.</param>
        /// <returns>Return true if slave device echoed data.</returns>
        bool ReturnQueryData(byte slaveAddress, ushort data);
    }
}
