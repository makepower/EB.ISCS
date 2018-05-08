using EB.ISCS.Common.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EB.ISCS.Admin.Controllers.Biz
{
    public class ComplaintController : BaseController
    {
        /// <summary>
        /// 管理列表页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            ViewBag.MenuId = id;
            return View();
        }
    }
}