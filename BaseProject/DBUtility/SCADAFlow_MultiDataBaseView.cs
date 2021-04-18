namespace Scada.DBUtility
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

    [Serializable]
    public class SCADAFlow_MultiDataBaseView : ISerializable
    {
        private string m_ConnectionString;

        public SCADAFlow_MultiDataBaseView()
        {
            this.m_ConnectionString = "";
            this.SqlString = "";
            this.UpdateCycle = 20;
            this.ViewFilter = new SCADAFlow_MultiDataBaseViewFilter();
            this.ViewPage = new SCADAFlow_MultiDataBaseViewPage();
            this.ValueType = SCADAFlow_DataBaseType.Table;
            this.AutoPage = false;
        }

        protected SCADAFlow_MultiDataBaseView(SerializationInfo info, StreamingContext context)
        {
            this.m_ConnectionString = "";
            this.Connection = (ScadaConnectionBase) info.GetValue("Connection", typeof(ScadaConnectionBase));
            this.SqlString = (string) info.GetValue("SqlString", typeof(string));
            this.m_ConnectionString = (string) info.GetValue("m_ConnectionString", typeof(string));
            this.UpdateCycle = (int) info.GetValue("UpdateCycle", typeof(int));
            this.AutoPage = (bool) info.GetValue("AutoPage", typeof(bool));
            this.ValueType = (SCADAFlow_DataBaseType) info.GetValue("ValueType", typeof(SCADAFlow_DataBaseType));
            this.ViewFilter = (SCADAFlow_MultiDataBaseViewFilter) info.GetValue("ViewFilter", typeof(SCADAFlow_MultiDataBaseViewFilter));
            this.ViewPage = (SCADAFlow_MultiDataBaseViewPage) info.GetValue("ViewPage", typeof(SCADAFlow_MultiDataBaseViewPage));
        }

        public string GetHtmlDataString(string uid)
        {
            if (this.Connection != null)
            {
                this.ConnectionString = this.Connection.ConnectionString;
            }
            object[] objArray1 = new object[] { " data-dbmultiple='json_", uid, "' data-datetime='' data-updatecycle='", this.UpdateCycle, "' " };
            return string.Concat(objArray1);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("m_ConnectionString", this.m_ConnectionString);
            info.AddValue("Connection", this.Connection);
            info.AddValue("SqlString", this.SqlString);
            info.AddValue("ValueType", this.ValueType);
            info.AddValue("ViewFilter", this.ViewFilter);
            info.AddValue("ViewPage", this.ViewPage);
            info.AddValue("UpdateCycle", this.UpdateCycle);
            info.AddValue("AutoPage", this.AutoPage);
        }

        public string GetObjectJson(string uid)
        {
            string str = ScadaJsonConvertor.ObjectToJson(this);
            string[] textArray1 = new string[] { " <script id='json_", uid, "' type='application/json'> ", str, "</script>" };
            return string.Concat(textArray1);
        }

        public override string ToString()
        {
            if (this.Connection != null)
            {
                return (this.Connection.ToString() + " " + this.ViewFilter.ToString());
            }
            return "";
        }

        public SCADAFlow_DataBaseType ValueType { get; set; }

        public string SqlString { get; set; }

        public int UpdateCycle { get; set; }

        public bool AutoPage { get; set; }

        public SCADAFlow_MultiDataBaseViewFilter ViewFilter { get; set; }

        public SCADAFlow_MultiDataBaseViewPage ViewPage { get; set; }

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

        public ScadaConnectionBase Connection { get; set; }
    }
}

