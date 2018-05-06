using Dapper;
using System;

namespace Maticsoft.Model
{
    /// <summary>
    ///首页监控指标信息 ：实体类
    /// </summary>	
    [Table("MonitorIndicator")]
    public class MonitorIndicator
    {

        /// <summary>
        /// Id
        /// </summary>		
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>		
        public string Name { get; set; }

        /// <summary>
        /// 英文指标
        /// </summary>	
        public string EnName { get; set; }
        /// <summary>
        /// 指标
        /// </summary>		
        public string ShortName { get; set; }
        /// <summary>
        /// value
        /// </summary>		
        public decimal Value { get; set; }
        /// <summary>
        /// StatisDate
        /// </summary>		
        public DateTime StatisDate { get; set; }

        /// <summary>
        /// 指标分组
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 统计业务大类
        /// </summary>
        public int StatisGroupType { get; set; }

        /// <summary>
        /// 环比指数
        /// </summary>		
        public decimal MoM { get; set; }
        /// <summary>
        /// 同比指数
        /// </summary>		
        public decimal YoY { get; set; }
        /// <summary>
        /// Unit
        /// </summary>		
        public string Unit { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }

        /// <summary>
        /// 店铺id
        /// </summary>
        public int ShipInfoId { get; set; }

        /// <summary>
        /// 同步序列号 递增
        /// </summary>
        public int  SyncSerialNumber { get; set; }

    }
}