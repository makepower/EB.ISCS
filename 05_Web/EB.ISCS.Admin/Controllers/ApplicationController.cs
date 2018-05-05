using System.Web.Mvc;

namespace EB.ISCS.Admin.Controllers
{
    public class ApplicationController : Controller
    {
        public ActionResult GetOnline(int flag)
        {
            var count = this.ControllerContext.HttpContext.Application["online"];
            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            return Json(new { OnlineCount = count }, JsonRequestBehavior.AllowGet);
        }
    }
}