using EB.ISCS.Common.BaseController;
using System.Web.Mvc;


namespace EB.ISCS.Admin.Controllers.Sys
{
    public class LogController : BaseController
    {
        // GET: Menu
        public ActionResult Index(int id)
        {
            ViewBag.MenuId = id;
            return View();
        }



    }
}