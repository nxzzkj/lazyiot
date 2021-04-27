namespace Scada.DBUtility
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

    [Serializable]
    public class ScadaConnectionBase : ISerializable
    {
        public Image Icon;

        public ScadaConnectionBase()
        {
            this.UID = Guid.NewGuid().ToString().Replace("-", "");
            this.DataBaseType = Scada.DBUtility.DataBaseType.SQLServer;
        }

        public ScadaConnectionBase(SerializationInfo info, StreamingContext context)
        {
            this.DataBaseType = (Scada.DBUtility.DataBaseType) info.GetValue("DataBaseType", typeof(Scada.DBUtility.DataBaseType));
            try
            {
                if (info.GetValue("UID", typeof(string)) != null)
                {
                    this.UID = (string) info.GetValue("UID", typeof(string));
                }
                else
                {
                    this.UID = Guid.NewGuid().ToString();
                }
            }
            catch
            {
                this.UID = Guid.NewGuid().ToString();
            }
            this.ConnectionString = (string) info.GetValue("ConnectionString", typeof(string));
            this.Icon = (Image) info.GetValue("Icon", typeof(Image));
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DataBaseType", this.DataBaseType);
            info.AddValue("ConnectionString", this.ConnectionString);
            info.AddValue("Icon", this.Icon);
            info.AddValue("UID", this.UID);
        }

        public virtual string ToSVGString() => 
            this.ConnectionString;

        public string UID { get; set; }

        public Scada.DBUtility.DataBaseType DataBaseType { get; set; }

        public string ConnectionString { get; set; }
    }
}

