using Scada.AsyncNetTcp.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Scada.AsyncNetTcp
{
    public delegate Task CommandHandle(byte[] datas, long commandid, string msg, ScadaTcpOperator command);
    public delegate Task HeartBeatHandle(AsyncTcpClient tcpClient, bool isconnect);
    public delegate void  SendFileHandle(AsyncTcpClient tcpClient, long total,long current,bool isend);
    public abstract class TcpHostMAC
    {
        private static string mac = "";
        public static string GetMAC()
        {
            string madAddr = null;
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc2 = mc.GetInstances();
            foreach (ManagementObject mo in moc2)
            {
                if (Convert.ToBoolean(mo["IPEnabled"]) == true)
                {
                    madAddr = mo["MacAddress"].ToString();
                    madAddr = madAddr.Replace(":", "").Replace("-", "");
                }
                mo.Dispose();
            }
            mac = madAddr;
            return madAddr;
        }

    }
    public    class SplitPakeage
    {
      /// <summary>
     /// 数组比较是否相等
     /// </summary>
     /// <param name="bt1">数组1</param>
     /// <param name="bt2">数组2</param>
     /// <returns>true:相等，false:不相等</returns>
        public   bool CompareArray(byte[] bt1, byte[] bt2)
        {
            var len1 = bt1.Length;
            var len2 = bt2.Length;
            if (len1 != len2)
            {
                return false;
            }
            for (var i = 0; i < len1; i++)
            {
                if (bt1[i] != bt2[i])
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 将一个数据组字节包装成当前的标准数据包
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public   byte[] AssembleBytes(ArraySegment<byte> datas, AsyncTcpClient client)
        {
           if( client.UsedPackageIdentification)
            {
                byte[] clientTypeBytes = new byte[1] { (byte)client.ScadaClientType };
                byte[] lengthBytes = BitConverter.GetBytes(Convert.ToInt32(datas.Count));
                int test_length = BitConverter.ToInt32(lengthBytes, 0);
                byte[] newData = new byte[datas.Count + client.PackInvalidSize + lengthBytes.Length];
                //构造新包,数据包的长度

                System.Array.Copy(client.HeadPackBytes, 0, newData, 0, client.HeadPackSize);//头部标识
                System.Array.Copy(client.MACBtyes, 0, newData, client.HeadPackSize, client.MACSize);//MAC地址
                System.Array.Copy(clientTypeBytes, 0, newData, client.HeadPackSize+ client.MACSize, client.ClientTypeSize);//标记当前客户端类型
                System.Array.Copy(lengthBytes, 0, newData, client.HeadPackSize +client.ClientTypeSize+ client.MACSize, lengthBytes.Length);//实际数据长度
                System.Array.Copy(datas.Array, datas.Offset, newData, client.HeadPackSize + client.ClientTypeSize + client.MACSize + lengthBytes.Length, datas.Count);//内容体
                System.Array.Copy(client.TailPackBytes, 0, newData, client.HeadPackSize + client.ClientTypeSize + client.MACSize + datas.Count + lengthBytes.Length, client.TailPackSize);//尾部标识
                return newData;
            }
            else
            {
                return datas.ToArray();
            }
        }
        public   byte[] AssembleBytes(ArraySegment<byte> datas, AsyncTcpListener Listener)
        {
            if (Listener.UsedPackageIdentification)
            {
                byte[] clientTypeBytes = new byte[1] { (byte)Listener.ScadaClientType };
                byte[] lengthBytes = BitConverter.GetBytes(Convert.ToInt32(datas.Count));
                int test_length = BitConverter.ToInt32(lengthBytes, 0);
                byte[] newData = new byte[datas.Count + Listener.PackInvalidSize + lengthBytes.Length];
                //构造新包,数据包的长度

                System.Array.Copy(Listener.HeadPackBytes, 0, newData, 0, Listener.HeadPackSize);//头部标识
                System.Array.Copy(Listener.MACBtyes, 0, newData, Listener.HeadPackSize, Listener.MACSize);//MAC地址
                System.Array.Copy(clientTypeBytes, 0, newData, Listener.HeadPackSize + Listener.MACSize, Listener.ClientTypeSize);//标记当前客户端类型
                System.Array.Copy(lengthBytes, 0, newData, Listener.HeadPackSize + Listener.ClientTypeSize+ Listener.MACSize, lengthBytes.Length);//实际数据长度
                System.Array.Copy(datas.Array, datas.Offset, newData, Listener.HeadPackSize +Listener.ClientTypeSize+ Listener.MACSize + lengthBytes.Length, datas.Count);//内容体
                System.Array.Copy(Listener.TailPackBytes, 0, newData, Listener.HeadPackSize + Listener.ClientTypeSize+Listener.MACSize + datas.Count + lengthBytes.Length, Listener.TailPackSize);//尾部标识
                return newData;
            }
            else
            {
                return datas.ToArray();
            }
        }
        /// <summary>
        /// 传入的数据是通过尾标识进行分隔的数据，所有此数据并不包含尾字节
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="client"></param>
        /// <param name="MAC"></param>
        /// <returns></returns>
        public   byte[]  RemoveIdentificationBytes(byte[] datas, AsyncTcpClient client,out string  MAC,out string message)
        {
            MAC = "";
            message = "";


            if (datas.Length < 0)
                return datas;
            if (client.UsedPackageIdentification)
            {

                //首先判断数据体是否否和数据包的要求
                //准备分隔数据包，由于本系统全部将字符串转换为字节，所以需要通过字符串来分隔
                byte[] clienttypebytes = new byte[1];//MAC地址
                byte[] headbytes = new byte[client.HeadPackSize];//头标识字节
                byte[] macbytes = new byte[client.MACSize];//MAC地址
                byte[] reallengthbytes = new byte[4];//实际数据长度字节
                byte[] tailbytes = new byte[client.TailPackSize];//获取尾标识
                   if(datas.Length<client.TailPackSize+ client.HeadPackSize+ client.MACSize+ clienttypebytes.Length)
                {
                    message = "心跳字节";
                    //表示心跳
                    return new byte[0];
                }

                try
                {
                    //获取头标识字节
                    System.Array.Copy(datas, 0, headbytes, 0, headbytes.Length);
                    //获取MAC标识字节
                    System.Array.Copy(datas, headbytes.Length, macbytes, 0, macbytes.Length);
                    System.Array.Copy(datas, headbytes.Length+ macbytes.Length, clienttypebytes, 0, clienttypebytes.Length);
                    //获取数据长度标识字节
                    System.Array.Copy(datas, headbytes.Length + clienttypebytes.Length+ macbytes.Length, reallengthbytes, 0, 4);
                    //获取尾标识字节
                    System.Array.Copy(datas, datas.Length - tailbytes.Length, tailbytes, 0, tailbytes.Length);
                }
                catch(Exception emx)
                {
                    message = ""+ emx.Message;
                    //表示心跳
                    return new byte[0];
                }

                //反回去获取分隔字节
                //判断包的头字节和尾字节是否一致，如果不包含头字节和尾字节，则放弃操作
                if (!CompareArray(headbytes, client.HeadPackBytes))
                {
         
                    return new byte[0];
                }
                ///实际数据体的字节长度

                int receive_length = BitConverter.ToInt32(reallengthbytes, 0);
                //数据体字节数+头字节数+MAC地址字节数+尾字节数应该与接收的数据字节数相等否则不做处理
                if (receive_length + client.HeadPackSize + client.MACSize + clienttypebytes.Length+ 4 + tailbytes.Length != datas.Length)
                {
                    return new byte[0];

                }
                //判断该字节是否包含头字节，如果包含则有效，如果不包含或者与头字节不一致，则认为不是符合要求的包，需要丢弃不处理
                bool isInvalid = true;
                for(int i=0;i< client.HeadPackSize;i++)
                {
                    if (datas[i] == client.HeadPackBytes[i])
                    {
                        continue;
                    }
                    else
                    {
                        isInvalid = false;
                        break;
                    }
                }
                if(!isInvalid)
                {
                    message = "无效字节";
                    return new byte[0];
                }
                  
                //获取MAC地址
                byte[] mac = new byte[client.MACSize];
                for (int i = client.HeadPackSize; i < client.HeadPackSize+ client.MACSize; i++)
                {
                    mac[i - client.HeadPackSize] = datas[i];
                }
                MAC = Encoding.UTF8.GetString(mac);//获取MAC
                client.ScadaClientType = (ScadaClientType)clienttypebytes[0];
                byte[] lengthbytes = new byte[4];
                for (int i = client.HeadPackSize+ client.MACSize + clienttypebytes.Length; i < client.HeadPackSize + client.MACSize + clienttypebytes.Length + 4; i++)
                {
                    lengthbytes[i - client.HeadPackSize- client.MACSize- clienttypebytes.Length] = datas[i];
                }
                int realength = BitConverter.ToInt32(lengthbytes,0);//实际内容的长度，包含了操作变量
                //返回实际内容的字节
                byte[] newData = new byte[realength];
                System.Array.Copy(datas, client.HeadPackSize+ client.MACSize+ clienttypebytes.Length + 4, newData,0, realength);
              
                return newData;
            }
            else
            {
                return datas;
            }
        }
    }
    public enum ScadaClientType
    {
        WebSystem=1,FlowDesign=2,IoManager=3,IoMonitor=4,IoServer=5
    }


}
