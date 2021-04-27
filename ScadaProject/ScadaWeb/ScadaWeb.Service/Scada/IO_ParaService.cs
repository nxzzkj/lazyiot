 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Model;
using ScadaWeb.IService;

namespace ScadaWeb.Service
{
  public  class IO_ParaService : BaseService<IOParaModel>, IIO_ParaService
    {
        public IO_ParaService()
        {
        }
        public dynamic GetListByFilter(IOParaModel filter, PageInfo pageInfo)
        {
            throw new NotImplementedException();
        }
    }
}
