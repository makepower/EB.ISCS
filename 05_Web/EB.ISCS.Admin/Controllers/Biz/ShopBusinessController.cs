using EB.ISCS.Common.BaseController;
using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Models;
using EB.ISCS.FrameworkEntity.Base;
using Maticsoft.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EB.ISCS.Admin.Controllers.Biz
{
    public class ShopBusinessController : BaseController
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

        /// <summary>
        /// 新增/修改页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View();
        }


        #region 获取数据

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult GetShipInfo(int Id)
        {
            var result = new BaseResult<ShipInfo> { Data = new ShipInfo() };
            if (Id > 0)
            {
                result = ServiceHelper.CallService<ShipInfo>($"{ServiceConst.BizApi.ShopGetModelById}/{Id}", null, this.CurrentUser.Token);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 增、删、改
        /// <summary>删除用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DelShop(int id)
        {
            var result = ServiceHelper.CallService(ServiceConst.BizApi.ShopDel,
                JsonConvert.SerializeObject(new DeleteModel
                {
                    Id = id,
                    UserId = this.CurrentUser.UserId
                }), this.CurrentUser.Token);
            return Json(result);
        }

        /// <summary>
        /// 获取用户列表，分页
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetShopListByQuery(JqGridParam jqgridparam)
        {
            QueryUserModel query = new QueryUserModel()
            {
                PageIndex = jqgridparam.page,
                PageSize = jqgridparam.rows,
                OrderBy = jqgridparam.sord,
                Where = $" and UserId={CurrentUser.UserId}"
            };
            var result = ServiceHelper.CallService<PagedListData<List<ShipInfo>>>(ServiceConst.BizApi.ShopGetPage,
                JsonConvert.SerializeObject(query), this.CurrentUser.Token);
            var json = result.Data.JqGridJsonData();
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveShop(ShipInfo model)
        {
            var result = new BaseResult() { Code = (int)ResultCode.Faild };
            model.UserId = CurrentUser.UserId;
            if (model != null)
            {
                if (model.Id > 0)
                {
                    result = ServiceHelper.CallService(
                        ServiceConst.BizApi.ShopUpdate,
                        JsonConvert.SerializeObject(model),
                        this.CurrentUser.Token);
                }
                else
                {

                    model.Status = 1;
                    model.InDate = System.DateTime.Now;
                    result = ServiceHelper.CallService(ServiceConst.BizApi.ShopInsert,
                        JsonConvert.SerializeObject(model),
                        this.CurrentUser.Token);
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}