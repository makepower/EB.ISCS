using System;
using Dapper;

namespace EB.ISCS.FrameworkEntity.SystemEntity
{
    [Table("SysUserMenu")]
    public partial class SysUserMenu
    {
        public int Id { get; set; }

        public int? MenuId { get; set; }

        public int? UserId { get; set; }

        public int? InUser { get; set; }

        public DateTime? InDate { get; set; }
    }
}
