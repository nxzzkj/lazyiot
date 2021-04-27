namespace Modbus.Device
{
    using System;
    using System.Threading.Tasks;

    using IO;

    /// <summary>
    ///     Modbus master device.
    /// </summary>
    public interface IModbusMaster : IDisposable
    {
        /// <summary>
        ///     Transport used by this master.
        /// </summary>
        ModbusTransport Transport { get; }

        /// <summary>
        ///    Reads from 1 to 2000 contiguous coils status.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from. 从中读取值的设备地址</param>
        /// <param name="startAddress">Address to begin reading. 开始阅读的地址</param>
        /// <param name="numberOfPoints">Number of coils to read. 要读取的线圈数</param>
        /// <returns>Coils status. 线圈状态</returns>
        bool[] ReadCoils(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        /// <summary>
        ///    Asynchronously reads from 1 to 2000 contiguous coils status.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from. 从中读取值的设备地址</param>
        /// <param name="startAddress">Address to begin reading. 开始阅读的地址</param>
        /// <param name="numberOfPoints">Number of coils to read. 要读取的线圈数</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        Task<bool[]> ReadCoilsAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        /// <summary>
        ///    Reads from 1 to 2000 contiguous discrete input status.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from. 从中读取值的设备地址</param>
        /// <param name="startAddress">Address to begin reading. 开始阅读的地址</param>
        /// <param name="numberOfPoints">Number of discrete inputs to read.要读取的离散输入数</param>
        /// <returns>Discrete inputs status.</returns>
        bool[] ReadInputs(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        /// <summary>
        ///    Asynchronously reads from 1 to 2000 contiguous discrete input status.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from. 从中读取值的设备地址</param>
        /// <param name="startAddress">Address to begin reading. 开始阅读的地</param>
        /// <param name="numberOfPoints">Number of discrete inputs to read. 要读取的离散输入数</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        Task<bool[]> ReadInputsAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        /// <summary>
        ///    Reads contiguous block of holding registers.读取保持寄存器的连续块。
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from. 从中读取值的设备地址</param>
        /// <param name="startAddress">Address to begin reading. 开始阅读的地址</param>
        /// <param name="numberOfPoints">Number of holding registers to read. 要读取的保持寄存器数</param>
        /// <returns>Holding registers status.</returns>
        ushort[] ReadHoldingRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        /// <summary>
        ///    Asynchronously reads contiguous block of holding registers.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from. 从中读取值的设备地址</param>
        /// <param name="startAddress">Address to begin reading. 开始阅读的地址</param>
        /// <param name="numberOfPoints">Number of holding registers to read. 要读取的保持寄存器数</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        Task<ushort[]> ReadHoldingRegistersAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        /// <summary>
        ///    Reads contiguous block of input registers.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>Input registers status.</returns>
        ushort[] ReadInputRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        /// <summary>
        ///    Asynchronously reads contiguous block of input registers.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        Task<ushort[]> ReadInputRegistersAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        /// <summary>
        ///    Writes a single coil value.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="coilAddress">Address to write value to.</param>
        /// <param name="value">Value to write.</param>
        void WriteSingleCoil(byte slaveAddress, ushort coilAddress, bool value);

        /// <summary>
        ///    Asynchronously writes a single coil value.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="coilAddress">Address to write value to.</param>
        /// <param name="value">Value to write.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        Task WriteSingleCoilAsync(byte slaveAddress, ushort coilAddress, bool value);

        /// <summary>
        ///    Writes a single holding register.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="registerAddress">Address to write.</param>
        /// <param name="value">Value to write.</param>
        void WriteSingleRegister(byte slaveAddress, ushort registerAddress, ushort value);

        /// <summary>
        ///    Asynchronously writes a single holding register.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="registerAddress">Address to write.</param>
        /// <param name="value">Value to write.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        Task WriteSingleRegisterAsync(byte slaveAddress, ushort registerAddress, ushort value);

        /// <summary>
        ///    Writes a block of 1 to 123 contiguous registers.
        ///    写入1到123个连续寄存器的块。
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to. 要写入的设备的地址</param>
        /// <param name="startAddress">Address to begin writing values. 开始写入值的地址 </param>
        /// <param name="data">Values to write. 要写入的值</param>
        void WriteMultipleRegisters(byte slaveAddress, ushort startAddress, ushort[] data);

        /// <summary>
        ///    Asynchronously writes a block of 1 to 123 contiguous registers.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        Task WriteMultipleRegistersAsync(byte slaveAddress, ushort startAddress, ushort[] data);

        /// <summary>
        ///    Writes a sequence of coils. 写一系列线圈
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        void WriteMultipleCoils(byte slaveAddress, ushort startAddress, bool[] data);

        /// <summary>
        ///    Asynchronously writes a sequence of coils.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        Task WriteMultipleCoilsAsync(byte slaveAddress, ushort startAddress, bool[] data);

        /// <summary>
        ///    Performs a combination of one read operation and one write operation in a single Modbus transaction.
        ///    在一个Modbus事务中执行一个读操作和一个写操作的组合。
        ///    The write operation is performed before the read.
        ///    在读取之前执行写入操作
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.从中读取值的设备地址</param>
        /// <param name="startReadAddress">Address to begin reading (Holding registers are addressed starting at 0).开始读取的地址（保持寄存器从0开始寻址）</param>
        /// <param name="numberOfPointsToRead">Number of registers to read.要读取的寄存器数</param>
        /// <param name="startWriteAddress">Address to begin writing (Holding registers are addressed starting at 0).开始写入的地址（保持寄存器从0开始寻址）</param>
        /// <param name="writeData">Register values to write.要写入的寄存器值</param>
        ushort[] ReadWriteMultipleRegisters(
            byte slaveAddress,
            ushort startReadAddress,
            ushort numberOfPointsToRead,
            ushort startWriteAddress,
            ushort[] writeData);

        /// <summary>
        ///    Asynchronously performs a combination of one read operation and one write operation in a single Modbus transaction.
        ///    The write operation is performed before the read.
        /// 在单个Modbus事务中异步执行一个读操作和一个写操作的组合。
        ///写入操作在读取之前执行。
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from. 要从中读取值的设备的地址。</param>
        /// <param name="startReadAddress">Address to begin reading (Holding registers are addressed starting at 0).开始读取的地址（保持寄存器从0开始寻址）</param>
        /// <param name="numberOfPointsToRead">Number of registers to read.要读取的寄存器数</param>
        /// <param name="startWriteAddress">Address to begin writing (Holding registers are addressed starting at 0).</param>
        /// <param name="writeData">Register values to write.开始写入的地址（保持寄存器的地址从0开始）。</param>
        /// <returns>A task that represents the asynchronous operation表示异步操作的任务</returns>
        Task<ushort[]> ReadWriteMultipleRegistersAsync(
            byte slaveAddress,
            ushort startReadAddress,
            ushort numberOfPointsToRead,
            ushort startWriteAddress,
            ushort[] writeData);
    }
}
