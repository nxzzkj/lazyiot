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
 * 文件名称: ULimitedQueue.cs
 * 文件说明: 定长队列类
 * 当前版本: V2.2
 * 创建日期: 2020-01-01
 *
 * 2020-01-01: V2.2.0 增加文件说明
******************************************************************************/

using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Sunny.UI
{
    /// <summary>
    /// 表示固定长度的对象的先进先出集合。
    /// </summary>
    /// <typeparam name="T">指定队列中元素的类型。</typeparam>
    public class LimitedQueue<T> : Queue<T>
    {
        /// <summary>
        /// 队列长度
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// 定长队列
        /// </summary>
        /// <param name="limit"></param>
        public LimitedQueue(int limit) : base(limit)
        {
            Limit = limit;
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="item"></param>
        public new void Enqueue(T item)
        {
            if (Count >= Limit)
            {
                Dequeue();
            }

            base.Enqueue(item);
        }
    }

    /// <summary>
    /// 表示固定长度的线程安全的先进先出 (FIFO) 集合。
    /// </summary>
    /// <typeparam name="T">队列中包含的元素的类型。</typeparam>
    public class ConcurrentLimitedQueue<T> : ConcurrentQueue<T>
    {
        /// <summary>
        /// 长度
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// 定长队列
        /// </summary>
        /// <param name="limit"></param>
        public ConcurrentLimitedQueue(int limit)
        {
            Limit = limit;
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="item"></param>
        public new void Enqueue(T item)
        {
            if (Count >= Limit)
            {
                TryDequeue(out var _);
            }

            base.Enqueue(item);
        }
    }
}