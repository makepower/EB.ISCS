using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Models;
using EB.ISCS.Common.ViewModel;
using EB.ISCS.DapperServices.Services.Sys;
using EB.ISCS.Framework.Utilities.String;
using EB.ISCS.FrameworkEntity.SystemEntity;
using EB.ISCS.FrameworkHelp.Tools;
using EB.ISCS.FrameworkLog.LogModel;
using EB.ISCS.ToolService.LogService;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace EB.ISCS.WebApi.Controllers.Sys
{
    /// <summary>
    /// 账号管理
    /// </summary>
    public class AccountController : BaseUnauthorizedApiController
    {
        /// <summary>
        /// 登录  
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>    
        [HttpPost]
        public ResponseResult<CurrentUserModel> SignIn(LoginModel model)
        {
            try
            {
                LogHelper.WriteInfoLog("SignIn....");

                #region 参数验证

                if (string.IsNullOrEmpty(model.LoginName))
                {
                    return ResponseResult<CurrentUserModel>.GenFaildResponse(ResultCode.UsernameIsNull);
                }
                if (string.IsNullOrEmpty(model.Password))
                {
                    return ResponseResult<CurrentUserModel>.GenFaildResponse(ResultCode.PasswordIsNull);
                }
                #endregion

                HttpRequestBase request = Context.Request;

                ExploreHelper eh = new ExploreHelper(request);

                SysLoginLog logEntity = new SysLoginLog
                {
                    ClientIpAddress = eh.ClientIP,
                    ClientName = eh.ClientMachineName,
                    Enabled = 1,
                    LogDate = DateTime.Now
                };
                //登录日志
                try
                {
                    logEntity.IPNum = (int)StringHelper.IPToInt(eh.ClientIP);
                }
                catch
                {
                    logEntity.IPNum = 0;
                }

                ResultCode code = ResultCode.Success;
                var service = GetService<SysUserService>();
                var data = service.Login(model.LoginName, model.Password);
                if (data != null)
                {
                    var token = new SysLoginTokenModel(data.UserDepId, data.Id)
                    {
                        UserId = data.Id
                    };

                    var services = GetService<SysLoginTokenService>();
                    services.Add(new SysLoginToken()
                    {
                        UserId = data.Id,
                        CustomerUser = data.UserType,
                        CustomerId = data.UserCustomerId,
                        Token = token.Token,
                        InDate = token.InDate,
                        ExpriedTime = token.ExpriedTime,
                        AccessChannelId = 0,
                    });

                    var currentUserModel = new CurrentUserModel
                    {
                        LoginName = model.LoginName,
                        UserId = data.Id,
                        UserIsFreeze = data.UserIsFreeze ? 0 : 1,
                        UserIsManage = data.UserIsManage,
                        UserName = data.UserName,
                        UserPosition = data.UserPosition,
                        UserDepId = data.UserDepId,
                        UserCustomerId = data.UserCustomerId,
                        Token = token.Token
                    };

                    logEntity.UserId = currentUserModel.UserId;
                    logEntity.Token = token.Token;
                    logEntity.UserName = currentUserModel.UserName;
                    logEntity.LogDate = System.DateTime.Now;


                    if (data.DelState == 1 || data.DepDelState == 1 || data.CompanyDelState == 1)
                    {
                        code = ResultCode.UserDeleted;

                        logEntity.IsSucceed = 0;
                        logEntity.LogReason = "用户已被删除";

                        WriteLoginLog.WriteLogLogin(logEntity);//写入登录日志
                    }
                    else if (data.Enabled == 0)
                    {
                        logEntity.IsSucceed = 0;
                        logEntity.LogReason = "用户已被冻结";

                        WriteLoginLog.WriteLogLogin(logEntity);//写入登录日志
                    }
                    else
                    {
                        SignInByIdentity(data, token);
                        code = ResultCode.Success;
                        WriteLoginLog.WriteLogLogin(logEntity);//写入登录日志
                    }
                    return ResponseResult<CurrentUserModel>.GenSuccessResponse(currentUserModel);
                }
                else
                {
                    code = ResultCode.UserWrongPassword;
                    logEntity.InUserType = 1;
                    logEntity.IsSucceed = 0;
                    logEntity.LogReason = "用户不存在或者密码错误";
                    WriteLoginLog.WriteLogLogin(logEntity);//写入登录日志
                    return ResponseResult<CurrentUserModel>.GenFaildResponse(code);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog(HttpContext.Current.Request.RawUrl, ex);
                return ResponseResult<CurrentUserModel>.GenSuccessResponse(ex.Message);

            }
        }

        /// <summary>
        ///  登出操作
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> SignOut()
        {
            System.Data.IDbTransaction idbTrans = null;
            try
            {
                var token = Request.Token();
                var loginTokenServices = GetService<SysLoginTokenService>();
                var loginLogService = GetService<SysLoginLogService>(loginTokenServices);
                idbTrans = loginTokenServices.BeginTrans();
                loginTokenServices.DisableToken(token, idbTrans);
                loginLogService.LoginOutByToken(token, idbTrans);
              
                idbTrans?.Commit();
                return ResponseResult<bool>.GenSuccessResponse(true);
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog(HttpContext.Current.Request.RawUrl, ex);
                idbTrans?.Rollback();
                return ResponseResult<bool>.GenFaildResponse(ex.Message);
            }
        }

        private void SignInByIdentity(SysUser user, SysLoginTokenModel token)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, nameof(EB.ISCS)),
                new Claim(ClaimTypes.Actor, "pc"),
                new Claim(ClaimTypes.System, string.Empty), // appType
                new Claim(ClaimTypes.Authentication, token.Token),
                new Claim(ClaimTypes.UserData, Newtonsoft.Json.JsonConvert.SerializeObject(user))
            };
            HttpContext.Current.User = new ClaimsPrincipal(new ClaimsIdentity(claims));
        }
    }
}
