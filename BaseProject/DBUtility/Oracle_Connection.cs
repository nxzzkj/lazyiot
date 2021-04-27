namespace Scada.DBUtility
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class Oracle_Connection : ScadaConnectionBase
    {
        public string user;
        public string password;
        public string DataSource;

        public Oracle_Connection()
        {
            this.user = "";
            this.password = "";
            this.DataSource = "";
            base.DataBaseType = DataBaseType.Oracle;
            base.Icon = ScadaFlowRes.oracle;
        }

        public Oracle_Connection(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.user = "";
            this.password = "";
            this.DataSource = "";
            this.user = (string) info.GetValue("user", typeof(string));
            this.password = (string) info.GetValue("password", typeof(string));
            this.DataSource = (string) info.GetValue("DataSource", typeof(string));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("user", this.user);
            info.AddValue("password", this.password);
            info.AddValue("DataSource", this.DataSource);
        }

        public override string ToString() => 
            (base.DataBaseType.ToString() + " " + DESEncrypt.Decrypt(this.DataSource));
    }
}

