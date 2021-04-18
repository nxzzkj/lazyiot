using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Model;

namespace ScadaWeb.IService
{
    public interface IOrganizeService : IBaseService<OrganizeModel>
    {
        IEnumerable<OrganizeModel> GetOrganizeList();
        IEnumerable<TreeSelect> GetOrganizeTreeSelect();
        string GetOrganizeNodeChildren(int id);

    }
}
