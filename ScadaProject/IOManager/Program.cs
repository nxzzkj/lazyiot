using IOManager.Core;
using Scada.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
         

            bool ret;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out ret);
            if (ret)
            {
                if (IPAddressSelector.Instance().ShowDialog() == DialogResult.OK)
                {
                    Application.EnableVisualStyles();
                    System.Windows.Forms.Application.DoEvents();


                    Application.ThreadException += Application_ThreadException;
                    AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                    LoginForm form = new LoginForm();
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        Application.Run(new IOMainForm());
                    }

                    mutex.ReleaseMutex();
                }
            }
            else
            {
                MessageBox.Show(null, "有一个和本程序相同的应用程序已经在运行，请不要同时运行多个本程序。\n\n这个程序即将退出。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //   提示信息，可以删除。   
                Application.Exit();//退出程序   
            }


        }

        private static  void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
             FormManager.SaveProject();
            MessageBox.Show(e.ExceptionObject.ToString());
        }

        private static  void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            FormManager.SaveProject();
            MessageBox.Show(e.Exception.Message);
        }
    }
}
