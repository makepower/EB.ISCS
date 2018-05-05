using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using EB.ISCS.Common.BaseController;
using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Models;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.Admin.Controllers.Sys
{
    public class MenuController : BaseController
    {

        #region 视图
        // GET: Menu
        public ActionResult Index(int id)
        {
            ViewBag.MenuId = id;
            return View();
        }

        public ActionResult Edit(int id, string actionType)
        {
            ViewBag.ActionType = actionType;
            ViewBag.Id = id;
            return View();
        }
        #endregion

        #region 操作方法

        /// <summary>
        /// 删除功能模块菜单信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult DeleteSysMenus(string ids)
        {
            var result = ServiceHelper.CallService(ServiceConst.MenuApi.Delete,
                JsonConvert.SerializeObject(new
                {
                    DelString = ids,
                    UserId = this.CurrentUser.UserId
                }),
                this.CurrentUser.Token);
            return Json(result);
        }
        /// <summary>
        /// 保存功能模块菜单信息
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public JsonResult SaveMenuInfo(SysMenu model)
        {
            var result = new BaseResult() { Code = (int)ResultCode.Faild };
            if (model != null)
            {
                model.MenuIsEvent = model.PageUrl != "" ? 1 : 0;
                if (model.Id > 0 && model.ActionType == "edit")
                {
                    model.EditUser = this.CurrentUser.UserId;
                    model.EditDate = System.DateTime.Now;
                    result = ServiceHelper.CallService(ServiceConst.MenuApi.Update, JsonConvert.SerializeObject(model), this.CurrentUser.Token);
                }
                else
                {
                    model.InUser = this.CurrentUser.UserId;
                    result = ServiceHelper.CallService(ServiceConst.MenuApi.Add, JsonConvert.SerializeObject(model), this.CurrentUser.Token);
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetList()
        {
            var result = ServiceHelper.CallService<List<SysMenu>>(ServiceConst.MenuApi.GetSysMenuList, null, this.CurrentUser.Token);
            return Json(getTreeList(result.Data, 0), JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 获取功能模块菜单信息
        /// </summary>
        /// <param name="menuCode"></param>
        /// <returns></returns>
        public JsonResult GetMenuInfo(int id)
        {
            var result = new BaseResult<SysMenu>();
            result.Data = new SysMenu();
            if (id > 0)
            {
                result = ServiceHelper.CallService<SysMenu>($"{ServiceConst.MenuApi.GetModelById}/{id}", null, this.CurrentUser.Token);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        private List<SysMenu> getTreeList(List<SysMenu> models, int id)
        {
            List<SysMenu> tree = new List<SysMenu>();
            models.OrderBy(p => p.MenuSort).Where(p => p.FatherId == id).ToList().ForEach(x =>
            {
                var model = new SysMenu();
                model = x;
                model.children = getTreeList(models, x.Id);
                tree.Add(model);
            });
            return tree;
        }

        /// <summary>
        /// 获取功能模块菜单树
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMenuTree()
        {
            var result = ServiceHelper.CallService<List<SysMenu>>(
                ServiceConst.MenuApi.GetSysMenuList,
                JsonConvert.SerializeObject(new QueryMenuModel()),
                this.CurrentUser.Token);
            if (result.Data != null && result.Data.Count > 0)
            {
                var treeList = GetChildren(result.Data, 0);
                treeList.Insert(0, new MenuTree() { id = 0, text = "根目录" });
                return Json(treeList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var treeList = new List<MenuTree>();
                treeList.Insert(0, new MenuTree() { id = 0, text = "根目录" });
                return Json(treeList, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 递归获取功能模块菜单树
        /// </summary>
        /// <param name="models"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        private List<MenuTree> GetChildren(List<SysMenu> models, int id)
        {
            List<MenuTree> children = new List<MenuTree>();
            models.Where(p => p.FatherId == id).ToList().ForEach(x =>
            {
                children.Add(new MenuTree()
                {
                    id = x.Id,
                    text = x.MenuName,
                    children = GetChildren(models, x.Id)
                });
            });
            return children;
        }
        #endregion
    }
}