using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scada.DBUtility
{
    /// <summary>
    /// 系统函数指的是System.Math中的固定函数
    /// 自定义含数指的是MathEx中定义的一些含数
    /// </summary>
   public  class FunctionItem
    {
       public FunctionItem()
       {
           FuncString="";
           level=0;//0为系统函数,1为自定义函数
       }
        //公式说明
        public string Description = "";
       public string FuncString
       {
           set;
           get;
       }
       public int level
       {
           set;
           get;
       }
       /// <summary>
       /// 保存计算值
       /// </summary>
       public double  Value
       {
           set;
           get;
       }
        public override string ToString()
        {
            return FuncString.ToString();
        }
    }
}
