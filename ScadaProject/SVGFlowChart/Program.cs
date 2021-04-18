using Scada.DBUtility;
using ScadaFlowDesign.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScadaFlowDesign
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
                    System.Windows.Forms.Application.DoEvents();

                    Application.ApplicationExit += Application_ApplicationExit;
                    Application.ThreadException += Application_ThreadException;
                    Application.ThreadExit += Application_ThreadExit;
                    AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                    LoginForm form = new LoginForm();
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        FlowManager.StartFlowManager();

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

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ExceptionSave();

        }

        private static void Application_ThreadExit(object sender, EventArgs e)
        {
         
        }
        private static void ExceptionSave()
        {
            for (int i = 0; i < FlowManager.Projects.Count; i++)
            {
                FlowManager.SaveProject(FlowManager.Projects[i]);

            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ExceptionSave();
            FlowManager.AddLogToMainLog(e.Exception.Message);
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            
           
           

        }
    }
}
