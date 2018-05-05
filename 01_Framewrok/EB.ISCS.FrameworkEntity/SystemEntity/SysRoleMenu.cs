using System;
using Dapper;

namespace EB.ISCS.FrameworkEntity.SystemEntity
{
    [Table("SysRoleMenu")]
    public partial class SysRoleMenu
    {
        public int Id { get; set; }

        public int? RoleId { get; set; }

        public int? MenuId { get; set; }

        public int? BizType { get; set; }

        public int? CheckBoxState { get; set; }

        public int? Enabled { get; set; }

        public int? InUser { get; set; }

        public DateTime? InDate { get; set; }
    }
}
