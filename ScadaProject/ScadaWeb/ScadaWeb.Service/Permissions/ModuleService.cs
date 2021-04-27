using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.IService;
using ScadaWeb.Model;
using ScadaWeb.IRepository;

namespace ScadaWeb.Service
{
    public class ModuleService : BaseService<ModuleModel>, IModuleService
    {
        public IModuleRepository ModuleRepository { get; set; }
        public IButtonService ButtonService { get; set; }
        public IRoleAuthorizeService RoleAuthorizeService { get; set; }

        public dynamic GetListByFilter(ModuleModel filter, PageInfo pageInfo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获得菜单列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public dynamic GetModuleList(int roleId)
        {
            IEnumerable<ModuleModel> allMenus = GetModuleListByRoleId(roleId);
            List<Tree> treeList = new List<Tree>();
            var rootMenus = allMenus.Where(x => x.ParentId == 0).OrderBy(x => x.SortCode);
            foreach (var item in rootMenus)
            {
                var _tree = new Tree { id = item.Id, title = item.FullName, href = item.UrlAddress, fontFamily = item.FontFamily, icon = item.Icon };
                GetModuleListByModuleId(treeList, allMenus, _tree, item.Id);
                treeList.Add(_tree);
            }
            var result = treeList;
            return result;
        }

        /// <summary>
        /// 根据一级菜单加载子菜单列表
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="allMenus"></param>
        /// <param name="tree"></param>
        /// <param name="moduleId"></param>
        private void GetModuleListByModuleId(List<Tree> treeList, IEnumerable<ModuleModel> allMenus, Tree tree, int moduleId)
        {
            var childMenus = allMenus.Where(x => x.ParentId == moduleId).OrderBy(x => x.SortCode);
            if (childMenus != null && childMenus.Count() > 0)
            {
                List<Tree> _children = new List<Tree>();
                foreach (var item in childMenus)
                {
                    var _tree = new Tree { id = item.Id, title = item.FullName, href = item.UrlAddress, fontFamily = item.FontFamily, icon = item.Icon };
                    _children.Add(_tree);
                    tree.children = _children;
                    GetModuleListByModuleId(treeList, allMenus, _tree, item.Id);
                }
            }
        }

        /// <summary>
        /// 根据角色ID获取菜单列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        private IEnumerable<ModuleModel> GetModuleListByRoleId(int roleId)
        {
            string sql = @"SELECT b.* FROM roleauthorize a
                           INNER JOIN module b ON a.ModuleId = b.Id";
            var list = ModuleRepository.GetModuleListByRoleId(sql, roleId);
            return list;
        }

        /// <summary>
        /// Module treeSelect数据列表
        /// </summary>
        public IEnumerable<TreeSelect> GetModuleTreeSelect()
        {
            IEnumerable<ModuleModel> moduleList = BaseRepository.GetAll("Id,FullName,ParentId", "ORDER BY SortCode ASC");
            var rootModuleList = moduleList.Where(x => x.ParentId == 0).OrderBy(x => x.SortCode);
            List<TreeSelect> treeSelectList = new List<TreeSelect>();
            foreach (var item in rootModuleList)
            {
                TreeSelect tree = new TreeSelect
                {
                    id = item.Id.ToString(),
                    name = item.FullName,
                    open = false
                };
                GetModuleChildren(treeSelectList, moduleList, tree, item.Id);
                treeSelectList.Add(tree);
            }
            return treeSelectList;
        }

        /// <summary>
        /// 递归遍历treeSelectList
        /// </summary>
        private void GetModuleChildren(List<TreeSelect> treeSelectList, IEnumerable<ModuleModel> moduleList, TreeSelect tree, int id)
        {
            var childModuleList = moduleList.Where(x => x.ParentId == id).OrderBy(x => x.SortCode);
            if (childModuleList != null && childModuleList.Count() > 0)
            {
                List<TreeSelect> _children = new List<TreeSelect>();
                foreach (var item in childModuleList)
                {
                    TreeSelect _tree = new TreeSelect
                    {
                        id = item.Id.ToString(),
                        name = item.FullName,
                        open = false
                    };
                    _children.Add(_tree);
                    tree.children = _children;
                    GetModuleChildren(treeSelectList, moduleList, _tree, item.Id);
                }
            }
        }
        /// <summary>
        /// 获取所有菜单列表及可用按钮权限列表
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public IEnumerable<ModuleModel> GetModuleButtonList(int roleId)
        {
            string returnFields = "Id,ParentId,FullName,Icon,SortCode";
            string orderby = "ORDER BY SortCode ASC";
            IEnumerable<ModuleModel> list = GetAll(returnFields, orderby);
            foreach (var item in list)
            {
                item.ModuleButtonHtml = ButtonService.GetButtonListHtmlByRoleIdModuleId(roleId, item.Id);
                item.IsChecked = RoleAuthorizeService.GetListByRoleIdModuleId(roleId, item.Id).Count() > 0 ? true : false;
            }
            return list;
        }
    }
}
