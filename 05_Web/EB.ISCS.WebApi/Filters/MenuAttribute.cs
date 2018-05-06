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
                        isAuthorized = true; // IsAuthorized(token, controllerName, actionName);
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
    }
}