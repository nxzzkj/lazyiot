using System;
using System.Configuration;
namespace Scada.DBUtility
{
    
    public class PubConstant
    {

       
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ReadDataTransType
        {           
            get 
            {
                if (ConfigurationManager.ConnectionStrings["ReadDataTransType"]!=null)
                {

              
                string ConnectionStrings_ = ConfigurationManager.ConnectionStrings["ReadDataTransType"].ConnectionString;       
                
                return ConnectionStrings_;
                }
                else
                {
                    return "";
                }
            }
        }
        
        public static string Product
        {
            get
            {
                if(ConfigurationManager.ConnectionStrings["Product"]!=null)
                {
                    string Product_ = ConfigurationManager.ConnectionStrings["Product"].ConnectionString;

                    return Product_;
                }
                else
                {
                    return "";
                }
             
            }
        }
       


    }
}
