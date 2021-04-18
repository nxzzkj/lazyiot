namespace Scada.DBUtility
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

    [Serializable]
    public class SCADAFlow_MultiDataBaseViewFilter : ISerializable
    {
        public SCADAFlow_MultiDataBaseViewFilter()
        {
            this.Enable = false;
            this.FilterFields = new List<SCADAFlow_DataBaseFilterRecord>();
        }

        public SCADAFlow_MultiDataBaseViewFilter(SerializationInfo info, StreamingContext context)
        {
            this.FilterFields = (List<SCADAFlow_DataBaseFilterRecord>) info.GetValue("FilterFields", typeof(List<SCADAFlow_DataBaseFilterRecord>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FilterFields", this.FilterFields);
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < this.FilterFields.Count; i++)
            {
                str = str + this.FilterFields[i].ToString() + ",";
            }
            return str.ToString();
        }

        public bool Enable { get; set; }

        public List<SCADAFlow_DataBaseFilterRecord> FilterFields { get; set; }
    }
}

