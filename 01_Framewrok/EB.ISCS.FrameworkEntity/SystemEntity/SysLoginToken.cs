using System;
using Dapper;

namespace EB.ISCS.FrameworkEntity.SystemEntity
{
    [Table("SysLoginToken")]
    public partial class SysLoginToken
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? CustomerId { get; set; }

        public string Token { get; set; }

        public int? CustomerUser { get; set; }

        public int? AccessChannelId { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? ExpriedTime { get; set; }

        public DateTime? InDate { get; set; }
    }
}
