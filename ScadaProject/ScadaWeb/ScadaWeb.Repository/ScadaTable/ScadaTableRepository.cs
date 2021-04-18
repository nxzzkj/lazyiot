using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Common;
using ScadaWeb.Model;
using ScadaWeb.Repository;
using System.Data;
using DapperExtensions.MySQLExt;

namespace ScadaWeb.IRepository
{
    public class ScadaTableRepository : BaseRepository<ScadaTableModel>, IScadaTableRepository
    {
 
    }
    public class ScadaTableRowsRepository : BaseRepository<ScadaTableRowsModel>, IScadaTableRowsRepository
    {

    }
    public class ScadaTableUserRoleRepository : BaseRepository<ScadaTableUserRoleModel>, IScadaTableUserRoleRepository
    {

    }
}
