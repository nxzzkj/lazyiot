using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace MQTTServer
{
    public class ScadaHexByteOperator
    {
        public static string ObjectToJson(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            return JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        /// Json字符串转内存对象
        /// </summary>
        /// <param name="jsonString"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
        [DataContract, Serializable]
        public class MqttJsonDevice
        {
            [DataMember]
            public string uid { set; get; }
            [DataMember]
            public string soft_version { set; get; }
            [DataMember]
            public string hard_version { set; get; }
            [DataMember]
            public string run_time { set; get; }
            [DataMember]
            public string status { set; get; }
        }
        [DataContract, Serializable]
        public class MqttJsonAnalog
        {
            [DataMember]
            public MqttJsonPara current { set; get; }

        }
        [DataContract, Serializable]
        public class MqttJsonDigital
        {
            [DataMember]
            public MqttJsonPara relevance { set; get; }//符合采集
            [DataMember]
            public MqttJsonPara pulse_width { set; get; }//脉冲量
            [DataMember]
            public MqttJsonPara Switch { set; get; }//开关量
        }
        [DataContract, Serializable]
        public class MqttJsonPara
        {
            [DataMember]
            public string version { set; get; }
            [DataMember]
            public List<List<Object>> data { set; get; }

        }
        [DataContract, Serializable]
        public class MqttJsonObject
        {
            [DataMember]
            public MqttJsonDevice device { set; get; }
            [DataMember]
            public MqttJsonAnalog dev_analog { set; get; }
            [DataMember]
            public MqttJsonDigital dev_digital { set; get; }
        }

    }
}

