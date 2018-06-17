using Dapper;
using System;

namespace Maticsoft.Model
{
    /// <summary>
    ///首页监控指标信息 ：实体类
    ///存放天粒度的运营数据 如 销售额,流量,订单数，成交额，成交件数等单目指标
    /// </summary>	
    [Table("MonitorIndicator")]
    public class MonitorIndicator
    {

        /// <summary>
        /// 指标 ID
        /// </summary>		
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 指标名称 如 流量
        /// </summary>		
        public string Name { get; set; }

        /// <summary>
        /// 指标英文名称 如 Flow
        /// </summary>	
        public string EnName { get; set; }
        /// <summary>
        /// 指标缩写 如：F
        /// </summary>		
        public string ShortName { get; set; }
        /// <summary>
        /// 指标值 如：600
        /// </summary>		
        public decimal Value { get; set; }
        /// <summary>
        /// 统计时间 如：2018-06-08
        /// </summary>		
        public DateTime StatisDate { get; set; }

        /// <summary>
        /// 指标分组 备用 
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 统计业务大类 0 运营指标  2 业务指标
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
        /// 单位
        /// </summary>		
        public string Unit { get; set; }
        /// <summary>
        /// 备注
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