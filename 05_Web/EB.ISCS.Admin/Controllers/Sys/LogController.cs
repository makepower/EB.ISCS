using EB.ISCS.Common.BaseController;
using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Models;
using EB.ISCS.FrameworkEntity.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;
using Newtonsoft.Json;
using System.Collections.Generic;
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


        public ActionResult Show(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        /// <summary>
        /// 获取用户列表，分页
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetList(int type, JqGridParam jqgridparam)
        {
            jqgridparam.rows = jqgridparam.rows < 1 ? 15 : jqgridparam.rows;
            if (type == 0)
            {
                var query = new QueryLoginLogModel()
                {
                    PageIndex = jqgridparam.page,
                    PageSize = jqgridparam.rows,
                    OrderBy = jqgridparam.sord,

                };
                var result = ServiceHelper.CallService<PagedListData<List<SysLoginLog>>>(ServiceConst.LogApi.GetLoginLogPageList,
             JsonConvert.SerializeObject(query), this.CurrentUser.Token);
                var json = result.Data.JqGridJsonData();
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            else if (type == 1)
            {
                var query = new QueryOperationLogModel()
                {
                    PageIndex = jqgridparam.page,
                    PageSize = jqgridparam.rows,
                    OrderBy = jqgridparam.sord,

                };
                var result = ServiceHelper.CallService<PagedListData<List<SysOperationLog>>>(ServiceConst.LogApi.GetOperaterLogPageList,
            JsonConvert.SerializeObject(query), this.CurrentUser.Token);
                var json = result.Data.JqGridJsonData();
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            else if (type == 2)
            {
                var query = new QueryExceptionLogModel()
                {
                    PageIndex = jqgridparam.page,
                    PageSize = jqgridparam.rows,
                    OrderBy = jqgridparam.sord,


                };
                var result = ServiceHelper.CallService<PagedListData<List<SysExceptionLog>>>(ServiceConst.LogApi.GetExceptionLogPageList,
          JsonConvert.SerializeObject(query), this.CurrentUser.Token);
                var json = result.Data.JqGridJsonData();
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(string.Empty, JsonRequestBehavior.AllowGet);
            }

        }
    }
}