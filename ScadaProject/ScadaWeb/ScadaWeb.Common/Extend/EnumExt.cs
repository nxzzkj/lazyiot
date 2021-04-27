using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web.Mvc;

namespace ScadaWeb.Common
{
    public class EnumExt
    {
        /// <summary>
        /// 根据枚举成员获取自定义属性EnumDisplayNameAttribute的属性DisplayName
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetEnumCustomDescription(object e)
        {
            //获取枚举的Type类型对象
            Type t = e.GetType();
            //获取枚举的所有字段
            FieldInfo[] ms = t.GetFields();
            //遍历所有枚举的所有字段
            foreach (FieldInfo f in ms)
            {
                if (f.Name != e.ToString())
                {
                    continue;
                }
                //第二个参数true表示查找EnumDisplayNameAttribute的继承链
                if (f.IsDefined(typeof(DisplayAttribute), true))
                {
                    return
                        (f.GetCustomAttributes(typeof(DisplayAttribute), true)[0] as DisplayAttribute)
                            .Name;
                }
            }
            //如果没有找到自定义属性，直接返回属性项的名称
            return e.ToString();
        }

        /// <summary>
        /// 根据枚举，把枚举自定义特性EnumDisplayNameAttribut的Display属性值撞到SelectListItem中
        /// </summary>
        /// <param name="enumType">枚举</param>
        /// <returns></returns>
        public static List<SelectListItem> GetSelectList(Type enumType)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (object e in Enum.GetValues(enumType))
            {
                selectList.Add(new SelectListItem() { Text = GetEnumCustomDescription(e), Value = ((int)e).ToString() });
            }
            return selectList;
        }
    }
}
