

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 宁夏众智科技有限公司 版权所有。 
// 开源版本代码仅限个人技术研究使用，未经作者允许严禁商用。宁夏众智科技有限公司是一家油田自动化行业经营多年的软件开发公司，公司承接OA、工控、组态、微信小程序等开发。
// 对于本系统的相关版权归属宁夏众智科技所有，如果本系统使用第三方开源模块，该模块版权归属原作者所有。
// 请大家尊重作者的劳动成果，共同促进行业健康发展。
// 相关技术交流群89226196 ,作者QQ:249250126 作者微信18695221159 邮箱:my820403@126.com
// 创建者：马勇
//----------------------------------------------------------------*/
#endregion
using Scada.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IOMonitor.Core
{
    /// <summary>
    /// 实时数据接收的缓存,数据中心接收到的数据全部保存到该缓存中，该缓存每200秒会自动向influxdb插入一条数据,通过这种方式可以有效提高系统的通讯效率
    /// </summary>
    public class ReceiveRealCache : IDisposable
    {
      
        public ReceiveRealCache(int Interval, int maxNumber)
        {
            ReceiveCache = new ConcurrentStack<ReceiveCacheObject>();
            AlarmCache = new ConcurrentStack<AlarmCacheObject>();
      
            TimeInterval = Interval;
            MaxReadNumber = maxNumber;
        }
        /// <summary>
        /// 准备要上传的实时数据
        /// </summary>
        public Func<List<ReceiveCacheObject>, Task> WillUpload;
        /// <summary>
        /// 准备要上传的报警数据
        /// </summary>
        public Func<List<AlarmCacheObject>, Task> WillUploadAlarm;
     

        public int TimeInterval = 100;//默认毫秒
        public int MaxReadNumber = 3000;//每次定时读取的最大数据量
        /// <summary>
        /// 接收数据缓存,采用线程安全的堆栈
        /// </summary>
        public static ConcurrentStack<ReceiveCacheObject> ReceiveCache;
        public static ConcurrentStack<AlarmCacheObject> AlarmCache;
 
        public void Push(ReceiveCacheObject cacheObject)
        {
            ReceiveCache.Push(cacheObject);
        }
        public void Push(AlarmCacheObject cacheObject)
        {
            AlarmCache.Push(cacheObject);
        }
    
        private Timer _timer = null;
        /// <summary>
        /// 删除过期的数据
        /// </summary>
        private List<ReceiveCacheObject> Pop()
        {
            List<ReceiveCacheObject> cacheObjects = new List<ReceiveCacheObject>();
            for (int i = 0; i < MaxReadNumber; i++)
            {
                ReceiveCacheObject result = null;
                if (ReceiveCache.TryPop(out result))
                {
                    if (!string.IsNullOrEmpty(result.DataString))
                        cacheObjects.Add(result);
                }
                else//如果没有则终止
                {
                    break;
                }

            }
            return cacheObjects;
        }
        private List<AlarmCacheObject> PopAlarms()
        {
            List<AlarmCacheObject> cacheObjects = new List<AlarmCacheObject>();
            for (int i = 0; i < MaxReadNumber; i++)
            {
                AlarmCacheObject result = null;
                if (AlarmCache.TryPop(out result))
                {
                    if (!string.IsNullOrEmpty(result.DataString))
                        cacheObjects.Add(result);
                }
                else//如果没有则终止
                {
                    break;
                }

            }
            return cacheObjects;
        }

      
        public void Dispose()
        {
            if (_timer != null)
            {
                _timer.Dispose();
                _timer = null;
            }
            ReceiveCache.Clear();
            ReceiveCache = null;
            AlarmCache.Clear();
            AlarmCache = null;
           


        }
       
        public void Read()
        {
            _timer = new Timer(delegate
            {
                //执行
                try
                {
                   
                    List<ReceiveCacheObject> receiveCaches = Pop();
                    if (WillUpload != null && receiveCaches.Count > 0)
                        WillUpload(receiveCaches);
                    
                }
                catch
                {

                }
                try
                {
                   
                        List<AlarmCacheObject> alarmCaches = PopAlarms();
                        
                            if (WillUploadAlarm != null && alarmCaches.Count > 0)
                                WillUploadAlarm(alarmCaches);
  
                }
                catch
                {

                }
                
            }, null, 10000, TimeInterval);
        }
    }
    public class ReceiveCacheObject:IDisposable
    {

     public   string DataString = "";

        public void Dispose()
        {
            DataString = "";
        }
    }
 
    public class AlarmCacheObject: IDisposable
    {

        public string DataString = "";
        public IO_PARAALARM Alarm = null;

        public void Dispose()
        {
            DataString = null;
               Alarm = null;
        }
    }
    
}
