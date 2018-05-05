using System;
using System.Collections.Generic;
using Dapper;

namespace EB.ISCS.FrameworkEntity.SystemEntity
{
    
    public partial class SysUserRole
    {
        public int Id { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> BizType { get; set; }
        public int Enabled { get; set; }
        public Nullable<int> InUser { get; set; }
        public Nullable<System.DateTime> InDate { get; set; }
        public Nullable<int> CheckBoxState { get; set; }


        #region 扩展属性

        /// <summary>
        /// 用户编号数组
        /// </summary>
        [NotMapped]
        public string UserIds { get; set; }

        /// <summary>
        /// 角色编号数组
        /// </summary>
        [NotMapped]
        public string RoleIds { get; set; }
        #endregion
    }

    public class UserRoles
    {
        public UserRoles()
        {
            Roles = new List<SysRole>();
        }
        public SysUser User { get; set; }
        public List<SysRole> Roles { get; set; }
    }
}
