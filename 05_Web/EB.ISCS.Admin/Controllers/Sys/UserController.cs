using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using EB.ISCS.Common.BaseController;
using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Models;
using EB.ISCS.FrameworkEntity.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;
using EB.ISCS.FrameworkHelp.Encryption;

namespace EB.ISCS.Admin.Controllers.Sys
{
    /// <summary>
    /// 用户管理控制器
    /// </summary>
    public class UserController : BaseController
    {

        #region 视图
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

        /// <summary>
        /// 用户角色
        /// </summary>
        /// <returns></returns>
        public ActionResult UserRole(int id)
        {
            if (this.CurrentUser.IsSysAdmin())
            {
                var userDataResult = ServiceHelper.CallService<SysUser>($"{ServiceConst.SysUserApi.GetModelById}/{id.ToString()}",
                    null, this.CurrentUser.Token);
            }
            ViewBag.Id = id;
            return View();
        }

        /// <summary>
        /// 选择用户
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectUser(string sqlWhere)
        {
            ViewBag.sqlWhere = string.IsNullOrEmpty(sqlWhere) ? "" : sqlWhere;
            return View();
        }

        /// <summary>
        /// 用户权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UserPermissions(int id)
        {
            string token = this.CurrentUser.Token;
            var userDataResult = ServiceHelper.CallService<SysUser>(
                $"{ServiceConst.SysUserApi.GetModelById}/{id}", null, this.CurrentUser.Token);
            userDataResult.Data.InUser = this.CurrentUser.UserId;
            return View(userDataResult.Data);
        }


        /// <summary>
        /// 获取所有的菜单、功能操作权限
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllPermissions(SysUser userModel)
        {
            var token = this.CurrentUser.Token;
            var permissionList = new List<SysMenu>();
            var result = ServiceHelper.CallService<List<SysMenu>>(
                ServiceConst.SysUserApi.GetMenuPermissionsListByUserId,
                JsonConvert.SerializeObject(userModel),
                 token);
            if (result.Code == (int)ResultCode.Success)
            {
                var menulist = result.Data;
                if (menulist != null && menulist.Count > 0)
                {
                    permissionList = menulist;
                }
            }

            string resultString = GetMenuTree(permissionList);
            return Content(resultString, "text/json");
        }

        /// <summary>
        /// 获取所有的菜单、功能操作权限
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserMenuById()
        {
            var userMenulist = MenuTreeModel();
            return Content(JsonConvert.SerializeObject(userMenulist), "text/json");
        }

        #endregion

        #region 获取数据

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult GetUser(int Id)
        {
            var result = new BaseResult<SysUser> { Data = new SysUser() { IsExpireDate = 0, UserIsFreeze = false } };
            if (Id > 0)
            {
                result = ServiceHelper.CallService<SysUser>($"{ServiceConst.SysUserApi.GetModelById}/{Id}", null, this.CurrentUser.Token);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 用户下拉框
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUserCombobox()
        {
            var result = ServiceHelper.CallService<List<SysUser>>(
                $"{ServiceConst.SysUserApi.GetList}/{this.CurrentUser.UserDepId}", null, this.CurrentUser.Token);
            return Json(result.Data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取用户信息列表
        /// </summary>
        /// <param name="parameterJson"></param>
        /// <param name="jqgridparam"></param>
        /// <returns></returns>
        public JsonResult GetUserListByQuery(string parameterJson, JqGridParam jqgridparam)
        {
            var model = new QueryUserModel();
            if (!string.IsNullOrWhiteSpace(parameterJson))
            {
                model = JsonConvert.DeserializeObject<QueryUserModel>(parameterJson);
            }
            model.PageIndex = jqgridparam.page;
            model.PageSize = jqgridparam.rows;
            model.UserType = (int)EnumUserType.User;
            var send = JsonConvert.SerializeObject(model);
            var result = ServiceHelper.CallService<PagedListData<List<SysUser>>>(
                ServiceConst.SysUserApi.GetUserListByQuery,
                send, this.CurrentUser.Token);
            var json = new
            {
                page = result.Data.PagingInfo.PageIndex,
                total = result.Data.PagingInfo.PageCount,
                records = result.Data.PagingInfo.TotalCount,
                rows = result.Data.PagingData.ToArray()
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 增、删、改
        /// <summary>删除用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DelUser(int id)
        {
            var result = ServiceHelper.CallService(ServiceConst.SysUserApi.Delete,
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
        public JsonResult GetUserListByQuery(JqGridParam jqgridparam)
        {
            QueryUserModel query = new QueryUserModel()
            {
                PageIndex = jqgridparam.page,
                PageSize = jqgridparam.rows,
                OrderBy = jqgridparam.sord
            };
            var result = ServiceHelper.CallService<PagedListData<List<SysUser>>>(ServiceConst.SysUserApi.GetUserListByQuery,
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
        public JsonResult SaveUser(SysUser model)
        {
            var result = new BaseResult() { Code = (int)ResultCode.Faild };
            if (model != null)
            {
                if (model.Id > 0)
                {
                    model.EditUser = this.CurrentUser.UserId;
                    model.EditDate = System.DateTime.Now;
                    result = ServiceHelper.CallService(
                        ServiceConst.SysUserApi.Update,
                        JsonConvert.SerializeObject(model),
                        this.CurrentUser.Token);
                }
                else
                {
                    model.UserName = model.LoginName;
                    model.PassWord = EncryptionHelper.Encrypt(EncryptionAlgorithm.Rijndael, model.PassWord);
                    model.UserType = (int)EnumUserType.User;
                    model.Enabled = 1;
                    model.InUser = this.CurrentUser.UserId;
                    model.InDate = System.DateTime.Now;
                    result = ServiceHelper.CallService(ServiceConst.SysUserApi.Add,
                        JsonConvert.SerializeObject(model),
                        this.CurrentUser.Token);
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 用户角色

        /// <summary>
        /// 根据用户编号获取角色列表（已关联、未关联）
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public JsonResult GetRoleList(int userId)
        {
            var relation = ServiceHelper.CallService<List<SysRole>>(ServiceConst.SysUserApi.GetRoleListByUserId,
                JsonConvert.SerializeObject(new
                {
                    UserId = userId
                }), this.CurrentUser.Token);
            var noRelation = ServiceHelper.CallService<List<SysRole>>(ServiceConst.SysUserApi.GetNoRoleListByUserId,
                JsonConvert.SerializeObject(new
                {
                    UserId = userId
                }), this.CurrentUser.Token);
            return Json(new
            {
                relation = relation.Data,
                noRelation = noRelation.Data
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 用户分配角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveUserRole(SysUserRole model)
        {
            model.Enabled = 1;
            model.InUser = this.CurrentUser.UserId;
            var result = ServiceHelper.CallService(
                ServiceConst.SysUserApi.AddRoleForUser,
                JsonConvert.SerializeObject(model),
                this.CurrentUser.Token);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 角色用户

        /// <summary>
        /// 根据角色编号获取用户信息列表（已关联、未关联）
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public JsonResult GetRoleUserList(int roleId)
        {
            var relation = ServiceHelper.CallService<List<SysUser>>(ServiceConst.SysUserApi.GetUserListByRoleId,
                JsonConvert.SerializeObject(new
                {
                    RoleId = roleId
                }),
                this.CurrentUser.Token);
            var noRelation = ServiceHelper.CallService<List<SysUser>>(ServiceConst.SysUserApi.GetNoUserListByRoleId,
                JsonConvert.SerializeObject(new
                {
                    RoleId = roleId
                }),
                this.CurrentUser.Token);
            return Json(new
            {
                relation = relation.Data,
                noRelation = noRelation.Data
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 给角色分配用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveRoleUser(SysUserRole model)
        {
            model.Enabled = 1;
            model.InUser = this.CurrentUser.UserId;
            var result = ServiceHelper.CallService(ServiceConst.SysUserApi.AddUserForRole,
                JsonConvert.SerializeObject(model),
                this.CurrentUser.Token);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 用户权限

        /// <summary>
        /// 保存用户权限、用户操作权限信息
        /// </summary>
        /// <param name="userMenuPermissionVm"></param>
        /// <returns></returns>
        public JsonResult SaveUserMenuPermissions(UserMenuPermission userMenuPermissionVm)
        {
            var token = this.CurrentUser.Token;
            userMenuPermissionVm.UserMenuViewModel.ForEach(x =>
            {
                x.InUser = this.CurrentUser.UserId;
                x.InDate = DateTime.Now;
            });
            userMenuPermissionVm.UserPermissionViewModel.ForEach(x =>
            {
                x.InUser = this.CurrentUser.UserId;
                x.InDate = DateTime.Now;
            });
            var result = ServiceHelper.CallService<bool>(ServiceConst.SysUserApi.SaveUserMenuPermissions,
                JsonConvert.SerializeObject(userMenuPermissionVm), token);

            return Json(result);
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 根据权限数据 list 构建 权限树 json 字符串
        /// </summary>
        /// <param name="permissionList"></param>
        /// <returns></returns>
        public string GetMenuTree(List<SysMenu> permissionList)
        {
            if (permissionList != null)
            {
                var root = permissionList.FirstOrDefault(m => m.FatherId == 0) ?? permissionList.FirstOrDefault();
                return GetChildren(permissionList, root.Id, "closed");
            }
            else
            {
                return $"[{string.Empty}]";
            }
        }

        /// <summary>
        /// 递归获取功能菜单
        /// </summary>
        /// <param name="menus"></param>
        /// <param name="menuCode"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetChildren(List<SysMenu> menus, int id, string state = "open")
        {
            string sepreator = "";
            StringBuilder sb = new StringBuilder();
            foreach (SysMenu item in menus.Where(m => m.FatherId == id))
            {
                sb.Append(sepreator + "{");
                sb.AppendFormat("\"id\":{0},", item.Id);
                sb.AppendFormat("\"text\":\"{0}\",", item.MenuName);
                //sb.AppendFormat("\"state\":\"{0}\",", state);
                if (item.Checked == 1)
                {
                    sb.AppendFormat("\"checked\":{0},", "true");
                }
                sb.AppendFormat("\"children\":{0},", GetChildren(menus, item.Id));
                sb.Append("\"attributes\":{\"isMenu\":" + (item.IsMenu == 0 ? "false" : "true") + "}");
                sb.Append("}");
                sepreator = ",";
            }
            return $"[{sb.ToString()}]";
        }
        #endregion


        [HttpPost]
        public ActionResult GetAllList()
        {
            var result = ServiceHelper.CallService<List<SysUser>>("Sys/SysUser/GetAllList", null, CurrentUser.Token);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}