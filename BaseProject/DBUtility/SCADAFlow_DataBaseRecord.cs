namespace Scada.DBUtility
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

    [Serializable]
    public class SCADAFlow_DataBaseRecord : ISerializable
    {
        public SCADAFlow_DataBaseRecord()
        {
            this.RecordType = SCADAFlow_DataBaseRecordType.Varchar;
            this.Format = "";
            this.DecimalPlaces = 0;
        }

        public SCADAFlow_DataBaseRecord(SerializationInfo info, StreamingContext context)
        {
            this.DecimalPlaces = (int) info.GetValue("DecimalPlaces", typeof(int));
            this.Title = (string) info.GetValue("Title", typeof(string));
            this.Record = (string) info.GetValue("Record", typeof(string));
            this.Format = (string) info.GetValue("Format", typeof(string));
            this.RecordType = (SCADAFlow_DataBaseRecordType) info.GetValue("RecordType", typeof(SCADAFlow_DataBaseRecordType));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DecimalPlaces", this.DecimalPlaces);
            info.AddValue("Format", this.Format);
            info.AddValue("Title", this.Title);
            info.AddValue("Record", this.Record);
            info.AddValue("RecordType", this.RecordType);
        }

        public override string ToString()
        {
            string[] textArray1 = new string[] { (this.Title != null) ? this.Title.ToString() : "", " ", this.Record, " ", this.RecordType.ToString(), " ", this.Format };
            return string.Concat(textArray1);
        }

        public string Title { get; set; }

        public string Record { get; set; }

        public SCADAFlow_DataBaseRecordType RecordType { get; set; }

        public string Format { get; set; }

        public int DecimalPlaces { get; set; }
    }
}

