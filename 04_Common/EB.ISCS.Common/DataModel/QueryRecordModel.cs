namespace EB.ISCS.Common.DataModel
{
    /// <summary>
    /// 请求记录模型
    /// </summary>
    public class QueryRecordModel
    {
        /// <summary>
        /// 用户
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 店铺
        /// </summary>
        public int ShipId { get; set; }
        /// <summary>
        /// 指标
        /// </summary>
        public int IndicatorId { get; set; }
        /// <summary>
        /// 追踪序列号
        /// </summary>
        public int SeriesNum { get; set; }
    }
}
