using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ScadaWeb.DapperExtensions
{
    public class DapperExtCommon
    {
        /// <summary>
        /// 关键字处理[name] `name`
        /// 获取id,sex,name
        /// </summary>
        /// <param name="fieldList"></param>
        /// <param name="leftChar">左符号</param>
        /// <param name="rightChar">右符号</param>
        /// <returns></returns>
        public static string GetFieldsStr(IEnumerable<string> fieldList, string leftChar, string rightChar)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in fieldList)
            {
                sb.AppendFormat("{0}{1}{2}", leftChar, item, rightChar);

                if (item != fieldList.Last())
                {
                    sb.Append(",");
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// //获取@id,@sex,@name
        /// </summary>
        /// <param name="fieldList"></param>
        /// <returns></returns>
        public static string GetFieldsAtStr(IEnumerable<string> fieldList)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in fieldList)
            {
                sb.AppendFormat("@{0}", item);

                if (item != fieldList.Last())
                {
                    sb.Append(",");
                }
            }
            return sb.ToString();
        }

        public static IEnumerable GetMultiExec(object param)
        {
            return (param is IEnumerable && !(param is string || param is IEnumerable<KeyValuePair<string, object>>)) ? (IEnumerable)param : null;
        }

        /// <summary>
        /// 判断输入参数是否有个数，用于in判断
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static bool ObjectIsEmpty(object param)
        {
            bool result = true;
            IEnumerable data = GetMultiExec(param);
            if (data != null)
            {
                foreach (var item in data)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 关键字处理[name] `name`
        /// 获取id=@id,name=@name
        /// </summary>
        /// <param name="fieldList"></param>
        /// <param name="leftChar">左符号</param>
        /// <param name="rightChar">右符号</param>
        /// <returns></returns>
        public static string GetFieldsEqStr(IEnumerable<string> fieldList, string leftChar, string rightChar)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in fieldList)
            {
                sb.AppendFormat("{0}{1}{2}=@{1}", leftChar, item, rightChar);

                if (item != fieldList.Last())
                {
                    sb.Append(",");
                }
            }
            return sb.ToString();
        }


        public static DapperExtSqls GetDapperExtSqls(Type t)
        {
            DapperExtSqls dapperextsqls = new DapperExtSqls();
            var tableAttr = t.GetCustomAttributes(false).FirstOrDefault(f => f is TableAttribute) as TableAttribute;
            if (tableAttr == null)
            {
                dapperextsqls.TableName = t.Name;
            }
            else
            {
                dapperextsqls.TableName = tableAttr.Name;
            }

            var allproperties = t.GetProperties();
            List<PropertyInfo> exceptKeyAndComputeproperties = new List<PropertyInfo>(); //去除主键和忽略
            List<PropertyInfo> exceptComputeproperties = new List<PropertyInfo>(); //去除忽略

            foreach (var item in allproperties)
            {
                var attribute = item.GetCustomAttributes(false).FirstOrDefault();
                if (attribute == null)
                {
                    exceptKeyAndComputeproperties.Add(item);
                    exceptComputeproperties.Add(item);
                }
                else
                {
                    if (attribute.GetType() != typeof(ComputedAttribute))
                    {
                        if (attribute.GetType() == typeof(KeyAttribute)) //主键列
                        {
                            dapperextsqls.HasKey = true;
                            dapperextsqls.KeyName = item.Name;
                            dapperextsqls.KeyType = item.PropertyType.Name;
                            KeyAttribute keyAttr = (KeyAttribute)attribute;
                            if (keyAttr.IsIdentity)
                            {
                                dapperextsqls.IsIdentity = true;
                            }
                        }
                        else
                        {
                            exceptKeyAndComputeproperties.Add(item);
                        }

                        exceptComputeproperties.Add(item);
                    }
                }
            }

            IEnumerable<string> exceptKeyAndComputeFieldsArr = exceptKeyAndComputeproperties.Select(s => s.Name);
            IEnumerable<string> exceptComputeFieldsArr = exceptComputeproperties.Select(s => s.Name);

            dapperextsqls.ExceptKeyFieldList = exceptKeyAndComputeFieldsArr;
            dapperextsqls.AllFieldList = exceptComputeFieldsArr;

            return dapperextsqls;
        }

        private static readonly ConcurrentDictionary<RuntimeTypeHandle, DapperExtSqls> dapperExtsqlsDict = new ConcurrentDictionary<RuntimeTypeHandle, DapperExtSqls>();
        public static DapperExtSqls GetDapperExtSqlsCache(Type t)
        {
            if (dapperExtsqlsDict.Keys.Contains(t.TypeHandle))
            {
                return dapperExtsqlsDict[t.TypeHandle];
            }
            else
            {
                DapperExtSqls dt = GetDapperExtSqls(t);
                dapperExtsqlsDict[t.TypeHandle] = dt;
                return dt;
            }
        }
    }
}
