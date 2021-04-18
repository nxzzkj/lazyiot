using System.Collections.Generic;
using ScadaWeb.Model;
 

namespace ScadaWeb.IService
{
    public interface IIO_ServerService : IBaseService<IOServerModel>
    {
        IEnumerable<TreeSelect> GetIOServerTreeSelect();
    }
}