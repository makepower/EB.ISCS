using EB.ISCS.DapperServices.Services.Sys;
using EB.ISCS.FrameworkHelp.Tools;
using System;
using System.Web.Http.Controllers;
using System.Linq;
using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using EB.ISCS.Common.Models;
using Newtonsoft.Json;
using System.Text;

namespace EB.ISCS.WebApi.Filters
{
    /// <summary>
    /// 菜单权限过滤器
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class MenuAttribute : ActionFilterAttribute
    {
        private bool _isEnable = true;
        private static readonly string[] _emptyArray = new string[0];
        private string _permission;
        private string[] _permissions = _emptyArray;


        /// <summary>
        /// 
        /// </summary>
        public MenuAttribute()
        {
            _isEnable = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public MenuAttribute(bool IsEnable)
        {
            _isEnable = IsEnable;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Permission
        {
            get { return _permission ?? string.Empty; }
            set
            {
                _permission = value;
                _permissions = this.SplitString(value, ',');
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string[] Permissions
        {
            get { return _permissions ?? _emptyArray; }
            set
            {
                _permissions = value;
                _permission = string.Join(",", value ?? _emptyArray);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var Request = actionContext.Request;
            string token = string.Empty;
            if (_isEnable)
            {
                var actionName = actionContext.ActionDescriptor.ActionName;
                var controllerName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;

                if (Request.Headers.Authorization != null && Request.Headers.Authorization.Parameter != null)
                {
                    token = Request.Token();
                }
                else
                {
                    base.OnActionExecuting(actionContext);
                }

                bool isAuthorized = true;
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous)
                {
                    // 匿名认证绕开Action过滤
                    isAuthorized = isAnonymous;
                }
                else
                {
                    if (!string.IsNullOrEmpty(token))
                        isAuthorized = IsAuthorized(token, controllerName, actionName);
                    else
                        isAuthorized = false;
                }

                if (!isAuthorized)
                {
                    var result = new ResponseResult() { Code = (int)ResultCode.UserTokenError, Message = "你没有访问此功能的权限，请联系管理员！" };
                    var str = JsonConvert.SerializeObject(result);
                    var response = new HttpResponseMessage
                    {
                        Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json"),
                        StatusCode = HttpStatusCode.OK    // 业务软放通
                    };
                    actionContext.Response = response;
                    return;
                }
            }

            base.OnActionExecuting(actionContext);
        }

        /// <summary>
        /// 根据token信息进行令牌认证
        /// 通过令牌获取用户菜单权限进行二次校验(缺省前端应用进行一次权限校验)
        /// </summary>
        /// <param name="token"></param>
        /// <param name="controllerName"></param>
        /// <param name="actionName"></param>
        /// <returns></returns>
        protected bool IsAuthorized(string token, string controllerName, string actionName)
        {


            if (_permissions == null)
            {
                // never null
                throw new ArgumentNullException("permissionIds");
            }
            var data = ApiCacheDicts.GetLoginToken(token, t =>
            {
                SysLoginTokenService sysUserService = new SysLoginTokenService();
                return sysUserService.GetByToken(token);
            });
            if (data == null)
            {
                return false;
            }
            else if (data.ExpriedTime < DateTime.Now)
            {
                return false;
            }
            else
            {
                controllerName = controllerName.Replace("Controller", string.Empty).Trim();
                //action权限认证
                var menuPermissions = ApiCacheDicts.GetUserMenuPermissionByToken(token, t =>
                {
                    MenuPermissionService menuPermissionService = new MenuPermissionService();
                    return menuPermissionService.GetUserPermissionsByUserId(data.UserId ?? 0);
                });

                return menuPermissions.Any(m =>
                {
                    if (string.IsNullOrEmpty(m.ControllerKey) || string.IsNullOrEmpty(m.ActionKey))
                        return false;
                    return m.ControllerKey.Equals(controllerName) && m.ActionKey.Equals(actionName);
                });
            }
        }
    }
}