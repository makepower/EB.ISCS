using System.Collections.Generic;
using EB.ISCS.Common.BaseController;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.Common.ViewModel
{
    public class RolePermissionViewModel
    {
        public RolePermissionViewModel()
        {
            CurrentRoleModel = new SysRole();
            AllPermissionItems = new List<NavigationItem>();
            AssignedPermissionItems = new List<NavigationItem>();
        }

        public RolePermissionViewModel(int userId, SysRole roleModel, List<NavigationItem> allItems)
        {
            this.CurrentUserId = userId;
            this.CurrentRoleModel = roleModel;
            this.AllPermissionItems = allItems;
        }
        public RolePermissionViewModel(int userId, int siteId, SysRole roleModel, List<NavigationItem> allItems)
        {
            this.CurrentSiteId = siteId;
            this.CurrentUserId = userId;
            this.CurrentRoleModel = roleModel;
            this.AllPermissionItems = allItems;
        }

        public int CurrentSiteId { get; set; }
        public int CurrentUserId { get; set; }
        public SysRole CurrentRoleModel { get; set; }
        public List<NavigationItem> AllPermissionItems { get; private set; }
        public List<NavigationItem> AssignedPermissionItems { get; set; }
    }
}
