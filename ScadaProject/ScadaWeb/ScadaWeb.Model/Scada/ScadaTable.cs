using ScadaWeb.DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Model.Scada
{
    [Table("ScadaTable")]
    public class ScadaTable : Entity
    {
        public string Title { set; get; }
        public int RoleUserID { set; get; }
        public string FilterRule { set; get; }
        public int ShowAlarmTable { set; get; }
        public int ShowRealSeries { set; get; }
    }
    [Table("ScadaTableRows")]
    public class ScadaTableRows : Entity
    {
        public string TableId { set; get; }
        public string FieldIOPaths { set; get; }
        public string FieldTitles { set; get; }
    }
}
