using ScadaWeb.Model;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.IService
{
    public interface IScadaFlowProjectService : IBaseService<ScadaFlowProjectModel>
    {
        bool LoginOn(string userName, string password,string projectId,out string nickname);
    }
    public interface IScadaFlowViewService : IBaseService<ScadaFlowViewModel>
    {
    }
}
