using Dapper;
using ScadaWeb.IRepository;
using ScadaWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Repository
{
    public class ScadaFlowProjectRepository : BaseRepository<ScadaFlowProjectModel>, IScadaFlowProjectRepository
    {
        
    }
    public class ScadaFlowViewRepository : BaseRepository<ScadaFlowViewModel>, IScadaFlowViewRepository
    {

    }
}
