using ScadaWeb.DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Model
{
    [Table("ScadaTableRows")]
    public class ScadaTableRowsModel : Entity
    {
        public int TableId { set; get; }
        public string FieldIOPaths { set; get; }
        public string FieldColors { set; get; }
        public string FieldFontSizes { set; get; }
        public string FieldBackColors { set; get; }
        public string FieldWidths { set; get; }
        public string FieldWeights { set; get; }


    }
}
