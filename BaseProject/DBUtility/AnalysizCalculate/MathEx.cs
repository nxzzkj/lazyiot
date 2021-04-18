using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scada.DBUtility
{
    /// <summary>
    /// 阶乘
    /// </summary>
    class FactorialMath
    {
        /// <summary>
        /// Factorial定义为：
        ///      ┌ 1        n=0       
        ///   N!=│
        ///      └ n(n-1)!  n>0
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int Factorial(int number)
        {
            if (number != 0)
            {
                return number * Factorial(number - 1);
            }
            else if (number == 0)
            {
                return 1;
            }
            return number;
        }

        private int FactorialRecursion(int number)
        {
            int F = 1;
            for (int i = 1; i <= number; i++)
            {
                F *= i;
            }
            return F;
        }
    }

    /// <summary>
    /// 自定义扩展函数,用来解析XML中配置的公式
    /// </summary>
    public class MathEx
    {
        /// <summary>
        /// 定义积分含数
        /// </summary>
        /// <param name="v"></param>
        /// <param name="d"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static double Integrate(double v, double d, double u)
        {

            return 0;

        }
        #region 定义 条件语句
        public static double Where(double c1, double c2, double tvalue, double fvalue, string opreator)
        {
        

            switch (opreator.Trim().ToLower())
            {
                case ">":
                    {
                        if (c1 > c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }

                case ">=":
                    {
                        if (c1 >= c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }
                case "<":
                    {
                        if (c1 < c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }
                case "<=":
                    {
                        if (c1 <= c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }
                case "=":
                    {
                        if (c1 == c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }

            }
            return 0;
        }
        public static decimal Where(decimal c1, decimal c2, decimal tvalue, decimal fvalue, string opreator)
        {
           

            switch (opreator.Trim().ToLower())
            {
                case ">":
                    {
                        if (c1 > c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }

                case ">=":
                    {
                        if (c1 >= c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }
                case "<":
                    {
                        if (c1 < c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }
                case "<=":
                    {
                        if (c1 <= c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }
                case "=":
                    {
                        if (c1 == c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }

            }
            return 0;
        }
        public static int Where(int c1, int c2, int tvalue, int fvalue, string opreator)
        {
         

            switch (opreator.Trim().ToLower())
            {
                case ">":
                    {
                        if (c1 > c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }

                case ">=":
                    {
                        if (c1 >= c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }
                case "<":
                    {
                        if (c1 < c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }
                case "<=":
                    {
                        if (c1 <= c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }
                case "=":
                    {
                        if (c1 == c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }

            }
            return 0;
        }
        public static float Where(float c1, float c2, float tvalue, float fvalue, string opreator)
        {
           

            switch (opreator.Trim().ToLower())
            {
                case ">":
                    {
                        if (c1 > c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }

                case ">=":
                    {
                        if (c1 >= c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }
                case "<":
                    {
                        if (c1 < c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }
                case "<=":
                    {
                        if (c1 <= c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }
                case "=":
                    {
                        if (c1 == c2)
                        {
                            return tvalue;
                        }
                        else
                        {
                            return fvalue;
                        }
                    }

            }
            return 0;
        }

        #endregion

        #region 定义SWITCH
        /// <summary>
        /// 定义switchex语句,使用方式Switchex([],[],c)
        /// </summary>
        /// <param name="swittext">开关</param>
        /// <param name="switvalues">对应值</param>
        ///  /// <param name="c">当前传入的</param>
        public static string Switchex(string[] swittext,string[] switvalues,string c)
        {
            for(int i=0;i< swittext.Length;i++)
            {
                if (c.Trim().ToLower() == swittext[i].Trim().ToLower())
                {
                    return switvalues[i].Trim();
                }
            }
            return "";

        }
        /// <summary>
        /// 开关语句比较函数,SwitchexGreaterThan(5,10,15,20,25,30,好，差，中，良，优秀，极品，优秀，10)
        /// </summary>
        /// <param name="swittext"></param>
        /// <param name="switvalues"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string SwitchexRange(double[] swittext, string[] switvalues, double c)
        {
            if (switvalues.Length == swittext.Length + 1 && swittext.Length>=3)
            {
           
                for (int i = 0; i < swittext.Length; i++)
                {
                    if (i == 0)
                    {
                        if (c < swittext[i])
                        {
                            return switvalues[0];
                        }
                    }
                    else if (i == swittext.Length - 1)
                    {
                        if (c >= swittext[i])
                        {
                            return switvalues[switvalues.Length - 1];
                        }
                    }
                    else
                    {
                        if (c >= swittext[i] && c < swittext[i+1])
                        {
                            return switvalues[i + 1];
                        }
                    }
                }
            }
            else if (switvalues.Length == swittext.Length + 1 && swittext.Length == 2)
            {
                if (c <= swittext[0])
                {
                    return switvalues[0];
                }
                else if (c > swittext[0] && c <= swittext[1])
                {
                    return switvalues[1];
                }
                else if (c >swittext[1])
                {
                    return switvalues[2];
                }
            }
            return "";

        }
       
     
        #endregion

        /// <summary>
        /// 定义求阶乘
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static double Factorial(int number)
        {
            return FactorialMath.Factorial(number);
        }
        /// <summary>
        /// 求任意数值之和
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static double Sum(double[] list)
        {
            double z = 0;
            for (int i = 0; i < list.Length; i++)
            {
                z += list[i];
            }
            return z;
        }
        /// <summary>
        /// 获取一组数中最大值
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static double MaxEx(double[] list)
        {
        
            list.OrderByDescending(x => x);
            if (list.Length >= 0)
            {
                return list[0];
            }
            else
            {
                return double.NaN;
            }
        }
        /// <summary>
        /// 获取一组数中最小值
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static double MinEx(double[] list)
        {

            list.OrderBy(x => x);
            if (list.Length >= 0)
            {
                return list[0];
            }
            else
            {
                return double.NaN;
            }
        }
        /// <summary>
        /// 获取一组数中指定元素的数
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string Find(string[] list, int index)
        {
            if (index < list.Length)
            {
                return list[index];
            }
            return "";
           
        }
        /// <summary>
        /// 获取一组数中第一个元素
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string FindFirst(string[] list)
        {
           
                return list[0];
          

        }

        /// <summary>
        /// 获取一组数中最后一个元素
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string FindLast(string[] list)
        {

            return list[list.Length-1];


        }
        /// <summary>
        /// 求任意数平均
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static double Avg(double[] list)
        {
            double z = 0;
            for (int i = 0; i < list.Length; i++)
            {
                z += list[i];
            }
            z = z / list.Length;
            return z;
        }
      

    }
}
