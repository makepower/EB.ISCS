using EB.ISCS.Common.BaseController;
using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Models;
using EB.ISCS.DapperServices.Services.Sys;
using EB.ISCS.FrameworkEntity.SystemEntity;
using EB.ISCS.FrameworkHelp.BizException;
using EB.ISCS.WebApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace EB.ISCS.WebApi.Controllers.Sys
{
    /// <summary>
    /// 功能菜单管理
    /// </summary>
    public class MenuController : BaseApiController
    {

        List<SysMenu> sysMenuList = new List<SysMenu>();

        /// <summary>
        /// 构造
        /// </summary>
        public MenuController()
        {
        }

        /// <summary>
        /// 根据查询条件获取功能模块菜单列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<List<SysMenu>> GetSysMenuList(QueryMenuModel query)
        {
            var menuService = GetService<MenuService>();
            var result = menuService.GetSysMenuList(query);
            return ResponseResult<List<SysMenu>>.GenSuccessResponse(result);
        }

        /// <summary>
        /// 根据Id删除功能模块菜单
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
            var menuService = GetService<MenuService>();
            var result = menuService.Delete(delModel);
            return ResponseResult<bool>.GenSuccessResponse(result);
        }


        /// <summary>
        /// 新增功能模块菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Add(SysMenu model)
        {
            try
            {
                var menuService = GetService<MenuService>();
                var vIsSuess = menuService.Add(model) > 0;
                return ResponseResult<bool>.GenSuccessResponse(vIsSuess);
            }
            catch (Exception ex)
            {
                return ResponseResult<bool>.GenFaildResponse(ex.Message);
            }
        }

        /// <summary>
        /// 修改功能模块菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [OperateLog]
        public ResponseResult<bool> Update(SysMenu model)
        {
            try
            {
                var menuService = GetService<MenuService>();
                var vIsSuess = menuService.Update(model);
                return ResponseResult<bool>.GenSuccessResponse(vIsSuess);
            }
            catch (Exception ex)
            {
                return ResponseResult<bool>.GenFaildResponse(ex.Message);
            }
        }

        /// <summary>
        /// 根据公司Id获取功能模块菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<SysMenu> GetModelById(int id)
        {
            var menuService = GetService<MenuService>();
            var result = menuService.GetModelById(id);
            return ResponseResult<SysMenu>.GenSuccessResponse(result);
        }

        /// <summary>
        /// 查询给定角色、公司下的菜单、功能操作权限列表（包括菜单、功能操作权限的选中状态）
        /// </summary>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<List<SysMenu>> GetMenuPermissionsList(SysRole roleModel)
        {
            try
            {
                ResultCode code = ResultCode.Success;
                var menuService = GetService<MenuService>();
                var listResult = menuService.GetRoleMenuList(roleModel);
                if (listResult == null)
                {
                    code = ResultCode.MenuCodeIsNull;
                    return ResponseResult<List<SysMenu>>.GenFaildResponse(code);
                }

                return ResponseResult<List<SysMenu>>.GenSuccessResponse(listResult);
            }
            catch (Exception ex)
            {
                return ResponseResult<List<SysMenu>>.GenFaildResponse(ex.Message);
            }

        }
        /// <summary>
        /// 查询给定用户、公司下的菜单、功能操作权限列表（包括菜单、功能操作权限的选中状态）
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<List<SysMenu>> GetMenuPermissionsListByUserId(SysUser userModel)
        {
            try
            {
                ResultCode code = ResultCode.Success;
                var menuService = GetService<MenuService>();
                var listResult = menuService.GetMenuPermissionsListByUserId(userModel.Id);
                if (listResult == null)
                {
                    code = ResultCode.MenuCodeIsNull;
                    return ResponseResult<List<SysMenu>>.GenFaildResponse(code);
                }

                return ResponseResult<List<SysMenu>>.GenSuccessResponse(listResult);
            }
            catch (Exception ex)
            {
                return ResponseResult<List<SysMenu>>.GenFaildResponse(ex.Message);
            }

        }
        /// <summary>
        /// 根据用户Id获取功能菜单 
        /// </summary>
        /// <param name="model">用户实体</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<NavigationItem> GetMenuByUserId(CurrentUserModel model)
        {

            try
            {
                #region 参数验证
                //if (string.IsNullOrEmpty(model.Token))
                //{
                //    return ResponseResult<NavigationItem>.GenFaildResponse(ResultCode.UserTokenError);
                //}
                #endregion

                ResultCode code = ResultCode.Success;
                var userId = CheckUserToken(model.Token);
                if (userId == 0)
                {
                    code = ResultCode.InvalidLoginCredential;
                    return ResponseResult<NavigationItem>.GenFaildResponse(code);
                }
                var menuService = GetService<MenuService>();
                var menuResult = menuService.GetUserMenus(userId);


                if (menuResult != null)
                {

                    code = ResultCode.Success;

                }
                else
                {
                    code = ResultCode.MenuCodeIsNull;
                    return ResponseResult<NavigationItem>.GenFaildResponse(code);
                }

                if (code == ResultCode.Success)
                {
                    // 获取用户信息
                    if (menuResult != null)
                    {
                        NavigationItem navItem = new NavigationItem();
                        var root = menuResult.Where(m => m.FatherId == 0).FirstOrDefault();
                        navItem.Url = root.PageUrl;
                        navItem.Title = root.MenuName;
                        navItem.IconClass = root.IconCSS;
                        navItem.Children = GetChildren(menuResult, root.Id);

                        return ResponseResult<NavigationItem>.GenSuccessResponse(navItem);
                    }
                    else
                    {
                        return ResponseResult<NavigationItem>.GenFaildResponse(code);
                    }
                }
                else
                {
                    return ResponseResult<NavigationItem>.GenFaildResponse(code);
                }
            }
            catch (BizException ex)
            {
                return ResponseResult<NavigationItem>.GenFaildResponse(ex.Message);
            }
            catch
            {
                return ResponseResult<NavigationItem>.GenFaildResponse();
            }
        }

        /// <summary>
        /// 递归获取功能菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        public List<NavigationItem> GetChildren(IEnumerable<SysMenu> menu, int id)
        {
            List<NavigationItem> children = new List<NavigationItem>();
            foreach (SysMenu item in menu.Where(m => m.FatherId == id))
            {
                children.Add(new NavigationItem()
                {
                    IconClass = item.IconCSS,
                    Title = item.MenuName,
                    Url = item.PageUrl,
                    Children = GetChildren(menu, item.Id)
                });
            }
            return children;
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


        #region 自定义
        /// <summary>
        /// 所有的菜单和动作
        /// 获取用户当前权限勾选项
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<List<MenuAllTree>> GetUserMenuById(int id)
        {
            try
            {
                ResultCode code = ResultCode.Success;
                var sysMenu = GetService<MenuService>();

                var listResult = sysMenu.GetUserMenuById(id);
                if (listResult == null)
                {
                    code = ResultCode.MenuCodeIsNull;
                    return ResponseResult<List<MenuAllTree>>.GenFaildResponse(code);
                }

                return ResponseResult<List<MenuAllTree>>.GenSuccessResponse(listResult);
            }
            catch (Exception ex)
            {
                return ResponseResult<List<MenuAllTree>>.GenFaildResponse(ex.Message);
            }
        }

        #endregion

    }
}
