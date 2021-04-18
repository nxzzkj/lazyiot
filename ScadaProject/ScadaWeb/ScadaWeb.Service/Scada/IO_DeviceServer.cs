 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Model;
using ScadaWeb.IService;

namespace ScadaWeb.Service
{
  public  class IO_DeviceService : BaseService<IODeviceModel>,IIO_DeviceService
    {
        public IO_DeviceService()
        {

        }
     
        public dynamic GetAll()
        {
            return base.GetAll(null, null);
        }

        public dynamic GetListByFilter(IODeviceModel filter, PageInfo pageInfo)
        {
            throw new NotImplementedException();
        }
     
    }
}
