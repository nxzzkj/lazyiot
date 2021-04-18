using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Model;
using ScadaWeb.Common;

namespace ScadaWeb.IService
{
    public interface IDeviceGroupService : IBaseService<DeviceGroupModel>
    {
        /// <summary>
        /// 保存菜单角色权限配置
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        int SaveDeviceGroup(IEnumerable<DeviceGroupModel> entitys, int groupId);

        /// <summary>
        /// 根据角色菜单获得列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        IEnumerable<DeviceGroupModel> GetListByGroupIdDeviceId(int groupId, string serverId, string commId, string deviceId);
        IEnumerable<DeviceGroupModel> GetListByGroupId(string groupstring);
        IEnumerable<DeviceGroupModel> GetListAll();
        DeviceGroupModel GetModel(int groupId, string serverId, string commId, string deviceId);
        bool UpdateModelByIOPara(DeviceGroupModel model);
    }
}
