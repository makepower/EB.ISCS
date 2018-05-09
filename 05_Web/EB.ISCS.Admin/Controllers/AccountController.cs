using EB.ISCS.Common.Models;
using EB.ISCS.Common.ViewModel;
using EB.ISCS.FrameworkHelp.Encryption;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;

namespace EB.ISCS.Admin.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ClaimIdentityHelper ClaimHelper => this.HttpContext.GetOwinContext().Get<ClaimIdentityHelper>();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        //
        // GET: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel loginModel, string returnUrl)
        {
            bool passed = true;
            if (passed && string.IsNullOrEmpty(loginModel.LoginName))
            {
                passed = false;
                ModelState.AddModelError("CredentialError", "用户账号不能为空！");
            }
            if (passed && ModelState.IsValid)
            {
                try
                {
                    passed = LocalLogin(loginModel);
                }
                catch (Exception ex)
                {
                    passed = false;
                    ModelState.AddModelError("CredentialError", "登录失败，有异常");
                }
            }
            else
            {
                passed = false;
                ModelState.AddModelError("CredentialError", "用户名或密码输入不正确，用户不存在!");
            }

            if (passed)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                return View(loginModel);
            }
        }


        [NonAction]
        private bool LocalLogin(LoginModel loginModel)
        {
            //个人中心
            var pwd = EncryptionHelper.Encrypt(EncryptionAlgorithm.Rijndael, loginModel.Password);
            NameValueCollection CenterCollection = new NameValueCollection();
            CenterCollection.Add("LoginName", loginModel.LoginName);
            CenterCollection.Add("Password", pwd);
            CenterCollection.Add("RememberMe", loginModel.RememberMe.ToString());
            if (loginModel.LoginName == "admin")
            {
                CenterCollection.Add("UserIsManage", "true");
            }
            var modelData = ServiceHelper.CallService<CurrentUserModel>(ServiceConst.Account.SignIn, CenterCollection);

            var result = ClaimHelper.SignIn(modelData, loginModel.RememberMe);
            if (result != SignInStatus.Success)
            {
                ModelState.AddModelError("CredentialError", modelData.Message);
                return false;
            }
            else
            {
                ViewBag.UserName = modelData.Data.UserName;
            }

            return true;
        }


        public ActionResult LogOff()
        {
            ClaimHelper.SignOut();
            var curUser = new CurrentUserModel().InitFromHttpContext();
            var var = ServiceHelper.CallService(ServiceConst.Account.SignOut, null, curUser?.Token);
            if (var.Code != (int)ResultCode.Success)
            {
                // Redirect ?
                return Redirect("/Account/Login");
            }
            else
                return Redirect("/Account/Login");
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }


        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }


        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }


        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region 帮助程序
        // 用于在添加外部登录名时提供 XSRF 保护
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}