using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EB.ISCS.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Test(string id)
        {
            var paths = "/";
            if (id.IndexOf("{", StringComparison.Ordinal) > 0)
            {
                paths += id.Replace("{id}", "0");
            }
            else
            {
                paths += id;
            }
            ViewBag.Id = paths;
            return View();
        }
    }
}
