using Dapper;
using System;

namespace Maticsoft.Model
{
    /// <summary>
    ///首页监控指标信息 ：实体类
    /// </summary>	
    [Table("GoodMonitorTopN")]
    public class GoodMonitorTopN
    {

        /// <summary>
        /// Id
        /// </summary>		
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 指标名称
        /// </summary>		
        public string Name { get; set; }
        /// <summary>
        /// 短名称
        /// </summary>		
        public string ShortName { get; set; }
        /// <summary>
        /// value
        /// </summary>		
        public decimal Value { get; set; }
        /// <summary>
        /// Unit
        /// </summary>		
        public string Unit { get; set; }
        /// <summary>
        /// 统计时间 或同步时间
        /// </summary>		
        public DateTime StatisDate { get; set; }
        /// <summary>
        /// 参考 静态指标 类目枚举
        /// </summary>		
        public string StatisType { get; set; }
        /// <summary>
        /// 0: 最近1天 1 最近7天  2: 最近30天 3: 最近90天
        /// see  EB.ISCS.Common.Enum.StatisPeriodType
        /// </summary>		
        public int StatisPeriodType { get; set; }
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
        public int SyncSerialNumber { get; set; }

    }
}