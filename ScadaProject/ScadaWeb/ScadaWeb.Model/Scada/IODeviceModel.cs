using ScadaWeb.DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Model
{
    [Table("IO_DEVICE")]
  public  class IODeviceModel
    {
        public string IO_DEVICE_ID { get; set; }
        public string IO_COMM_ID { get; set; }
        public string IO_SERVER_ID { get; set; }
        public string IO_DEVICE_NAME { get; set; }
        public string IO_DEVICE_LABLE { get; set; }
        public string IO_DEVICE_REMARK { get; set; }
        public string IO_DEVICE_UPDATECYCLE { get; set; }
        public string IO_DEVICE_STATUS { get; set; }
        public string IO_DEVICE_OVERTIME { get; set; }
        public string IO_DEVICE_ADDRESS { get; set; }
        public string IO_DEVICE_PARASTRING { get; set; }
        public string DEVICE_DRIVER_ID { get; set; }
        
    }
}
