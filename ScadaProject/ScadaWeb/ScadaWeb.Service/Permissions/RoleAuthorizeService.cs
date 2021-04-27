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
    public class RoleAuthorizeService : BaseService<RoleAuthorizeModel>, IRoleAuthorizeService
    {
        public IRoleAuthorizeRepository RoleAuthorizeRepository { get; set; }

        public dynamic GetListByFilter(RoleAuthorizeModel filter, PageInfo pageInfo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存菜单角色权限配置
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int SavePremission(IEnumerable<RoleAuthorizeModel> entitys, int roleId)
        {
            return RoleAuthorizeRepository.SavePremission(entitys, roleId);
        }

        /// <summary>
        /// 根据角色菜单获得列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public IEnumerable<RoleAuthorizeModel> GetListByRoleIdModuleId(int roleId, int moduleId)
        {
            string where = "where RoleId=@RoleId and ModuleId=@ModuleId";
            return GetByWhere(where, new { RoleId = roleId, ModuleId = moduleId });
        }
    }
}
