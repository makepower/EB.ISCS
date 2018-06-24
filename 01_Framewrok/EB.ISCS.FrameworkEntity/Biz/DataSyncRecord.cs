using Dapper;
using System;

namespace EB.ISCS.FrameworkEntity
{
    /// <summary>
    /// 数据同步记录
    /// </summary>
    [Table("DataSyncRecord")]
    public class DataSyncRecord
    {
        /// <summary>
        /// 自增
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 店铺id
        /// </summary>
        public int ShopId { get; set; }
        /// <summary>
        /// 最新同步序列号
        /// </summary>
        public int LastSynSeriesNum { get; set; }
        /// <summary>
        /// 最新同步时间
        /// </summary>
        public DateTime LastSynDate { get; set; }
        /// <summary>
        /// 状态  0 失败 1 成功
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
