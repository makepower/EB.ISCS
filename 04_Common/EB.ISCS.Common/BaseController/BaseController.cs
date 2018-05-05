using EB.ISCS.Common.Models;
using EB.ISCS.FrameworkEntity.SystemEntity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace EB.ISCS.Common.BaseController
{
    /// <summary>
    /// Base controller
    /// </summary>   
    [Authorize]
    public abstract class BaseController : Controller
    {
        //   public static readonly string ManageLoginUrl = $"{Configs.SSOPassportDomainName}/Account/Default";

        public BaseController()
        {
            CurrentUser = new CurrentUserModel().InitFromHttpContext();

            if (CurrentUser != null)
            {
                ViewBag.UserName = CurrentUser.UserName;
            }
            else
            {
                RedirectToAction("Login", "Account");
            }
        }

        public CurrentUserModel CurrentUser { get; set; }

        public int CurrentMenuId { get; set; }

        public List<NavigationItem> GetNavigationList(CurrentUserModel currentUser)
        {
            var result = ServiceHelper.CallService<List<NavigationItem>>(ServiceConst.CommonService.GetNavigationList,
                JsonConvert.SerializeObject(currentUser), this.CurrentUser.Token);
            var navigationList = result.Data;
            return navigationList;
        }

        /// <summary>
        /// 获取功能菜单树，
        /// </summary>
        /// <returns></returns>
        public List<MenuTree> MenuTreeModel()
        {
            var menuTree = new List<MenuTree>();
            var result = ServiceHelper.CallService<List<MenuAllTree>>($"{ServiceConst.MenuApi.GetUserMenuById}/{this.CurrentUser.UserId}", null, this.CurrentUser.Token);
            if (result.Code == (int)ResultCode.Success)
            {
                menuTree = GetTreeList(result.Data, 0);
            }
            return menuTree;
        }

        protected List<MenuTree> GetTreeList(List<MenuAllTree> model, int id)
        {
            var menuTree = new List<MenuTree>();
            model.Where(p => p.FId == id).ToList().ForEach(x =>
            {
                var ch = GetTreeList(model, x.Id);
                menuTree.Add(new MenuTree
                {
                    id = x.Id,
                    text = x.Name,
                    attributes = new { isMenu = x.IsMenu == 1 ? true : false },
                    children = ch,
                    @checked = ch.Count == 0 && (x.CheckState == 1 ? true : false)
                });
            });
            return menuTree;
        }

      

    
        
        #region 时间序列化Json格式化

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding)
        {
            return new ExtendJsonResult { Data = data, ContentType = contentType, ContentEncoding = contentEncoding };
        }
        public new JsonResult Json(object data, JsonRequestBehavior jsonRequest)
        {
            return new ExtendJsonResult { Data = data, JsonRequestBehavior = jsonRequest };
        }
        public new JsonResult Json(object data)
        {
            return new ExtendJsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        #endregion
    }
}
