 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Model;
using ScadaWeb.IService;

namespace ScadaWeb.Service
{
    public class IO_ServerService : BaseService<IOServerModel>, IIO_ServerService
    {
  
        public IO_ServerService()
        {

        }
        public dynamic GetListByFilter(IOServerModel filter, PageInfo pageInfo)
        {
            return null;
       
        }
        public dynamic GetAll()
        {
          return   base.GetAll(null, null);
        }
        /// <summary>
        /// Organize treeSelect数据列表
        /// </summary>
        public IEnumerable<TreeSelect> GetIOServerTreeSelect()
        {
            IEnumerable<IOServerModel> serverList = BaseRepository.GetAll("SERVER_ID,SERVER_NAME,SERVER_IP", "");
            var rootOrganizeList = serverList;
            List<TreeSelect> treeSelectList = new List<TreeSelect>();
            foreach (var item in rootOrganizeList)
            {
                TreeSelect tree = new TreeSelect
                {
                    id = item.SERVER_ID,
                    name = item.SERVER_NAME,
                    open = false
                };
             
                treeSelectList.Add(tree);
            }
            return treeSelectList;
        }
 
       
    }
}
