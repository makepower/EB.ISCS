using System;
using Dapper;

namespace EB.ISCS.FrameworkEntity.SystemEntity
{
    [Table("SysUserPermission")]
    public partial class SysUserPermission
    {
        public int Id { get; set; }

        public int? MenuActionId { get; set; }

        public int? MenuId { get; set; }

        public int? UserId { get; set; }

        public int? InUser { get; set; }

        public DateTime? InDate { get; set; }
    }
}
