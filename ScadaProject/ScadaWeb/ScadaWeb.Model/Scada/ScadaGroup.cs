using ScadaWeb.DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Model
{
    [Table("ScadaGroup")]
    public  class ScadaGroupModel:Entity
    {
        public string GroupTitle { set; get; }
        public int ParentId { set; get; }

    }
}
