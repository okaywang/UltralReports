using System;
using System.Runtime.Serialization;

namespace EdnaUtility.Data
{
    /// <summary>
    ///     测点数据信息
    /// </summary>
    [Serializable]
    [DataContract]
    public class RecordData
    {
        /// <summary>
        ///     创建一个测点数据实例
        /// </summary>
        public RecordData()
        {
            Value = double.NaN;
        }

        /// <summary>
        ///     获取或设置所属测点
        /// </summary>
        [IgnoreDataMember]
        public PointModel Point { get; set; }

        /// <summary>
        ///     获取或设置测点数值
        /// </summary>
        [DataMember]
        public double Value { get; set; }

        /// <summary>
        ///     获取或设置数据时刻
        /// </summary>
        [DataMember]
        public DateTime Time { get; set; }

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        ///     A string that represents the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return string.Format("[{0:yyyy-MM-dd HH:mm:ss}] [{1}] [{2}]", Time, Value, Point.Name);
        }
    }

    /// <summary>
    ///     X-Y 测点对比
    /// </summary>
    [Serializable]
    [DataContract]
    public class PointDataPair
    {
        /// <summary>
        ///     Time
        /// </summary>
        [DataMember]
        public DateTime Time { get; set; }

        /// <summary>
        ///     PointX
        /// </summary>
        [IgnoreDataMember]
        public PointModel PointX { get; set; }

        /// <summary>
        ///     PointY
        /// </summary>
        [IgnoreDataMember]
        public PointModel PointY { get; set; }

        /// <summary>
        ///     XValue
        /// </summary>
        [DataMember]
        public double XValue { get; set; }

        /// <summary>
        ///     YValue
        /// </summary>
        [DataMember]
        public double YValue { get; set; }
    }

    /// <summary>
    ///     回写测点数据结构，当回写实时值时不对 Time 进行赋值
    /// </summary>
    [Serializable]
    public class WriteablePointData : RecordData
    {
        /// <summary>
        ///     获取数据回写状态信息描述
        /// </summary>
        public string Status { get; internal set; }

        /// <summary>
        ///     获取一个bool值，表明数据是否写入成功
        /// </summary>
        public bool Successed { get; internal set; }
    }
}