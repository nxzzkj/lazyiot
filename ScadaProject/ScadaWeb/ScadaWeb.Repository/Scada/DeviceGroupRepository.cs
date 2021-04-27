using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Common;
using ScadaWeb.Model;
using ScadaWeb.Repository;
using System.Data;
using DapperExtensions.MySQLExt;

namespace ScadaWeb.IRepository
{
    public class DeviceGroupRepository : BaseRepository<DeviceGroupModel>, IDeviceGroupRepository
    {
        /// <summary>
        /// 保存设备分组配置
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int SaveDeviceGroup(IEnumerable<DeviceGroupModel> entitys, int GroupId)
        {
            int result = 0;
            using (var conn = MySqlHelper.GetConnection())
            {
                IDbTransaction transaction = conn.BeginTransaction();
                try
                {
                    //先删除当前角色所有权限
                    conn.DeleteByWhere<DeviceGroupModel>("where GroupId=@GroupId", new { GroupId = GroupId }, transaction);
                    if (entitys != null)
                    {
                        //批量插入权限
                        conn.InsertBatch<DeviceGroupModel>(entitys, transaction);
                    }
                    result = 1;
                    transaction.Commit();
                }
                catch (Exception)
                {
                    result = -1;
                    transaction.Rollback();
                }
            }
            return result;
        }
    }
}
