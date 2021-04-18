using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.IService;
using ScadaWeb.Model;

namespace ScadaWeb.Service
{
    public class ItemsDetailService : BaseService<ItemsDetailModel>, IItemsDetailService
    {
        public dynamic GetListByFilter(ItemsDetailModel filter, PageInfo pageInfo)
        {
            pageInfo.prefix = "a.";
            string _where = " itemsdetail a INNER JOIN items b ON a.ItemId=b.Id";
            if (!string.IsNullOrEmpty(filter.ItemCode))
            {
                _where += string.Format(" and {0}ItemCode=@ItemCode", pageInfo.prefix);
            }
            if (!string.IsNullOrEmpty(filter.ItemName))
            {
                _where += string.Format(" and {0}ItemName=@ItemName", pageInfo.prefix);
            }
            if (filter.ItemId != 0)
            {
                _where += string.Format(" and {0}ItemId=@ItemId", pageInfo.prefix);
            }
            pageInfo.returnFields = string.Format("{0}Id,{0}ItemCode,{0}ItemName,{0}SortCode,b.FullName as 'ItemType',{0}CreateTime", pageInfo.prefix);
            return GetPageUnite(filter, pageInfo, _where);
        }

    }
}
