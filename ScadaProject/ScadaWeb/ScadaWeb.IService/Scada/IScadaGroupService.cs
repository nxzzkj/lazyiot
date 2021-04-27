using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Model;

namespace ScadaWeb.IService
{
    public interface IScadaGroupService : IBaseService<ScadaGroupModel>
    {
        IEnumerable<ScadaGroupModel> GetGroupList();
        IEnumerable<TreeSelect> GetGroupTreeSelect();
        string GetGroupNodeChildren(int id);

    }
}
