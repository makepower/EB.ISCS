using System;
using System.Linq;
using System.Transactions;
using System.Web.Http;
using EB.ISCS.Common.Models;
using EB.ISCS.Common.ViewModel;
using EB.ISCS.DapperServices.InterFace.Sys;
using EB.ISCS.DapperServices.Services.Sys;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.WebApi.Controllers.Sys
{
    /// <summary>
    /// 操作记录管理
    /// </summary>
    public class RoleMenuController : BaseApiController
    {
        #region RoleMenu Services

        private IRoleMenuService _roleMenuService;
        private IRolePermissionService _rolePermissionService;

        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public RoleMenuController()
        {
        }

        /// <summary>
        /// 保存角色操作权限列表
        /// </summary>
        /// <param name="roleMenuPermissionVm"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> SaveRoleMenuPermissions(RoleMenuPermissionViewModel roleMenuPermissionVm)
        {
            var roleMenuList = roleMenuPermissionVm.RoleMenuViewModel;
            var rolePermissionList = roleMenuPermissionVm.RolePermissionViewModel;
            if ((roleMenuList == null || roleMenuList.Count <= 0) && (rolePermissionList == null || rolePermissionList.Count<=0))
            {
                return ResponseResult<bool>.GenSuccessResponse(false);
            }
            var roleId = roleMenuList.FirstOrDefault().RoleId;
            if (roleId <= 0)
            {
                return ResponseResult<bool>.GenSuccessResponse(false);
            }

            _roleMenuService = GetService<RoleMenuService>();
            _rolePermissionService = GetService<RolePermissionService>();

            using (TransactionScope ts = new TransactionScope())
            {
                var result = false;
                try
                {
                    //先删除角色菜单记录，再添加新的
                    result = _roleMenuService.DeleteRoleMenus((int)roleId);
                    foreach (var roleMenu in roleMenuList)
                    {
                        result &= _roleMenuService.Add(roleMenu) > 0;
                    }

                    //先删除角色操作记录，在添加新的
                    result &= _rolePermissionService.DeleteRolePermissions((int)roleId);
                    foreach (var rolePermission in rolePermissionList)
                    {
                        result &= _rolePermissionService.Add(rolePermission) > 0;
                    }

                    ts.Complete();
                }
                catch (Exception ex)
                {
                    result = false;
                    ts.Dispose();
                }
                
                return ResponseResult<bool>.GenSuccessResponse(result);
            }
        }
        
        /// <summary>
        /// 根据Id删除操作记录
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Delete(int roleId)
        {
            if (roleId <= 0)
            {
                return ResponseResult<bool>.GenSuccessResponse(false);
            }
            _roleMenuService = GetService<RoleMenuService>();
            var result = _roleMenuService.DeleteRoleMenus(roleId);
            return ResponseResult<bool>.GenSuccessResponse(result);
        }

        /// <summary>
        /// 新增公司信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Add(SysRoleMenu model)
        {
            _roleMenuService = GetService<RoleMenuService>();
            var vIsSuess = _roleMenuService.Add(model) > 0;
            return ResponseResult<bool>.GenSuccessResponse(vIsSuess);
        }
    }
}
