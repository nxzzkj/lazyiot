using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.IService;
using ScadaWeb.Model;
using ScadaWeb.IRepository;
using ScadaWeb.Common;

namespace ScadaWeb.Service
{
    public class WellService : BaseService<WellModel>, IWellService
    {
        public IWellRepository WellRepository { get; set; }
        public IWellOrganizeService WellOrganizeServer { get; set; }

    public bool AddWell(WellModel model)
        {
            string sid = model.IO_ServerID.Split('/')[0];
            string cid = model.IO_ServerID.Split('/')[1];
            model.IO_ServerID = sid;
            model.IO_CommunicateID = cid;
            //插入井号与设备的组织关系
            int mid = 0;
            bool res= Insert(model,out mid);
            if(res)
            {
                WellOrganizeServer.DeleteByWellId(model.Id);
                WellOrganizeServer.Insert(new WellOrganizeModel() {  Id=0, OrganizeId=model.OrganizeId, WellId= mid });
            }
            
            return res;
        }
 
        public dynamic GetListByFilter(WellModel filter, PageInfo pageInfo)
        {
            pageInfo.prefix = "a.";
            string _where = "  Well a left JOIN WellOrganize b ON a.Id=b.WellId left JOIN organize c ON b.OrganizeId=c.Id left join IO_DEVICE  d on d.IO_DEVICE_ID=a.IO_DeviceID  where 1=1 ";


            if (!string.IsNullOrEmpty(filter.WellName))
            {
                _where += string.Format(" and {0}WellName like '%" + filter.WellName + "%'", pageInfo.prefix);
            }
            if (!string.IsNullOrEmpty(filter.EnCode))
            {
                _where += string.Format(" and {0}EnCode  like '%@EnCode%'", pageInfo.prefix);
            }
            if (!string.IsNullOrEmpty(filter.WellType)&& filter.WellType!="0")
            {
                _where += string.Format(" and {0}WellType =@WellType", pageInfo.prefix);
            }
            if (filter.OrganizeId>1)
            {
                _where += string.Format(" and {0}id=@OrganizeId", "c.");
            }
            pageInfo.returnFields = string.Format("{0}Id,{0}WellName,{0}WellStatus,{0}IO_ServerID,{0}IO_CommunicateID,{0}IO_DeviceID,{0}CreateUserId,{0}CreateTime,{0}WellType,{0}IO_DDLY,{0}IO_DYM,{0}IO_JKTY,{0}IO_XTYL,{0}IO_LJCQL,{0}IO_SSCQL,{0}IO_QTWD,{0}IO_SXGL,{0}IO_BPQPL,{0}IO_DJGZDL,{0}IO_LJCSL,{0}IO_SSCSL,{0}IO_GTCC,{0}IO_GTCC1,{0}IO_SXDY,{0}IO_GTZH,{0}IO_SXDL,{0}IO_YDL,{0}IO_DJNJ,{0}IO_DJGZDY,{0}WellType,{0}Contractor,{0}XZH,{0}YZH,c.Id as OrganizeId,c.FullName as fullname,d.IO_DEVICE_UPDATECYCLE as UpdateCycle", pageInfo.prefix);
            return GetPageUnite(filter, pageInfo, _where);
        }

        public IEnumerable<WellModel> GetListObjectByFilter(WellModel filter, PageInfo pageInfo,out long total)
        {
            pageInfo.prefix = "a.";
            string _where = "  Well a left JOIN WellOrganize b ON a.Id=b.WellId left JOIN organize c ON b.OrganizeId=c.Id left join IO_DEVICE  d on d.IO_DEVICE_ID=a.IO_DeviceID  where 1=1 ";


            if (!string.IsNullOrEmpty(filter.WellName))
            {
                _where += string.Format(" and {0}WellName like '%"+ filter.WellName + "%'", pageInfo.prefix);
            }
            if (!string.IsNullOrEmpty(filter.WellType) && filter.WellType != "0")
            {
                _where += string.Format(" and {0}WellType =@WellType", pageInfo.prefix);
            }
            if (filter.OrganizeId > 1)
            {
                _where += string.Format(" and {0}id=@OrganizeId", "c.");
            }
            pageInfo.returnFields = string.Format("{0}Id,{0}WellName,{0}WellStatus,{0}IO_ServerID,{0}IO_CommunicateID,{0}IO_DeviceID,{0}CreateUserId,{0}CreateTime,{0}WellType,{0}IO_DDLY,{0}IO_DYM,{0}IO_JKTY,{0}IO_XTYL,{0}IO_LJCQL,{0}IO_SSCQL,{0}IO_QTWD,{0}IO_SXGL,{0}IO_BPQPL,{0}IO_DJGZDL,{0}IO_LJCSL,{0}IO_SSCSL,{0}IO_GTCC,{0}IO_GTCC1,{0}IO_SXDY,{0}IO_GTZH,{0}IO_SXDL,{0}IO_YDL,{0}IO_DJNJ,{0}IO_DJGZDY,{0}WellType,{0}Contractor,{0}XZH,{0}YZH,c.Id as OrganizeId,c.FullName as fullname,d.IO_DEVICE_UPDATECYCLE as UpdateCycle", pageInfo.prefix);
            return GetPageOjectsUnite(filter, pageInfo, out total, _where);
        }

        public IEnumerable<WellModel> GetListObjectByOrganize(string OrganizeIdList)
        {
            PageInfo pageInfo = new PageInfo();
            pageInfo.order = "";
            pageInfo.page = 1;
            pageInfo.limit = 10000;
            pageInfo.prefix = "a.";
            string _where = "  Well a left JOIN WellOrganize b ON a.Id=b.WellId left JOIN organize c ON b.OrganizeId=c.Id left join IO_DEVICE  d on d.IO_DEVICE_ID=a.IO_DeviceID ";
            if(OrganizeIdList!="")
            {
                _where +=" where   c.id in(" + OrganizeIdList+")";

            }

         long   total = 0;

            pageInfo.returnFields = string.Format("{0}Id,{0}WellName,{0}WellStatus,{0}IO_ServerID,{0}IO_CommunicateID,{0}IO_DeviceID,{0}CreateUserId,{0}CreateTime,{0}WellType,{0}IO_DDLY,{0}IO_DYM,{0}IO_JKTY,{0}IO_XTYL,{0}IO_LJCQL,{0}IO_SSCQL,{0}IO_QTWD,{0}IO_SXGL,{0}IO_BPQPL,{0}IO_DJGZDL,{0}IO_LJCSL,{0}IO_SSCSL,{0}IO_GTCC,{0}IO_GTCC1,{0}IO_SXDY,{0}IO_GTZH,{0}IO_SXDL,{0}IO_YDL,{0}IO_DJNJ,{0}IO_DJGZDY,{0}WellType,{0}Contractor,{0}XZH,{0}YZH,c.Id as OrganizeId,c.FullName as fullname,d.IO_DEVICE_UPDATECYCLE as UpdateCycle", pageInfo.prefix);
            return GetPageOjectsUnite(null, pageInfo, out total, _where);
        }
        
    }
}
