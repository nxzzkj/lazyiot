using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scada.AsyncNetTcp
{

    //网络配置相关
  public abstract  class TcpPackConfig
    {
        public static string HeartBeat = "HH";
        public static string HeadPack = "ZZTEC";
        public static string TailPack = "SCADA";
        public static bool UsedPackageIdentification = true;
        public static int NormalPackSize = 2048;
        public static int ReceiveTimeout = 100000;//100秒
        public static int SendTimeout = 100000;
        public static int SendBufferSize = 5120;
        public static int ReceiveBufferSize = 5120;
        public static int ByteBufferCapacity = 20480;
        public static int DelayTime = 20;

        /// <summary>
        /// 获取网络延迟时间,动态调整发送数据的时间
        /// </summary>
        public static   void  SendDelayTime()
        {
           
            Thread.Sleep(DelayTime);


        }


    }
}
