using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using EB.ISCS.Common.BaseController;
using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Models;
using EB.ISCS.FrameworkEntity.SystemEntity;
using Maticsoft.Model;
using System;

namespace EB.ISCS.Admin.Controllers.Sys
{
    public class SynchronizationController : BaseController
    {
        // GET: MenuPermission
        public ActionResult Index(int id)
        {
            ViewBag.MenuId = id;
            return View();
        }

        #region 功能操作增删改查

        /// <summary>
        /// 获取功能操作信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetConfig()
        {
            var Id = CurrentUser.UserId;
            var result = new BaseResult<SynchronizationConfig>() { Code = (int)ResultCode.Success, Data = new SynchronizationConfig() { UserId = CurrentUser.UserId } };
            if (Id > 0)
            {
                var tmp = ServiceHelper.CallService<SynchronizationConfig>(string.Format(ServiceConst.BizApi.SyncConfigGetByUserId,Id.ToString()), null, this.CurrentUser.Token);
                if (tmp.Data != null && tmp.Code == (int)ResultCode.Success)
                    result = tmp;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存功能操作信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveConfig(SynchronizationConfig model)
        {
            var result = new BaseResult() { Code = (int)ResultCode.Faild };
            if (model != null)
            {
                model.EditDate = DateTime.Now;
                result = ServiceHelper.CallService(ServiceConst.BizApi.SyncConfigSave,
                         JsonConvert.SerializeObject(model),
                         this.CurrentUser.Token);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取结构数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ContentResult GetSyncShopTree()
        {
            var result = new BaseResult() { Code = (int)ResultCode.Faild };
            var cfg = ServiceHelper.CallService<SynchronizationConfig>(string.Format(ServiceConst.BizApi.SyncConfigGetByUserId,
                 CurrentUser.UserId.ToString()), null, this.CurrentUser.Token);
            var shops = ServiceHelper.CallService<List<ShipInfo>>(string.Format(ServiceConst.BizApi.ShopGetAllByUser,
               CurrentUser.UserId.ToString()), null, this.CurrentUser.Token);

            //shops.Data = new List<ShipInfo>();
            //shops.Data.Add(new ShipInfo() { Id = 1, Plat = 0, PlatName = "淘宝", Name = "淘宝小店" });
            //shops.Data.Add(new ShipInfo() { Id = 2, Plat = 1, PlatName = "天猫", Name = "天猫小店" });
            //shops.Data.Add(new ShipInfo() { Id = 3, Plat = 2, PlatName = "京东", Name = "京东小店" });

            var treeList = new List<MenuTree>();

            if (shops.Data != null && shops.Data.Any())
            {
                var gp = from p in shops.Data
                         group p by p.Plat into g
                         select g;

                foreach (var item in gp)
                {
                    var childList = new List<MenuTree>();
                    item?.ToList().ForEach(x =>
                    {
                        childList.Add(new MenuTree()
                        {
                            id = x.Id,
                            @checked = cfg.Data?.StoreIds?.Contains(x.Id.ToString()) ?? false,
                            text = x.Name,
                            isFreeze = 0,
                            attributes = x.Plat
                        });
                    });
                    treeList.Add(new MenuTree()
                    {
                        id = -item.Key,
                        text = item.First().PlatName,
                        children = childList,
                        @checked = childList.All(x => x.@checked)
                    });
                }
            }
            return Content(JsonConvert.SerializeObject(treeList), "text/json");
        }


        #endregion
    }
}