

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
using System.Threading;
using System.Threading.Tasks;

namespace ScadaCenterServer.Core
{
    /// <summary>
    /// 实时数据接收的缓存,数据中心接收到的数据全部保存到该缓存中，该缓存每200秒会自动向influxdb插入一条数据
    /// </summary>
    public class ReceiveRealCache : IDisposable
    {
        public Func<List<ReceiveCacheObject>, Task> InsertInfluxdb;
        public Func<List<AlarmCacheObject>, Task> InsertAlarmInfluxdb;
 
        public int TimeInterval = 200;//默认毫秒
        public int MaxInsertNumber = 3000;
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
            for (int i = 0; i < MaxInsertNumber; i++)
            {
                ReceiveCacheObject result = null;
                if (ReceiveCache.TryPop(out result))
                {

                    cacheObjects.Add(result);
                }
                else//如果没有则终止
                {
                    break;
                }

            }
            return cacheObjects;
        }
        private List<AlarmCacheObject> PopAlarm()
        {
            List<AlarmCacheObject> cacheObjects = new List<AlarmCacheObject>();
            for (int i = 0; i < MaxInsertNumber; i++)
            {
                AlarmCacheObject result = null;
                if (AlarmCache.TryPop(out result))
                {

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
        public ReceiveRealCache()
        {
            ReceiveCache = new ConcurrentStack<ReceiveCacheObject>();
            AlarmCache = new ConcurrentStack<AlarmCacheObject>();
    
        }
        public void Read()
        {
            _timer = new Timer(delegate
            {
                //执行

                List<ReceiveCacheObject> receiveCaches = Pop();
                if (InsertInfluxdb != null && receiveCaches.Count > 0)
                {
                    InsertInfluxdb(receiveCaches);
                }

                List<AlarmCacheObject> alarmCaches = PopAlarm();
                if (InsertAlarmInfluxdb != null && alarmCaches.Count > 0)
                {
                    InsertAlarmInfluxdb(alarmCaches);
                }

               
            }, null, 10000, TimeInterval);
        }
    }
    public class ReceiveCacheObject
    {
        public DateTime? RealDate { set; get; }

        public IO_SERVER server = null;
        public IO_COMMUNICATION communication = null;
        public IO_DEVICE device = null;

    }
    public class AlarmCacheObject
    {
        public DateTime? RealDate { set; get; }

        public IO_SERVER server = null;
        public IO_COMMUNICATION communication = null;
        public IO_DEVICE device = null;
        public IO_PARAALARM Alarm = null;

    }
   
}
