using IOMonitor.Core;
using Scada.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IOMonitor
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
                    Application.EnableVisualStyles();
                    Application.DoEvents();
                    Application.ThreadException += Application_ThreadException;
                    AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                    try
                    {
                        IOMonitorManager.CreateConfig();

                        LoginForm form = new LoginForm();
                        if (form.ShowDialog() == DialogResult.OK)
                        {

                            //保存配置文件信息
                            IOMonitorManager.Config.WriteConfig();
                            Application.Run(new MonitorForm());


                        }
                    }
                    catch(Exception emx)
                    {
                        MessageBox.Show(emx.Message);

                    }
                    mutex.ReleaseMutex();
                }

            }
            else
            {
                Scada.Controls.Forms.FrmDialog.ShowDialog(null, "有一个和本程序相同的应用程序已经在运行，请不要同时运行多个本程序。\n\n这个程序即将退出。", Application.ProductName);
                //   提示信息，可以删除。   
                Application.Exit();//退出程序   
            }


           
        }

      
        static    void Application_ApplicationExit(object sender, EventArgs e)
        {
             MonitorFormManager.ApplicationExit();
        }

       

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(((Exception)e.ExceptionObject).Message);
        }

    }
}
