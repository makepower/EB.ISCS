using Maticsoft.Model;
using System.Collections.Generic;

namespace EB.ISCS.ToolService.Adapter
{
    /// <summary>
    /// 用户数据同步上下文
    /// </summary>
    public class UserSyncContext
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 任务id
        /// </summary>
        public string TaskId { get; set; }
        /// <summary>
        /// 所拥有的店铺
        /// </summary>
        public List<ShipInfo> Shops { get; set; }
        /// <summary>
        /// 同步小时
        /// </summary>
        public int SyncPeriodHours { get; set; }

    }

    /// <summary>
    /// 同步上下文
    /// </summary>
    public class SyncContext
    {
        /// <summary>
        /// 上下文
        /// </summary>
        public List<UserSyncContext> Context { get; set; } = new List<UserSyncContext>();
    }
}
