namespace EdnaUtility.Data
{
    /// <summary>
    ///     边界取值方式
    /// </summary>
    public enum BoundaryType
    {
        /// <summary>
        ///     自动计算方式，优先使用原始数据，其次插值方式
        /// </summary>
        Auto = 0,

        /// <summary>
        ///     向前取值，仅使用原始数据
        /// </summary>
        Before = 2
    }
}