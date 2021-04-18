using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ScadaWeb.Common;
using ScadaWeb.IRepository;
using ScadaWeb.Model;

namespace ScadaWeb.Repository
{
    public class TopButtonRepository : BaseRepository<TopButtonModel>, ITopButtonRepository
    {
        
    }
}
