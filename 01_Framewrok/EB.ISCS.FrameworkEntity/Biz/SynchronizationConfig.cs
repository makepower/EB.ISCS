using Dapper;
using System;

namespace Maticsoft.Model
{
    /// <summary>
    ///同步配置
    /// </summary>	
    [Table("SynchronizationConfig")]
    public class SynchronizationConfig
    {

        /// <summary>
        /// 主键
        /// </summary>		
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>		
        public int UserId { get; set; }
        /// <summary>
        /// 0 阿里  1 京东  
        /// </summary>		
        public int PlatId { get; set; }
        /// <summary>
        /// 店铺的id  多个之间用逗号隔开
        /// </summary>		
        public string StoreIds { get; set; }
        /// <summary>
        /// 同步周期
        /// </summary>		
        public int SyncPeriod { get; set; }
        /// <summary>
        /// 同步时间单位
        /// </summary>		
        public string SyncUnit { get; set; }
        /// <summary>
        /// 编辑时间
        /// </summary>		
        public DateTime EditDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>		
        public string Remark { get; set; }
    }
}