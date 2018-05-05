using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using QS.FrameworkEntity.SystemEntity;
using QS.FrameworkHelp.Configuration;

namespace QS.WebApi.Filters
{
    /// <summary>
    /// 身份验证筛选器
    /// </summary>
    //public class TokenAuthenticationAttribute : FilterAttribute, IAuthenticationFilter
    //{

    //    private readonly string authorizationHeaderName = "Authorization";
    //    private readonly string wwwAuthenticationHeaderName = "WWW-Authenticate";
    //    private readonly string authenticationScheme = "Basic";
    //    private readonly UInt64 requestMaxAgeInSeconds = 300;  //5 mins
    //    private string serviceAuth = ConfigurationManager.AppSettings["api_auth"];
    //    private string secretKey = ConfigurationManager.AppSettings["SecretKey"];



    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="context"></param>
    //    /// <param name="cancellationToken"></param>
    //    /// <returns></returns>
    //    //public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
    //    //{
    //    //    var req = context.Request;

    //    //    #region 如果授权不需要，则身份验证也免了
    //    //    //此处 不能取得  AllowAnonymousAttribute 属性，原因未知
    //    //    //bool skipAuthorization = (context.ActionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Any()
    //    //    //              || context.ActionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Any());
    //    //    bool skipAuthorization = (context.ActionContext.ActionDescriptor.GetCustomAttributes<NoTokenAuthenticationAttribute>(true).Any()
    //    //                  || context.ActionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<NoTokenAuthenticationAttribute>(true).Any());

    //    //    if (skipAuthorization)
    //    //    {
    //    //        return Task.FromResult(0);
    //    //    }
    //    //    #endregion

    //    //    //有授权请求的进行身份验证，否则，放行到授权
    //    //    if (req.Headers.Authorization != null &&
    //    //        authenticationScheme.Equals(req.Headers.Authorization.Scheme, StringComparison.OrdinalIgnoreCase))
    //    //    {
    //    //        var rawAuthzHeader = req.Headers.Authorization.Parameter;
    //    //        var autherizationHeaderArray = GetAutherizationHeaderValues(rawAuthzHeader);

    //    //        if (autherizationHeaderArray != null)
    //    //        {
    //    //            var appId = autherizationHeaderArray[0];
    //    //            var token = autherizationHeaderArray[1];
    //    //            var accessChannelInfo = ConfigurationHelper.AccessChannelSetting;
    //    //            var accessChannel = accessChannelInfo.AccessChannelList.FirstOrDefault(p => appId.Equals(p.AppType + "|" + p.AppID, StringComparison.OrdinalIgnoreCase));
    //    //            #region 验证身份
    //    //            if (accessChannel != null)
    //    //            {
    //    //                return Task.Run(() =>
    //    //                {
    //    //                    AuthenticationTicket ticket = null;
    //    //                    try
    //    //                    {
    //    //                        var issuer = "http://Sea2.com/";
    //    //                        var data = ApiCacheDicts.GetLoginToken(token);
    //    //                        //验证用户信息是否合法
    //    //                        if (data == null)
    //    //                        {
    //    //                            context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], context.Request);
    //    //                        }
    //    //                        else
    //    //                        {
    //    //                            ticket = this.CreateClaimsIdentity(data);
    //    //                            ticket.Identity.AddClaim(new Claim(ClaimTypes.Actor, accessChannel.AccessChannelID));
    //    //                            ticket.Identity.AddClaim(new Claim(ClaimTypes.Authentication, token));
    //    //                            ticket.Identity.AddClaim(new Claim(ClaimTypes.Anonymous, accessChannel.AppType));
    //    //                            List<string> roles = new List<string>();
    //    //                            if (string.IsNullOrEmpty(data.CompanyCode))
    //    //                            {
    //    //                                roles.Add("systemAdmin");
    //    //                            }
    //    //                            else
    //    //                            {
    //    //                                roles.Add("companyUser");
    //    //                                if (data.UserIsManage==1)
    //    //                                {
    //    //                                    roles.Add("companyAdmin");
    //    //                                }
    //    //                            }
                                    
    //    //                            var currentPrincipal = new GenericPrincipal(ticket.Identity, roles.ToArray());
    //    //                            context.Principal = currentPrincipal;
    //    //                            context.Request.Properties.Add("AccessChannelID", accessChannel.AccessChannelID);
    //    //                        }
    //    //                    }
    //    //                    catch (Exception ex)
    //    //                    {
    //    //                        Trace.WriteLine(ex.Message);
    //    //                        context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], context.Request);
    //    //                    }
    //    //                }, cancellationToken);
    //    //            }

    //    //        }
    //    //        #endregion
    //    //        context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], context.Request);
    //    //    }
    //    //    //else
    //    //    //{
    //    //    //    context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], context.Request);
    //    //    //}

    //    //    return Task.FromResult(0);
    //    //}
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="context"></param>
    //    /// <param name="cancellationToken"></param>
    //    /// <returns></returns>
    //    public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
    //    {
    //        //context.Result = new ResultWithChallenge(context.Result);
    //        return Task.FromResult(0);
    //    }

    //    public bool AllowMultiple
    //    {
    //        get { return false; }
    //    }

    //    /// <summary>
    //    /// 建立声明
    //    /// </summary>
    //    /// <param name="user"></param>
    //    /// <returns></returns>
    //    //protected AuthenticationTicket CreateClaimsIdentity(SysUser user)
    //    //{

    //    //    if (user == null)
    //    //    {
    //    //        return null;
    //    //    }
    //    //    var claims = new List<Claim>();
    //    //    // create required claims
    //    //    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
    //    //    claims.Add(new Claim(ClaimTypes.Name, user.UserName));
    //    //    claims.Add(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));
    //    //    //claims.Add(new Claim("AspNet.Identity.SecurityStamp", Guid.NewGuid().ToString()));
    //    //    claims.Add(new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(user)));
    //    //    var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

    //    //    Dictionary<string, string> propList = new Dictionary<string, string>();
    //    //    propList.Add("UserId", user.Id.ToString());
    //    //    propList.Add("UserName", user.UserName);
    //    //    propList.Add("Role", "user");

    //    //    AuthenticationProperties properties = new AuthenticationProperties(propList);

    //    //    AuthenticationTicket ticket = new AuthenticationTicket(identity, properties);

    //    //    DateTime currentUtc = DateTime.UtcNow;
    //    //    DateTime expireUtc = currentUtc.Add(TimeSpan.FromHours(24));
    //    //    ticket.Properties.IssuedUtc = currentUtc;
    //    //    ticket.Properties.ExpiresUtc = expireUtc;

    //    //    return ticket;
    //    //}
    //    private string[] GetAutherizationHeaderValues(string rawAuthzHeader)
    //    {

    //        var credArray = rawAuthzHeader?.Split(';');

    //        if (credArray?.Length == 2)
    //        {
    //            return credArray;
    //        }
    //        else
    //        {
    //            return null;
    //        }

    //    }

    //}


    ///// <summary>
    ///// 取消全局的 TokenAuthenticationAttribute 身份验证
    ///// </summary>
    //public class NoTokenAuthenticationAttribute : Attribute
    //{
        
    //}
    ///// <summary>
    ///// 强制用户重新认证，不启用该项功能
    ///// </summary>
    //public class ResultWithChallenge : IHttpActionResult
    //{
    //    private readonly string authenticationScheme = "Basic";
    //    private readonly IHttpActionResult next;

    //    public ResultWithChallenge(IHttpActionResult next)
    //    {
    //        this.next = next;
    //    }

    //    public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    //    {
    //        var response = await next.ExecuteAsync(cancellationToken);

    //        if (response.StatusCode == HttpStatusCode.Unauthorized)
    //        {
    //            response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(authenticationScheme));
    //        }

    //        return response;
    //    }
    //}

}