using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Model;

namespace ScadaWeb.IService
{
    public interface IItemsService : IBaseService<ItemsModel>
    {
        IEnumerable<TreeSelect> GetItemsTreeSelect();
        ItemsModel GetItemByEnCode(string encode);
    }
}
