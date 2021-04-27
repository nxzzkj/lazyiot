using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScadaWeb.DapperExtensions
{
    public class DapperExtSqls
    {
        public string TableName { get; set; }
        public bool HasKey { get; set; } //是否含有主键
        public bool IsIdentity { get; set; } //是否是自增键

        public string KeyName { get; set; } //主键名称

        public string KeyType { get; set; } //主键类型

        public IEnumerable<string> AllFieldList { get; set; } //所有列
        public IEnumerable<string> ExceptKeyFieldList { get; set; } //除主键列
        public string AllFields { get; set; }//所有列逗号分隔

        public string InsertSql { get; set; }
        public string InsertIdentitySql { get; set; }
        public string GetByIdSql { get; set; }
        public string GetByIdsSql { get; set; }
        public string GetAllSql { get; set; }
        public string DeleteByIdSql { get; set; }
        public string DeleteByIdsSql { get; set; }
        public string DeleteAllSql { get; set; }
        public string UpdateByIdSql { get; set; }

    }
}
