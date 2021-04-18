using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScadaWeb.DapperExtensions
{
    /// <summary>
    /// 表属性 Table("people")
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public string Name { get; set; }
        public TableAttribute(string tableName)
        {
            this.Name = tableName;
        }
    }

    /// <summary>
    /// 主键属性 Key(true)  Key(false) 表示主键自增、或者主键非自增
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class KeyAttribute : Attribute
    {
        public bool IsIdentity { get; set; }
        public KeyAttribute(bool isidentity)
        {
            IsIdentity = isidentity;
        }
    }

    /// <summary>
    /// 忽略列，表示非数据库字段
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ComputedAttribute : Attribute
    {

    }
}
