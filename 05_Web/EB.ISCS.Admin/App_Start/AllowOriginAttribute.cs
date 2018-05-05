using System;
using System.Linq;
using System.Web.Mvc;

namespace EB.ISCS.Admin
{
    public class AllowOriginAttribute
    {
        public static void onExcute(ControllerContext context, string[] AllowSites)
        {
            var origin = context.HttpContext.Request.Headers["Origin"];
            Action action = () =>
            {
                context.HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", origin);

            };
            if (AllowSites != null && AllowSites.Any())
            {
                if (AllowSites.Contains(origin))
                {
                    action();
                }
            }
        }
    }

    public class ActionAllowOriginAttribute : ActionFilterAttribute
    {
        public string[] AllowSites { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            AllowOriginAttribute.onExcute(filterContext, AllowSites);
            base.OnActionExecuting(filterContext);
        }
    }
    public class ControllerAllowOriginAttribute : AuthorizeAttribute
    {
        public string[] AllowSites { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            AllowOriginAttribute.onExcute(filterContext, AllowSites);
        }

    }

}