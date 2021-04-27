using ScadaWeb.DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Model
{
    
   [Table("IO_SERVER")]
  public  class IOServerModel
    {
        public string SERVER_ID { get; set; }
        public string SERVER_NAME { get; set; }
        public int SERVER_STATUS { get; set; }
        public string SERVER_IP { get; set; }
        public string SERVER_CREATEDATE { get; set; }
        public string SERVER_REMARK { get; set; }
    }
}
