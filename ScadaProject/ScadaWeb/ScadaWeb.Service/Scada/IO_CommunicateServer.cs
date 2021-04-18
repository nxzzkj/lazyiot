 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Model;
using ScadaWeb.IService;

namespace ScadaWeb.Service
{
  public  class IO_CommunicateService : BaseService<IOCommunicateModel>, IIO_CommunicateService
    {
        public IO_CommunicateService()
        {

        }
        public dynamic GetListByFilter(IOCommunicateModel filter, PageInfo pageInfo)
        {
            throw new NotImplementedException();
        }
        public dynamic GetAll()
        {
            return base.GetAll(null, null);
        }

      
    }
}
