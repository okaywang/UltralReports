using System;
using System.Collections.Generic;
using System.Linq;
using EdnaUtility.Data;

namespace EdnaUtility.Drivers
{

    #region SupportedDrivers
    
    /// <summary>
    ///     所支持的数据库驱动类型
    ///     © 1985-2015 matteo swift
    /// </summary>
    public enum SupportedDrivers
    {
        /// <summary>
        ///     eDNA
        /// </summary>
        eDNA = 5,

        /// <summary>
        ///     PI (PIAPI 1.6.8.12)
        /// </summary>
        [Obsolete("建议使用PIAPI代替")]
        PI = 3,

        /// <summary>
        ///     PIAPI 1.6.8.12
        /// </summary>
        PIAPI = 3,

        /// <summary>
        ///     PISDK 1.4.4.484
        /// </summary>
        PISDK = 9,

        /// <summary>
        ///     openPlant1
        /// </summary>
        openPlant1 = 12,

        /// <summary>
        ///     openPlant
        /// </summary>
        [Obsolete("建议使用openPlant2代替")]
        openPlant = 13,

        /// <summary>
        ///     openPlant2
        /// </summary>
        openPlant2 = 13
    }

    #endregion
  
    /// <summary>
    ///     实时历史数据库访问类
    ///     © 1985-2015 matteo swift
    /// </summary>
    /// <remarks>
    ///     版本： 6.14.03.16
    /// </remarks>
    [Serializable]
    public abstract class RealtimeClient 
    {
        #region property

        /// <summary>
        ///     获取数据库连接字符串
        /// </summary>
        public string ConnectionString { get; protected set; }

        /// <summary>
        ///     获取数据库驱动信息
        /// </summary>
        public string DriverInfo { get; protected set; }

        #endregion
         
        #region abstract
         
        /// <summary>
        ///     单个测点名称转为ID
        /// </summary>
        /// <param name="tag">测点名称</param>
        /// <returns></returns>
        public abstract dynamic GetID(string tag);

        /// <summary>
        ///     获取单测点信息
        /// </summary>
        /// <param name="tag">测点名</param>
        public abstract PointDetails GetPoint(string tag);
         

        /// <summary>
        ///     读取单测点快照数据
        /// </summary>
        /// <param name="point">测点</param>
        public abstract RecordData Snap(PointModel point);

        /// <summary>
        ///     读取测点统计数据
        /// </summary>
        /// <param name="point">测点</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="statisType">统计数据计算类型</param>
        public abstract RecordData Statis(PointModel point, DateTime startTime, DateTime endTime, StatisType statisType);

        /// <summary>
        ///     读取单测点原始数据
        /// </summary>
        /// <param name="point">测点</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        public abstract List<RecordData> Raw(PointModel point, DateTime startTime, DateTime endTime);
 
        /// <summary>
        ///     读取单测点指定时刻历史数据
        /// </summary>
        /// <param name="point">测点</param>
        /// <param name="time">时刻</param>
        /// <param name="boundaryType">数据取值方式</param>
        public abstract RecordData Hist(PointModel point, DateTime time, BoundaryType boundaryType = BoundaryType.Auto);

 
        #endregion

        #region virtual



        /// <summary>
        ///     多测点名称转为ID
        /// </summary>
        /// <param name="tags">测点名称集合</param>
        public virtual List<dynamic> GetID(List<string> tags)
        {
            var ret = tags.Select(GetID).ToList();
            return ret;
        }

        /// <summary>
        ///     获取多测点信息
        /// </summary>
        /// <param name="tags">测点集合</param>
        public virtual List<PointDetails> GetPoint(List<string> tags)
        {
            return tags.Select(this.GetPoint).ToList();
        }

        /// <summary>
        ///     读取多测点快照数据
        /// </summary>
        /// <param name="points">测点集合</param>
        public virtual List<RecordData> Snap(List<PointModel> points)
        {
            return points.Select(this.Snap).ToList();
        }

        /// <summary>
        ///     读取多测点原始数据
        /// </summary>
        /// <param name="points">测点集合</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        public virtual List<List<RecordData>> Raw(List<PointModel> points, DateTime startTime, DateTime endTime)
        {
            var result = new List<List<RecordData>>();

            foreach (var point in points)
            {
                try
                {
                    result.Add(this.Raw(point, startTime, endTime));
                }
                catch (Exception)
                {
                    result.Add(new List<RecordData>());
                }
            }
            return result;
        }

        

        /// <summary>
        ///     读取单测点历史数据
        /// </summary>
        /// <param name="point">测点</param>
        /// <param name="times">历史时刻集合</param>
        /// <param name="boundaryType">数据取值方式</param>
        public virtual List<RecordData> Hist(PointModel point, List<DateTime> times, BoundaryType boundaryType = BoundaryType.Auto)
        {
            return times.Select(x => this.Hist(point, x, boundaryType)).ToList();
        }

        /// <summary>
        ///     读取单测点历史数据
        /// </summary>
        /// <param name="point">测点</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="interval">采样间隔</param>
        /// <param name="boundaryType">数据取值方式</param>
        public virtual List<RecordData> Hist(PointModel point, DateTime startTime, DateTime endTime, TimeSpan interval, BoundaryType boundaryType = BoundaryType.Auto)
        {
            var result = new List<RecordData>();
            var time = startTime;
            do
            {
                result.Add(this.Hist(point, time, boundaryType));
                time = time.Add(interval);
            } while (time <= endTime);
            return result;
        }

        /// <summary>
        ///     读取多测点历史数据
        /// </summary>
        /// <param name="points">测点集合</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="interval">采样间隔</param>
        /// <param name="boundaryType">数据取值方式</param>
        public virtual List<List<RecordData>> Hist(List<PointModel> points, DateTime startTime, DateTime endTime, TimeSpan interval, BoundaryType boundaryType = BoundaryType.Auto)
        {
            var result = new List<List<RecordData>>();

            foreach (var point in points)
            {
                var source = new List<RecordData>();
                try
                {
                    source.AddRange(this.Hist(point, startTime, endTime, interval, boundaryType));
                }
                catch (Exception ex)
                {
                    var count = (int)Math.Floor((endTime - startTime).TotalSeconds / interval.TotalSeconds);
                    source.AddRange(Enumerable.Range(0, count).Select(x => new RecordData { Point = point, Time = startTime.Add(interval), Value = double.NaN }));
                }
                result.Add(source);
            }
            return result;
        }

        /// <summary>
        ///     读取多测点指定时刻历史数据
        /// </summary>
        /// <param name="points">测点集合</param>
        /// <param name="time">时刻</param>
        /// <param name="boundaryType">数据取值方式</param>
        /// <returns>返回测点集中的每个测点指定时刻的历史数据</returns>
        public virtual List<RecordData> Hist(List<PointModel> points, DateTime time, BoundaryType boundaryType = BoundaryType.Auto)
        {
            var result = new List<RecordData>();
            foreach (var point in points)
            {
                try
                {
                    result.Add(this.Hist(point, time, boundaryType));
                }
                catch (Exception ex)
                {
                    result.Add(new RecordData { Point = point, Time = time, Value = double.NaN });
                }
            }
            return result;
        }
         
         
 
        #endregion
 
        #region static
         
        
        /// <summary>
        ///     计算时间集合
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="interval"></param>
        /// <param name="forceEndTime"></param>
        /// <returns></returns>
        public static List<DateTime> CalculateTimes(DateTime startTime, DateTime endTime, TimeSpan interval, bool forceEndTime = false)
        {
            var span = endTime - startTime;
            var count = (int)(span.TotalSeconds / interval.TotalSeconds) + 1;
            var times = Enumerable.Range(0, count).Select((x, i) => startTime.AddSeconds(interval.TotalSeconds * i)).ToList();
            if (times[times.Count - 1] > endTime)
            {
                times.RemoveAt(times.Count - 1);
            }

            if (forceEndTime && times[times.Count - 1] < endTime)
            {
                times.Add(endTime);
            }

            return times;
        }
       
        #endregion
         
    }
}