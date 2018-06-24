using System;

namespace EB.ISCS.Common.Models
{
    public class ServiceConst
    {
        static ServiceConst()
        {
            #region 系统服务

            Account = new Account();
            CommonService = new CommonService();
            SysUserApi = new SysUserApi();
            MenuApi = new MenuApi();
            LogApi = new LogApi();

            #endregion

            #region 业务服务
            BizApi = new BizApi();
            #endregion
        }


        #region 系统服务
        public static Account Account { get; }
        public static LogApi LogApi { get; }
        public static CommonService CommonService { get; }
        public static SysUserApi SysUserApi { get; }
        public static MenuApi MenuApi { get; }

        #endregion
        #region 业务服务
        public static BizApi BizApi { get; }
        #endregion
    }

    #region 系统服务
    public class Account
    {
        public string SignIn = "Sys/Account/SignIn";
        public string SignOut = "Sys/Account/SignOut";
    }
    public class CommonService
    {
        public string GetNavigationList = "Sys/Common/GetNavigationList";
        public string GetMenuPermissionsList = "Sys/Menu/GetMenuPermissionsList";
        public string GetUserPagePermissions = "Sys/Menu/GetUserPagePermissions";
        public string GetEnumKeyDescripion = "Common/Enum/EnumKeyDescripion";
    }

    public class SysUserApi
    {
        /// <summary>
        /// 根据公司Id获取用户信息
        /// </summary>
        public string GetList = "Sys/SysUser/GetList";

        /// <summary>
        /// 根据用户编号获取用户信息
        /// </summary>
        public string GetModelById = "Sys/SysUser/GetModelById";

        /// <summary>
        /// 根据用户编号获取用户权限及菜单
        /// </summary>
        public string GetMenuPermissionsListByUserId = "Sys/Menu/GetMenuPermissionsListByUserId";

        /// <summary>
        /// 获取用户列表（分页）
        /// </summary>
        public string GetUserListByQuery = "Sys/SysUser/GetUserListByQuery";

        /// <summary>
        /// 删除用户信息
        /// </summary>
        public string Delete = "Sys/SysUser/Delete";

        /// <summary>
        /// 修改用户信息
        /// </summary>
        public string Update = "Sys/SysUser/Update";

        /// <summary>
        /// 修改用户密码
        /// </summary>
        public string ChangePassword = "Sys/SysUser/ChangePassword";

        /// <summary>
        /// 添加用户信息
        /// </summary>
        public string Add = "Sys/SysUser/Add";

        /// <summary>
        /// 根据用户编号获取角色信息列表（已关联）
        /// </summary>
        public string GetRoleListByUserId = "Sys/UserRole/GetRoleListByUserId";

        /// <summary>
        /// 根据用户编号获取角色信息列表（未关联）
        /// </summary>
        public string GetNoRoleListByUserId = "Sys/UserRole/GetNoRoleListByUserId";

        /// <summary>
        /// 根据角色编号获取用户列表（已关联）
        /// </summary>
        public string GetUserListByRoleId = "Sys/UserRole/GetUserListByRoleId";

        /// <summary>
        /// 根据角色编号获取用户列表（未关联）
        /// </summary>
        public string GetNoUserListByRoleId = "Sys/UserRole/GetNoUserListByRoleId";

        /// <summary>
        /// 给用户分配角色
        /// </summary>
        public string AddRoleForUser = "Sys/UserRole/AddRoleForUser";

        /// <summary>
        /// 给角色分配用户
        /// </summary>
        public string AddUserForRole = "Sys/UserRole/AddUserForRole";

        /// <summary>
        /// 给用户分配权限菜单
        /// </summary>
        public string SaveUserMenuPermissions = "Sys/SysUser/SaveUserMenuPermissions";


        /// <summary>
        /// 添加用户信息(Dapper实现)
        /// </summary>
        public string AddUser = "Sys/SysUser/AddUser";

        /// <summary>
        /// 删除用户信息(Dapper实现)
        /// </summary>
        public string DeleteUser = "Sys/SysUser/DeleteUser";

        /// <summary>
        /// 修改用户信息(Dapper实现)
        /// </summary>
        public string UpdateUser = "Sys/SysUser/UpdateUser";

        /// <summary>
        /// 根据用户编号获取用户信息(Dapper实现)
        /// </summary>
        public string GetUserById = "Sys/SysUser/GetUserById";

        /// <summary>
        /// 获取用户列表（Dapper实现分页）
        /// </summary>
        public string GetListPageByQuery = "Sys/SysUser/GetListPageByQuery";

        /// <summary>
        /// 根据用户编号获取角色信息列表（已关联）
        /// </summary>
        public string GetUserRoleListByUserId = "Sys/SysUser/GetUserRoleListByUserId";

        /// <summary>
        /// 根据用户编号获取角色信息列表（未关联）
        /// </summary>
        public string GetNoUserRoleListByUserId = "Sys/SysUser/GetNoUserRoleListByUserId";

        /// <summary>
        /// 给用户分配角色
        /// </summary>
        public string AddUserRolesForUser = "Sys/SysUser/AddUserRolesForUser";
    }
    public class MenuApi
    {
        public string GetModelById = "Sys/Menu/GetModelById";
        public string GetLGetChildrenist = "Sys/Menu/GetChildren";
        public string Update = "Sys/Menu/Update";
        public string Add = "Sys/Menu/Add";
        public string Delete = "Sys/Menu/Delete";
        public string GetSysMenuList = "Sys/Menu/GetSysMenuList";

        public string GetUserMenuById = "Sys/Menu/GetUserMenuById";

        public string GetMenuPermissionsList = "Sys/Menu/GetMenuPermissionsList";
        public string PermissionAdd = "Sys/MenuPermission/Add";
        public string PermissionDelete = "Sys/MenuPermission/Delete";
        public string PermissionUpdate = "Sys/MenuPermission/Update";
        public string PermissionGetModelById = "Sys/MenuPermission/GetModelById/{0}";
        public string GetMenuPermissionListPage = "Sys/MenuPermission/GetMenuPermissionList";

    }
    public class LogApi
    {
        public string GetLoginLogPageList = "Sys/Log/GetLoginLogPageList";
        public string GetOperaterLogPageList = "Sys/Log/GetOperaterLogPageList";
        public string GetExceptionLogPageList = "Sys/Log/GetExceptionLogPageList";
    }
    #endregion

    #region 业务服务
    public class BizApi
    {
        public string DashBoardTodayRealMonitorIndicator = "Biz/DashBoard/GetTodayRealMonitorIndicator";
        public string DashBoardGetDashBoardChartViewData = "Biz/DashBoard/GetDashBoardChartViewData";

        public string ShopInsert = "Biz/ShopManager/Insert";
        public string ShopUpdate = "Biz/ShopManager/Update";
        public string ShopDel = "Biz/ShopManager/Delete";

        public string ShopGetModelById = "Biz/ShopManager/GetModelById";
        public string ShopGetPage = "Biz/ShopManager/GetPage";
        public string ShopGetAllByUser = "Biz/ShopManager/GetAll/{0}";



        public string SyncConfigSave = "Biz/SyncConfig/Save";
        public string SyncConfigGetByUserId = "Biz/SyncConfig/GetByUserId/{0}";
    }
    #endregion

}