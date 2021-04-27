using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Common;
using ScadaWeb.Model;

namespace ScadaWeb.IRepository
{
    public interface IScadaTableRepository : IBaseRepository<ScadaTableModel>
    {
       
    }
    public interface IScadaTableRowsRepository : IBaseRepository<ScadaTableRowsModel>
    {

    }
    public interface IScadaTableUserRoleRepository : IBaseRepository<ScadaTableUserRoleModel>
    {

    }
}
