using System;

namespace EB.ISCS.FrameworkEntity.Base
{
    /// <summary>
    /// 基础指标数据记录
    /// </summary>
    public class BaseIndicator
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 记录值
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// 标注信息 
        /// </summary>
        public string Tag { get; set; }
    }
}
