namespace Scada.DBUtility
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;

    [Serializable]
    public class SQLite_Connection : ScadaConnectionBase
    {
        public string Version;
        public string DataSource;
        public string password;

        public SQLite_Connection()
        {
            this.Version = "";
            this.DataSource = "";
            this.password = "";
            base.DataBaseType = DataBaseType.SQLite;
            base.Icon = ScadaFlowRes.sqlite;
        }

        public SQLite_Connection(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.Version = "";
            this.DataSource = "";
            this.password = "";
            this.Version = (string) info.GetValue("Version", typeof(string));
            this.DataSource = (string) info.GetValue("DataSource", typeof(string));
            this.password = (string) info.GetValue("password", typeof(string));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Version", this.Version);
            info.AddValue("DataSource", this.DataSource);
            info.AddValue("password", this.password);
        }

        public override string ToString()
        {
            string[] textArray1 = new string[] { base.DataBaseType.ToString(), " ", Path.GetFileNameWithoutExtension(DESEncrypt.Decrypt(this.DataSource)), " Version=", DESEncrypt.Decrypt(this.Version) };
            return string.Concat(textArray1);
        }
    }
}

