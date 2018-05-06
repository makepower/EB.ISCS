using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Models;
using EB.ISCS.DapperServices.Services.Sys;
using EB.ISCS.FrameworkEntity.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.WebApi.Controllers.Sys
{
    /// <summary>
    /// 
    /// </summary>
    public class SysUserController : BaseApiController
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<int> Insert(SysUser user)
        {
            var service = GetService<SysUserService>();
            var result = service.Add(user);
            return ResponseResult<int>.GenSuccessResponse(result);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<List<SysUser>> GetList()
        {
            var service = GetService<SysUserService>();
            var result = service.GetModelById(0);
            return ResponseResult<List<SysUser>>.GenSuccessResponse(result);
        }


        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<SysUser> SuperLogin(string loginName, string password)
        {
            var service = GetService<SysUserService>();
            var result = service.GetList();
            return ResponseResult<SysUser>.GenSuccessResponse(result);
        }



        #region 增、删、改、查

        /// <summary>
        /// 根据查询条件获取公司列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<PagedListData<List<SysUser>>> GetUserListByQuery(QueryUserModel query)
        {
            PagedListData<List<SysUser>> model = new PagedListData<List<SysUser>>();

            var userService = GetService<SysUserService>();
            var result = userService.GetUserListByQuery(query);
            model.PagingData = result.PagingData?.ToList();
            model.PagingInfo = result.PagingInfo;
            return ResponseResult<PagedListData<List<SysUser>>>.GenSuccessResponse(model);
        }

        /// <summary>
        /// 根据Id删除用户
        /// </summary>
        /// <param name="delModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Delete(DeleteModel delModel)
        {
            var userService = GetService<SysUserService>();
            var result = userService.Delete(delModel);
            return ResponseResult<bool>.GenSuccessResponse(result);
        }


        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<int> Add(SysUser model)
        {
            try
            {
                var userService = GetService<SysUserService>();
                var vIsSuess = userService.Add(model);
                return ResponseResult<int>.GenSuccessResponse(vIsSuess);
            }
            catch (Exception ex)
            {
                return ResponseResult<int>.GenFaildResponse(ex.Message);
            }

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Update(SysUser model)
        {
            try
            {
                var userService = GetService<SysUserService>();
                var vIsSuess = userService.Update(model);
                return ResponseResult<bool>.GenSuccessResponse(vIsSuess);
            }
            catch (Exception ex)
            {
                return ResponseResult<bool>.GenFaildResponse(ex.Message);
            }

        }

        /// <summary>
        /// 根据用户Id获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<SysUser> GetModelById(int id)
        {
            var userService = GetService<SysUserService>();
            var userInfo = userService.GetModelById(id);
            return ResponseResult<SysUser>.GenSuccessResponse(userInfo);
        }

        /// <summary>
        /// 获取查询用户
        /// </summary>
        /// <param name="id">公司Id,废弃参数</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<List<SysUser>> GetList(int id)
        {
            var userService = GetService<SysUserService>();
            var result = userService.GetList();
            return ResponseResult<List<SysUser>>.GenSuccessResponse(result);
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> ChangePassword(SysUser model)
        {
            var userService = GetService<SysUserService>();
            var vIsSuess = userService.ChangePassword(model);
            return ResponseResult<bool>.GenSuccessResponse(vIsSuess);
        }

        #endregion

        #region 用户权限
        /// <summary>
        /// 保存用户操作权限列表
        /// </summary>
        /// <param name="userMenuPermissionVm"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> SaveUserMenuPermissions(UserMenuPermission userMenuPermissionVm)
        {
            // 更新权限 同步更新缓存
            var token = Request.Token();

            var userService = GetService<SysUserService>();
            var result = userService.SaveUserPermission(userMenuPermissionVm);
            return ResponseResult<bool>.GenSuccessResponse(result);
        }
        #endregion

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<List<SysUser>> GetAllList()
        {
            try
            {
                var service = GetService<SysUserService>();
                var result = service.GetAllList();
                return ResponseResult<List<SysUser>>.GenSuccessResponse(result);
            }
            catch (Exception ex)
            {
                return ResponseResult<List<SysUser>>.GenFaildResponse(ex.Message);
            }
        }
    }
}
