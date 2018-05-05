using System;
using System.Web.Http.Filters;

namespace EB.ISCS.WebApi.Filters
{
    /// <summary>
    /// webapi資源釋放過濾器
    /// </summary>
    public class WebApiDisposeFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 回收，Api调用的Services的连接
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            GC.Collect();
        }
    }
}