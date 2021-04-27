namespace Scada.DBUtility
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class MySQL_Connection : ScadaConnectionBase
    {
        public string user;
        public string password;
        public string server;
        public int port;
        public string database;

        public MySQL_Connection()
        {
            this.user = "";
            this.password = "";
            this.server = "";
            this.port = 0xcea;
            this.database = "";
            base.DataBaseType = DataBaseType.MySQL;
            base.Icon = ScadaFlowRes.mysql;
        }

        public MySQL_Connection(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.user = "";
            this.password = "";
            this.server = "";
            this.port = 0xcea;
            this.database = "";
            this.user = (string) info.GetValue("user", typeof(string));
            this.password = (string) info.GetValue("password", typeof(string));
            this.server = (string) info.GetValue("server", typeof(string));
            this.port = (int) info.GetValue("port", typeof(int));
            this.database = (string) info.GetValue("database", typeof(string));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("user", this.user);
            info.AddValue("password", this.password);
            info.AddValue("server", this.server);
            info.AddValue("port", this.port);
            info.AddValue("database", this.database);
        }

        public override string ToString()
        {
            string[] textArray1 = new string[] { base.DataBaseType.ToString(), " ", DESEncrypt.Decrypt(this.server), " ", DESEncrypt.Decrypt(this.database) };
            return string.Concat(textArray1);
        }
    }
}

