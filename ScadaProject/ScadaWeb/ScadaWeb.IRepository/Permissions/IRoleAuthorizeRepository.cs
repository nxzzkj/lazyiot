using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Common;
using ScadaWeb.Model;

namespace ScadaWeb.IRepository
{
    public interface IRoleAuthorizeRepository : IBaseRepository<RoleAuthorizeModel>
    {
        /// <summary>
        /// 保存菜单角色权限配置
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        int SavePremission(IEnumerable<RoleAuthorizeModel> entitys, int roleId);
    }
}
