using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using EB.ISCS.Common.BaseController;
using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Models;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.Admin.Controllers.Sys
{
    public class MenuPermissionController : BaseController
    {
        // GET: MenuPermission
        public ActionResult Index(int id)
        {
            ViewBag.MenuId = id;
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        #region 功能操作增删改查

        /// <summary>
        /// 获取功能操作信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetMenuPermission(int Id)
        {
            var result = new BaseResult<SysMenuPermission>();
            result.Data = new SysMenuPermission();
            if (Id > 0)
            {
                result = ServiceHelper.CallService<SysMenuPermission>(string.Format(ServiceConst.MenuApi.PermissionGetModelById,
                    Id.ToString()), null, this.CurrentUser.Token);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMenuPermissionsList(SysMenu model)
        {
            var token = this.CurrentUser.Token;
            // 请求查询操作 webApi
            var result = ServiceHelper.CallService<List<SysMenuPermission>>(ServiceConst.MenuApi.GetMenuPermissionsList,
                JsonConvert.SerializeObject(model), token);

            if (result.Code == (int)ResultCode.Success)
            {
                return Json(new { rows = result.Data.ToList() }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { rows = new List<SysMenuPermission>() }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 批量删除选中的功能操作记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult Delete(string id)
        {
            var token = this.CurrentUser.Token;
            var result = ServiceHelper.CallService<bool>(ServiceConst.MenuApi.PermissionDelete,
                JsonConvert.SerializeObject(new
                {
                    DelString = id,
                    UserId = this.CurrentUser.UserId
                }), token);
            return Json(result);
        }

        /// <summary>
        /// 保存功能操作信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveMenuPermission(SysMenuPermission model)
        {
            var result = new BaseResult() { Code = (int)ResultCode.Faild };
            if (model != null)
            {
                if (model.Id > 0)
                {
                    model.EditUser = this.CurrentUser.UserId;
                    model.EditDate = System.DateTime.Now;
                    result = ServiceHelper.CallService(ServiceConst.MenuApi.PermissionUpdate,
                        JsonConvert.SerializeObject(model),
                        this.CurrentUser.Token);
                }
                else
                {
                    model.InUser = this.CurrentUser.UserId;
                    model.InDate = System.DateTime.Now;
                    result = ServiceHelper.CallService(ServiceConst.MenuApi.PermissionAdd,
                        JsonConvert.SerializeObject(model),
                        this.CurrentUser.Token);
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取功能模块菜单树
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMenuTree()
        {
            var result = ServiceHelper.CallService<List<SysMenu>>(ServiceConst.MenuApi.GetSysMenuList,
                JsonConvert.SerializeObject(new QueryMenuModel()),
                this.CurrentUser.Token);
            if (result.Data != null && result.Data.Count > 0)
            {
                var treeList = GetChildren(result.Data, 0);
                return Json(treeList, JsonRequestBehavior.AllowGet);
            }
            return Json(new List<MenuTree>(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 递归获取功能模块菜单树
        /// </summary>
        /// <param name="models"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private List<MenuTree> GetChildren(List<SysMenu> models, int id)
        {
            List<MenuTree> children = new List<MenuTree>();
            models.OrderBy(p => p.MenuSort).Where(p => p.FatherId == id).ToList().ForEach(x =>
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

        [HttpPost]
        public JsonResult GetMenuPermissionListPage(int id)
        {
            var result = ServiceHelper.CallService<List<SysMenuPermission>>($"{ServiceConst.MenuApi.GetMenuPermissionListPage}/{id}",
               null,
                this.CurrentUser.Token);
            return Json(result.Data, JsonRequestBehavior.AllowGet);
        }



        #endregion
    }
}