namespace Scada.DBUtility
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

    [Serializable]
    public class SCADAFlow_SingleDataBaseValue : ISerializable
    {
        private string m_ConnectionString;
        public int Decimalplace;

        public SCADAFlow_SingleDataBaseValue()
        {
            this.m_ConnectionString = "";
            this.SqlString = "";
            this.elementId = "";
            this.ValueType = SCADAFlow_DataBaseType.Single;
            this.UpdateCycle = 60;
            this.DateFormat = "yyyy-MM-dd HH:mm:ss";
            this.DateFormat = "yyyy-MM-dd HH:mm:ss";
            this.Value = "0.0";
        }

        public SCADAFlow_SingleDataBaseValue(string mDefault)
        {
            this.m_ConnectionString = "";
            this.SqlString = "";
            this.Value = mDefault;
        }

        protected SCADAFlow_SingleDataBaseValue(SerializationInfo info, StreamingContext context)
        {
            this.m_ConnectionString = "";
            this.Connection = (ScadaConnectionBase) info.GetValue("Connection", typeof(ScadaConnectionBase));
            this.SqlString = (string) info.GetValue("SqlString", typeof(string));
            this.UpdateCycle = (int) info.GetValue("UpdateCycle", typeof(int));
            this.Value = (string) info.GetValue("Value", typeof(string));
            this.DateFormat = (string) info.GetValue("DateFormat", typeof(string));
            this.ConnectionString = (string) info.GetValue("ConnectionString", typeof(string));
            this.Decimalplace = (int) info.GetValue("Decimalplace", typeof(int));
            this.ValueType = (SCADAFlow_DataBaseType) info.GetValue("ValueType", typeof(SCADAFlow_DataBaseType));
            this.Record = (SCADAFlow_DataBaseRecord) info.GetValue("Record", typeof(SCADAFlow_DataBaseRecord));
        }

        public SCADAFlow_SingleDataBaseValue(float mDefault, string format)
        {
            this.m_ConnectionString = "";
            this.SqlString = "";
            this.Value = mDefault.ToString(format);
        }

        public string GetHtmlDataString(string uid)
        {
            if (this.Connection != null)
            {
                this.ConnectionString = this.Connection.ConnectionString;
            }
            object[] objArray1 = new object[] { " data-dbsingle='json_", uid, "' data-datetime='' data-updatecycle='", this.UpdateCycle, "' data-decimalplace='", this.Decimalplace, "'" };
            return string.Concat(objArray1);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Connection", this.Connection);
            info.AddValue("SqlString", this.SqlString);
            info.AddValue("ValueType", this.ValueType);
            info.AddValue("Record", this.Record);
            info.AddValue("UpdateCycle", this.UpdateCycle);
            info.AddValue("Value", this.Value);
            info.AddValue("DateFormat", this.DateFormat);
            info.AddValue("Decimalplace", this.Decimalplace);
            info.AddValue("ConnectionString", this.ConnectionString);
        }

        public string GetObjectJson(string uid)
        {
            string str = ScadaJsonConvertor.ObjectToJson(this);
            string[] textArray1 = new string[] { " <script id='json_", uid, "' type='application/json'> ", str, "</script>" };
            return string.Concat(textArray1);
        }

        public override string ToString()
        {
            if (this.Connection == null)
            {
                string[] textArray1 = new string[] { (this.Record != null) ? this.Record.ToString() : "", " ", this.UpdateCycle.ToString(), " ", this.Value };
                return string.Concat(textArray1);
            }
            return this.Connection.ToString();
        }

        public string elementId { get; set; }

        public SCADAFlow_DataBaseType ValueType { get; set; }

        public SCADAFlow_DataBaseRecord Record { get; set; }

        public int UpdateCycle { get; set; }

        public string DateFormat { get; set; }

        public string ConnectionString
        {
            get
            {
                return this.m_ConnectionString;
            }
            set
            {
                this.m_ConnectionString = value;
            }
        }

        public string Value { get; set; }

        public ScadaConnectionBase Connection { get; set; }

        public string SqlString { get; set; }
    }
}

