namespace Scada.DBUtility
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class SyBase_Connection : ScadaConnectionBase
    {
        public int Port;
        public string DataSource;
        public string servername;
        public string database;
        public string UID;
        public string PWD;

        public SyBase_Connection()
        {
            this.Port = 0x1838;
            this.DataSource = "";
            this.servername = "";
            this.database = "";
            this.UID = "";
            this.PWD = "";
            base.DataBaseType = DataBaseType.SyBase;
            base.Icon = ScadaFlowRes.sybase;
        }

        public SyBase_Connection(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.Port = 0x1838;
            this.DataSource = "";
            this.servername = "";
            this.database = "";
            this.UID = "";
            this.PWD = "";
            this.Port = (int) info.GetValue("Port", typeof(int));
            this.DataSource = (string) info.GetValue("DataSource", typeof(string));
            this.servername = (string) info.GetValue("servername", typeof(string));
            this.database = (string) info.GetValue("database", typeof(string));
            this.UID = (string) info.GetValue("UID", typeof(string));
            this.PWD = (string) info.GetValue("PWD", typeof(string));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Port", this.Port);
            info.AddValue("DataSource", this.DataSource);
            info.AddValue("servername", this.servername);
            info.AddValue("database", this.database);
            info.AddValue("UID", this.UID);
            info.AddValue("PWD", this.PWD);
        }

        public override string ToString()
        {
            string[] textArray1 = new string[] { base.DataBaseType.ToString(), " ", DESEncrypt.Decrypt(this.DataSource), " ", DESEncrypt.Decrypt(this.servername), " ", DESEncrypt.Decrypt(this.database) };
            return string.Concat(textArray1);
        }
    }
}

