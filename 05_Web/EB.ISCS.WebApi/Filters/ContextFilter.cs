using System.Linq;
using System.Security.Claims;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Newtonsoft.Json;
using QS.Common.DataModel;
using QS.FrameworkEntity.SystemEntity;

namespace QS.WebApi.Filters
{
    /// <summary>
    /// 对Api请求数据进行整理、格式
    /// </summary>
    public class ContextFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var apiController = actionContext.ControllerContext.Controller as BaseApiController;
            if (apiController != null)
            {
                var bModel = apiController.BModel;
                //增加授权用户信息到BModel
                if (actionContext.RequestContext.Principal?.Identity?.IsAuthenticated??false)
                {
                    var id = actionContext.RequestContext.Principal.Identity as ClaimsIdentity;

                    var accessChannelId = 0;
                    int.TryParse(id?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Actor)?.Value, out accessChannelId);

                    var data = id?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.UserData)?.Value;
                    if (data != null)
                    {
                        var user = JsonConvert.DeserializeObject<SysUser>(data);
                        bModel.User = user;
                        //var companyMetas = ApiCacheDicts.CompanyMetas;
                       // bModel.Company = companyMetas.FirstOrDefault(x => x.OrgCode == user.CompanyCode);
                    }
                }



            }
            if (actionContext.ActionArguments.ContainsKey("model"))
            {
                if (actionContext.ActionArguments["model"] is BaseModel baseModel)
                {
                    if (actionContext.Request.Properties.ContainsKey("AccessChannelID"))
                    {
                        var accessChannelId = 0;
                        int.TryParse(actionContext.Request.Properties["AccessChannelID"]?.ToString(), out accessChannelId);
                    }

                }
            }
            base.OnActionExecuting(actionContext);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}