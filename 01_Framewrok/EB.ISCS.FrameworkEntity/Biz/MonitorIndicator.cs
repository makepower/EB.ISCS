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
        /// 指标编码 如 Flow
        /// </summary>	
        public string Code { get; set; }
        /// <summary>
        /// 指标缩写 如：F
        /// </summary>		
        public string ShortName { get; set; }
        /// <summary>
        /// 指标分组 备用 
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 统计类型  eg：年-月-日-时-分-秒
        /// </summary>
        public int StatisticalType { get; set; }

        /// <summary>
        /// 业务类型   eg：EB.ISCS.Common.Enum.StatisGroupType
        /// </summary>
        public int BizType { get; set; }

        /// <summary>
        /// 单位
        /// </summary>		
        public string Unit { get; set; }

        /// <summary>
        /// 统计间隔
        /// </summary>		
        public int Interval { get; set; }
        /// <summary>
        /// 统计数目
        /// </summary>		
        public int KeepNum { get; set; }

        /// <summary>
        /// 备注
        /// </summary>		
        public string Remark { get; set; }
    }
}