using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using QS.FrameworkHelp.Tools;

namespace QS.WebApi.Filters
{
    /// <summary>
    /// 操作权限
    /// </summary>
    public class MenuActionAttribute : ActionFilterAttribute
    {
        private bool _isEnable = true;
        private static readonly string[] _emptyArray = new string[0];
        private string _permission;
        private string[] _permissions = _emptyArray;

        /// <summary>
        /// 
        /// </summary>
        public MenuActionAttribute() 
        {
            _isEnable = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsEnable"></param>
        public MenuActionAttribute(bool IsEnable) 
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
                    token = Request.Headers.Authorization.Parameter;
                }
                else
                {
                    base.OnActionExecuting(actionContext);
                }

                //检测token
                var tokenparts = token.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                //IsAuthorized(tokenparts[1]);
                
               // filterContext.Result = new ContentResult() { Content = "你没有访问此功能的权限，请联系管理员！" };
            }

            base.OnActionExecuting(actionContext);
        }
        /// <summary>
        /// 根据token信息判断是否有权限
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        //protected bool IsAuthorized(string token)
        //{
        //    SysLoginTokenService _sysUserService = new SysLoginTokenService();

        //    if (_permissions == null)
        //    {
        //        throw new ArgumentNullException("permissionIds");
        //    }
        //    var data = _sysUserService.GetModelByToken(token);
        //    if (data == null)
        //    {
        //        return false;
        //    }
        //    else if (data.ExpriedTime < DateTime.Now)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        后面补充action权限认证
        //        return true;
        //    }

        //}
    }
}