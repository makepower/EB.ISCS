using System.Web.Mvc;

namespace EB.ISCS.Admin
{
    public class ViewEngineConfig : RazorViewEngine
    {
        public ViewEngineConfig()
        {
            ViewLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Account/{0}.cshtml",
                "~/Views/Common/{0}.cshtml",
                "~/Views/Sys/{1}/{0}.cshtml",//系统管理
                "~/Views/Biz/{1}/{0}.cshtml"//业务管理

            };
        }
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            return base.FindView(controllerContext, viewName, masterName, useCache);
        }
    }
}