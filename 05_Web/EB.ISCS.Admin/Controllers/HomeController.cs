using EB.ISCS.Common.BaseController;
using System.Web.Mvc;

namespace EB.ISCS.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DashBoard()
        {
            return View();
        }
 
        public ActionResult LeftNavigation()
        {
            ViewBag.Token = this.CurrentUser.Token;
            var navigationList = this.GetNavigationList(this.CurrentUser);
            var navigationModel = new NavigationModel(navigationList);
            return PartialView(navigationModel);
        }
    }
}