using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.IOStructure
{
    [Serializable]
   public  class DllInfo
    {
        public string Title = "";//标题
        public string Product = "";//产品
        public string Company = "";//公司
        public string Version = "";//版本
        public string FullName = "";
        public string ClassName = "";
        public string FillName = "";//文件名称
        public string Description = "";
        public string GUID = "";
        public List<DriverInfo> CommDrivers = new List<DriverInfo>();
        public List<DriverInfo> DeviceDrivers = new List<DriverInfo>();
    }
    [Serializable]
    public class DriverInfo
    {
        public string Title = "";//标题
        public string ClassName = "";
        public string FullName = "";
        public string Guid = "";
        public string Namespace = "";
        public string DllGuid = "";
    }


}
