using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Model;
using ScadaWeb.Common;

namespace ScadaWeb.IService
{
    public interface IWellOrganizeService : IBaseService<WellOrganizeModel>
    {
        
        /// <summary>
        /// 根据菜单获得列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        IEnumerable<WellOrganizeModel> GetListByWellId(int WellId);
        IEnumerable<WellOrganizeModel> GetListByOrganizeId(int OrganizeId);
        bool DeleteByWellId(int WellId);
    }
}
