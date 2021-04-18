﻿/******************************************************************************
 * SunnyUI 开源控件库、工具类库、扩展类库、多页面开发框架。
 * CopyRight (C) 2012-2020 ShenYongHua(沈永华).
 * QQ群：56829229 QQ：17612584 EMail：SunnyUI@qq.com
 *
 * Blog:   https://www.cnblogs.com/yhuse
 * Gitee:  https://gitee.com/yhuse/SunnyUI
 * GitHub: https://github.com/yhuse/SunnyUI
 *
 * SunnyUI.dll can be used for free under the GPL-3.0 license.
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 文件名称: USystem.cs
 * 文件说明: 系统相关扩展类
 * 当前版本: V2.2
 * 创建日期: 2020-01-01
 *
 * 2020-01-01: V2.2.0 增加文件说明
******************************************************************************/

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;

namespace Sunny.UI
{
    /// <summary>
    /// 系统相关扩展类
    /// </summary>
    public static class SystemEx
    {
        public static void ConsoleWriteLine(this object obj, string preText = "")
        {
            if (preText != "")
                Console.WriteLine(preText + ": " + obj);
            else
                Console.WriteLine(obj.ToString());
        }

        /// <summary>
        /// Delays the specified ms.
        /// </summary>
        /// <param name="ms">The ms.</param>
        public static void Delay(int ms)
        {
            int start = Environment.TickCount;
            while (Environment.TickCount - start < ms)
            {
                System.Threading.Thread.Sleep(1);
                Application.DoEvents();
            }
        }

        /// <summary>
        /// 运行dos命令
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>System.String.</returns>
        public static string RunDosCmd(string command)
        {
            string str;
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd", "/c " + command)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo))
            {
                if (process == null) return string.Empty;
                using (StreamReader reader = process.StandardOutput)
                {
                    str = reader.ReadToEnd();
                }

                process.WaitForExit();
            }

            return str.Trim();
        }

        /// <summary>
        /// Byte To KB
        /// </summary>
        /// <param name="byteValue">Byte value</param>
        /// <returns>KB</returns>
        public static long ToKB(this long byteValue)
        {
            return (long)(byteValue / 1024.0);
        }

        /// <summary>
        /// Byte To MB
        /// </summary>
        /// <param name="byteValue">Byte value</param>
        /// <returns>MB</returns>
        public static long ToMB(this long byteValue)
        {
            return (long)(byteValue / 1024.0 / 1024.0);
        }

        /// <summary>
        /// Byte To GB
        /// </summary>
        /// <param name="byteValue">Byte value</param>
        /// <returns>GB</returns>
        public static long ToGB(this long byteValue)
        {
            return (long)(byteValue / 1024.0 / 1024.0 / 1024.0);
        }

        /// <summary>
        /// Byte To TB
        /// </summary>
        /// <param name="byteValue">Byte value</param>
        /// <returns>TB</returns>
        public static long ToTB(this long byteValue)
        {
            return (long)(byteValue / 1024.0 / 1024.0 / 1024.0 / 1024.0);
        }

        /// <summary>
        /// 获取当前进程占用内存大小(单位：MB)
        /// </summary>
        /// <returns>当前进程占用内存大小(单位：MB)</returns>
        public static double ProcessRamUsed()
        {
            return Process.GetCurrentProcess().WorkingSet64.ToMB();
        }

        /// <summary>
        /// 根据文件名或者磁盘名获取磁盘信息
        /// </summary>
        /// <param name="diskName">文件名或者磁盘名（取第一个字符）</param>
        /// <returns>磁盘信息</returns>
        public static DriveInfo Disk(string diskName)
        {
            if (diskName.IsNullOrEmpty())
            {
                return null;
            }

            diskName = (diskName.Left(1) + ":\\").ToUpper();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                if (drive.Name.ToUpper() == diskName)
                {
                    return drive;
                }
            }

            return null;
        }

        /// <summary>
        /// 根据文件名或者磁盘名判断磁盘是否存在
        /// </summary>
        /// <param name="diskName">文件名或者磁盘名（取第一个字符）</param>
        /// <returns>磁盘是否存在</returns>
        public static bool DiskExist(this string diskName)
        {
            return Disk(diskName) != null;
        }

        /// <summary>
        /// CPU使用率(单位：%)
        /// </summary>
        /// <returns>CPU使用率(单位：%)</returns>
        public static float CpuUsed()
        {
            const string CategoryName = "Processor";
            const string CounterName = "% Processor Time";
            const string InstanceName = "_Total";
            var pc = new PerformanceCounter(CategoryName, CounterName, InstanceName);
            return pc.NextValue();
        }

        //        /// <summary>
        //        /// 总内存大小(单位：Byte)
        //        /// </summary>
        //        /// <returns>总内存大小(单位：Byte)</returns>
        //        public static ulong RamTotal()
        //        {
        //            return new ComputerInfo().TotalPhysicalMemory;
        //        }
        //
        //        /// <summary>
        //        /// 可用内存大小(单位：Byte)
        //        /// </summary>
        //        /// <returns>可用内存大小(单位：Byte)</returns>
        //        public static ulong RamFree()
        //        {
        //            return new ComputerInfo().AvailablePhysicalMemory;
        //        }
        //
        //        /// <summary>
        //        /// 内存使用率(单位：%)
        //        /// </summary>
        //        /// <returns>内存使用率(单位：%)</returns>
        //        public static float RamUsed()
        //        {
        //            return 100 - (RamFree() * 100.00f / RamTotal());
        //        }

        /// <summary>
        /// 程序已经运行
        /// </summary>
        /// <returns>是否运行</returns>
        [EnvironmentPermission(SecurityAction.LinkDemand, Unrestricted = true)]
        public static bool ProcessIsRun()
        {
            Process instance = RunningInstance();
            return (instance != null);
        }

        /// <summary>
        /// 将程序调至前台
        /// </summary>
        /// <param name="showStyle">显示风格</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public static void BringToFront(int showStyle = SW_SHOW)
        {
            Process instance = RunningInstance();
            HandleRunningInstance(instance, showStyle);
        }

        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public static Process RunningInstance()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(currentProcess.ProcessName);
            if (currentProcess.MainModule == null) return null;

            //遍历与当前进程名称相同的进程列表
            return processes.Where(process => process.Id != currentProcess.Id).FirstOrDefault(
                process => string.Equals(
                    Assembly.GetExecutingAssembly().Location.Replace("/", "\\").SplitBeforeLast("\\"),
                    currentProcess.MainModule.FileName.SplitBeforeLast("\\"),
                    StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// 关闭进程
        /// </summary>
        /// <param name="filename">文件名</param>
        public static void CloseFile(string filename)
        {
            Process[] processes = Process.GetProcesses();
            //遍历与当前进程名称相同的进程列表
            foreach (Process process in processes)
            {
                if (!string.Equals(process.ProcessName, filename, StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }

                process.Kill();
                process.Close();
            }
        }

        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        private static void HandleRunningInstance(Process instance, int showStyle)
        {
            ShowWindowAsync(instance.MainWindowHandle, showStyle); //调用api函数，正常显示窗口
            SetForegroundWindow(instance.MainWindowHandle); //将窗口放置最前端。
        }

        /// <summary>
        /// 显示器个数
        /// </summary>
        /// <returns>个数</returns>
        public static int ScreenCount()
        {
            return Screen.AllScreens.Length;
        }

        /// <summary>
        /// 多显示器扩展，指定显示器显示
        /// </summary>
        /// <param name="frm">窗体</param>
        /// <param name="monitor">显示器序号</param>
        /// <param name="showMax">最大化</param>
        /// <param name="left">左边距离</param>
        /// <param name="top">顶部距离</param>
        public static void ShowOnMonitor(this Form frm, int monitor, bool showMax = true, int left = 0, int top = 0)
        {
            Screen[] sc = Screen.AllScreens;
            if (monitor >= sc.Length)
            {
                monitor = 0;
            }

            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(sc[monitor].Bounds.Left + left, sc[monitor].Bounds.Top + top);
            frm.WindowState = showMax ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// 最小化显示
        /// Hides the window and activates another window.
        /// </summary>
        public const int SW_HIDE = 0;

        /// <summary>
        /// 正常显示
        /// Activates and displays a window. If the window is minimized or maximized, the system restores it to the original size and position. An application specifies this flag when displaying the window for the first time.
        /// </summary>
        public const int SW_NORMAL = 1;

        /// <summary>
        /// 激活窗口并将其最小化
        /// Activates the window, and displays it as a minimized window.
        /// </summary>
        public const int SW_SHOWMINIMIZED = 2;

        /// <summary>
        /// 激活窗口并将其最大化 
        /// Activates the window, and displays it as a maximized window.
        /// </summary>
        public const int SW_SHOWMAXIMIZED = 3;

        /// <summary>
        /// 以窗口最近一次的大小和状态显示窗口。激活窗口仍然维持激活状态。
        /// Displays a window in its most recent size and position. This value is similar to SW_SHOWNORMAL, except that the window is not activated. 
        /// </summary>
        public const int SW_SHOWNOACTIVATE = 4;

        /// <summary>
        /// 在窗口原来的位置以原来的尺寸激活和显示窗口。 
        /// Activates the window, and displays it at the current size and position.
        /// </summary>
        public const int SW_SHOW = 5;

        /// <summary>
        /// 最小化指定的窗口并且激活在Z序中的下一个顶层窗口。
        /// Minimizes the specified window, and activates the next top-level window in the Z order.
        /// </summary>
        public const int SW_MINIMIZE = 6;

        /// <summary>
        /// 窗口最小化，激活窗口仍然维持激活状态。 
        /// Displays the window as a minimized window. This value is similar to SW_SHOWMINIMZED, except that the window is not activated.     
        /// </summary>
        public const int SW_SHOWMINNOACTIVE = 7;

        /// <summary>
        /// 以窗口原来的状态显示窗口。激活窗口仍然维持激活状态。
        /// Displays the window at the current size and position. This value is similar to SW_SHOW, except that the window is not activated.
        /// </summary>
        public const int SW_SHOWNA = 8;

        /// <summary>
        /// 激活并显示窗口。如果窗口最小化或最大化，则系统将窗口恢复到原来的尺寸和位置。在恢复最小化窗口时，应用程序应该指定这个标志。 
        /// Activates and displays the window. If the window is minimized or maximized, the system restores it to the original size and position. An application specifies this flag when restoring a minimized window. 
        /// </summary>
        public const int SW_RESTORE = 9;

        /// <summary>
        /// 依据在STARTUPINFO结构中指定的SW_FLAG标志设定显示状态，STARTUPINFO结构是由启动应用程序的程序传递给CreateProcess函数的。  
        /// Sets the show state based on the SW_ value that is specified in the STARTUPINFO structure passed to the CreateProcess function by the program that starts the application.
        /// </summary>
        public const int SW_SHOWDEFAULT = 10;

        /// <summary>
        /// 在WindowNT5.0中最小化窗口，即使拥有窗口的线程被挂起也会最小化。在从其他线程最小化窗口时才使用这个参数。 
        /// Windows Server 2003, Windows 2000, and Windows XP:  Minimizes a window, even when the thread that owns the window is hung. Only use this flag when minimizing windows from a different thread.
        /// </summary>
        public const int SW_FORCEMINIMIZE = 11;
    }
}