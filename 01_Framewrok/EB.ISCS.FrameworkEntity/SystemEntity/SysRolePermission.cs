using System;
using System.Collections.Generic;
using Dapper;

namespace EB.ISCS.FrameworkEntity.SystemEntity
{
    [Table("SysRolePermission")]
    public partial class SysRolePermission
    {
        public int Id { get; set; }

        public int? RoleId { get; set; }

        public int? MenuActionId { get; set; }

        public int? MenuId { get; set; }

        public int? BizType { get; set; }

        public int? CheckBoxState { get; set; }

        public int? Enabled { get; set; }

        public int? InUser { get; set; }

        public DateTime? InDate { get; set; }
    }
}
