using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.IRepository;
using ScadaWeb.Model;
using Dapper;

namespace ScadaWeb.Repository
{
    public class WellRepository : BaseRepository<WellModel>, IWellRepository
    { /// <summary>
      /// 获取一批井的信息
      /// </summary>
      /// <param name="username"></param>
      /// <param name="password"></param>
      /// <returns></returns>
        public WellModel GetWellList(string where)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                var sql = "Select * from Well ";
                if (!string.IsNullOrEmpty(where))
                {
                    sql += " where "+ where;
                }

                return conn.Query<WellModel>(sql).FirstOrDefault();
            }
        }
        /// <summary>
        /// 获取一口井的信息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public WellModel GetWell(string wellname)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                var sql = "Select * from Well where 1=1";
                if (!string.IsNullOrEmpty(wellname))
                {
                    sql += " and WellName=@WellName";
                }
                
                return conn.Query<WellModel>(sql, new { WellName = wellname }).FirstOrDefault();
            }
        }
        /// <summary>
        /// 修改井位信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int ModifyWell(WellModel model)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                var sql = "UPDATE Well SET WellName=@WellName,WellStatus=@WellStatus,UpdateTime=@UpdateTime,UpdateUserId=@UpdateUserId,EnCode=@EnCode,SortCode=@SortCode,IO_DDLY=@IO_DDLY,IO_DYM=@IO_DYM,IO_JKTY=@IO_JKTY,IO_XTYL=@IO_XTYL,IO_LJCQL=@IO_LJCQL,IO_SSCQL=@IO_SSCQL,IO_QTWD=@IO_QTWD,IO_SXGL=@IO_SXGL,IO_BPQPL=@IO_BPQPL,IO_DJGZDL=@IO_DJGZDL,IO_LJCSL=@IO_LJCSL,IO_SSCSL=@IO_SSCSL,IO_GTCC=@IO_GTCC,IO_GTCC1=@IO_GTCC1,IO_SXDY=@IO_SXDY,IO_GTZH=@IO_GTZH,IO_SXDL=@IO_SXDL,IO_YDL=@IO_YDL,IO_DJNJ=@IO_DJNJ,IO_DJGZDY=@IO_DJGZDY,WellType=@WellType,IO_ServerID=@IO_ServerID,IO_CommunicateID=@IO_CommunicateID,IO_DeviceID=@IO_DeviceID ,Contractor=@Contractor,XZH=@XZH,YZH=@YZH WHERE Id=@Id";
                return conn.Execute(sql, new { WellName = model.WellName,
                    Id = model.Id,
                    WellStatus = model.WellStatus,
                    IO_ServerID = model.IO_ServerID,
                    IO_CommunicateID = model.IO_CommunicateID,
                    IO_DeviceID = model.IO_DeviceID,
                    WellType=model.WellType,
                    SortCode =model.SortCode,
                    EnCode =model.EnCode,
                    IO_DDLY = model.IO_DDLY,
                    IO_DYM = model.IO_DYM,
                    IO_JKTY = model.IO_JKTY,
                    IO_XTYL = model.IO_XTYL,
                    IO_LJCQL = model.IO_LJCQL,
                    IO_SSCQL = model.IO_SSCQL,
                    IO_QTWD = model.IO_QTWD,
                    IO_SXGL = model.IO_SXGL,
                    IO_BPQPL = model.IO_BPQPL,
                    IO_DJGZDL = model.IO_DJGZDL,
                    IO_LJCSL = model.IO_LJCSL,
                    IO_SSCSL = model.IO_SSCSL,
                    IO_GTCC = model.IO_GTCC,
                    IO_GTCC1 = model.IO_GTCC1,
                    IO_SXDY = model.IO_SXDY,
                    IO_GTZH = model.IO_GTZH,
                    IO_SXDL = model.IO_SXDL,
                    IO_YDL = model.IO_YDL,
                    IO_DJNJ = model.IO_DJNJ,
                    IO_DJGZDY = model.IO_DJGZDY,
                    XZH = model.XZH,
                    YZH = model.YZH,
                    Contractor =model.Contractor

                });
            }
        }
        /// <summary>
        /// 增加一个井
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddWell(WellModel model)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                var sql = "insert into  Well(Id,WellName,WellStatus,IO_ServerID,IO_CommunicateID,IO_DeviceID,WellType,CreateUserId,CreateTime,UpdateTime,UpdateUserId,IO_DDLY,IO_DYM,IO_JKTY,IO_XTYL,IO_LJCQL,IO_SSCQL,IO_QTWD,IO_SXGLIO_BPQPL,IO_DJGZDL,IO_LJCSL,IO_SSCSL,IO_GTCC,IO_GTCC1,IO_SXDY,IO_GTZH,IO_SXDL,IO_YDL,IO_DJNJ,IO_DJGZDY,Contractor) values(@Id,@WellName,@WellStatus,@IO_ServerID,@IO_CommunicateID,@IO_DeviceID,@WellType,@CreateUserId,@CreateTime,@UpdateTime,@UpdateUserId,@IO_DDLY,@IO_DYM,@IO_JKTY,@IO_XTYL,@IO_LJCQL,@IO_SSCQL,@IO_QTWD,@IO_SXGLIO_BPQPL,@IO_DJGZDL,@IO_LJCSL,@IO_SSCSL,@IO_GTCC,@IO_GTCC1,@IO_SXDY,@IO_GTZH,@IO_SXDL,@IO_YDL,@IO_DJNJ,@IO_DJGZDY,@Contractor,@XZH,@YZH)";
                return conn.Execute(sql, new { WellName = model.WellName,
                    Id = model.Id, WellStatus = model.WellStatus,
                    IO_ServerID = model.IO_ServerID,
                    IO_CommunicateID = model.IO_CommunicateID,
                    IO_DeviceID = model.IO_DeviceID,
                    CreateUserId =model.CreateUserId,
                    CreateTime =model.CreateTime,
                    UpdateTime =model.UpdateTime,
                    UpdateUserId =model.UpdateUserId,
                    WellType = model.WellType,
                    IO_DDLY = model.IO_DDLY,
                    IO_DYM = model.IO_DYM,
                    IO_JKTY = model.IO_JKTY,
                    IO_XTYL = model.IO_XTYL,
                    IO_LJCQL = model.IO_LJCQL,
                    IO_SSCQL = model.IO_SSCQL,
                    IO_QTWD = model.IO_QTWD,
                    IO_SXGL = model.IO_SXGL,
                    IO_BPQPL = model.IO_BPQPL,
                    IO_DJGZDL = model.IO_DJGZDL,
                    IO_LJCSL = model.IO_LJCSL,
                    IO_SSCSL = model.IO_SSCSL,
                    IO_GTCC = model.IO_GTCC,
                    IO_GTCC1 = model.IO_GTCC1,
                    IO_SXDY = model.IO_SXDY,
                    IO_GTZH = model.IO_GTZH,
                    IO_SXDL = model.IO_SXDL,
                    IO_YDL = model.IO_YDL,
                    IO_DJNJ = model.IO_DJNJ,
                    IO_DJGZDY = model.IO_DJGZDY,
                    XZH = model.XZH,
                    YZH = model.YZH,
                    Contractor =model.Contractor

                });



            }
        }
        /// <summary>
        /// 删除一个井
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int  DeleteWell(WellModel model)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                var sql = " delete from Well where WellName=@WellName";
                return conn.Execute(sql, new { WellName = model.WellName });



            }
        }
    }
}
