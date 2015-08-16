using System;
using System.Runtime.Serialization;

namespace EdnaUtility.Data
{

    /// <summary>
    ///     测点基础属性信息
    /// </summary>
    [Serializable]
    [DataContract]
    public class PointModel
    {
        /// <summary>
        ///     获取或设置测点ID
        /// </summary>
        /// <returns>根据不同数据库特性，返回值类型为整数或字符串。</returns>
        [DataMember(Order = 0)]
        public dynamic ID { get; set; }
         
        /// <summary>
        ///     获取或设置测点名称
        /// </summary>
        [DataMember(Order = 1)]
        public string Name { get; set; }

        /// <summary>
        ///     测点数据类型 AI(65)|DI(68)
        /// </summary>
        [DataMember(Order = 2)]
        public string PointType { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

    /// <summary>
    ///     测点详细属性信息
    /// </summary>
    [Serializable]
    [DataContract]
    public class PointDetails : PointModel
    {
        /// <summary>
        ///     测点描述
        /// </summary>
        [DataMember(Order = 7)]
        public string Descriptor { get; set; }

        /// <summary>
        ///     数据单位
        /// </summary>
        [DataMember(Order = 3)]
        public string Unit { get; set; }

        /// <summary>
        ///     数据显示精度
        /// </summary>
        [DataMember(Order = 4)]
        public string Format { get; set; }

        /// <summary>
        ///     数据配置最大值
        /// </summary>
        [DataMember(Order = 6)]
        public double Maximum { get; set; }

        /// <summary>
        ///     数据配置最小值
        /// </summary>
        [DataMember(Order = 5)]
        public double Minimum { get; set; }

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        ///     A string that represents the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return string.Format("[{0}] [{1}] [{2}] [{3}]", ID ?? "--ID--", Name ?? "--TAG--", Unit ?? "--UNIT--", Descriptor ?? "--DESC--");
        }
    }
}