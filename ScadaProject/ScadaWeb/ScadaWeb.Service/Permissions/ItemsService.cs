using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.IService;
using ScadaWeb.Model;

namespace ScadaWeb.Service
{
    public class ItemsService : BaseService<ItemsModel>, IItemsService
    {
        public dynamic GetListByFilter(ItemsModel filter, PageInfo pageInfo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Items treeSelect数据列表
        /// </summary>
        public IEnumerable<TreeSelect> GetItemsTreeSelect()
        {
            IEnumerable<ItemsModel> moduleList = BaseRepository.GetAll("Id,FullName,ParentId", "ORDER BY SortCode ASC");
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
                GetItemsChildren(treeSelectList, moduleList, tree, item.Id);
                treeSelectList.Add(tree);
            }
            return treeSelectList;
        }

        /// <summary>
        /// 递归遍历treeSelectList
        /// </summary>
        private void GetItemsChildren(List<TreeSelect> treeSelectList, IEnumerable<ItemsModel> moduleList, TreeSelect tree, int id)
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
                    GetItemsChildren(treeSelectList, moduleList, _tree, item.Id);
                }
            }
        }

        public ItemsModel GetItemByEnCode(string encode)
        {
            IEnumerable<ItemsModel> itemList = BaseRepository.GetByWhere("where EnCode='"+ encode + "'");

            ItemsModel itemM = null;
            foreach (var item in itemList)
            {
                itemM = item;
            }
            return itemM;
        }
    }
}
