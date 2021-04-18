
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Scada.DBUtility
{
    /// <summary>
    /// 该工具主要是解析XML中定义的公式，并计算结果，输入参数只要是普通的公式即可
    /// </summary>
    public class AnalyzeCalculate
    {
        /**
       * 定义运算符
       */
        private static List<string> lc = new List<string>()
	  {
          "+",
          "-",
          "*",
          "/"
	};

        /**
         * 定义逻辑运算符
         */
        private static List<string> lj = new List<string>()
	  {
          ">",
          "<",
          "=",
          "!"
	 
	};
        /**
             * int数组注释,第一个标识:0自带函数 1自定义函数;第二个标识:参数个数 自带函数,可利用反射机制
         *  "tan","atan","tanh","pow","exp","log10","log","abs","cos","acos","asin","ceiling","cosh","floor","ieeeremainder","max","min","round","sin","sinh","sqrt","truncate"
             */
        public static List<FunctionItem> funMap = new List<FunctionItem>()
        { 
    new  FunctionItem(){ FuncString="tan", level=0},
    new  FunctionItem(){ FuncString="atan", level=0},
    new  FunctionItem(){ FuncString="pow", level=0},
    new  FunctionItem(){ FuncString="exp", level=0},
    new  FunctionItem(){ FuncString="log10", level=0},
    new  FunctionItem(){ FuncString="log", level=0},
    new  FunctionItem(){ FuncString="abs", level=0},
    new  FunctionItem(){ FuncString="cos", level=0},
    new  FunctionItem(){ FuncString="acos", level=0},
    new  FunctionItem(){ FuncString="asin", level=0},
    new  FunctionItem(){ FuncString="ceiling", level=0},
    new  FunctionItem(){ FuncString="cosh", level=0},
    new  FunctionItem(){ FuncString="floor", level=0},
    new  FunctionItem(){ FuncString="ieeeremainder", level=0},
    new  FunctionItem(){ FuncString="max", level=0},
    new  FunctionItem(){ FuncString="min", level=0},
    new  FunctionItem(){ FuncString="sin", level=0},
    new  FunctionItem(){ FuncString="sinh", level=0},
    new  FunctionItem(){ FuncString="truncate", level=0},
    new  FunctionItem(){ FuncString="sqrt", level=0},
    new  FunctionItem(){ FuncString="integrate", level=1},//自定义函数，求定积分
    new  FunctionItem(){ FuncString="fact", level=1},//自定义函数求阶乘
    new  FunctionItem(){ FuncString="where", level=1},//自定义条件函数 条件语句
    new  FunctionItem(){ FuncString="factorial", level=1},//自定义条件函数 求阶乘1-N的阶乘
    new  FunctionItem(){ FuncString="switchexrange", level=1},//自定开关函数 范围内对比
    new  FunctionItem(){ FuncString="sum", level=1},//求一系列数之和
    new  FunctionItem(){ FuncString="avg", level=1},//求一系列数只平均
    new  FunctionItem(){ FuncString="minex", level=1},//获取一组数种最小值
    new  FunctionItem(){ FuncString="maxex", level=1},//获取一组数种最大值
    new  FunctionItem(){ FuncString="find", level=1},//获取指定数组的指定索引元素值
    new  FunctionItem(){ FuncString="findfirst", level=1},//获取指定数组的第一个元素值
    new  FunctionItem(){ FuncString="findlast", level=1},//获取指定数组的最后元素值
    new  FunctionItem(){ FuncString="switchex", level=1}//自定开关函数
        };
        /// <summary>
        /// 支持的函数
        /// </summary>
        public static string Function
        {
            get
            {
                string str = "";
                foreach (FunctionItem item in funMap)
                {
                    str += "  " + item.FuncString;
                }
               
                return str;
            }
        }
        /// <summary>
        /// 支持的操作符
        /// </summary>
        public static string Operator
        {
            get
            {
                
                string str = "";
                foreach (string item in lc)
                {
                    str += "  " + item;
                }
                return str;
            }
        }
        /// <summary>
        /// 判断某个字符串是否属于函数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static bool IsSystemFun(string str)
        {
            if (str.Trim() == "")
                return false;
            return funMap.Exists(delegate(FunctionItem p) { return p.FuncString.Trim().ToLower() == str.Trim().ToLower(); });
        }

        /**
	 * 公式初始化转换
	 * 
	 * @param str
	 * @return 处理过的计算客串
	 */
        private static String strCast(String str)
        {
            //str = str.toLowerCase();// 去除空格，变小写

            if (str == null ? true : str.Length == 0)
                return "0";
            if (!checkFormula(str))
                return "0";
            str = str.Replace("\\*-", "**");
            str = str.Replace("-\\*", "**");
            str = str.Replace("/-", "//");
            str = str.Replace("-/", "//");
            str = str.Replace("\\+-", "-");
            str = str.Replace("-\\+", "-");
            str = str.Replace("-", "-");
            str = str.Replace("\\*\\*", "*-");
            str = str.Replace("+~", "-");
            str = str.Replace("~+", "-");
            str = str.Replace("//", "/-");
            str = str.Replace(" ", "");
            str = str.Replace("－", "-");
             str = str.Replace("－", "-");
             str = str.Replace("[", "(");
             str = str.Replace("]", ")");
          

            return str;
        }
        /**
	 * 检查公式中括号出现次数是否正确
	 * 
	 * @param formulaStr
	 * @return 公式中的括号是否成对
	 */
        private static bool checkFormula(String formulaStr)
        {
            bool flag = true;
            int count = 0;
            for (int i = 0; i < formulaStr.Length; i++)
            {
                string s = formulaStr[i].ToString();
                if ("(".Equals(s))
                    count++;
                else if (")".Equals(s))
                    count--;
            }
            flag = count == 0;
            return flag;
        }


        /**
         * 分割函数
         * 
         * @param str
         * @param bs
         * @return 分割后的客串
         */
        private static string[] spliteFun(String str, String bs)
        {
            List<string> list = new List<string>();
            String bds = "";
            int bracket = 0;
            int len = str.Length;
            for (int i = 0; i < len; i++)
            {
                String s = str[i].ToString();
                if ("(".Equals(s))
                {
                    bracket++;
                }
                else if (")".Equals(s))
                {
                    bracket--;
                }

                if (bracket == 0 && bs.Equals(s))
                {
                    list.Add(bds);
                    bds = "";
                    continue;
                }

                bds += s;
            }

            list.Add(bds);

            String[] ss = new String[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                ss[i] = list[i];
            }

            return ss;
        }
        /**
	 * 用户自定义函数
	 * 
	 * @param str
	 * @param funStr
	 * @return 处理用户自定义函数
	 */
        private static String customFun(String str, String funStr)
        {
            String reval = "0";

            String[] gss = spliteFun(str, ",");
            if ("if".Equals(funStr))
            {
                if (compare(gss[0]))
                {
                    reval = Calculate(gss[1]);
                }
                else
                {
                    reval = Calculate(gss[2]);
                }
            }
            else if ("mod".Equals(funStr))
            {
                double d2 = Convert.ToDouble(Calculate(gss[1]));
                if (d2 == 0)
                    return reval;
                double d1 = Convert.ToDouble(Calculate(gss[0]));
                reval = (d1 % d2) + "";
            }
            else if ("int".Equals(funStr))
            {
                reval = Math.Floor(Convert.ToDouble(Calculate(gss[0]))) + "";
            }
            return reval;
        }

        /**
	 * 逻辑表达式判断
	 * 
	 * @param str
	 * @return true or false
	 */
        private static bool compare(String str)
        {
            bool flag = false;
            bool bs = false;
            int len = str.Length;
            int bracket = 0;
            string ljbds = "";
            double d_left = 0;
            double d_right = 0;

            for (int i = 0; i < len; i++)
            {
                String s = str[i].ToString();
                if ("(".Equals(s))
                {
                    bracket++;
                }
                else if (")".Equals(s))
                {
                    bracket--;
                }

                if (bracket == 0 && lj.Contains(s))
                {
                    for (int j = i; j < len; j++)
                    {
                        String ts = str[j].ToString();
                        if (lj.Contains(ts))
                        {
                            ljbds += ts;
                        }
                        else
                        {
                            bs = true;
                            break;
                        }
                    }
                }
                if (bs)
                    break;
            }

            string[] ms = str.Split(new string[1] { ljbds }, StringSplitOptions.RemoveEmptyEntries);
            d_left = Convert.ToDouble(Calculate(ms[0]));
            d_right = Convert.ToDouble(Calculate(ms[1]));

            if ("<".Equals(ljbds))
            {
                if (d_left < d_right)
                    return true;
            }
            else if (">".Equals(ljbds))
            {
                if (d_left > d_right)
                    return true;
            }
            else if ("=".Equals(ljbds))
            {
                if (d_left == d_right)
                    return true;
            }
            else if (">=".Equals(ljbds))
            {
                if (d_left >= d_right)
                    return true;
            }
            else if ("<=".Equals(ljbds))
            {
                if (d_left <= d_right)
                    return true;
            }
            else if ("<>".Equals(ljbds) || "!=".Equals(ljbds))
            {
                if (d_left != d_right)
                    return true;
            }

            return flag;
        }
        private static string Substring(string str, int StartIndex, int EndIndex)
        {

            return str.Substring(StartIndex, EndIndex - StartIndex);
        }


        /**
     * 递归调用运算
     * 
     * @param str
     * @return String
     */
        public static String Calculate(String str)
        {
            str = strCast(str);

            String reval = "";
            String bds = "";
            int bracket = 0;// 对应括号个数
            int pos = 0;
            bool title = false;

            if (Substring(str, 0, 1).Equals("~"))
            {
                str = str.Substring(1);
                title = true;
            }

            int len = str.Length;

            for (int i = 0; i < len; i++)
            {
                String s = str[i].ToString();
                pos = i;
                bracket = 0;
                if (!lc.Contains(s))
                {// 如果没遇到运算符
                    if ("(".Equals(s))
                    {// 如果遇到左括号
                        // if (funMap.containsKey(bds))
                        if (funMap.FindIndex(delegate(FunctionItem p) { return p.FuncString == bds; }) >= 0)
                        {// 如果左括号前是函数
                            for (int j = i + 1; j < len; j++)
                            {// 从左括号后开始循环
                                pos++;// 累计移动字符位数
                                String ts = str[j].ToString();// 单个字符
                                // reval+=ts;
                                if ("(".Equals(ts))// 如果是左括号累计
                                    bracket++;
                                else if (")".Equals(ts))
                                {// 如果是右括号进行减少
                                    bracket--;
                                    if (bracket == -1)
                                    {
                                        // 如果是-1,标识括号结束
                                        reval = Substring(reval, 0, reval.Length - bds.Length);// 重新获得去掉函数头的表达式
                                        string cf = Substring(str, i + 1, j);
                                        reval += funCalculate(cf, bds);// 表达式加上函数结果,形成新表达式
                                        i = pos;// 计数器增加
                                        bds = "";// 函数头清空
                                        break;// 退出本次循环
                                    }
                                }
                            }
                        }
                        else
                        {// 如果是普通运算
                            for (int j = i + 1; j < len; j++)
                            {
                                pos++;
                                String ts = str[j].ToString();
                                if ("(".Equals(ts))
                                    bracket++;
                                else if (")".Equals(ts))
                                {
                                    bracket--;
                                    if (bracket == -1)
                                    {
                                        string cf = Substring(str, i + 1, pos);
                                        reval += Calculate(cf);
                                      
                                        i = pos;
                                        bds = "";
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {// 累加总表达式和最后一个运算数(或函数)
                        bds += s;
                        reval += s;
                    }
                }
                else
                {// 遇到运算符最后一个运算数(或函数)清空
                    bds = "";
                    reval += s;
                }
            }

            if (title)
                reval = "~" + reval;
            return szys(reval);
        }
        /**
	 * 公式里的参数分割
	 * 
	 * @param str
	 * @return String[]
	 */
        private static String[] zlcs(String str)
        {
            int len = str.Length;
            bool flag = true;
            String tstr = "";

            for (int i = 0; i < len; i++)
            {
                String s = str[i].ToString();
                if ("(".Equals(s))
                {
                    flag = false;
                }
                else if (")".Equals(s))
                {
                    flag = true;
                }
                if (flag && ",".Equals(s))
                {
                    tstr += "﹟";
                }
                else
                {
                    tstr += s;
                }
            }

            return tstr.Split(new char[] { '﹟' }, StringSplitOptions.RemoveEmptyEntries);

        }

        /**
         * 四则运算表达式处理
         * 
         * @param str
         * @return String
         */
        private static String szys(String gs)
        {

            gs = gs + "+0"; // 因为下面的计算是遇到符号才进行,所以多加入一个计算符号,不影响值.
            String c1 = "";// 第一个运算符号
            String c2 = "";// 第二个运算符号
            String s1 = "";// 第一个运算数
            String s2 = "";// 第二个运算数
            String s3 = "";// 第三个运算数

            int len = gs.Length;
            for (int i = 0; i < len; i++)
            {
                String s = gs[i].ToString();// 获得该位置字符并转换成字符串做比较

                if (lc.Contains(s))
                { // 如果是运算符号
                    if (c1.Length == 0)// 如果第一个运算符号为空,加入
                        c1 = s;
                    else if (c2.Length == 0)
                    {// 否则,如果第二个运算符号为空,加入
                        c2 = s;// 第二个运算符号
                        if ("+".Equals(c2) || "-".Equals(c2))
                        {// 如果第二个运算符号级别低,那么进行计算
                            s1 = _4zys(s1, c1, s2);// 第一个和第二个数计算
                            c1 = c2;// 保存第二个运算符,其他为空
                            c2 = "";
                            s2 = "";
                        }
                        else if (("/".Equals(c2) || "*".Equals(c2)) && ("/".Equals(c1) || "*".Equals(c1)))
                        {
                            s1 = _4zys(s1, c1, s2);// 第一个和第二个数计算
                            c1 = c2;// 保存第二个运算符,其他为空
                            c2 = "";
                            s2 = "";

                        }
                    }
                    else
                    {// 上述都保存过
                        if ("+".Equals(s) || "-".Equals(s))
                        {// 如果第三个运算符级别低,进行运算
                            s2 = _4zys(s2, c2, s3);// 先算第二三个数,保存至第二个
                            s1 = _4zys(s1, c1, s2);// 再算第一二个,保存至第一个
                            c1 = s;// 保存当前运算符,其他为空
                            s2 = "";
                            c2 = "";
                            s3 = "";
                        }
                        else
                        {// 如果第三个运算符级别高

                            s2 = _4zys(s2, c2, s3);// 先算第二三个数,保存至第二个
                            c2 = s;// 前面不动,保存运算符
                            s3 = "";
                        }
                    }
                }
                else if (s1.Length > 0 && c1.Length > 0 && c2.Length == 0)
                {
                    // 如果第一个数,第一个运算符已保存,第二个运算符未保存,保存第二哥数
                    s2 += s;
                }
                else if (c1.Length == 0)
                {// 如果没有运算符,保存第一个数
                    s1 += s;
                }
                else if (s1.Length > 0 && s2.Length > 0 && c1.Length > 0
                      && c2.Length > 0)
                {// 如果第一二个数和运算符都有,保存第三个数
                    s3 += s;
                }
            }
            return s1;
        }

        /**
         * 基本四则运算
         * 
         * @param c1
         *            运算数1
         * @param s1
         *            运算符(加减乘除)
         * @param c2
         *            运算数2
         * @return String
         */
        private static String _4zys(String c1, String s1, String c2)
        {
            double z = 0;
            String reval = "0";
            if (c1 == "" || c2 == "")
                return reval = "0";
            if (c1.Contains("~"))
            {
                c1 = c1.Replace("~", "-");
            }
            if (c2.Contains("~"))
            {
                c2 = c2.Replace("~", "-");
            }
            try
            {
                double ln = Convert.ToDouble(c1);
                double rn = Convert.ToDouble(c2);
                if ("+".Equals(s1))
                {
                    z = (ln + rn);

                }
                else if ("-".Equals(s1))
                {

                    z = ln - rn;

                }
                else if ("*".Equals(s1))
                {
                    z = ln * rn;
                }
                else if ("/".Equals(s1))
                {
                    if (rn == 0)
                        return reval;
                    else
                    {
                        z = ln / rn;

                    }
                }

                if (z >= 0)
                {
                    return z + "";
                }
                else
                {
                    return "~" + Math.Abs(z) + "";
                }

            }
            catch 
            {
            }
            finally
            {
            }

            return reval;
        }



        /**
     * 函数运算 目前只支持系统函数
     * 
     * @param gs
     * @param flag
     * @return String
     */
        private static string StringValueCast(double d)
        {
            if (d < 0)
            {
                return "~" + Convert.ToDecimal(Math.Abs(d)).ToString("0.0000000000");
            }
            else
            {
                return Convert.ToDecimal(d).ToString("0.0000000000");
            }
        }
        private static string funCalculate(string gs, string funStr)
        {

            string rval = "0";

            List<FunctionItem> finders = funMap.FindAll(delegate(FunctionItem p) { return p.FuncString == funStr; });
            if (finders != null && finders.Count > 0)
            {
                finders.ForEach(delegate(FunctionItem finder)
                    {

                        #region 函数计算部分
                        // "tan","atan","tanh","pow","exp","log10","log","abs","cos","acos","asin","ceiling","cosh","floor","ieeeremainder","max","min","round","sin","sinh","sqrt","truncate"
                        switch (finder.FuncString.Trim().ToLower())
                        {

                            case "tan":
                                {

                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 1)
                                    {
                                        throw new Exception("tan 只能有一个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    rval = StringValueCast(Math.Tan(parasvalue)).ToString();


                                }
                                break;
                            case "atan":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 1)
                                    {
                                        throw new Exception("atan 只能有一个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    rval = StringValueCast(Math.Atan(parasvalue)).ToString();
                                }
                                break;
                            case "tanh":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 1)
                                    {
                                        throw new Exception("tanh 只能有一个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    rval = StringValueCast(Math.Tanh(parasvalue)).ToString();
                                }
                                break;
                            case "pow":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 2)
                                    {
                                        throw new Exception("pow 只能有二个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    double parasvalue2 = Convert.ToDouble(Calculate(funparas[1]).Replace("~", "-"));
                                    rval = StringValueCast(Math.Pow(parasvalue, parasvalue2)).ToString();
                                }
                                break;
                            case "exp":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 1)
                                    {
                                        throw new Exception("exp 只能有一个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    rval = StringValueCast(Math.Exp(parasvalue)).ToString();
                                
                                }
                                break;
                            case "log10":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 1)
                                    {
                                        throw new Exception("log10 只能有一个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                  
                                    rval = StringValueCast(Math.Log10(parasvalue)).ToString();
                                }
                                break;
                            case "log":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 2)
                                    {
                                        throw new Exception("log 只能有二个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    double parasvalue2 = Convert.ToDouble(Calculate(funparas[1]).Replace("~", "-"));
                                    
                                    rval = StringValueCast(Math.Log(parasvalue, parasvalue2)).ToString();
                                }

                                break;
                            case "abs":
                                {

                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 1)
                                    {
                                        throw new Exception("abs 只能有一个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    rval = StringValueCast(Math.Abs(parasvalue)).ToString();
                                }
                                break;
                            case "cos":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 1)
                                    {
                                        throw new Exception("cos 只能有一个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    rval = StringValueCast(Math.Cos(parasvalue)).ToString();
                                }
                                break;
                            case "acos":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 1)
                                    {
                                        throw new Exception("acos 只能有一个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    rval = StringValueCast(Math.Acos(parasvalue)).ToString();
                                }
                                break;
                            case "asin":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 1)
                                    {
                                        throw new Exception("asin 只能有一个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    rval = StringValueCast(Math.Asin(parasvalue)).ToString();
                                }
                                break;
                            case "ceiling":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 1)
                                    {
                                        throw new Exception("ceiling 只能有一个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    rval = StringValueCast(Math.Ceiling(parasvalue)).ToString();
                                }
                                break;
                            case "cosh":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 1)
                                    {
                                        throw new Exception("cosh 只能有一个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    rval = StringValueCast(Math.Cosh(parasvalue)).ToString();
                                }
                                break;
                            case "floor":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 1)
                                    {
                                        throw new Exception("floor 只能有一个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    rval = StringValueCast(Math.Floor(parasvalue)).ToString();
                                }
                                break;
                            case "ieeeremainder":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数

                                    if (funparas.Length != 2)
                                    {
                                        throw new Exception("ieeeremainder 只能有二个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    double parasvalue2 = Convert.ToDouble(Calculate(funparas[1]).Replace("~", "-"));
                                    rval = StringValueCast(Math.IEEERemainder(parasvalue, parasvalue2)).ToString();
                                }
                                break;
                            case "max":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数

                                    if (funparas.Length != 2)
                                    {
                                        throw new Exception("max 只能有二个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    double parasvalue2 = Convert.ToDouble(Calculate(funparas[1]).Replace("~", "-"));
                                    rval = StringValueCast(Math.Max(parasvalue, parasvalue2)).ToString();
                                }
                                break;
                            case "min":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数

                                    if (funparas.Length != 2)
                                    {
                                        throw new Exception("min 只能有二个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    double parasvalue2 = Convert.ToDouble(Calculate(funparas[1]).Replace("~", "-"));
                                    rval = StringValueCast(Math.Min(parasvalue, parasvalue2)).ToString();
                                }
                                break;

                            case "round":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 1)
                                    {
                                        throw new Exception("round 只能有一个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    rval = StringValueCast(Math.Round(parasvalue)).ToString();
                                }
                                break;
                            case "sin":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 1)
                                    {
                                        throw new Exception("sin 只能有一个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    rval = StringValueCast(Math.Sin(parasvalue)).ToString();
                                }
                                break;
                            case "sinh":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 1)
                                    {
                                        throw new Exception("sinh 只能有一个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    rval = StringValueCast(Math.Sinh(parasvalue)).ToString();
                                }
                                break;
                            case "sqrt":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 1)
                                    {
                                        throw new Exception("sqrt 只能有一个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    if (parasvalue <= 0)
                                    {
                                        throw new Exception("sqrt 只能有一个参数,并且参数不能为0");
                                    }
                                    rval = StringValueCast(Math.Sqrt(parasvalue)).ToString();
                                }
                                break;

                            case "truncate":
                                {

                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 1)
                                    {
                                        throw new Exception("truncate 只能有一个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    rval = StringValueCast(Math.Truncate(parasvalue)).ToString();
                                }
                                break;
                            case "where":
                                {
                                    string[] funparas = zlcs(gs);//获取公式里的所有参数

                                    if (funparas.Length != 5)
                                    {
                                        throw new Exception("where 必须有5个个参数");
                                    }
                                        string operater = funparas[4].Trim().ToLower();
                                 
                                        double c1 = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                        double c2 = Convert.ToDouble(Calculate(funparas[1]).Replace("~", "-"));
                                        double tvalue = Convert.ToDouble(Calculate(funparas[2]).Replace("~", "-"));
                                        double fvalue = Convert.ToDouble(Calculate(funparas[3]).Replace("~", "-"));
                                        rval = StringValueCast(MathEx.Where(c1, c2, tvalue, fvalue, operater)).ToString();
                                    
                                    
                                }
                                break;
                            case "switchex"://开关量不能参与计算
                                {

                                    string[] funparas = zlcs(gs);//获取公式里的所有参数

                                    int numswitch = (funparas.Length - 1) / 2;//获取参数中对应的开关量和开关值
                                    string[] swi = new string[numswitch];
                                    string[] vs = new string[numswitch];
                                    string c = funparas[funparas.Length - 1];
                                    for (int i = 0; i < numswitch; i++)
                                    {
                                        swi[i] = Calculate(funparas[i]).Replace("~", "-");
                                        vs[i] = Calculate(funparas[numswitch + i]).Replace("~", "-");
                                    }
                                    rval = MathEx.Switchex(swi, vs, c);
                                  
                                }
                                break;
                            case "factorial"://求到N的积分
                                {

                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    if (funparas.Length != 1)
                                    {
                                        throw new Exception("factorial 只能有一个参数");
                                    }
                                    double parasvalue = Convert.ToDouble(Calculate(funparas[0]).Replace("~", "-"));
                                    rval = StringValueCast(MathEx.Factorial(Convert.ToInt32(parasvalue))).ToString();
                                }
                                break;

         

                            case "switchexrange"://开关量不能参与计算
                                {

                                    string[] funparas = zlcs(gs);//获取公式里的所有参数

                                    int numswitch = (funparas.Length ) / 2;//获取参数中对应的开关量和开关值
                                    double[] swi = new double[numswitch - 1];
                                    string[] vs = new string[numswitch];
                                    double c = Convert.ToDouble(Calculate(funparas[funparas.Length - 1]).Replace("~", "-"));
                                    for (int i = 0; i < numswitch; i++)
                                    {
                                        if (i < swi.Length)
                                        {
                                            swi[i] = Convert.ToDouble(Calculate(funparas[i]).Replace("~", "-"));
                                        }
                                        if (i < vs.Length)
                                        {
                                            vs[i] = Calculate(funparas[swi.Length + i ]).Replace("~", "-");
                                        }
                               
                                    }
                                    rval = MathEx.SwitchexRange(swi, vs, c);
                                }
                                break;
                            case "sum"://获取某一组数之和
                                {

                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    double[] paras = new double[funparas.Length];
                                    for (int i = 0; i < paras.Length; i++)
                                    {
                                        double parasvalue = Convert.ToDouble(Calculate(funparas[i]).Replace("~", "-"));
                                        paras[i] = parasvalue;
                                    }
                                    rval = StringValueCast(MathEx.Sum(paras)).ToString();
                                }
                                break;
                            case "avg"://获取某一组数平均值
                                {

                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    double[] paras = new double[funparas.Length];
                                    for (int i = 0; i < paras.Length; i++)
                                    {
                                        double parasvalue = Convert.ToDouble(Calculate(funparas[i]).Replace("~", "-"));
                                        paras[i] = parasvalue;
                                    }
                                    rval = StringValueCast(MathEx.Avg(paras)).ToString();
                                }
                                break;
                            case "minex"://获取某一组数的最小值
                                {

                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    double[] paras = new double[funparas.Length];
                                    for (int i = 0; i < paras.Length; i++)
                                    {
                                        double parasvalue = Convert.ToDouble(Calculate(funparas[i]).Replace("~", "-"));
                                        paras[i] = parasvalue;
                                    }
                                    rval = StringValueCast(MathEx.MinEx(paras)).ToString();
                                }
                                break;
                            case "maxex"://获取某一组数的最大值
                                {

                                    string[] funparas = zlcs(gs);//获取公式里的所有参数
                                    double[] paras = new double[funparas.Length];
                                    for (int i = 0; i < paras.Length; i++)
                                    {
                                        double parasvalue = Convert.ToDouble(Calculate(funparas[i]).Replace("~", "-"));
                                        paras[i] = parasvalue;
                                    }
                                    rval = StringValueCast(MathEx.MaxEx(paras)).ToString();
                                }
                                break;
                           
 

                        }

                        #endregion

                    });

            }

            return rval;
        }


    }
}
