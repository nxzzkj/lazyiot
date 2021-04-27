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
    public class OrganizeService : BaseService<OrganizeModel>, IOrganizeService
    {
        public IOrganizeRepository OrganizeRepository { get; set; }
        public dynamic GetListByFilter(OrganizeModel filter, PageInfo pageInfo)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Organize TreeGrid数据列表
        /// </summary>
        public IEnumerable<OrganizeModel> GetOrganizeList()
        {
            return OrganizeRepository.GetOrganizeList();
        }
        /// <summary>
        /// Organize treeSelect数据列表
        /// </summary>
        public IEnumerable<TreeSelect> GetOrganizeTreeSelect()
        {
            IEnumerable<OrganizeModel> organizeList = BaseRepository.GetAll("Id,FullName,ParentId", "ORDER BY SortCode ASC");
            var rootOrganizeList = organizeList.Where(x => x.ParentId == 0).OrderBy(x => x.SortCode);
            List<TreeSelect> treeSelectList = new List<TreeSelect>();
            foreach (var item in rootOrganizeList)
            {
                TreeSelect tree = new TreeSelect
                {
                    id = item.Id.ToString(),
                    name = item.FullName,
                    open = false
                };
                GetOrganizeChildren(treeSelectList, organizeList, tree, item.Id);
                treeSelectList.Add(tree);
            }
            return treeSelectList;
        }
        public string GetOrganizeNodeChildren(int id)
        {
            IEnumerable<OrganizeModel> organizeList = BaseRepository.GetAll("Id,FullName,ParentId", "ORDER BY SortCode ASC");
            var rootOrganizeList = organizeList.Where(x => x.Id == id).OrderBy(x => x.SortCode);
            List<TreeSelect> treeSelectList = new List<TreeSelect>();
            foreach (var item in rootOrganizeList)
            {
                TreeSelect tree = new TreeSelect
                {
                    id = item.Id.ToString(),
                    name = item.FullName,
                    open = false
                };
 
                treeSelectList.Add(tree);
                GetOrganizeChildren(treeSelectList, organizeList, tree, item.Id);
            }
            string str = GetTreeListString(treeSelectList);
           
            return str;
        }
        private string GetTreeListString(List<TreeSelect> treeSelectList)
        {
            string str = "0";
            foreach (var item in treeSelectList)
            {
                str += "," + item.id;
                GetTreeChildenListString(item,ref str);
            }
            return str;
        }
        private void  GetTreeChildenListString(TreeSelect tree,ref string str)
        {
            if (tree.children == null)
                return;
            foreach (var item in tree.children)
            {
                str += "," + item.id;
                GetTreeChildenListString(item, ref str);
            }
     
        }
        /// <summary>
        /// 递归遍历treeSelectList
        /// </summary>
        private void GetOrganizeChildren(List<TreeSelect> treeSelectList, IEnumerable<OrganizeModel> organizeList, TreeSelect tree, int id)
        {
            var childOrganizeList = organizeList.Where(x => x.ParentId == id).OrderBy(x => x.SortCode);
            if (childOrganizeList != null && childOrganizeList.Count() > 0)
            {
                List<TreeSelect> _children = new List<TreeSelect>();
                foreach (var item in childOrganizeList)
                {
                    TreeSelect _tree = new TreeSelect
                    {
                        id = item.Id.ToString(),
                        name = item.FullName,
                        open = false
                    };
                    _children.Add(_tree);
                    tree.children = _children;
                    GetOrganizeChildren(treeSelectList, organizeList, _tree, item.Id);
                }
            }
        }

    }
}
