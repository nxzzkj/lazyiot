namespace Scada.DBUtility
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class SqlServer_Connection : ScadaConnectionBase
    {
        public string Database;
        public string userid;
        public string password;
        public int ConnectTimeout;
        public string Server;

        public SqlServer_Connection()
        {
            this.Database = "";
            this.userid = "";
            this.password = "";
            this.ConnectTimeout = 30;
            this.Server = "";
            base.DataBaseType = DataBaseType.SQLServer;
            base.Icon = ScadaFlowRes.sqlserver;
        }

        public SqlServer_Connection(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.Database = "";
            this.userid = "";
            this.password = "";
            this.ConnectTimeout = 30;
            this.Server = "";
            this.Database = (string) info.GetValue("Database", typeof(string));
            this.userid = (string) info.GetValue("userid", typeof(string));
            this.password = (string) info.GetValue("password", typeof(string));
            this.ConnectTimeout = (int) info.GetValue("ConnectTimeout", typeof(int));
            this.Server = (string) info.GetValue("Server", typeof(string));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Database", this.Database);
            info.AddValue("userid", this.userid);
            info.AddValue("password", this.password);
            info.AddValue("ConnectTimeout", this.ConnectTimeout);
            info.AddValue("Server", this.Server);
        }

        public override string ToString()
        {
            string[] textArray1 = new string[] { base.DataBaseType.ToString(), " ", DESEncrypt.Decrypt(this.Server), " ", DESEncrypt.Decrypt(this.Database) };
            return string.Concat(textArray1);
        }
    }
}

