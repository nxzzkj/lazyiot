using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Model;
using ScadaWeb.Common;

namespace ScadaWeb.IService
{
    public interface IRoleAuthorizeService : IBaseService<RoleAuthorizeModel>
    {
        /// <summary>
        /// 保存菜单角色权限配置
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        int SavePremission(IEnumerable<RoleAuthorizeModel> entitys, int roleId);

        /// <summary>
        /// 根据角色菜单获得列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        IEnumerable<RoleAuthorizeModel> GetListByRoleIdModuleId(int roleId, int moduleId);
    }
}
