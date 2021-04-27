using ScadaWeb.DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Model
{
    [Table("IO_PARA")]
    public class IOParaModel
    {
        public string IO_DEVICE_ID { get; set; }
        public string IO_COMM_ID { get; set; }
        public string IO_SERVER_ID { get; set; }
        public string IO_ID { get; set; }
        public string IO_NAME { get; set; }
        public string IO_LABEL { get; set; }
        [Computed]
        public string IO_ALIASNAME { set; get; }
        [Computed]
        public bool LAY_CHECKED { set; get; }
    }
}
