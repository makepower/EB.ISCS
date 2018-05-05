using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EB.ISCS.Common.BaseController;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.Common.DataModel
{
    /// <summary>
    /// 用户操作权限()
    /// </summary>
    public class SysUserPermissionModel : BaseModel
    {

        public SysUserPermissionModel()
        {
            CurrentUserModel = new SysUser();
            AllPermissionItems = new List<NavigationItem>();
            AssignedPermissionItems = new List<NavigationItem>();
        }


       

        #region 扩展属性

        public SysUserPermissionModel(int userId, SysUser userModel, List<NavigationItem> allItems)
        {
            this.CurrentUserId = userId;
            this.CurrentUserModel = userModel;
            this.AllPermissionItems = allItems;
        }
        public int CurrentUserId { get; set; }
        public SysUser CurrentUserModel { get; set; }
        public List<NavigationItem> AllPermissionItems { get; private set; }
        public List<NavigationItem> AssignedPermissionItems { get; set; }
    }
    #endregion


    #region 
    public class UserMenuPermission
    {
        public UserMenuPermission()
        {
            UserMenuViewModel = new List<SysUserMenu>();
            UserPermissionViewModel = new List<SysUserPermission>();
        }
        public List<SysUserMenu> UserMenuViewModel { get; set; }
        public List<SysUserPermission> UserPermissionViewModel { get; set; }
    }
    #endregion
}
