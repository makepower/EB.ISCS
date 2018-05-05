using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Models;
using EB.ISCS.DapperServices.Services.Sys;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.WebApi.Controllers.Sys
{
    /// <summary>
    /// 功能能操作管理API
    /// </summary>
    public class MenuPermissionController : BaseApiController
    {
        /// <summary>
        /// 根据Id删除功能操作
        /// </summary>
        /// <param name="delModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Delete(DeleteModel delModel)
        {
            var idparts = delModel.DelString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (idparts.Length < 1)
            {
                return ResponseResult<bool>.GenSuccessResponse(false);
            }
            var sysMenuPermissionService = GetService<MenuPermissionService>();
            var result = sysMenuPermissionService.Delete(delModel);
            return ResponseResult<bool>.GenSuccessResponse(result);
        }


        /// <summary>
        /// 新增功能操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Add(SysMenuPermission model)
        {
            var sysMenuPermissionService = GetService<MenuPermissionService>();
            var vIsSuess = sysMenuPermissionService.Add(model) > 0;
            return ResponseResult<bool>.GenSuccessResponse(vIsSuess);
        }

        /// <summary>
        /// 修改功能操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Update(SysMenuPermission model)
        {
            var sysMenuPermissionService = GetService<MenuPermissionService>();
            var vIsSuess = sysMenuPermissionService.Update(model);
            return ResponseResult<bool>.GenSuccessResponse(vIsSuess);
        }

        /// <summary>
        /// 根据公司Id获取功能操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<SysMenuPermission> GetModelById(int id)
        {
            var sysMenuPermissionService = GetService<MenuPermissionService>();
            return ResponseResult<SysMenuPermission>.GenSuccessResponse(sysMenuPermissionService.GetModelById(id));
        }

        /// <summary>
        /// 查询给定角色、公司下的菜单、功能操作权限列表（包括菜单、功能操作权限的选中状态）
        /// </summary>
        /// <param name="menuModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<List<SysMenuPermission>> GetMenuPermissionsList(SysMenu menuModel)
        {
            try
            {
                ResultCode code = ResultCode.Success;
                var sysMenuPermissionService = GetService<MenuPermissionService>();
                var listResult = sysMenuPermissionService.GetSysMenuPermissionsByMenu(menuModel);
                if (listResult == null)
                {
                    code = ResultCode.MenuCodeIsNull;
                    return ResponseResult<List<SysMenuPermission>>.GenFaildResponse(code);
                }

                return ResponseResult<List<SysMenuPermission>>.GenSuccessResponse(listResult);
            }
            catch (Exception ex)
            {
                return ResponseResult<List<SysMenuPermission>>.GenFaildResponse(ex.Message);
            }

        }

        /// <summary>
        /// 查询给定公司的用户在当前页面上的按钮权限列表
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<List<SysMenuPermission>> GetUserPagePermissions(QueryUserPermissionModel queryModel)
        {
            try
            {
                ResultCode code = ResultCode.Success;
                var sysMenuPermissionService = GetService<MenuPermissionService>();

                var listResult = sysMenuPermissionService.GetUserPagePermissions(queryModel);
                if (listResult == null)
                {
                    code = ResultCode.MenuCodeIsNull;
                    return ResponseResult<List<SysMenuPermission>>.GenFaildResponse(code);
                }

                return ResponseResult<List<SysMenuPermission>>.GenSuccessResponse(listResult);
            }
            catch (Exception ex)
            {
                return ResponseResult<List<SysMenuPermission>>.GenFaildResponse(ex.Message);
            }

        }

        [HttpPost]
        public ResponseResult<List<SysMenuPermission>> GetMenuPermissionList(int id)
        {
            var userService = GetService<MenuPermissionService>();
            var result = userService.GetMenuPermissionList(id);
            return ResponseResult<List<SysMenuPermission>>.GenSuccessResponse(result);
        }
    }
}
