
using ScadaCenterServer.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scada.DBUtility;

namespace ScadaCenterServer
{
    static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool ret;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out ret);
            if (ret)
            {
                if (IPAddressSelector.Instance().ShowDialog() == DialogResult.OK)
                {
                    try
                    {

                        Application.EnableVisualStyles();
                        Application.DoEvents();
                        Application.ThreadException += Application_ThreadException;
                        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                        if (args.Length <= 0)
                            Application.Run(new IOCenterMainForm());
                        else if (args.Length == 2)
                        {
                            if (IOCenterManager.IOProject.ServerConfig.User.Trim() == args[0].Trim()
                  && IOCenterManager.IOProject.ServerConfig.Password.Trim() == args[1].Trim())
                            {
                                Application.Run(new IOCenterMainForm(IOCenterManager.IOProject.ServerConfig.User.Trim(), IOCenterManager.IOProject.ServerConfig.Password.Trim()));
                            }

                        }


                        mutex.ReleaseMutex();



                    }
                    catch (Exception ex)
                    {
                        IOCenterManager.QueryFormManager.CloseInfluxDBServer();
                        MessageBox.Show("执行失败 错误原因:" + ex.Message);
                    }
                }
            }
            else
            {
                Scada.Controls.Forms.FrmDialog.ShowDialog(null, "有一个和本程序相同的应用程序已经在运行，请不要同时运行多个本程序。\n\n这个程序即将退出。", Application.ProductName);
                //   提示信息，可以删除。   
                Application.Exit();//退出程序   
            }

        }

        private   static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
              IOCenterManager.QueryFormManager.CloseInfluxDBServer();
        }

        private   static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
              IOCenterManager.QueryFormManager.CloseInfluxDBServer();
        }

        private static   void Application_ApplicationExit(object sender, EventArgs e)
        {
              IOCenterManager.QueryFormManager.CloseInfluxDBServer();

        }
    }
}
