using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Text;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Documents;
using System.Windows;
using System.Net.NetworkInformation;

namespace Scada.DBUtility
{
 
 
    //当前应用程序进程信息
    public class ProcessInfo
    {
        //  int string TimeSpan long stirng 

        public int Id = 0;
        public string ProcessName = "";
        public double TotalMilliseconds = 0;
        public int ThreadsCount = 0;//获取当前进程的总线程数 获取进程中运行的线程，也就是与当前进程关联的所有线程，主线程不一定是索引0的线程.返回类型为ProcessThread集合类型。
        public double TotalProcessorTime = 0; //获取进程的总的处理器时间，也就是CPU总耗时，是UserProcessorTime和PrivilegedProcessorTime时间之和，并非是程序允许总时间
        public string StartTime = "";//程序开始运行时间
        public string MainModuleFileName = "";//进程名称
        private float mCpuRate = 0;
        public float CpuRate
        {
            get { return mCpuRate; }
        }




        public long VirtualMemory64 = 0;//虚拟内存使用量
        public long WorkingSet64 = 0;//物理内存量
  
        public ProcessInfo(int id, string pname, double totalmilliseconds, string mainModuleFileName, long virtualMemory64, long workingSet64, double totalProcessorTime, string startTime,int threadsCount, PerformanceCounter pcCpuLoad)
        {
            Id = id;
            ProcessName = pname;
            TotalMilliseconds = totalmilliseconds;

            MainModuleFileName = mainModuleFileName;
            WorkingSet64 = workingSet64;
            VirtualMemory64 = virtualMemory64;
            ThreadsCount = threadsCount;
            TotalProcessorTime = totalProcessorTime;
            StartTime = startTime;
            if(pcCpuLoad != null)
            mCpuRate = pcCpuLoad.NextValue();
        }
    }

   
  public   class ComputerInfo
    {
        private int m_ProcessorCount = 0;   //CPU个数 
        private PerformanceCounter pcCpuLoad;   //CPU计数器 
        private PerformanceCounter processCpuLoad;   //CPU计数器 
        private long m_PhysicalMemory = 0;   //物理内存 
        private string mServer_ID = "";
        public string ServerID
        {
            get { return mServer_ID; }
        }
        
        private string mac = "";//网卡地址
        private string m_computerName = "";
        private string ip = "";//本机ip地址
        private const int GW_HWNDFIRST = 0;
        private const int GW_HWNDNEXT = 2;
        private const int GWL_STYLE = (-16);
        private const int WS_VISIBLE = 268435456;
        private const int WS_BORDER = 8388608;

        #region AIP声明 
        [DllImport("IpHlpApi.dll")]
        extern static public uint GetIfTable(byte[] pIfTable, ref uint pdwSize, bool bOrder);

        [DllImport("User32")]
        private extern static int GetWindow(int hWnd, int wCmd);

        [DllImport("User32")]
        private extern static int GetWindowLongA(int hWnd, int wIndx);

        [DllImport("user32.dll")]
        private static extern bool GetWindowText(int hWnd, StringBuilder title, int maxBufSize);

        [DllImport("user32", CharSet = CharSet.Auto)]
        private extern static int GetWindowTextLength(IntPtr hWnd);
        #endregion
        private static ComputerInfo mComputerInfo = null;
        public static ComputerInfo GetInstall()
        {
            if(mComputerInfo==null)
            {
                mComputerInfo = new ComputerInfo();
            }
            return mComputerInfo;
        }

        #region 构造函数 
        public   string GetMAC()
        {
            string madAddr = null;
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc2 = mc.GetInstances();
            foreach (ManagementObject mo in moc2)
            {
                if (Convert.ToBoolean(mo["IPEnabled"]) == true)
                {
                    madAddr = mo["MacAddress"].ToString();
                    madAddr = madAddr.Replace(":", "").Replace("-", "");
                }
                mo.Dispose();
            }
        
            return madAddr;
        }
        ///  
        /// 构造函数，初始化计数器等 
        ///  
        public ComputerInfo()
        {
            //初始化CPU计数器 
            pcCpuLoad = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            pcCpuLoad.MachineName = ".";
            pcCpuLoad.NextValue();

            //CPU个数 
            m_ProcessorCount = Environment.ProcessorCount;
            //物理内存
            m_PhysicalMemory = this.get_totalphysicalmemory();
            //主板绑定
            mac = this.GetMAC();
      
            //IP地址
            ip = this.get_ip();
            m_computerName = this.get_computerName();
            mServer_ID = mac.Replace(":","");
        }
        #endregion
        //获取物理内存
        private long get_totalphysicalmemory()
        {
            long m_physicalMemory = 0;
            //获得物理内存 
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (mo["TotalPhysicalMemory"] != null)
                {
                    m_physicalMemory += long.Parse(mo["TotalPhysicalMemory"].ToString());
                }

            }
            return m_physicalMemory;
        }
    
        

        //获取本机的ip地址
        private string get_ip()
        {
            try
            {
                string st = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        //st=mo["IpAddress"].ToString(); 
                        System.Array ar;
                        ar = (System.Array)(mo.Properties["IpAddress"].Value);
                        st = ar.GetValue(0).ToString();
                        break;
                    }
                }
                moc = null;
                mc = null;
                return st;
            }
            catch
            {
                return "unknow";
            }
        }

       

        //获得电脑名称
        private string get_computerName()
        {
            try
            {
                return System.Environment.GetEnvironmentVariable("ComputerName");
            }
            catch
            {
                return "unknow";
            }
        }
 
       
         
        #region CPU个数 
        ///  
        /// 获取CPU个数 
        ///  
        public int ProcessorCount
        {
            get
            {
                return m_ProcessorCount;
            }
        }
        #endregion

        #region CPU占用率 
        ///  
        /// 获取CPU占用率 
        ///  
        public float CpuLoad
        {
            get
            {
                return pcCpuLoad.NextValue();
            }
        }
        #endregion

      

        #region 物理内存 
        ///  
        /// 获取物理内存 
        ///  
        public long PhysicalMemory
        {
            get
            {
                return m_PhysicalMemory;
            }
        }
        #endregion

       
        #region MAC地址
        ///  
        /// 获取虚拟内存 
        ///  
        public string MAC
        {
            get
            {
                return this.mac;
            }
        }
        #endregion

        #region MAC地址
        ///  
        /// 获取虚拟内存 
        ///  
        public string IP
        {
            get
            {
                return this.ip;
            }
        }
        #endregion
        /// <summary>
        /// 获取计算机名称
        /// </summary>
        public string ComputerName
        {
            get { return m_computerName; }
        }

        #region 获得进程列表 
    
        ///  
        /// 获得进程列表 
        ///  
        public List<ProcessInfo> GetProcessInfo()
        {
            List<ProcessInfo> pInfo = new List<ProcessInfo>();
            Process[] processes = Process.GetProcesses();
            foreach (Process instance in processes)
            {
                try
                {
                    if(processCpuLoad==null)
                    {
                        processCpuLoad = new PerformanceCounter("Process", "% Processor Time", instance.ProcessName);
                        processCpuLoad.NextValue();


                    }
          
                    pInfo.Add(new ProcessInfo(instance.Id,
                        instance.ProcessName,
                        instance.TotalProcessorTime.TotalMilliseconds,
                        instance.MainModule.FileName, instance.VirtualMemorySize64, instance.WorkingSet64, instance.TotalProcessorTime.Minutes, instance.StartTime.ToString("yyyy-MM-dd HH:mm:ss"), instance.Threads.Count, processCpuLoad));
                 
                }
                catch { }
            }
            return pInfo;
        }
        Process instance = null;
        ///  
        /// 获得特定进程信息 运行时间 物理内存，虚拟内存占用
        ///  
        /// 进程名称 
        public ProcessInfo GetProcessInfo(string ProcessName)
        {
            if (instance == null)
            {
                Process[] processes = Process.GetProcessesByName(ProcessName);
                if (processes.Length > 0)
                {
                    instance = processes[0];
                    if (pcCpuLoad == null)
                    {
                        pcCpuLoad = new PerformanceCounter("Process", "% Processor Time", instance.ProcessName);
                        pcCpuLoad.NextValue();
                    }


                    return new ProcessInfo(instance.Id,
                          instance.ProcessName,
                          instance.TotalProcessorTime.TotalMilliseconds,
                          instance.MainModule.FileName, instance.VirtualMemorySize64, instance.WorkingSet64, instance.TotalProcessorTime.Hours, instance.StartTime.ToString("yyyy-MM-dd HH:mm:ss"), instance.Threads.Count, pcCpuLoad);
                }
            }
            else
            {
                if (pcCpuLoad == null)
                {
                    pcCpuLoad = new PerformanceCounter("Process", "% Processor Time", instance.ProcessName);
                    pcCpuLoad.NextValue();
                }
                return new ProcessInfo(instance.Id,
                         instance.ProcessName,
                         instance.TotalProcessorTime.TotalMilliseconds,
                         instance.MainModule.FileName, instance.VirtualMemorySize64, instance.WorkingSet64, instance.TotalProcessorTime.Hours, instance.StartTime.ToString("yyyy-MM-dd HH:mm:ss"), instance.Threads.Count, pcCpuLoad);

            }

            return null;
        }


        #endregion

        /// <summary>
                /// 解析长整形的数据使其转换为macID
                /// </summary>
                /// <param name="valuetolong">长整形的数据</param>
                /// <returns>macID字符串</returns>
        private   string Int64ToMacID(long valuetolong)
        {
            //解析长整形的数据使其转换为MAC; 
            string valuetostr = valuetolong.ToString("X2");
            valuetostr = valuetostr.PadLeft(12, '0');
            List<string> listArr = new List<string>();
            for (var i = 0; i <= 11; i++)
            {
                listArr.Add(valuetostr[i].ToString());
                if (i < 11 && i % 2 == 1)
                {
                    listArr.Add("-");
                }
            }
            valuetostr = string.Join("", listArr.ToArray());
            return valuetostr;
        }

        /// <summary>
        /// 将MAC转为长整形
        /// </summary>
        /// <param name="macID">macID</param>
        /// <returns>长整形</returns>
        private   long MacIDToInt64(string macID)
        {
            long valuetolong = 0;
            string v = null;
            //将MAC转为长整形： 
            //测试：string vv = "00-26-2D-F2-5C-28".Replace("-", "");
            //string v = macID.Replace("-", "");
            if (macID.Contains("-"))
            {
                v = macID.Replace("-", "");
            }
            if (long.TryParse(v, System.Globalization.NumberStyles.HexNumber, null, out  valuetolong))
            {
               
            }
            return valuetolong;
        }

        private static String keys = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static int exponent = keys.Length;
        public static string Long2MACID(long value)
        {
            string result = string.Empty;
            do
            {
                long index = value % exponent;
                result = keys[(int)index] + result;
                value = (value - index) / exponent;
            }
            while (value > 0);
            result = result.PadLeft(12, '0');
            List<string> listArr = new List<string>();
            for (var i = 0; i <= 11; i++)
            {
                listArr.Add(result[i].ToString());
                if (i < 11 && i % 2 == 1)
                {
                    listArr.Add("-");
                }
            }
            return string.Join("", listArr.ToArray());
        }
        public static long MACID2Long(string value)
        {
            value = value.Replace("-", "");
            long result = 0;
            for (int i = 0; i < value.Length; i++)
            {
                int x = value.Length - i - 1;
                result += keys.IndexOf(value[i]) * Pow(exponent, x);
            }
            return result;
        }
        /// <summary>
        /// 一个数据的N次方
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static long Pow(long baseNo, long x)
        {
            long value = 1;
            while (x > 0)
            {
                value = value * baseNo;
                x--;
            }
            return value;
        }
 
         

    }
}
