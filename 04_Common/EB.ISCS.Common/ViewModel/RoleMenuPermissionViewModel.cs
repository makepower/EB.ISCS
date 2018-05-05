using System.Collections.Generic;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.Common.ViewModel
{
    public class RoleMenuPermissionViewModel
    {
        public RoleMenuPermissionViewModel()
        {
            RoleMenuViewModel = new List<SysRoleMenu>();
            RolePermissionViewModel = new List<SysRolePermission>();
        }
        public List<SysRoleMenu> RoleMenuViewModel { get; set; }
        public List<SysRolePermission> RolePermissionViewModel { get; set; }
    }
}
