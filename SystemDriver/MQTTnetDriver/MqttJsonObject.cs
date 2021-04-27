using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTnet
{
    [Serializable]
    public class MqttJsonDevice
    {
        public string uid { set; get; }
        public string soft_version{set;get;}
        public string hard_version { set; get; }
        public string run_time { set; get; }
        public string status { set; get; }
    }
    
    [Serializable]
    public class MqttJsonPara
    {
        public string name { set; get; }
        public string datatype { set; get; }
        public string iotype { set; get; }
        public string version { set; get; }
        public List<Object> data { set; get; }

    }
 
   
    [Serializable]
    public  class MqttJsonObject
    {
        public MqttJsonDevice device { set; get; }
        public  List<MqttJsonPara> paras
        {
            set; get;
        }
    }
    ///定义西安亚泰的数据解析类
    [Serializable]
    public class CommonMqttJsonPara
    {
        public string name { set; get; }
        public List<Object> data { set; get; }

    }
    [Serializable]
    public class CommonMqttJsonDevice
    {
        public string uid { set; get; }
    }

    [Serializable]
    public class CommonMqttJsonObject
    {
        public CommonMqttJsonDevice device { set; get; }
        public List<CommonMqttJsonPara> paras
        {
            set; get;
        }
    }

}

