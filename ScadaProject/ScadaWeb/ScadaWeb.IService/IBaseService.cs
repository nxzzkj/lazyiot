using ScadaWeb.Model;
using System;
using System.Collections.Generic;

namespace ScadaWeb.IService
{
    public interface IBaseService<T> where T : class, new()
    {
        #region CRUD
        /// <summary>
        /// 根据主键返回实体
        /// </summary>
        T GetById(int Id);
        bool Insert(T model,out int id);
        /// <summary>
        /// 新增
        /// </summary>
        bool Insert(T model);
        /// <summary>
        /// 根据主键修改数据
        /// </summary>
        bool UpdateById(T model);
        /// <summary>
        /// 根据主键修改数据 修改指定字段
        /// </summary>
        bool UpdateById(T model, string updateFields);
        /// <summary>
        /// 根据主键删除数据
        /// </summary>
        bool DeleteById(int Id);
        /// <summary>
        /// 根据主键批量删除数据
        /// </summary>
        bool DeleteByIds(object Ids);
        /// <summary>
        /// 根据条件删除
        /// </summary>
        bool DeleteByWhere(string where);
        #endregion

        dynamic GetListByFilter(T filter, PageInfo pageInfo);
        /// <summary>
        /// 返回整张表数据
        /// returnFields需要返回的列，用逗号隔开。默认null，返回所有列
        /// </summary>
        IEnumerable<T> GetAll(string returnFields = null, string orderby = null);
        /// <summary>
        /// 根据查询条件获取数据
        /// </summary>
        IEnumerable<T> GetByWhere(string where = null, object param = null, string returnFields = null, string orderby = null);

    }
}
