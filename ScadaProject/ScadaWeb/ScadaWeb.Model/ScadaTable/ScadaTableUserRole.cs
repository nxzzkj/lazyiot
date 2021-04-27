using ScadaWeb.DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Model
{
    [Table("ScadaTableUserRole")]
    public class ScadaTableUserRoleModel : Entity
    {
        public int UserId { set; get; }
        public int TableId { set; get; }

    }
}
