using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Common;
using ScadaWeb.IService;
using ScadaWeb.Model;
using ScadaWeb.IRepository;

namespace ScadaWeb.Service
{
    public class DeviceGroupService : BaseService<DeviceGroupModel>, IDeviceGroupService
    {
        public IDeviceGroupRepository DeviceGroupRepository { get; set; }

        public dynamic GetListByFilter(DeviceGroupModel filter, PageInfo pageInfo)
        {

            return null;
        }
       
    /// <summary>
    /// 保存菜单角色权限配置
    /// </summary>
    /// <param name="entitys"></param>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public int SaveDeviceGroup(IEnumerable<DeviceGroupModel> entitys, int groupId)
        {
            return DeviceGroupRepository.SaveDeviceGroup(entitys, groupId);
        }

        /// <summary>
        /// 根据角色菜单获得列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public IEnumerable<DeviceGroupModel> GetListByGroupIdDeviceId(int groupId,string serverId,string commId,string deviceId)
        {
            string where = "where GroupId=@GroupId and IO_SERVER_ID=@IO_SERVER_ID and IO_COMM_ID=@IO_COMM_ID and IO_DEVICE_ID=@IO_DEVICE_ID";
            return GetByWhere(where, new { GroupId = groupId, IO_SERVER_ID = serverId, IO_COMM_ID= commId, IO_DEVICE_ID= deviceId });
        }
        public IEnumerable<DeviceGroupModel> GetListByGroupId(string groupstring)
        {
            string ids ="'"+ groupstring.Replace(",","','")+"'";
            string where = "where GroupId in ("+ ids + ")";
            return GetByWhere(where);
        }
        public IEnumerable<DeviceGroupModel> GetListAll()
        {
            string sql = "select a.IO_DEVICE_ID ,a.IO_COMM_ID , a.IO_SERVER_ID, b.SERVER_NAME as IOServerName,c.IO_COMM_LABEL as IOCommunicateName,a.IO_DEVICE_LABLE as IODeviceName ,a.IO_DEVICE_LABLE as ALIASNAME,a.IO_DEVICE_UPDATECYCLE as UpdateCycle from IO_DEVICE a,IO_SERVER b,IO_COMMUNICATION c where a.IO_SERVER_ID=b.SERVER_ID and a.IO_COMM_ID=c.IO_COMM_ID order by  a.IO_SERVER_ID,a.IO_COMM_ID  asc ";
            return GetBySql(sql, null);
        }

        public DeviceGroupModel GetModel(int groupId, string serverId, string commId, string deviceId)
        {
            string where = "where GroupId=@GroupId and IO_SERVER_ID=@IO_SERVER_ID and IO_COMM_ID=@IO_COMM_ID and IO_DEVICE_ID=@IO_DEVICE_ID";
            var selects= GetByWhere(where, new { GroupId = groupId, IO_SERVER_ID = serverId, IO_COMM_ID = commId, IO_DEVICE_ID = deviceId });
            return selects.First();
        }

        public bool UpdateModelByIOPara(DeviceGroupModel model)
        {
             
            if(model!=null&&model.Id>0)
            {
             
                return UpdateById(model);
            }
            else
            {
                return false;
            }
  
        }
        /// <summary>
        /// Organize treeSelect数据列表
        /// </summary>
   
    }
}
