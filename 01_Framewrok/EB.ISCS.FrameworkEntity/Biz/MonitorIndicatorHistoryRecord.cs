using Dapper;
using System;
using EB.ISCS.FrameworkHelp.Utilities;

namespace Maticsoft.Model
{
    /// <summary>
    ///首页监控历史记录
    /// </summary>	
    [Table("MonitorIndicatorHistoryRecord")]
    public class MonitorIndicatorHistoryRecord
    {

        /// <summary>
        /// Id
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
        public int ShipInfoId { get; set; }

        /// <summary>
        /// 同步序列号 递增
        /// </summary>
        public int SyncSerialNumber { get; set; }
        /// <summary>
        /// 统计时间 或同步时间
        /// </summary>		
        public DateTime StatisDate { get; set; }
        /// <summary>
        /// 是否是统计记录 首页展示的是统计记录
        /// </summary>
        public bool IsStatisRecord { get; set; } = false;

        /// <summary>
        /// 指标Id 
        /// </summary>
        public string IndicatorId { get; set; }
        /// <summary>
        /// value
        /// </summary>		
        public decimal Value { get; set; }
        /// <summary>
        /// 业务产生时间
        /// </summary>		
        public DateTime BizDate { get; set; }

        /// <summary>
        /// 环比指数
        /// </summary>		
        public decimal MoM { get; set; }
        /// <summary>
        /// 同比指数
        /// </summary>		
        public decimal YoY { get; set; }

        /// <summary>
        /// 排序
        /// </summary>		
        public int Sort { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }
    
    }
}