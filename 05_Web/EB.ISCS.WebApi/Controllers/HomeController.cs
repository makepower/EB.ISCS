using EB.ISCS.ToolService.AuthServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EB.ISCS.WebApi.Controllers
{
    /// <summary>
    /// 主页
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        /// <summary>
        /// 认证回调接口
        /// </summary>
        /// <returns></returns>
        public JsonResult AuthCallBack()
        {
            string code = Request.QueryString["code"];
            var state = Request.QueryString["state"];
            AuthFactory.Instance.Notify(code, state);
            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }
    }
}
