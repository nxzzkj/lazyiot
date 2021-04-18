using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Model;

namespace ScadaWeb.IService
{
    public interface IWellService : IBaseService<WellModel>
    {
         bool AddWell(WellModel model);
        IEnumerable<WellModel> GetListObjectByFilter(WellModel filter, PageInfo pageInfo, out long total);
        IEnumerable<WellModel> GetListObjectByOrganize(string OrganizeIdList);
    }
}
