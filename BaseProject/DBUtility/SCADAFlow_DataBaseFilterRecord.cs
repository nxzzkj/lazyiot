namespace Scada.DBUtility
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

    [Serializable]
    public class SCADAFlow_DataBaseFilterRecord : ISerializable
    {
        public SCADAFlow_DataBaseFilterRecord()
        {
            this.ID = Guid.NewGuid().ToString().Replace("-", "");
            this.ValueRecord = new SCADAFlow_DataBaseRecord();
            this.TextRecord = new SCADAFlow_DataBaseRecord();
            this.FilterType = SCADAFlow_DataBaseFilterType.Key;
            this.TextItems = new List<string>();
            this.ValueItems = new List<string>();
            this.Label = "";
            this.DynamicRecord = new FilterDropDownRecord();
        }

        public SCADAFlow_DataBaseFilterRecord(SerializationInfo info, StreamingContext context)
        {
            this.Label = (string) info.GetValue("Label", typeof(string));
            this.DynamicRecord = (FilterDropDownRecord) info.GetValue("DynamicRecord", typeof(FilterDropDownRecord));
            this.TextItems = (List<string>) info.GetValue("TextItems", typeof(List<string>));
            this.ValueItems = (List<string>) info.GetValue("ValueItems", typeof(List<string>));
            this.ValueRecord = (SCADAFlow_DataBaseRecord) info.GetValue("ValueRecord", typeof(SCADAFlow_DataBaseRecord));
            this.TextRecord = (SCADAFlow_DataBaseRecord) info.GetValue("TextRecord", typeof(SCADAFlow_DataBaseRecord));
            this.FilterType = (SCADAFlow_DataBaseFilterType) info.GetValue("FilterType", typeof(SCADAFlow_DataBaseFilterType));
        }

        public string GetHtmlDataString() => 
            (" data-dbdynamiclist='json_" + this.ID + "' ");

        public string GetHtmlDataString(string id) => 
            (" data-dbdynamiclist='" + id + "' ");

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Label", this.Label);
            info.AddValue("DynamicRecord", this.DynamicRecord);
            info.AddValue("TextItems", this.TextItems);
            info.AddValue("ValueItems", this.ValueItems);
            info.AddValue("ValueRecord", this.ValueRecord);
            info.AddValue("TextRecord", this.TextRecord);
            info.AddValue("FilterType", this.FilterType);
        }

        public string GetObjectJson()
        {
            string str = ScadaJsonConvertor.ObjectToJson(this);
            string[] textArray1 = new string[] { " <script id='json_", this.ID, "' type='application/json'> ", str, "</script>" };
            return string.Concat(textArray1);
        }

        public string GetObjectJson(string id)
        {
            string str = ScadaJsonConvertor.ObjectToJson(this);
            string[] textArray1 = new string[] { " <script id='", id, "' type='application/json'> ", str, "</script>" };
            return string.Concat(textArray1);
        }

        public override string ToString()
        {
            switch (this.FilterType)
            {
                case SCADAFlow_DataBaseFilterType.StaticDropList:
                {
                    object[] objArray4 = new object[] { this.Label, " ", this.FilterType, " ", string.Join(";", this.TextItems.ToArray()) };
                    return string.Concat(objArray4);
                }
                case SCADAFlow_DataBaseFilterType.DynamicDropList:
                {
                    object[] objArray3 = new object[] { this.Label, " ", this.FilterType, " ", this.DynamicRecord.ToString() };
                    return string.Concat(objArray3);
                }
                case SCADAFlow_DataBaseFilterType.Key:
                {
                    object[] objArray1 = new object[] { this.Label, " ", this.FilterType, " ", this.ValueRecord.ToString() };
                    return string.Concat(objArray1);
                }
                case SCADAFlow_DataBaseFilterType.DateRange:
                {
                    object[] objArray2 = new object[] { this.Label, " ", this.FilterType, " ", this.ValueRecord.ToString() };
                    return string.Concat(objArray2);
                }
            }
            return "";
        }

        public string ID { get; set; }

        public SCADAFlow_DataBaseRecord ValueRecord { get; set; }

        public SCADAFlow_DataBaseRecord TextRecord { get; set; }

        public SCADAFlow_DataBaseFilterType FilterType { get; set; }

        public List<string> TextItems { get; set; }

        public List<string> ValueItems { get; set; }

        public string Label { get; set; }

        public FilterDropDownRecord DynamicRecord { get; set; }
    }
}

