using EB.ISCS.Common.Models;
using EB.ISCS.FrameworkHelp.Tools;
using EB.ISCS.FrameworkLog.LogModel;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace EB.ISCS.WebApi.Filters
{
    /// <summary>
    ///  授权筛选器
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class ApiAuthorizeFilter : AuthorizeAttribute
    {
        /// <summary>
        /// 登录认证
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            var Request = actionContext.Request;
            string token = string.Empty;
            Exception exception = null;

            // 开启令牌认证
            if (Request.Headers.Authorization != null && Request.Headers.Authorization.Parameter != null)
            {
                token = Request.Headers.Authorization.Parameter;
            }
            else
            {
                exception = new UnauthorizedAccessException("无法提供有效的认证令牌");
                base.HandleUnauthorizedRequest(actionContext);
            }
            if (exception != null)
                LogHelper.WriteErrorLog(actionContext.Request.RequestUri.AbsolutePath, exception);
            //检测token
            var tokenparts = token.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokenparts.Length == 0)
            {
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous) base.OnAuthorization(actionContext);
                else HandleUnauthorizedRequest(actionContext);
            }
        }
    }
}


