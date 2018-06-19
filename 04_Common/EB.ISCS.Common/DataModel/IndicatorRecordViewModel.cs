using System;
using Maticsoft.Model;

namespace EB.ISCS.Common.DataModel
{
    /// <summary>
    /// 指标记录视图模型
    /// </summary>
    public class IndicatorRecordViewModel
    {
        /// <summary>
        /// 指标定义
        /// </summary>
        public MonitorIndicator Define { get; set; }
        /// <summary>
        /// 指标对应的记录
        /// </summary>
        public MonitorIndicatorRecord[] Records { get; set; }
    }
}