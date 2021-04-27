using Scada.AsyncNetTcp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace IOMonitor
{
    /// <summary>
    /// 采集器端配置
    /// </summary>
    public class IOConfig
    {
        public string xmlname = System.Windows.Forms.Application.StartupPath + "/Config.xml";
        public IOConfig(string xml)
        {
            xmlname = xml;
            //读取xml文件
            ReadConfig(xml);
        }
        public IOConfig()
        {
            //读取xml文件
            ReadConfig(System.Windows.Forms.Application.StartupPath + "/Config.xml");
        }
        public string RemoteIP = "";
        public string RemotePort = "8888";
        public string LocalPort = "8888";
        public string User = "admin";
        public string Password = "123456";
        public string Project = "";
 
        public void ReadConfig(string filename)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);
                XmlNodeList list = doc.SelectNodes("/IOServer");
                if (list == null)
                {
                    return;
                }
                foreach (XmlNode item in list)
                {
                    RemoteIP = item["RemoteIP"].InnerText.Trim();
                    RemotePort = item["RemotePort"].InnerText.Trim();
                    LocalPort = item["LocalPort"].InnerText.Trim();
                
                    User = item["User"].InnerText.Trim();
                    Password = item["Password"].InnerText.Trim();
                    Project = item["Project"].InnerText.Trim();
                    TcpPackConfig.HeartBeat = item["HeartBeat"].InnerText.Trim();
                    TcpPackConfig.HeadPack = item["HeadPack"].InnerText.Trim();
                    TcpPackConfig.TailPack = item["TailPack"].InnerText.Trim();

                    int DelayTime = 20;
                    if (int.TryParse(item["DelayTime"].InnerText.Trim(), out DelayTime))
                    {
                        TcpPackConfig.DelayTime = DelayTime;
                    }
                    int recbuffsize = 5120;
                    if (int.TryParse(item["ReceiveBufferSize"].InnerText.Trim(), out recbuffsize))
                    {
                        TcpPackConfig.ReceiveBufferSize = recbuffsize;
                    }

                    int sendbuffsize = 5120;
                    if (int.TryParse(item["SendBufferSize"].InnerText.Trim(), out sendbuffsize))
                    {
                        TcpPackConfig.SendBufferSize = sendbuffsize;
                    }
                    int sendtimeout = 100000;
                    if (int.TryParse(item["SendTimeout"].InnerText.Trim(), out sendtimeout))
                    {
                        TcpPackConfig.SendTimeout = sendtimeout;
                    }
                    int rectimeout = 100000;
                    if (int.TryParse(item["ReceiveTimeout"].InnerText.Trim(), out rectimeout))
                    {
                        TcpPackConfig.ReceiveTimeout = rectimeout;
                    }

                }
                doc = null;
            }
            catch(Exception emx)
            {
                MessageBox.Show(emx.Message);
            }
        }
        public void WriteConfig()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlname);
            XmlNodeList list = doc.SelectNodes("/IOServer");
            foreach (XmlNode item in list)
            {
                item["RemoteIP"].InnerText=RemoteIP ;
                item["RemotePort"].InnerText= RemotePort;
                item["LocalPort"].InnerText= LocalPort;
              
                item["User"].InnerText= User;
                item["Password"].InnerText= Password ;
                item["Project"].InnerText= Project ;
                item["HeartBeat"].InnerText = TcpPackConfig.HeartBeat;
                item["HeadPack"].InnerText = TcpPackConfig.HeadPack;
                item["TailPack"].InnerText = TcpPackConfig.TailPack;
                item["DelayTime"].InnerText = TcpPackConfig.DelayTime.ToString();
                item["ReceiveBufferSize"].InnerText = TcpPackConfig.ReceiveBufferSize.ToString();
                item["SendBufferSize"].InnerText = TcpPackConfig.SendBufferSize.ToString();
                item["SendTimeout"].InnerText = TcpPackConfig.SendTimeout.ToString();
                item["ReceiveTimeout"].InnerText = TcpPackConfig.ReceiveTimeout.ToString();
            }

            doc.Save(xmlname);
            doc = null;
        }
    }
}
