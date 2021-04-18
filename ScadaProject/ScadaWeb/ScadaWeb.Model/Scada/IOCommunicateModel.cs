using ScadaWeb.DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Model
{
    [Table("IO_COMMUNICATION")]
    public class IOCommunicateModel
    {
        public string IO_COMM_ID { get; set; }
        public string IO_COMM_NAME { get; set; }
        public string IO_COMM_LABEL { get; set; }
        public string IO_COMM_REMARK { get; set; }
        public int IO_COMM_STATUS { get; set; }
        public string IO_COMM_DRIVER_ID { get; set; }
        public string IO_SERVER_ID { get; set; }
        public string IO_COMM_PARASTRING { get; set; }
    }
}
