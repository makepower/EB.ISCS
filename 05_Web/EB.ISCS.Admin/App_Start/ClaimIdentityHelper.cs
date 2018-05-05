using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using EB.ISCS.Common.Models;

namespace EB.ISCS.Admin
{
    public class ClaimIdentityHelper : IDisposable
    {
        public static ClaimIdentityHelper Create(IdentityFactoryOptions<ClaimIdentityHelper> options, IOwinContext context)
        {
            return new ClaimIdentityHelper(context);
        }

        private ClaimIdentityHelper(IOwinContext context)
        {
            _context = context;
        }

        private IOwinContext _context;
        /// <summary>
        /// 用户授权登录，写cookie，分配id等
        /// </summary>
        /// <param name="userModel"></param>
        /// <param name="rememberMe"></param>
        /// <returns></returns>
        public SignInStatus SignIn(BaseResult<CurrentUserModel> userModel, bool rememberMe = false)
        {
            SignInStatus status = SignInStatus.Success;

            if (userModel?.Data == null)
            {
                return SignInStatus.Failure;
            }
            if (userModel.Code != (int)ResultCode.Success)
            {
                return SignInStatus.Failure;
            }

            var user = userModel.Data;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",  "ASP.NET Identity"),
                new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(user))
            };
            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            var expiration = DateTime.UtcNow;
            if (rememberMe)
            {
                expiration = DateTime.UtcNow.AddDays(Configs.CookieMaxAge);
            }
            else
            {
                var sessionStateSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
                expiration = DateTime.UtcNow.AddMinutes(sessionStateSection.Timeout.TotalMinutes);
            }
            AuthenticationManager.SignIn(new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = rememberMe,
                ExpiresUtc = expiration
            }, identity);

            return status;
        }

        /// <summary>
        /// 用户授权清空
        /// </summary>
        public void SignOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
        private IAuthenticationManager AuthenticationManager => this._context.Authentication;

        public void Dispose()
        {

        }
    }
}