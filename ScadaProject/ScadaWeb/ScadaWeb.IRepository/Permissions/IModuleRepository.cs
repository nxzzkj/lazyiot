using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Model;

namespace ScadaWeb.IRepository
{
    public interface IModuleRepository : IBaseRepository<ModuleModel>
    {
        /// <summary>
        /// 根据角色ID获取菜单列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        IEnumerable<ModuleModel> GetModuleListByRoleId(string sql, int roleId);
        
    }
}
