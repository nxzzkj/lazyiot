using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
namespace GasMonitor
{
   public class ExitWindows
    {
        #region win32 api
        [StructLayout(LayoutKind.Sequential, Pack = 1)]

        private struct TokPriv1Luid
        {

            public int Count;

            public long Luid;

            public int Attr;

        }

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetCurrentProcess();

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall,
            ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool ExitWindowsEx(int flg, int rea);

        #endregion

        private const int SE_PRIVILEGE_ENABLED = 0x00000002;

        private const int TOKEN_QUERY = 0x00000008;

        private const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;

        private const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";

        #region Exit Windows Flags
        private const int EWX_LOGOFF = 0x00000000;

        private const int EWX_SHUTDOWN = 0x00000001;

        private const int EWX_REBOOT = 0x00000002;

        private const int EWX_FORCE = 0x00000004;

        private const int EWX_POWEROFF = 0x00000008;

        private const int EWX_FORCEIFHUNG = 0x00000010;

        #endregion

        public static void DoExitWin(int flg)
        {

            //give current process SeShutdownPrivilege
            TokPriv1Luid tp;

            IntPtr hproc = GetCurrentProcess();

            IntPtr htok = IntPtr.Zero;

            if (!OpenProcessToken(hproc, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok))
            {
                throw new Exception("Open Process Token fail");
            }

            tp.Count = 1;

            tp.Luid = 0;

            tp.Attr = SE_PRIVILEGE_ENABLED;

            if (!LookupPrivilegeValue(null, SE_SHUTDOWN_NAME, ref tp.Luid))
            {
                throw new Exception("Lookup Privilege Value fail");
            }

            if (!AdjustTokenPrivileges(htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero))
            {
                throw new Exception("Adjust Token Privileges fail");
            }

            //Exit windows
            if (!ExitWindowsEx(flg, 0))
            {
                throw new Exception("Exit Windows fail");
            }
        }

        /// <summary>
        /// Reboot computer
        /// </summary>
        /// <param name="force">force reboot</param>
        public static void Reboot(bool force)
        {
            if (force)
            {
                DoExitWin(EWX_REBOOT | EWX_FORCE);
            }
            else
            {
                DoExitWin(EWX_REBOOT | EWX_FORCEIFHUNG);
            }
        }

        /// <summary>
        /// Reboot computer force if hung
        /// </summary>
        public static void Reboot()
        {
            Reboot(false);
        }

        /// <summary>
        /// Shut down computer
        /// </summary>
        /// <param name="force">force shut down</param>
        public static void Shutdown(bool force)
        {
            if (force)
            {
                DoExitWin(EWX_SHUTDOWN | EWX_FORCE);
            }
            else
            {
                DoExitWin(EWX_SHUTDOWN | EWX_FORCEIFHUNG);
            }
        }

        /// <summary>
        /// Shut down computer force if hung
        /// </summary>
        public static void Shutdown()
        {
            Shutdown(false);
        }

        /// <summary>
        /// Log off
        /// </summary>
        /// <param name="force">force logoff</param>
        public static void Logoff(bool force)
        {
            if (force)
            {
                DoExitWin(EWX_LOGOFF | EWX_FORCE);
            }
            else
            {
                DoExitWin(EWX_LOGOFF | EWX_FORCEIFHUNG);
            }
        }

        /// <summary>
        /// logoff computer force if hung
        /// </summary>
        public static void Logoff()
        {
            Logoff(false);
        }
    }
}
