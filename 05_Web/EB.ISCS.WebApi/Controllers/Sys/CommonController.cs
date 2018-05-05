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

namespace EB.ISCS.WebApi.Controllers.Sys
{
    /// <summary>
    /// 公共控制器
    /// </summary>
    public class CommonController : BaseUnauthorizedApiController
    {
        /// <summary>
        /// 根据用户Id获取功能菜单 
        /// </summary>
        /// <param name="model">用户实体</param>
        /// <returns></returns>
        [NoLog]
        [HttpPost]
        public ResponseResult<List<NavigationItem>> GetNavigationList(CurrentUserModel model)
        {
            try
            {
                ResultCode code = ResultCode.Success;
                var userId = CheckUserToken(model.Token);
                userId = model.UserId;
                if (userId == 0)
                {
                    code = ResultCode.InvalidLoginCredential;
                    return ResponseResult<List<NavigationItem>>.GenFaildResponse(code);
                }
                var menuService = GetService<MenuService>();
                var menuResult = menuService.GetUserMenus(model.UserId);
                if (menuResult != null)
                {
                    code = ResultCode.Success;
                    var sysMenus = menuResult as SysMenu[] ?? menuResult.ToArray();
                    var rootMenuId = sysMenus.OrderBy(x => x.FatherId).Select(x => x.FatherId).FirstOrDefault();
                    var navigationList = GetChildren(sysMenus, rootMenuId, model.Token);
                    return ResponseResult<List<NavigationItem>>.GenSuccessResponse(navigationList);
                }
                else
                {
                    code = ResultCode.MenuCodeIsNull;
                    return ResponseResult<List<NavigationItem>>.GenFaildResponse(code);
                }
            }
            catch (BizException zdEx)
            {
                return ResponseResult<List<NavigationItem>>.GenFaildResponse(zdEx.Message);
            }
            catch (Exception ex)
            {
                return ResponseResult<List<NavigationItem>>.GenFaildResponse(ex.Message);
            }
        }
        /// <summary>
        /// 根据用户Id获取功能菜单 
        /// </summary>
        /// <param name="model">用户实体</param>
        /// <returns></returns>
        [NoLog]
        [HttpPost]
        [Obsolete]
        public ResponseResult<List<NavigationItem>> GetUserMenusByMenuCodes(QueryMenuModel model)
        {
            try
            {
                //var menuResult = _sysMenuService.GetUserMenusByMenuCodes(model.MenuCodes).ToViewModels();
                List<NavigationItem> navigationList = new List<NavigationItem>();
                //// 获取用户信息
                //if (menuResult != null)
                //{
                //    navigationList = GetChildren(menuResult, 1000001, model.Token);

                //}

                return ResponseResult<List<NavigationItem>>.GenSuccessResponse(navigationList);
            }
            catch (BizException sea2Ex)
            {
                return ResponseResult<List<NavigationItem>>.GenFaildResponse(sea2Ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseResult<List<NavigationItem>>.GenFaildResponse(ex.Message);
            }
        }
        /// <summary>
        /// 递归获取功能菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<NavigationItem> GetChildren(IEnumerable<SysMenu> menu, int id, string token)
        {
            List<NavigationItem> children = new List<NavigationItem>();
            var sysMenuModels = menu as SysMenu[] ?? menu.ToArray();
            foreach (SysMenu item in sysMenuModels.Where(m => m.FatherId == id))
            {
                children.Add(new NavigationItem()
                {
                    MenuId = item.Id,
                    IconClass = item.IconCSS,
                    Title = item.MenuName,
                    Url = item.PageUrl,//GetPageUrl(item.PageUrl,token),
                    Children = GetChildren(sysMenuModels, item.Id, token)
                });
            }
            return children;
        }

        private string GetPageUrl(string pageUrl, string token)
        {
            var url = pageUrl;
            //处理单点登陆跨域的 Menu 的 url 要附带 token 参数
            if (!string.IsNullOrEmpty(pageUrl) && pageUrl.Contains("http://"))
            {
                url = $"{pageUrl}?token={Uri.EscapeDataString(token)}";
            }
            return url;
        }
    }
}
