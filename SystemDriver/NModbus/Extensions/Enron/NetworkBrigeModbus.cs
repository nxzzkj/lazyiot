using Modbus.Device;
using Modbus.Globel;
using Modbus.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Modbus.Extensions.Enron
{
    /// <summary>
    /// 基于网桥传输的modbus
    /// </summary>
    public class ModbusNetworkBrigeModbus : ModbusMaster
    { /// <summary>
      ///     Modbus IP master device.
      /// </summary>
      /// <param name="transport">Transport used by this master.</param>
        private ModbusNetworkBrigeModbus(ModbusTransport transport)
            : base(transport)
        {
        }
        public static ModbusNetworkBrigeModbus CreateIp(TcpClient tcpClient)
        {
            if (tcpClient == null)
            {
                throw new ArgumentNullException(nameof(tcpClient));
            }

            return CreateIp(new TcpClientAdapter(tcpClient));
        }

        /// <summary>
        ///    Modbus IP master factory method.
        /// </summary>
        /// <returns>New instance of Modbus IP master device using provided UDP client.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Breaking change.")]
        public static ModbusNetworkBrigeModbus CreateIp(UdpClient udpClient)
        {
            if (udpClient == null)
            {
                throw new ArgumentNullException(nameof(udpClient));
            }

            if (!udpClient.Client.Connected)
            {
                throw new InvalidOperationException(Resources.UdpClientNotConnected);
            }

            return CreateIp(new UdpClientAdapter(udpClient));
        }

        

        /// <summary>
        ///     Modbus IP master factory method.
        /// </summary>
        /// <returns>New instance of Modbus IP master device using provided stream resource.</returns>
        public static ModbusNetworkBrigeModbus CreateIp(IStreamResource streamResource)
        {
            if (streamResource == null)
            {
                throw new ArgumentNullException(nameof(streamResource));
            }

            return new ModbusNetworkBrigeModbus(new ModbusIpTransport(streamResource));
        }
    }
}
