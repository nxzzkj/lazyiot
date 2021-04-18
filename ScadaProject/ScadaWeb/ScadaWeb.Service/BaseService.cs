using ScadaWeb.IRepository;
using ScadaWeb.IService;
using ScadaWeb.Model;
using System.Collections.Generic;

namespace ScadaWeb.Service
{
    public abstract class BaseService<T> where T : class, new()
    {
        public IBaseRepository<T> BaseRepository { get; set; }
        #region CRUD
        /// <summary>
        /// 根据主键返回实体
        /// </summary>
        public T GetById(int Id)
        {
            return BaseRepository.GetById(Id);
        }
        /// <summary>
        /// 新增
        /// </summary>
        public  bool Insert(T model)
        {
            int id = BaseRepository.Insert(model);
    
            return id > 0 ? true : false;
        }
        public bool Insert(T model,out int id)
        {
            id = BaseRepository.Insert(model);
            return id > 0 ? true : false;
        }
        /// <summary>
        /// 根据主键修改数据
        /// </summary>
        public bool UpdateById(T model)
        {
            return BaseRepository.UpdateById(model) > 0 ? true : false;
        }
        /// <summary>
        /// 根据主键修改数据 修改指定字段
        /// </summary>
        public bool UpdateById(T model, string updateFields)
        {
            return BaseRepository.UpdateById(model, updateFields) > 0 ? true : false;
        }
        /// <summary>
        /// 根据主键删除数据
        /// </summary>
        public bool DeleteById(int Id)
        {
            return BaseRepository.DeleteById(Id) > 0 ? true : false;
        }
        /// <summary>
        /// 根据主键批量删除数据
        /// </summary>
        public bool DeleteByIds(object Ids)
        {
            return BaseRepository.DeleteByIds(Ids) > 0 ? true : false;
        }
        /// <summary>
        /// 根据条件删除
        /// </summary>
        public bool DeleteByWhere(string where)
        {
            return BaseRepository.DeleteByWhere(where) > 0 ? true : false;
        }
        #endregion
        /// <summary>
        /// 获取分页数据
        /// </summary>
        public dynamic GetListByFilter(T filter, PageInfo pageInfo, string where = null)
        {
            string _orderBy = string.Empty;
            if (!string.IsNullOrEmpty(pageInfo.field))
            {
                _orderBy = string.Format(" ORDER BY {0} {1}", pageInfo.field, pageInfo.order);
            }
            else
            {
                _orderBy = " ORDER BY CreateTime desc";
            }
            long total = 0;
            var list = BaseRepository.GetByPage(new SearchFilter { pageIndex = pageInfo.page, pageSize = pageInfo.limit, returnFields = pageInfo.returnFields, param = filter, where = where, orderBy = _orderBy }, out total);
            return Pager.Paging(list, total);
        }
     
        /// <summary>
        /// 获取分页数据 联合查询
        /// </summary>
        public dynamic GetPageUnite(T filter, PageInfo pageInfo, string where = null)
        {
            string _orderBy = string.Empty;
            if (!string.IsNullOrEmpty(pageInfo.field))
            {
                _orderBy = string.Format(" ORDER BY {0} {1}", pageInfo.field, pageInfo.order);
            }
            else
            {
                _orderBy = " ORDER BY "+ pageInfo .prefix+ "CreateTime desc";
            }
            long total = 0;
            var list = BaseRepository.GetByPageUnite(new SearchFilter { pageIndex = pageInfo.page, pageSize = pageInfo.limit, returnFields = pageInfo.returnFields, param = filter, where = where, orderBy = _orderBy }, out total);
            return Pager.Paging(list, total);
        }
        public dynamic GetPageOjectsUnite(T filter, PageInfo pageInfo, out long total,string where = null)
        {
            string _orderBy = string.Empty;
            if (!string.IsNullOrEmpty(pageInfo.field))
            {
                _orderBy = string.Format(" ORDER BY {0} {1}", pageInfo.field, pageInfo.order);
            }
            else
            {
                _orderBy = " ORDER BY " + pageInfo.prefix + "CreateTime desc";
            }
            total = 0;
            var list = BaseRepository.GetByPageUnite(new SearchFilter { pageIndex = pageInfo.page, pageSize = pageInfo.limit, returnFields = pageInfo.returnFields, param = filter, where = where, orderBy = _orderBy }, out total);
            return list;
        }
        /// <summary>
        /// 返回整张表数据
        /// returnFields需要返回的列，用逗号隔开。默认null，返回所有列
        /// </summary>
        public IEnumerable<T> GetAll(string returnFields = null, string orderby = null)
        {
            return BaseRepository.GetAll(returnFields, orderby);
        }
        /// <summary>
        /// 创建时间范围条件
        /// </summary>
        protected string CreateTimeWhereStr(string StartEndDate, string _where, string prefix = null)
        {
            if (!string.IsNullOrEmpty(StartEndDate) && StartEndDate != " ~ ")
            {
                if (StartEndDate.Contains("~"))
                {
                    if (StartEndDate.Contains("+"))
                    {
                        StartEndDate = StartEndDate.Replace("+", "");
                    }
                    var dts = StartEndDate.Split('~');
                    var start = dts[0].Trim();
                    var end = dts[1].Trim();
                    if (!string.IsNullOrEmpty(start))
                    {
                        if (!string.IsNullOrEmpty(prefix))
                        {
                            _where += string.Format(" and {1}CreateTime>='{0} 00:00'", start, prefix);
                        }
                        else
                        {
                            _where += string.Format(" and CreateTime>='{0} 00:00'", start);
                        }
                    }
                    if (!string.IsNullOrEmpty(end))
                    {
                        if (!string.IsNullOrEmpty(prefix))
                        {
                            _where += string.Format(" and {1}CreateTime<='{0} 59:59'", end, prefix);
                        }
                        else
                        {
                            _where += string.Format(" and CreateTime<='{0} 59:59'", end);
                        }
                    }
                }
            }
            return _where;
        }
        /// <summary>
        /// 根据查询条件获取数据
        /// </summary>
        public IEnumerable<T> GetByWhere(string where = null, object param = null, string returnFields = null, string orderby = null)
        {
            return BaseRepository.GetByWhere(where, param, returnFields, orderby);
        }
        public IEnumerable<T> GetBySql(string sql = null, object param = null)
        {
            return BaseRepository.GetBySql(sql, param);
        }
    }
}
