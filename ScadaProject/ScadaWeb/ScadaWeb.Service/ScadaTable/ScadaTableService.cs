using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Common;
using ScadaWeb.IService;
using ScadaWeb.Model;
using ScadaWeb.IRepository;

namespace ScadaWeb.Service
{
    public class ScadaTableService : BaseService<ScadaTableModel>, IScadaTableService
    {
        public dynamic GetListByFilter(ScadaTableModel filter, PageInfo pageInfo)
        {
            string _where = " where 1=1";
            if (!string.IsNullOrEmpty(filter.Title))
            {
                _where += " and Title=@Title";
            }
           
            return GetListByFilter(filter, pageInfo, _where);
        }
    }
    public class ScadaTableRowsService : BaseService<ScadaTableRowsModel>, IScadaTableRowsService
    {
        public dynamic GetListByFilter(ScadaTableRowsModel filter, PageInfo pageInfo)
        {
            throw new NotImplementedException();
        }
    }
    public class ScadaTableUserRoleService : BaseService<ScadaTableUserRoleModel>, IScadaTableUserRoleService
    {
        public dynamic GetListByFilter(ScadaTableUserRoleModel filter, PageInfo pageInfo)
        {
            throw new NotImplementedException();
        }
    }
}
