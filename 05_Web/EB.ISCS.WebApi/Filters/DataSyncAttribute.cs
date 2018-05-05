using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace QS.WebApi.Filters
{
    /// <summary>
    /// 数据同步Filter
    /// </summary>
    public class DataSyncAttribute : ActionFilterAttribute
    {
        ///// <summary>
        ///// 业务数据类型
        ///// </summary>
        //public BusinessDataType BizDataType { get; set; }

        ///// <summary>
        ///// 数据更新类型： 新增、删除、修改、查询
        ///// </summary>
        //public DataUpdateType DataUpdateType { get; set; }

        ///// <summary>
        ///// 操作开始时间
        ///// </summary>
        //private static readonly string key = "enterTime";

        ///// <summary>
        ///// OnActionExecutingAsync
        ///// </summary>
        ///// <param name="actionContext"></param>
        ///// <param name="cancellationToken"></param>
        ///// <returns></returns>
        //public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        //{
        //    //记录进入请求的时间
        //    actionContext.Request.Properties[key] = DateTime.Now.ToBinary();
        //    return base.OnActionExecutingAsync(actionContext, cancellationToken);
        //}

        ///// <summary>
        ///// OnActionExecutedAsync
        ///// </summary>
        ///// <param name="actionExecutedContext"></param>
        ///// <param name="cancellationToken"></param>
        ///// <returns></returns>
        //public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        //{
        //    object beginTime = null;
        //    if (actionExecutedContext.Request.Properties.TryGetValue(key, out beginTime))
        //    {
        //        var tokenInfo = string.Empty;
        //        var request = actionExecutedContext.Request;
        //        var appMidCollect = new AppMidCollect();

        //        if (request.Headers.Authorization != null && request.Headers.Authorization.Parameter != null)
        //        {
        //            tokenInfo = request.Headers.Authorization.Parameter;
        //        }

        //        //检测token
        //        var tokenparts = tokenInfo.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        //        if (tokenparts.Length == 2)
        //        {
        //            var token = tokenparts[1];

        //            SysLoginTokenModel loginUser = getUserByToken(token);
        //            //获取用户token
        //            appMidCollect.UserId = loginUser == null ? 0 : loginUser.UserId;
        //            appMidCollect.BizCode = (int)this.BizDataType;
        //            appMidCollect.EditDate = DateTime.Now;
        //            if(this.DataUpdateType == DataUpdateType.Search)
        //                appMidCollect.BizNum = 0;

        //            APPService appService = new APPService();
        //            appService.SaveAppMidCollect(appMidCollect);
        //        }
        //    }
        //    return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        //}

        ///// <summary>
        ///// 获取当前登录用户的id
        ///// </summary>
        ///// <param name="token"></param>
        ///// <returns></returns>
        //public static SysLoginTokenModel getUserByToken(string token)
        //{
        //    SysLoginTokenService _sysUserService = new SysLoginTokenService();
        //    var data = _sysUserService.GetModelByToken(token).ToViewModel();

        //    return data;
        //}
    }
}