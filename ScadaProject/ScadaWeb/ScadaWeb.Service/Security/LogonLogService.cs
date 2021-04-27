using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Common;
using ScadaWeb.IService;
using ScadaWeb.Model;

namespace ScadaWeb.Service
{
    public class LogonLogService : BaseService<LogonLogModel>, ILogonLogService
    {
        public dynamic GetListByFilter(LogonLogModel filter, PageInfo pageInfo)
        {
            string _where = " where 1=1";
            if (!string.IsNullOrEmpty(filter.Account))
            {
                _where += " and Account=@Account";
            }
            if (!string.IsNullOrEmpty(filter.RealName))
            {
                _where += " and RealName=@RealName";
            }
            _where = CreateTimeWhereStr(filter.StartEndDate, _where);
            return GetListByFilter(filter, pageInfo, _where);
        }

        /// <summary>
        /// 写入登录日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int WriteDbLog(LogonLogModel model)
        {
            model.IPAddress = Net.Ip;
            model.IPAddressName = Net.GetLocation(model.IPAddress);
            model.CreateTime = DateTime.Now;
            return BaseRepository.Insert(model);
        }
    }
}
