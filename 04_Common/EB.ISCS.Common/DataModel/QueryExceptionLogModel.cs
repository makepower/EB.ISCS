using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.ISCS.Common.DataModel
{
    /// <summary>
    /// 异常日志查询条件
    /// </summary>
    public class QueryExceptionLogModel : SearchCondition
    {
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? BeginDate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 渠道
        /// </summary>
        public int? AccessChannelId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 操作内容
        /// </summary>
        public string Exception { get; set; }
        /// <summary>
        /// 操作Action
        /// </summary>
        public string MenuActionName { get; set; }
        /// <summary>
        /// 删除状态
        /// </summary>
        public int? DeleteState { get; set; }

    }
}
