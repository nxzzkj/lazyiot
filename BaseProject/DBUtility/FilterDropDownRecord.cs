namespace Scada.DBUtility
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

    [Serializable]
    public class FilterDropDownRecord : ISerializable
    {
        public FilterDropDownRecord()
        {
            this.DynamicSql = "";
            this.TextRecord = new SCADAFlow_DataBaseRecord();
            this.ValueRecord = new SCADAFlow_DataBaseRecord();
        }

        public FilterDropDownRecord(SerializationInfo info, StreamingContext context)
        {
            this.DynamicSql = (string) info.GetValue("DynamicSql", typeof(string));
            this.TextRecord = (SCADAFlow_DataBaseRecord) info.GetValue("TextRecord", typeof(SCADAFlow_DataBaseRecord));
            this.ValueRecord = (SCADAFlow_DataBaseRecord) info.GetValue("ValueRecord", typeof(SCADAFlow_DataBaseRecord));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DynamicSql", this.DynamicSql);
            info.AddValue("TextRecord", this.TextRecord);
            info.AddValue("ValueRecord", this.ValueRecord);
        }

        public override string ToString() => 
            this.TextRecord.ToString();

        public SCADAFlow_DataBaseRecord TextRecord { get; set; }

        public SCADAFlow_DataBaseRecord ValueRecord { get; set; }

        public string DynamicSql { get; set; }
    }
}

