namespace Scada.DBUtility
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

    [Serializable]
    public class SCADAFlow_MultiDataBaseViewPage : ISerializable
    {
        public SCADAFlow_MultiDataBaseViewPage()
        {
            this.PageSize = 100;
            this.Enable = true;
        }

        public SCADAFlow_MultiDataBaseViewPage(SerializationInfo info, StreamingContext context)
        {
            this.PageSize = (int) info.GetValue("PageSize", typeof(int));
            this.Enable = (bool) info.GetValue("Enable", typeof(bool));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PageSize", this.PageSize);
            info.AddValue("Enable", this.Enable);
        }

        public int PageSize { get; set; }

        public bool Enable { get; set; }
    }
}

